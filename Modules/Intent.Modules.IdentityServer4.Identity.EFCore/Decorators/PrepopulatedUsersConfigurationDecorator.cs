using System.Collections.Generic;
using Intent.Engine;
using Intent.Modules.AspNetCore.Templates.Startup;
using Intent.Modules.Common;
using Intent.Modules.IdentityServer4.SecureTokenServer.Events;
using Intent.Modules.IdentityServer4.SecureTokenServer.Settings;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.TemplateDecorator", Version = "1.0")]

namespace Intent.Modules.IdentityServer4.Identity.EFCore.Decorators
{
    [IntentManaged(Mode.Merge)]
    public class PrepopulatedUsersConfigurationDecorator : StartupDecorator, IDecoratorExecutionHooks, IDeclareUsings
    {
        [IntentManaged(Mode.Fully)]
        public const string DecoratorId = "Intent.IdentityServer4.Identity.EFCore.PrepopulatedUsersConfigurationDecorator";

        [IntentManaged(Mode.Fully)]
        private readonly StartupTemplate _template;
        [IntentManaged(Mode.Fully)]
        private readonly IApplication _application;

        [IntentManaged(Mode.Merge)]
        public PrepopulatedUsersConfigurationDecorator(StartupTemplate template, IApplication application)
        {
            _template = template;
            _application = application;
            Priority = 100;
        }

        public void BeforeTemplateExecution()
        {
            _application.EventDispatcher.Publish(new PrepopulatedUsersSpecifiedEvent());
        }

        public override string Configuration()
        {
            if (!_application.Settings.GetIdentityServerSettings().CreateTestUsers())
            {
                return base.Configuration();
            }
            return "CreateTestUsers(app);";
        }

        public IEnumerable<string> DeclareUsings()
        {
            if (!_application.Settings.GetIdentityServerSettings().CreateTestUsers())
            {
                yield break;
            }
            yield return "Microsoft.AspNetCore.Identity";
            yield return "System.Security.Claims";
        }

        public override string Methods()
        {
            if (!_application.Settings.GetIdentityServerSettings().CreateTestUsers())
            {
                return base.Methods();
            }

            return @"

        // The creation of test users can be disabled in Intent Architect's application settings.
        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        private void CreateTestUsers(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                if (!userManager.Users.Any())
                {
                    var identityUser = new IdentityUser(""admin"");
                    userManager.CreateAsync(identityUser, ""P@ssw0rd"").Wait();
                    userManager.AddClaimsAsync(identityUser, new[] 
                        {
                            new Claim(""role"", ""MyRole""), 
                            new Claim(""__tenant__"", ""tenant1"") // e.g. if claim-strategy based Multitenancy is installed, set tenant identifier
                        }).Wait();
                }
            }
        }
";
        }
    }
}
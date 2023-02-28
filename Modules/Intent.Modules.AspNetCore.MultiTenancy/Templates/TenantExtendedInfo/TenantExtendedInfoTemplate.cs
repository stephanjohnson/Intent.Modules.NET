// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.AspNetCore.MultiTenancy.Templates.TenantExtendedInfo
{
    using System.Collections.Generic;
    using System.Linq;
    using Intent.Modules.Common;
    using Intent.Modules.Common.Templates;
    using Intent.Modules.Common.CSharp.Templates;
    using Intent.Templates;
    using Intent.Metadata.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore.MultiTenancy\Templates\TenantExtendedInfo\TenantExtendedInfoTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class TenantExtendedInfoTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Finbu" +
                    "ckle.MultiTenant;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 17 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore.MultiTenancy\Templates\TenantExtendedInfo\TenantExtendedInfoTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\npublic class ");
            
            #line 19 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.AspNetCore.MultiTenancy\Templates\TenantExtendedInfo\TenantExtendedInfoTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(@" : ITenantInfo
{
    public string Id { get; set; }
    public string Identifier { get; set; }
    public string Name { get; set; }

    string ITenantInfo.ConnectionString
    {
        get => throw new InvalidOperationException(
            $""This class supports connection strings for multiple database connection technologies, use \""{ConnectionStrings}\"" instead"");
        set => throw new InvalidOperationException(
            $""This class supports connection strings for multiple database connection technologies, use \""{ConnectionStrings}\"" instead"");
    }

    public ICollection<TenantConnectionString> ConnectionStrings { get; set; } = new List<TenantConnectionString>();

    public ITenantInfo this[string name] => new TenantInfo
    {
        Id = Id,
        Identifier = Identifier,
        Name = Name,
        ConnectionString = ConnectionStrings.Single(x => x.Name == name).Value
    };
}

public class TenantConnectionString
{
    public Guid Id { get; set; }
    public string CustomTenantInfoId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}
");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
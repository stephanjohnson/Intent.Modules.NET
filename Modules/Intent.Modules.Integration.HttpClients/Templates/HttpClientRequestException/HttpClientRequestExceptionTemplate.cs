﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Intent.Modules.Integration.HttpClients.Templates.HttpClientRequestException
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
    
    #line 1 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Integration.HttpClients\Templates\HttpClientRequestException\HttpClientRequestExceptionTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class HttpClientRequestExceptionTemplate : CSharpTemplateBase<object>
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Net;\r\nusing System.Net.Http;\r\nusing System.Threading;\r\nusing System.Threading.Tasks;\r\nusing Intent.RoslynWeaver.Attributes;\r\n\r\n[assembly: DefaultIntentManaged(Mode.Fully)]\r\n\r\nnamespace ");
            
            #line 21 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Integration.HttpClients\Templates\HttpClientRequestException\HttpClientRequestExceptionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            
            #line default
            #line hidden
            this.Write("\r\n{\r\n    public class ");
            
            #line 23 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Integration.HttpClients\Templates\HttpClientRequestException\HttpClientRequestExceptionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write(" : Exception\r\n    {\r\n        public static async Task<");
            
            #line 25 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Integration.HttpClients\Templates\HttpClientRequestException\HttpClientRequestExceptionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("> Create(Uri baseAddress, HttpRequestMessage request, HttpResponseMessage response, CancellationToken cancellationToken)\r\n        {\r\n            var fullRequestUri = new Uri(baseAddress, request.RequestUri!);\r\n            var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);\r\n            var headers = response.Headers.ToDictionary(k => k.Key, v => v.Value);\r\n            return new ");
            
            #line 30 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Integration.HttpClients\Templates\HttpClientRequestException\HttpClientRequestExceptionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(fullRequestUri, response.StatusCode, headers, response.ReasonPhrase, content);\r\n        }\r\n\r\n        public ");
            
            #line 33 "C:\Dev\Intent.Modules.NET\Modules\Intent.Modules.Integration.HttpClients\Templates\HttpClientRequestException\HttpClientRequestExceptionTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ClassName));
            
            #line default
            #line hidden
            this.Write("(\r\n            Uri requestUri, \r\n            HttpStatusCode statusCode, \r\n            IReadOnlyDictionary<string, IEnumerable<string>> responseHeaders,\r\n            string reasonPhrase,\r\n            string responseContent)\r\n            : base(GetMessage(requestUri, statusCode, reasonPhrase, responseContent))\r\n        {\r\n            RequestUri = requestUri;\r\n            StatusCode = statusCode;\r\n            ResponseHeaders = responseHeaders;\r\n            ReasonPhrase = reasonPhrase;\r\n            ResponseContent = responseContent;\r\n        }\r\n        \r\n        public Uri RequestUri { get; private set; }\r\n        public HttpStatusCode StatusCode { get; private set; }\r\n        public IReadOnlyDictionary<string, IEnumerable<string>> ResponseHeaders { get; private set; }\r\n        public string ReasonPhrase { get; private set; }\r\n        public string ResponseContent { get; private set; }\r\n        \r\n        private static string GetMessage(Uri requestUri, HttpStatusCode statusCode, string reasonPhrase, string responseContent)\r\n        {\r\n            var message = $\"Request to {requestUri} failed with status code {(int)statusCode} {reasonPhrase}.\";\r\n            if (!string.IsNullOrWhiteSpace(responseContent))\r\n            {\r\n                message += \" See content for more detail.\";\r\n            }\r\n            return message;\r\n        }\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
}
#pragma checksum "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d67cd1153f46106f1e0f68fced0c4e63a9ddcb53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users__PartialViewDetails), @"mvc.1.0.view", @"/Views/Users/_PartialViewDetails.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projetos\fork\floritasstore\FloritasStore\Views\_ViewImports.cshtml"
using FloritasStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projetos\fork\floritasstore\FloritasStore\Views\_ViewImports.cshtml"
using FloritasStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d67cd1153f46106f1e0f68fced0c4e63a9ddcb53", @"/Views/Users/_PartialViewDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c5aa2f3601350a299b638393722597f48a28f66", @"/Views/_ViewImports.cshtml")]
    public class Views_Users__PartialViewDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FloritasStore.ViewModels.Users.UserDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
  
    var nameAction = ViewContext.RouteData.Values["Action"].ToString().ToLower();
    var carOutLineColor = nameAction == "details" ? "card-primary" : "card-danger";
    //var userPhoto = Url.Action("GetPhotoUser", "Users", new { id = Model.Id });

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div");
            BeginWriteAttribute("class", " class=\"", 326, "\"", 368, 3);
            WriteAttributeValue("", 334, "card", 334, 4, true);
#nullable restore
#line 9 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
WriteAttributeValue(" ", 338, carOutLineColor, 339, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 355, "card-outline", 356, 13, true);
            EndWriteAttribute();
            WriteLiteral(@">
    <div class=""card-header"">
        <h3 class=""card-title"">
            <i class=""fas fa-folder""></i>
            Usuário
        </h3>
    </div>
    <div class=""card-body"">        
        
        <dl>            
            <dt>
                ");
#nullable restore
#line 20 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 23 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
           Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 26 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 29 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
           Write(Html.DisplayFor(model => model.Cpf));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 32 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 35 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
           Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                Telefone:\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 41 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
            Write(Model.PhoneNumber ?? "Telefone não Cadastrado" );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n\r\n            <dt>\r\n                ");
#nullable restore
#line 45 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
           Write(Html.DisplayNameFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 48 "D:\Projetos\fork\floritasstore\FloritasStore\Views\Users\_PartialViewDetails.cshtml"
           Write(Html.DisplayFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FloritasStore.ViewModels.Users.UserDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
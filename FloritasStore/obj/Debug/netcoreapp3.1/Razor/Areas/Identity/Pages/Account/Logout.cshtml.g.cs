#pragma checksum "D:\Projetos\fork\floritasstore\FloritasStore\Areas\Identity\Pages\Account\Logout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "711cacfede69756d620c00b7fccbc55af3ea7ba3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_Logout), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/Logout.cshtml")]
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
#line 1 "D:\Projetos\fork\floritasstore\FloritasStore\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projetos\fork\floritasstore\FloritasStore\Areas\Identity\Pages\_ViewImports.cshtml"
using FloritasStore.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Projetos\fork\floritasstore\FloritasStore\Areas\Identity\Pages\_ViewImports.cshtml"
using FloritasStore.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Projetos\fork\floritasstore\FloritasStore\Areas\Identity\Pages\_ViewImports.cshtml"
using FloritasStore.Models.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Projetos\fork\floritasstore\FloritasStore\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using FloritasStore.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"711cacfede69756d620c00b7fccbc55af3ea7ba3", @"/Areas/Identity/Pages/Account/Logout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97778fe92a31ce0513b4453a87718f3fdd657fee", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7917230d8ccc4f7fb9f5da9e4d0f427baf94dc1", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_Logout : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Projetos\fork\floritasstore\FloritasStore\Areas\Identity\Pages\Account\Logout.cshtml"
  
    ViewData["Title"] = "Log out";
    Layout = "~/Views/Shared/_LayoutAdminLTE.cshtml";    
 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <h1>");
#nullable restore
#line 9 "D:\Projetos\fork\floritasstore\FloritasStore\Areas\Identity\Pages\Account\Logout.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p>You have successfully logged out of the application.</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LogoutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogoutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<LogoutModel>)PageContext?.ViewData;
        public LogoutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

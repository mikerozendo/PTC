#pragma checksum "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdf81ad45192eef221f6c4bda1891720406d307b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Proprietario_Index), @"mvc.1.0.view", @"/Views/Proprietario/Index.cshtml")]
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
#line 1 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\_ViewImports.cshtml"
using PTC.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\_ViewImports.cshtml"
using PTC.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdf81ad45192eef221f6c4bda1891720406d307b", @"/Views/Proprietario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e22f2bf1948ed7fab6abffe94d0fcafbfc719cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Proprietario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-12\" style=\"text-align: right; margin-top: 20px; margin-bottom:5px\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 118, "\"", 164, 1);
#nullable restore
#line 3 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
WriteAttributeValue("", 125, Url.Action("Adicionar","Proprietario"), 125, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success btnApp"">Novo</a>
    </div>
</div>
<table id=""tblMarcas"" class=""table table-striped table-hover"">
    <thead>
        <tr>
            <th>Nome</th>
            <th>Tipo Documento</th>
            <th>Documento</th>
            <th>E-mail</th>
            <th>Endereco</th>
            <th>Situação</th>
        </tr>
    </thead>
</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

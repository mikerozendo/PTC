#pragma checksum "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bb3be9fc2e78e279dcebbcba7f203497f204316"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bb3be9fc2e78e279dcebbcba7f203497f204316", @"/Views/Proprietario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e22f2bf1948ed7fab6abffe94d0fcafbfc719cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Proprietario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PTC.Domain.Entities.Proprietario>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "4", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"modalContainner\"></div>\r\n<div class=\"modal-content margin-modais\">\r\n    <div class=\"modal-header\" style=\"display: block;\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bb3be9fc2e78e279dcebbcba7f203497f2043164716", async() => {
                WriteLiteral("\r\n            <div class=\"row\">\r\n                <div class=\"col-3\" style=\"text-align:center\">\r\n                    <label for=\"inicio\">Inicio</label>\r\n                    <input class=\"form-control form-control-sm\" type=\"date\" name=\"inicio\"");
                BeginWriteAttribute("value", " value=\"", 511, "\"", 519, 0);
                EndWriteAttribute();
                WriteLiteral(" required />\r\n                </div>\r\n                <div class=\"col-3\" style=\"text-align:center\">\r\n                    <label for=\"termino\">Término</label>\r\n                    <input class=\"form-control form-control-sm\" type=\"date\" name=\"termino\"");
                BeginWriteAttribute("value", " value=\"", 769, "\"", 777, 0);
                EndWriteAttribute();
                WriteLiteral(@" required />
                </div>
                <div class=""col-3"" style=""text-align:center"">
                    <label for=""situacao"">Situação</label>
                    <select id=""situacao"" class=""form-control form-control-sm"" name=""situacao"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bb3be9fc2e78e279dcebbcba7f203497f2043166101", async() => {
                    WriteLiteral("Selecione");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bb3be9fc2e78e279dcebbcba7f203497f2043167351", async() => {
                    WriteLiteral("Todos");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bb3be9fc2e78e279dcebbcba7f203497f2043168597", async() => {
                    WriteLiteral("Ativo");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bb3be9fc2e78e279dcebbcba7f203497f2043169843", async() => {
                    WriteLiteral("Inativo");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </select>
                </div>
                <div class=""col-3 div-btn-end"">
                    <button type=""submit"" class=""btn btn-primary btn-info btn-pesquisar-filtro"">
                        Pesquisar
                        <i class=""fa fa-search"" aria-hidden=""true""></i>
                    </button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 6 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
AddHtmlAttributeValue("", 211, Url.Action("ObterFiltrados","Proprietario"), 211, 44, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <div class=\"modal-body tbl-modal\">\r\n        <div class=\"row\">\r\n            <div class=\"col-6 div-btn-end div-btn-novo\" style=\"text-align:start\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1856, "\"", 1902, 1);
#nullable restore
#line 37 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
WriteAttributeValue("", 1863, Url.Action("Adicionar","Proprietario"), 1863, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-success btn-novo"">
                    Novo
                    <i class=""fa fa-plus"" aria-hidden=""true""></i>
                </a>
            </div>
            <div class=""col-6"" style=""text-align: end"">
                <input class=""input-filtro-dinamico"" type=""text"" name=""filtro""");
            BeginWriteAttribute("value", " value=\"", 2209, "\"", 2217, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                <a class=""btn btn-success btn-novo filtro-dinamico-link"">
                    Filtrar
                    <i class=""fa fa-search"" aria-hidden=""true""></i>
                </a>
            </div>
        </div>
        <table id=""tblMarcas"" class=""table table-striped table-hover table-bordered"">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th style=""width: 10%;"">Telefone</th>
                    <th>Cadastro</th>
                    <th>Exclusão</th>
                    <th>Documento</th>
                    <th>Endereço</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 63 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                 foreach (PTC.Domain.Entities.Proprietario obj in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 66 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                       Write(obj.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <button onclick=\"AbrirWhatsAppWeb(this)\" class=\"btn btn-sm btn-success btn-icon\" data-id=\"");
#nullable restore
#line 68 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                                                                                                                 Write(obj.WhatsApp);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""">
                                <i class=""fa fa-whatsapp"" aria-hidden=""true""></i>
                            </button>
                            <span>|</span>
                            <button id=""CopyWhatsApp"" onclick=""CopiarConteudo()"" class=""btn btn-sm btn-info btn-icon""");
            BeginWriteAttribute("value", " value=\"", 3543, "\"", 3564, 1);
#nullable restore
#line 72 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
WriteAttributeValue("", 3551, obj.WhatsApp, 3551, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"fa fa-clone\" aria-hidden=\"true\"></i>\r\n                            </button>\r\n                        </td>\r\n                        <td>");
#nullable restore
#line 76 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                       Write(obj.Cadastro);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 77 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                       Write(obj.Exclusao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 78 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                       Write(obj.Documento);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>\r\n                            <button class=\"btn btn-sm btn-success\" onclick=\"AbrirGoogleMaps(this)\" data-endereco=\"https://www.google.com.br/maps/place/");
#nullable restore
#line 80 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                                                                                                                                                  Write(obj.Endereco.Cep);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                <i class=\"fa fa-map-marker\" aria-hidden=\"true\"></i>\r\n                            </button>\r\n                        </td>\r\n                        <td>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 4280, "\"", 4345, 1);
#nullable restore
#line 85 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
WriteAttributeValue("", 4287, Url.Action("Editar", "Proprietario", new { id = obj.Id} ), 4287, 58, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-warning btn-icon\">\r\n                                <i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i>\r\n                            </a>\r\n");
#nullable restore
#line 88 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                             if (obj.Exclusao is null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>|</span>\r\n                                <button class=\"btn btn-sm btn-danger btn-icon\" data-id=\"");
#nullable restore
#line 91 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                                                                                   Write(System.Text.Json.JsonSerializer.Serialize(obj));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                    <i class=\"fa fa-trash\" aria-hidden=\"true\"></i>\r\n                                </button>\r\n");
#nullable restore
#line 94 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 97 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var objValue = null;
        var objAlterar = null;
        $(document).ready(function () {
            $("".btn-danger"").on('click', function (e) {
                e.stopImmediatePropagation();
                objValue = JSON.parse($(this).attr('data-id'));
                let html =
                    `
<div id=""travaDelete"" class=""modal"" tabindex=""-1"" role=""dialog"">
  <div class=""modal-dialog"" role=""document"">
    <div class=""modal-content"">
      <div class=""modal-header"">
        <h5 class=""modal-title"">Cuidado!</h5>
        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
          <span aria-hidden=""true"">&times;</span>
        </button>
      </div>
      <div class=""modal-body"">
        <p>Tem certeza que deseja excluir o proprietário ${objValue.Nome}?</p>
      </div>
      <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"" style=""text-align:right;"">Cancelar</button>
       ");
                WriteLiteral(@" <button onclick=""Deletar()"" type=""button"" class=""btn btn-primary btn-success"" style=""text-align: left;"">Continuar</button>
      </div>
    </div>
  </div>
</div>
                    `;
                $(""#modalContainner"").html(html);
                $(""#travaDelete"").modal({ backdrop: 'static', keyboard: true });
            });
        });

        function AbrirGoogleMaps(obj) {
            let link = $(obj).attr(""data-endereco"");
            window.open(link, ""_blank"");
        }

        function Deletar() {
            $(""#travaDelete"").modal('hide');
            var form = new FormData();
            form.append(""Id"", objValue.Id);
            var request = new XMLHttpRequest();
            request.onload = Reload;
            request.open(""POST"", """);
#nullable restore
#line 151 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Index.cshtml"
                             Write(Url.Action("Deletar", "Proprietario"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\");\r\n            request.send(form);\r\n        }\r\n\r\n        function Reload() {\r\n            window.location.href = window.location.href;\r\n        }\r\n    </script>\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PTC.Domain.Entities.Proprietario>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Adicionar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f66f99a1772d628f2e5942a675c2c326aaf68236"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Proprietario_Adicionar), @"mvc.1.0.view", @"/Views/Proprietario/Adicionar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f66f99a1772d628f2e5942a675c2c326aaf68236", @"/Views/Proprietario/Adicionar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e22f2bf1948ed7fab6abffe94d0fcafbfc719cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Proprietario_Adicionar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "none", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("incluirProprietario"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"modal-content margin-modais\">\r\n    <div class=\"modal-header\">\r\n        <h3>\r\n            Novo Proprietário <i class=\"fa fa-user\" aria-hidden=\"true\"></i>\r\n        </h3>\r\n    </div>\r\n    <div class=\"modal-body\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f66f99a1772d628f2e5942a675c2c326aaf682365154", async() => {
                WriteLiteral(@"
            <div class=""form-group"">
                <div class=""row"" style=""padding-bottom:20px"">
                    <div class=""col-4"">
                        <label for=""Nome"">Nome</label>
                        <input id=""Nome"" type=""text"" name=""Nome""");
                BeginWriteAttribute("value", " value=\"", 587, "\"", 595, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" required />
                    </div>
                    <div class=""col-4"">
                        <label for=""tipoDocumento"">Tipo Documento</label>
                        <select id=""tipoDocumento"" class=""form-control"" required>
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f66f99a1772d628f2e5942a675c2c326aaf682366142", async() => {
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
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f66f99a1772d628f2e5942a675c2c326aaf682367396", async() => {
                    WriteLiteral("CPF");
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
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f66f99a1772d628f2e5942a675c2c326aaf682368644", async() => {
                    WriteLiteral("CNPJ");
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
                WriteLiteral("\r\n                        </select>\r\n                    </div>\r\n                    <div class=\"col-4\">\r\n                        <label for=\"documento\">Documento</label>\r\n                        <input id=\"documento\" type=\"text\" name=\"documento\"");
                BeginWriteAttribute("value", " value=\"", 1292, "\"", 1300, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" placeholder=""Selecione um tipo de documento"" readonly required />
                    </div>
                </div>
                <div class=""row"" style=""padding-bottom:20px"">
                    <div class=""col-2"">
                        <label for=""Cep"">CEP</label>
                        <input id=""Cep"" type=""text"" name=""Endereco.Cep""");
                BeginWriteAttribute("value", " value=\"", 1671, "\"", 1679, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" placeholder=""00000-000"" onkeypress=""$(this).mask('00000-000')"" required />
                    </div>
                    <div class=""col-3"">
                        <label for=""Bairro"">Bairro</label>
                        <input id=""Bairro"" type=""text"" name=""Endereco.Bairro""");
                BeginWriteAttribute("value", " value=\"", 1984, "\"", 1992, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" readonly />\r\n                    </div>\r\n                    <div class=\"col-2\">\r\n                        <label for=\"Uf\">Estado</label>\r\n                        <input id=\"Uf\" type=\"text\" name=\"Endereco.Uf\"");
                BeginWriteAttribute("value", " value=\"", 2222, "\"", 2230, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" readonly />\r\n                    </div>\r\n                    <div class=\"col-3\">\r\n                        <label for=\"Cidade\">Cidade</label>\r\n                        <input id=\"Cidade\" type=\"text\" name=\"Endereco.Cidade\"");
                BeginWriteAttribute("value", " value=\"", 2472, "\"", 2480, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" readonly />\r\n                    </div>\r\n                    <div class=\"col-2\">\r\n                        <label for=\"Numero\">Numero</label>\r\n                        <input id=\"Numero\" type=\"text\" name=\"Endereco.Numero\"");
                BeginWriteAttribute("value", " value=\"", 2722, "\"", 2730, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" required />
                    </div>
                </div>
                <div class=""row"" style=""padding-bottom:20px"">
                    <div class=""col-6"">
                        <label for=""Logradouro"">Logradouro</label>
                        <input id=""Logradouro"" type=""text"" name=""Endereco.Logradouro""");
                BeginWriteAttribute("value", " value=\"", 3075, "\"", 3083, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" readonly />
                    </div>
                    <div class=""col-6"">
                        <label for=""pontoReferencia"">Ponto de referência</label>
                        <input id=""pontoReferencia"" type=""text"" name=""Endereco.pontoReferencia""");
                BeginWriteAttribute("value", " value=\"", 3365, "\"", 3373, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" />
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-6"">
                        <label for=""Email"">E-mail</label>
                        <input id=""Email"" type=""text"" name=""Email""");
                BeginWriteAttribute("value", " value=\"", 3653, "\"", 3661, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" required />\r\n                    </div>\r\n                    <div class=\"col-6\">\r\n                        <label for=\"WhatsApp\">WhatsApp</label>\r\n                        <input id=\"WhatsApp\" type=\"text\" name=\"WhatsApp\"");
                BeginWriteAttribute("value", " value=\"", 3902, "\"", 3910, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" placeholder=""(00) 0 0000-0000"" onkeypress=""$(this).mask('(00) 0 0000-0000')"" required />
                    </div>
                </div>
            </div>
            <hr />
            <div class=""row"">
                <div class=""col-12 div-btn-end"" style=""padding-top: 15px;"">
                    <a class=""btn btn-danger"" href=""/home/index"">Cancelar</a>
                    &nbsp;|&nbsp;
                    <button type=""submit"" class=""btn btn-success"">Salvar</button>
                </div>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 8 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Adicionar.cshtml"
AddHtmlAttributeValue("", 270, Url.Action("Inserir","Proprietario"), 270, 37, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $('#Cep').keyup(function () {
            if ($(this).val().length == 0) {
                $('#mdlEnrecoRetornoContent').hide();
            }
            if ($(this).val().length == 9) {
                var value = $(this).val().replace('-', '');
                ConsultarCep(value);
            }
        });

        function ConsultarCep(obj) {
            $.ajax({
                url: ""https://viacep.com.br/ws/"" + obj + ""/json/"",
                type: ""GET"",
                success: function (json) {
                    if (json != null) {
                        if (json.erro != true) {
                            $('#Logradouro').val(json.logradouro);
                            $('#Bairro').val(json.bairro);
                            $('#Cidade').val(json.localidade);
                            $('#Uf').val(json.uf);
                        }
                    }
                },
            });
        }

        $(""#tipoDocumento"").on('change', ");
                WriteLiteral(@"function (e) {
            e.stopImmediatePropagation();
            $(""#documento"").removeAttr(""placeholder"").removeAttr(""readonly"");
            $(""#documento"").val("""");

            if ($(""#tipoDocumento"").val() == 0) {
                $(""#documento"").attr(""placeholder"", ""000.000.000-00"");
            }
            else if ($(""#tipoDocumento"").val() == 1) {
                $(""#documento"").attr(""placeholder"", ""99.999.999/9999-99"");
            }
            else {
                $(""#documento"").attr(""readonly"", true);
                $(""#documento"").attr(""placeholder"", ""Selecione um tipo de documento"");
            }
        });

        $(""#documento"").on(""keyup"", function (e) {
            e.stopImmediatePropagation();

            if ($(this).val().length == 11 && $(""#tipoDocumento"").val() == 0) {
                $(this).mask('999.999.999-99');
            }
            else if ($(this).val().length == 14 && $(""#tipoDocumento"").val() == 1) {
                $(this).mask(""99.999.9");
                WriteLiteral(@"99/9999-99"");
            }
        });

        document.forms['incluirProprietario'].addEventListener('submit', (event) => {
            event.preventDefault();
            ColetarEventoServidor();
        });

        function ColetarEventoServidor() {
            let value = fetch(event.target.action, {
                method: 'POST',
                body: new URLSearchParams(new FormData(event.target)) 
            }).then(function (serverPromise) {
                serverPromise.text()
                    .then(function (j) {
                        alert(j);
                        if (j.toString().includes(""sucesso"")) {
                            window.location.href = """);
#nullable restore
#line 155 "C:\Users\junior\Documents\Projetos\PTC\PTC.Web\Views\Proprietario\Adicionar.cshtml"
                                               Write(Url.Action("Index","Proprietario"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n                       }\r\n                    })\r\n                    .catch(function (e) {\r\n                        console.log(e);\r\n                    });\r\n            });\r\n            \r\n        }\r\n\r\n    </script>\r\n\r\n");
            }
            );
            WriteLiteral(" ");
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

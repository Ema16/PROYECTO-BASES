#pragma checksum "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Edicions\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe74542369aaf88663d3ebfb4d214923a4e1a099"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Edicions_Details), @"mvc.1.0.view", @"/Views/Edicions/Details.cshtml")]
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
#line 1 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\_ViewImports.cshtml"
using BibliotecaCUNOR;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\_ViewImports.cshtml"
using BibliotecaCUNOR.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe74542369aaf88663d3ebfb4d214923a4e1a099", @"/Views/Edicions/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7378079423c5926812f56648bf7500783e6aa0", @"/Views/_ViewImports.cshtml")]
    public class Views_Edicions_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Autors/Create1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Editorials/Create1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Edicions/Create1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/user01.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("user"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive center-box"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-width: 110px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Edicions\Details.cshtml"
  
    ViewData["Title"] = "listaEdicions";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"es\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe74542369aaf88663d3ebfb4d214923a4e1a0996217", async() => {
                WriteLiteral(@"
    <title>Administradores</title>
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.22/css/jquery.dataTables.css"">
    <script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.10.22/js/jquery.dataTables.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe74542369aaf88663d3ebfb4d214923a4e1a0997469", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""page-header"">
            <h1 class=""all-tittles"">Sistema bibliotecario <small>Lista de Autores</small></h1>
        </div>
    </div>
    <div class=""container-fluid"">
        <ul class=""nav nav-tabs nav-justified"" style=""font-size: 17px;"">
            <li role=""presentation"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe74542369aaf88663d3ebfb4d214923a4e1a0998073", async() => {
                    WriteLiteral("Autor");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n            <li role=\"presentation\" >");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe74542369aaf88663d3ebfb4d214923a4e1a0999251", async() => {
                    WriteLiteral("Editorial");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n            <li role=\"presentation\" class=\"active\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe74542369aaf88663d3ebfb4d214923a4e1a09910449", async() => {
                    WriteLiteral("Edicion");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</li>\r\n        </ul>\r\n    </div>\r\n    <div class=\"container-fluid\" style=\"margin: 50px 0;\">\r\n        <div class=\"row\">\r\n            <div class=\"col-xs-12 col-sm-4 col-md-3\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fe74542369aaf88663d3ebfb4d214923a4e1a09911793", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </div>
            <div class=""col-xs-12 col-sm-8 col-md-8 text-justify lead"">
                Bienvenido a la sección donde se encuentra el listado de Ediciones registrador en el sistema Biblioteca CUNOR.
            </div>
        </div>
    </div>
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-xs-12 lead"">
                <ol class=""breadcrumb"">
                    <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe74542369aaf88663d3ebfb4d214923a4e1a09913589", async() => {
                    WriteLiteral("Nueva Edicion");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"</li>
                    <li class=""active"">Listado de Ediciones</li>
                </ol>
            </div>
        </div>
    </div>
    <div class=""container-fluid"">
        <h2 class=""text-center all-tittles"">Lista de Ediciones</h2>
        <div class=""table-responsive"">
            <table id=""table_id"" class=""display"">
                <thead>
                    <tr>
                        <th>Edicion</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
        <!--
        <div class=""div-table"">
            <div class=""div-table-row div-table-head"">
                <div class=""div-table-cell"">#</div>
                <div class=""div-table-cell"">Nombre</div>
                <div class=""div-table-cell"">Nombre de usuario</div>
                <div class=""div-table-cell"">Email</div>
                <div class=""div-table-cell"">Estado</div>
                <div class=""div-table-cell"">Cambiar ");
                WriteLiteral(@"E.</div>
                <div class=""div-table-cell"">Actualizar</div>
                <div class=""div-table-cell"">Eliminar</div>
            </div>
            <div class=""div-table-row"">
                <div class=""div-table-cell"">#</div>
                <div class=""div-table-cell"">Nombre</div>
                <div class=""div-table-cell"">Nombre de usuario</div>
                <div class=""div-table-cell"">Email</div>
                <div class=""div-table-cell"">Estado</div>
                <div class=""div-table-cell"">
                    <button type=""submit"" class=""btn btn-info tooltips-general"" data-toggle=""tooltip"" data-placement=""top"" title=""Cuenta desactivada, pulsa el botón para activarla""><i class=""zmdi zmdi-swap""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-success""><i class=""zmdi zmdi-refresh""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button clas");
                WriteLiteral(@"s=""btn btn-danger""><i class=""zmdi zmdi-delete""></i></button>
                </div>
            </div>
            <div class=""div-table-row"">
                <div class=""div-table-cell"">#</div>
                <div class=""div-table-cell"">Nombre</div>
                <div class=""div-table-cell"">Nombre de usuario</div>
                <div class=""div-table-cell"">Email</div>
                <div class=""div-table-cell"">Estado</div>
                <div class=""div-table-cell"">
                    <button type=""submit"" class=""btn btn-info tooltips-general"" data-toggle=""tooltip"" data-placement=""top"" title=""Cuenta desactivada, pulsa el botón para activarla""><i class=""zmdi zmdi-swap""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-success""><i class=""zmdi zmdi-refresh""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-danger""><i class=""zmdi zmdi-delete""");
                WriteLiteral(@"></i></button>
                </div>
            </div>
            <div class=""div-table-row"">
                <div class=""div-table-cell"">#</div>
                <div class=""div-table-cell"">Nombre</div>
                <div class=""div-table-cell"">Nombre de usuario</div>
                <div class=""div-table-cell"">Email</div>
                <div class=""div-table-cell"">Estado</div>
                <div class=""div-table-cell"">
                    <button type=""submit"" class=""btn btn-info tooltips-general"" data-toggle=""tooltip"" data-placement=""top"" title=""Cuenta desactivada, pulsa el botón para activarla""><i class=""zmdi zmdi-swap""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-success""><i class=""zmdi zmdi-refresh""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-danger""><i class=""zmdi zmdi-delete""></i></button>
                </div>
      ");
                WriteLiteral(@"      </div>
            <div class=""div-table-row"">
                <div class=""div-table-cell"">#</div>
                <div class=""div-table-cell"">Nombre</div>
                <div class=""div-table-cell"">Nombre de usuario</div>
                <div class=""div-table-cell"">Email</div>
                <div class=""div-table-cell"">Estado</div>
                <div class=""div-table-cell"">
                    <button type=""submit"" class=""btn btn-info tooltips-general"" data-toggle=""tooltip"" data-placement=""top"" title=""Cuenta desactivada, pulsa el botón para activarla""><i class=""zmdi zmdi-swap""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-success""><i class=""zmdi zmdi-refresh""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-danger""><i class=""zmdi zmdi-delete""></i></button>
                </div>
            </div>
            <div class=""div-tabl");
                WriteLiteral(@"e-row"">
                <div class=""div-table-cell"">#</div>
                <div class=""div-table-cell"">Nombre</div>
                <div class=""div-table-cell"">Nombre de usuario</div>
                <div class=""div-table-cell"">Email</div>
                <div class=""div-table-cell"">Estado</div>
                <div class=""div-table-cell"">
                    <button type=""submit"" class=""btn btn-info tooltips-general"" data-toggle=""tooltip"" data-placement=""top"" title=""Cuenta desactivada, pulsa el botón para activarla""><i class=""zmdi zmdi-swap""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-success""><i class=""zmdi zmdi-refresh""></i></button>
                </div>
                <div class=""div-table-cell"">
                    <button class=""btn btn-danger""><i class=""zmdi zmdi-delete""></i></button>
                </div>
            </div>
        </div>
        -->
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>

<script>
    var table;
    var placeholderElement = $(""#modal-placeholder"");
    $(document).ready(function () {
       table=$(""#table_id"").DataTable({
                language:
                    {
                    ""sProcessing"": ""Procesando..."",
                    ""sLengthMenu"": ""Mostrar _MENU_ registros"",
                    ""sZeroRecords"": ""No se encontraron resultados"",
                    ""sEmptyTable"": ""Ningún dato disponible en esta tabla"",
                    ""sInfo"": ""Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros"",
                    ""sInfoEmpty"": ""Mostrando registros del 0 al 0 de un total de 0 registros"",
                    ""sInfoFiltered"": ""(filtrado de un total de _MAX_ registros)"",
                    ""sInfoPostFix"": """",
                    ""sSearch"": ""Buscar:"",
                    ""sUrl"": """",
                    ""sInfoThousands"": "","",
                    ""sLoadingRecords"": ""Cargando..."",
                    ""oPaginate"": {
  ");
            WriteLiteral(@"                      ""sFirst"": ""Primero"",
                        ""sLast"": ""Último"",
                        ""sNext"": ""Siguiente"",
                        ""sPrevious"": ""Anterior""
                    },
                    ""oAria"": {
                        ""sSortAscending"": "": Activar para ordenar la columna de manera ascendente"",
                        ""sSortDescending"": "": Activar para ordenar la columna de manera descendente""
                    },
                    ""buttons"": {
                        ""copy"": ""Copiar"",
                        ""colvis"": ""Visibilidad""
                    }
                },
                ""proccessing"": true,
                ""serverSide"": true,
                ""filter"": true,
                ""ajax"": {
                    ""url"": """);
#nullable restore
#line 194 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Edicions\Details.cshtml"
                       Write(Url.Content("~/Edicions/Json"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },
           ""columns"": [
               { ""data"": ""edicion"", ""name"": ""Edicion"", ""autoWidth"": true },
                ]

            });

    });
</script>


");
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

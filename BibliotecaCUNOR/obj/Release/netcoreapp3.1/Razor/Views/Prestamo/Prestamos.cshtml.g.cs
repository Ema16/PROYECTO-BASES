#pragma checksum "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\Prestamos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c41190707b488519681f184b127e359253afc579"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prestamo_Prestamos), @"mvc.1.0.view", @"/Views/Prestamo/Prestamos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c41190707b488519681f184b127e359253afc579", @"/Views/Prestamo/Prestamos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7378079423c5926812f56648bf7500783e6aa0", @"/Views/_ViewImports.cshtml")]
    public class Views_Prestamo_Prestamos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Prestamo/Prestamos"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Prestamo/DevolucionesPendientes"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Prestamo/Ficha"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/calendar_book.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("calendar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"es\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41190707b488519681f184b127e359253afc5796004", async() => {
                WriteLiteral(@"
    <title>Prestamos</title>
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41190707b488519681f184b127e359253afc5797252", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""page-header"">
            <h1 class=""all-tittles"">Sistema bibliotecario <small>Préstamos y Reservaciones</small></h1>
        </div>
    </div>
    <div class=""conteiner-fluid"">
        <ul class=""nav nav-tabs nav-justified"" style=""font-size: 17px;"">
            <li class=""active"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41190707b488519681f184b127e359253afc5797860", async() => {
                    WriteLiteral("Todos los préstamos");
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
                WriteLiteral("</li>\r\n            <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41190707b488519681f184b127e359253afc5799029", async() => {
                    WriteLiteral("Devoluciones pendientes");
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
                WriteLiteral("</li>\r\n            <li>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c41190707b488519681f184b127e359253afc57910202", async() => {
                    WriteLiteral("Nuevo Prestamo");
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c41190707b488519681f184b127e359253afc57911553", async() => {
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
                Bienvenido a esta sección, aquí se muestran todos los préstamos de libros realizados hasta la fecha y que ya se entregaron satisfactoriamente
            </div>
        </div>
    </div>


    <div class=""container-fluid"">
        <h2 class=""text-center all-tittles"">Listado de préstamos</h2>
        <div id=""modal-placeholder""></div>
        <table id=""tbprestamos_id"" class=""display"">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre del Libro</th>
                    <th>Nombre de Usuario</th>
                    <th>Tipo</th>
                    <th>Fecha Solicitud</th>
                    <th>Fecha de Entrega</th>
                    <th>Ver Ficha</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
        </table>
    </div>

    <!--
    <div class=""container-fluid"">
        <h2");
                WriteLiteral(@" class=""text-center all-tittles"">Listado de préstamos</h2>
        <div class=""table-responsive"">
            <div class=""div-table"" style=""margin:0 !important;"">
                <div class=""div-table-row div-table-row-list"" style=""background-color:#DFF0D8; font-weight:bold;"">
                    <div class=""div-table-cell"" style=""width: 6%;"">#</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de libro</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de usuario</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">Tipo</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Solicitud</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Entrega</div>
                    <div class=""div-table-cell"" style=""width: 8%;"">Eliminar</div>
                    <div class=""div-table-cell"" style=""width: 8%;"">Ver Ficha</div>
                </div>
            </div>
        </div>
 ");
                WriteLiteral(@"       <div class=""table-responsive"">
            <div class=""div-table"" style=""margin:0 !important;"">
                <div class=""div-table-row div-table-row-list"">
                    <div class=""div-table-cell"" style=""width: 6%;"">#</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Libro</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Usuario</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">Tipo</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Solicitud</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Entrega</div>
                    <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-danger""><i class=""zmdi zmdi-delete""></i></button>
                    </div>
                    <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-info""><i class=""zmdi zmdi-file");
                WriteLiteral(@"-text""></i></button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""table-responsive"">
            <div class=""div-table"" style=""margin:0 !important;"">
                <div class=""div-table-row div-table-row-list"">
                    <div class=""div-table-cell"" style=""width: 6%;"">#</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Libro</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Usuario</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">Tipo</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Solicitud</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Entrega</div>
                    <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-danger""><i class=""zmdi zmdi-delete""></i></button>
                    </div>
                    <div class=""div");
                WriteLiteral(@"-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-info""><i class=""zmdi zmdi-file-text""></i></button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""table-responsive"">
            <div class=""div-table"" style=""margin:0 !important;"">
                <div class=""div-table-row div-table-row-list"">
                    <div class=""div-table-cell"" style=""width: 6%;"">#</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Libro</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Usuario</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">Tipo</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Solicitud</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Entrega</div>
                    <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-dan");
                WriteLiteral(@"ger""><i class=""zmdi zmdi-delete""></i></button>
                    </div>
                    <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-info""><i class=""zmdi zmdi-file-text""></i></button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""table-responsive"">
            <div class=""div-table"" style=""margin:0 !important;"">
                <div class=""div-table-row div-table-row-list"">
                    <div class=""div-table-cell"" style=""width: 6%;"">#</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Libro</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Usuario</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">Tipo</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Solicitud</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Entrega</div>
        ");
                WriteLiteral(@"            <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-danger""><i class=""zmdi zmdi-delete""></i></button>
                    </div>
                    <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-info""><i class=""zmdi zmdi-file-text""></i></button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""table-responsive"">
            <div class=""div-table"" style=""margin:0 !important;"">
                <div class=""div-table-row div-table-row-list"">
                    <div class=""div-table-cell"" style=""width: 6%;"">#</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Libro</div>
                    <div class=""div-table-cell"" style=""width: 22%;"">Nombre de Usuario</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">Tipo</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. ");
                WriteLiteral(@"Solicitud</div>
                    <div class=""div-table-cell"" style=""width: 10%;"">F. Entrega</div>
                    <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-danger""><i class=""zmdi zmdi-delete""></i></button>
                    </div>
                    <div class=""div-table-cell"" style=""width: 8%;"">
                        <button class=""btn btn-info""><i class=""zmdi zmdi-file-text""></i></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    -->
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
    var placeholderElement = $(""#modal-placeholder"");
        $(document).ready(function () {
            $(""#tbprestamos_id"").DataTable({
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
            WriteLiteral(@"               ""sFirst"": ""Primero"",
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
                ""aoColumnDefs"": [{ 'bSortable': false, 'aTargets': [5] }],
                ""proccessing"": true,
                ""serverSide"": true,
                ""filter"": true,
                ""ajax"": {
                    ""url"": """);
#nullable restore
#line 206 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\Prestamos.cshtml"
                       Write(Url.Content("~/Prestamo/Json"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },
                ""pageLength"": 10,
                ""responsivePriority"": 1,
                ""data"": null,
                ""columns"": [
                    { ""data"": ""codPrestamo"", ""name"": ""CodPrestamo"", ""autoWidth"": true },
                    { ""data"": ""libro"", ""name"": ""Libro"", ""autoWidth"": true },
                    { ""data"": ""nombreUsuario"", ""name"": ""NombreUsuario"", ""autoWidth"": true },
                    { ""data"": ""tipo"", ""name"": ""Tipo"", ""autoWidth"": true },
                    { ""data"": ""fechaSolicitud"", ""name"": ""FechaSolicitud"", ""autoWidth"": true },
                    { ""data"": ""fechaRecepcion"", ""name"": ""FechaRecepcion"", ""autoWidth"": true },
                    { ""defaultContent"": ""<button id='iddetalle' type='button' class='form btn btn-info'> <span class='glyphicon glyphicon-info-sign'></span> &nbsp;&nbsp;Detalles</button>"" },
                ]

            });


            $('#tbpre");
            WriteLiteral(@"stamos_id tbody').on('click', '#iddetalle', function () //Al hacer click sobre el boton button.form de la linea de arriba
            {
                var row = $(this).parent().parent().children().first().text();
                // console.log(row);
                $.ajax({
                    url: ""/Prestamo/DetalleDevuelto"",
                    method: ""GET"",
                    data: { id: row },
                    async: true,
                    success: function (res) {
                        placeholderElement.html(res);
                        placeholderElement.find('.modal').modal('show');
                    }
                });

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

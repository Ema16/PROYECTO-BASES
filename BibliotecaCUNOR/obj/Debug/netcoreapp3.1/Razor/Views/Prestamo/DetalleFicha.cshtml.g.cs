#pragma checksum "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "256d64e580ea30afcafa3e524334eb09bcc475e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prestamo_DetalleFicha), @"mvc.1.0.view", @"/Views/Prestamo/DetalleFicha.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"256d64e580ea30afcafa3e524334eb09bcc475e7", @"/Views/Prestamo/DetalleFicha.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7378079423c5926812f56648bf7500783e6aa0", @"/Views/_ViewImports.cshtml")]
    public class Views_Prestamo_DetalleFicha : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BibliotecaCUNOR.Models.Prestamo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""modal"" tabindex=""-1"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Detalle del Prestamo </h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>

            <div class=""modal-body"">
                <ol class=""breadcrumb"">
                    <li><a href=""#"" class=""close"" data-dismiss=""modal"">Devoluciones Pendientes</a></li>
                    <li class=""active"">Prestamo de : <strong>");
#nullable restore
#line 21 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                                                         Write(Model.CodUsuarioNavigation.Nombre+" "+ @Model.CodUsuarioNavigation.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></li>
                </ol>

                <div class=""panel panel-default"">
                    <div class=""panel-heading"">Datos del Usuario</div>
                    <div class=""panel-body"">
                        <dl class=""dl-horizontal"">
                            <dt>Datos del Usuario</dt>
                            <dd>");
#nullable restore
#line 29 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                           Write(Model.CodUsuarioNavigation.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 29 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                                                              Write(Model.CodUsuarioNavigation.Apellido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                            <dt>Telefono</dt>\r\n                            <dd>");
#nullable restore
#line 31 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                           Write(Model.CodUsuarioNavigation.Telefono);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                            <dt>Carnet</dt>\r\n                            <dd>");
#nullable restore
#line 33 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                           Write(Model.CodUsuarioNavigation.Usuario1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                            <dt>Correo Electronico</dt>\r\n                            <dd>");
#nullable restore
#line 35 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                           Write(Model.CodUsuarioNavigation.CorreoElectronico);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</dd>
                        </dl>
                    </div>
                </div>
                <div class=""panel panel-default"">
                    <div class=""panel-heading"">Informacion del Prestamo</div>
                    <div class=""panel-body"">
                        <dl class=""dl-horizontal"">
                            <dt>Fecha de Prestamo</dt>
                            <dd>");
#nullable restore
#line 44 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                           Write(Model.FechaPrestamo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                            <dt>Fecha Devolucion</dt>\r\n                            <dd>");
#nullable restore
#line 46 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                           Write(Model.FechaDevolucion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                            <dt>Dias de Atraso</dt>\r\n                            <dd>");
#nullable restore
#line 48 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                           Write(Model.DiasAtraso);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n                            <dt>Mora Generado</dt>\r\n                            <dd>Q.");
#nullable restore
#line 50 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                             Write(Model.Mora);

#line default
#line hidden
#nullable disable
            WriteLiteral(@".00</dd>
                        </dl>
                    </div>
                </div>

                <div class=""panel panel-default"">
                    <div class=""panel-heading"">Libro/Libros Prestados</div>
                    <div class=""panel-body"">
                        <ul class=""list-group"">
");
#nullable restore
#line 59 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                             foreach (var item in Model.DetPrestamo)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"list-group-item\">\r\n                                    ");
#nullable restore
#line 62 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                               Write(Html.DisplayFor(modelItem => item.CodLibroNavigation.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </li>\r\n");
#nullable restore
#line 64 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\Prestamo\DetalleFicha.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </ul>
                    </div>
                </div>
                
            </div>

            <div class=""modal-footer"">

                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button>

            </div>
        </div>

    </div>
</div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BibliotecaCUNOR.Models.Prestamo> Html { get; private set; }
    }
}
#pragma warning restore 1591
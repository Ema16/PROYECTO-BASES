#pragma checksum "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cb8c564537ac1b357ba946fd98862213a04fe3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TrabajoGraduacions_Busqueda), @"mvc.1.0.view", @"/Views/TrabajoGraduacions/Busqueda.cshtml")]
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
#nullable restore
#line 2 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cb8c564537ac1b357ba946fd98862213a04fe3e", @"/Views/TrabajoGraduacions/Busqueda.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7378079423c5926812f56648bf7500783e6aa0", @"/Views/_ViewImports.cshtml")]
    public class Views_TrabajoGraduacions_Busqueda : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BibliotecaCUNOR.Models.TrabajoGraduacion>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/checklist.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("pdf"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive center-box"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-width: 110px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-padding"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TrabajoGraduacions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Busqueda", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("media-object"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/book.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Libro"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("48"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("48"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
  
    ViewData["Title"] = "Busqueda";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"es\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb8c564537ac1b357ba946fd98862213a04fe3e8665", async() => {
                WriteLiteral("\r\n    <title>Buscar libro</title>\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb8c564537ac1b357ba946fd98862213a04fe3e9666", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""page-header"">
            <h1 class=""all-tittles"">Sistema bibliotecario <small>Catálogo Trabajos de Graduacion</small></h1>
        </div>
    </div>
    <div class=""container-fluid"" style=""margin: 40px 0;"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-4 col-md-3"">
                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5cb8c564537ac1b357ba946fd98862213a04fe3e10297", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
                Bienvenido al catálogo,  si deseas buscar un Trabajo de Graduacion/TESIS por nombre o título has click en el icono &nbsp; <i class=""zmdi zmdi-search""></i> &nbsp; que se encuentra en la barra superior
            </div>
        </div>
    </div>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cb8c564537ac1b357ba946fd98862213a04fe3e12013", async() => {
                    WriteLiteral("\r\n        <div class=\"input-group right\">\r\n            <span class=\"input-group-addon\"></span>\r\n            <input type=\"search\" placeholder=\"Ingrese palabras claves\" class=\"form-control\"");
                    BeginWriteAttribute("value", " value=\"", 1356, "\"", 1395, 1);
#nullable restore
#line 33 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
WriteAttributeValue("", 1364, ViewData["Getemployeedetails"], 1364, 31, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"bookName\" />\r\n        </div>\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <div id=\"modal-placeholder\"></div>\r\n    <div class=\"container-fluid\">\r\n        <br>\r\n        <h3 class=\"text-center all-tittles\">Resultados de la búsqueda</h3>\r\n");
#nullable restore
#line 41 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
          int contador = 1; 

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 43 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
         if (Model.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                <div class=""media media-hover"">
                    <div class=""media-left media-middle"">
                        <a href=""#!"" class=""tooltips-general"" data-toggle=""tooltip"" data-placement=""right"" title=""Más información del libro"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5cb8c564537ac1b357ba946fd98862213a04fe3e15735", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </a>
                    </div>
                    <div class=""media-body"">
                        <h4 class=""media-heading"">
                            <a href=""#"" data-toggle=""ajax-model"" data-target=""#detail-trabajo"" data-url=""");
#nullable restore
#line 55 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                                                    Write(Url.Action($"DetailsTrabajo/{item.CodRegistro}","TrabajoGraduacions"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\"><strong>");
#nullable restore
#line 55 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                                                                                                                                    Write(contador);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong> ");
#nullable restore
#line 55 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                                                                                                                                                       Write(Html.DisplayFor(modelItem => item.Titulo));

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                        </h4>\r\n                        <div class=\"pull-left\">\r\n                            ");
#nullable restore
#line 58 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NombreAutor));

#line default
#line hidden
#nullable disable
                WriteLiteral("  ");
#nullable restore
#line 58 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                        Write(Html.DisplayFor(modelItem => item.ApellidoAutor));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br>\r\n                            ");
#nullable restore
#line 59 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NombreInstitucion));

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 59 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                               Write(Html.DisplayFor(modelItem => item.CodCarreraNavigation.Carrera1));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br>\r\n                            ");
#nullable restore
#line 60 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CodTipotrabajoNavigation.Tipo));

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 60 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                                           Write(Html.DisplayFor(modelItem => item.CodCatNavigation.Categoria));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br />\r\n                        </div>\r\n                        <p class=\"text-center pull-right\">\r\n                            <a href=\"#!\" data-toggle=\"ajax-model\" data-target=\"#detail-trabajo\" data-url=\"");
#nullable restore
#line 63 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                                                     Write(Url.Action($"DetailsTrabajo/{item.CodRegistro}","TrabajoGraduacions"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\" class=\"btn btn-info btn-xs\" style=\"margin-right: 10px;\"><i class=\"zmdi zmdi-info-outline\"></i> &nbsp;&nbsp; Más información</a>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 67 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"



                contador = contador + 1;

#line default
#line hidden
#nullable disable
                WriteLiteral("                <!--\r\n                    <a asp-action=\"Edit\" asp-route-id=\"");
#nullable restore
#line 72 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                  Write(item.CodRegistro);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Edit</a> |\r\n                    <a asp-action=\"Details\" asp-route-id=\"");
#nullable restore
#line 73 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                     Write(item.CodRegistro);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Details</a> |\r\n                    <a asp-action=\"Delete\" asp-route-id=\"");
#nullable restore
#line 74 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                    Write(item.CodRegistro);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">Delete</a>\r\n                -->\r\n");
#nullable restore
#line 76 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"

            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h2 class=\"text-center\"><i class=\"zmdi zmdi-mood-bad zmdi-hc-5x\"></i><br><br>Lo sentimos, no hemos encontrado ningún Trabajo de Graduacion/TESIS con el nombre <strong>");
#nullable restore
#line 81 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                                                                                                                              Write(ViewData["Busqueda1"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </strong> en el sistema</h2>\r\n");
#nullable restore
#line 82 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 86 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
         if (ViewBag.Titulo != null || ViewBag.Titulo != "" || ViewBag.NombreAutor != null || ViewBag.NombreAutor != "" || ViewBag.NombreInstitucion != null || ViewBag.NombreInstitucion != "" || ViewBag.Empresa != null || ViewBag.Empresa != "")
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
       Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("Index", new { pagina = page, titulo = @ViewBag.Titulo, autor = @ViewBag.NombreAutor, institucion = @ViewBag.NombreInstitucion, Empsearch = @ViewBag.Empresa })));

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                                                                                                                                                                                       
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
       Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("Index", new { pagina = page })));

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\Emanuel\source\repos\BibliotecaCUNOR\BibliotecaCUNOR\Views\TrabajoGraduacions\Busqueda.cshtml"
                                                                                                       
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </div>\r\n\r\n");
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
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BibliotecaCUNOR.Models.TrabajoGraduacion>> Html { get; private set; }
    }
}
#pragma warning restore 1591

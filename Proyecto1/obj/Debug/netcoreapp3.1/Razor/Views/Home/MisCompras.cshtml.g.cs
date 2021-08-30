#pragma checksum "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "560010098deb65bece8f45f47a844c0bd69ee158"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_MisCompras), @"mvc.1.0.view", @"/Views/Home/MisCompras.cshtml")]
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
#line 1 "C:\proyectos\proyecto1\Views\_ViewImports.cshtml"
using Proyecto1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\proyectos\proyecto1\Views\_ViewImports.cshtml"
using Proyecto1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"560010098deb65bece8f45f47a844c0bd69ee158", @"/Views/Home/MisCompras.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d24d21b32d764fc8d98ee73773e047b752d0866", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_MisCompras : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<VPNET.Data.Model.Productos>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-3.6.0.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
  
    ViewData["Title"] = "Carrito";
    Layout = "~/Views/Shared/_Layout.cshtml";
    int user = int.Parse(Context.Session.GetString("UserID"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table table-success table-striped"">
    <thead>
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Nombre</th>
            <th scope=""col"">Precio</th>
            <th scope=""col"">Cantidad</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
         foreach (var i in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\"><img");
            BeginWriteAttribute("src", " src=\"", 613, "\"", 651, 2);
            WriteAttributeValue("", 619, "data:image/png;base64,", 619, 22, true);
#nullable restore
#line 22 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
WriteAttributeValue(" ", 641, i.Imagen, 642, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rounded float-start\" alt=\"...\" style=\"height:70px;width:70px\"></th>\r\n                <td style=\"padding-top:40px; font-weight:bolder\"><a");
            BeginWriteAttribute("href", " href=\"", 796, "\"", 864, 1);
#nullable restore
#line 23 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
WriteAttributeValue("", 803, Url.Action("ProductoDetalle", "Home", new { idProc = user }), 803, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
                                                                                                                                    Write(i.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                <td style=\"padding-top:40px; font-weight:bolder\">$");
#nullable restore
#line 24 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
                                                             Write(decimal.Round(i.Precio, 2).ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td style=\"padding-top:40px; font-weight:bolder;padding-left:3rem\">");
#nullable restore
#line 25 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
                                                                              Write(i.Stock.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 27 "C:\proyectos\proyecto1\Views\Home\MisCompras.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "560010098deb65bece8f45f47a844c0bd69ee1586980", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "560010098deb65bece8f45f47a844c0bd69ee1588019", async() => {
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
            WriteLiteral("\r\n<script src=\"https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.all.min.js\"></script>\r\n<script src=\"https://unpkg.com/sweetalert/dist/sweetalert.min.js\"></script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<VPNET.Data.Model.Productos>> Html { get; private set; }
    }
}
#pragma warning restore 1591

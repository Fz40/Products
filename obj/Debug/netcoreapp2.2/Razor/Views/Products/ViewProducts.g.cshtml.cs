#pragma checksum "d:\Test_C\MVC\Views\Products\ViewProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2e21a77113f30f10bed81f3fef71b5ce439a824"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_ViewProducts), @"mvc.1.0.view", @"/Views/Products/ViewProducts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/ViewProducts.cshtml", typeof(AspNetCore.Views_Products_ViewProducts))]
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
#line 1 "d:\Test_C\MVC\Views\_ViewImports.cshtml"
using MVC;

#line default
#line hidden
#line 2 "d:\Test_C\MVC\Views\_ViewImports.cshtml"
using MVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2e21a77113f30f10bed81f3fef71b5ce439a824", @"/Views/Products/ViewProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d7a8f56340c239c091cff637a00cc2fdf252300", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_ViewProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Products>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(17, 10, true);
            WriteLiteral("\r\n<p>ID = ");
            EndContext();
            BeginContext(28, 15, false);
#line 3 "d:\Test_C\MVC\Views\Products\ViewProducts.cshtml"
   Write(Model.ProductID);

#line default
#line hidden
            EndContext();
            BeginContext(43, 16, true);
            WriteLiteral("</p>\r\n<p>name = ");
            EndContext();
            BeginContext(60, 17, false);
#line 4 "d:\Test_C\MVC\Views\Products\ViewProducts.cshtml"
     Write(Model.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(77, 21, true);
            WriteLiteral("</p>\r\n<p>UnitPrice = ");
            EndContext();
            BeginContext(99, 15, false);
#line 5 "d:\Test_C\MVC\Views\Products\ViewProducts.cshtml"
          Write(Model.UnitPrice);

#line default
#line hidden
            EndContext();
            BeginContext(114, 27, true);
            WriteLiteral("</p>\r\n<p>QuantityPerUnit = ");
            EndContext();
            BeginContext(142, 21, false);
#line 6 "d:\Test_C\MVC\Views\Products\ViewProducts.cshtml"
                Write(Model.QuantityPerUnit);

#line default
#line hidden
            EndContext();
            BeginContext(163, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Products> Html { get; private set; }
    }
}
#pragma warning restore 1591

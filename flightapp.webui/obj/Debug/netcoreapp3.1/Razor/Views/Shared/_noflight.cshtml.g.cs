#pragma checksum "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Shared\_noflight.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "378dcd85c0f41e055592604e3d368a0f39d53129da60031a02115d0ee0b52bfe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__noflight), @"mvc.1.0.view", @"/Views/Shared/_noflight.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\_ViewImports.cshtml"
using flightapp.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\_ViewImports.cshtml"
using flightapp.webui.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\_ViewImports.cshtml"
using flightapp.webui.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\_ViewImports.cshtml"
using flightapp.webui.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"378dcd85c0f41e055592604e3d368a0f39d53129da60031a02115d0ee0b52bfe", @"/Views/Shared/_noflight.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4cc4f0c2dcfaa75fed97c667f22c787b7e269bb8b1e120828ff1bf9a7e980413", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__noflight : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@" <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""alert alert-danger"">
                                No flight found    
                            </div>
                        </div>
                    </div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

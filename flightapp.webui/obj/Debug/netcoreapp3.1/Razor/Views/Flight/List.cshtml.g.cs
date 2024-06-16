#pragma checksum "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "31ac4d9d83e998373af9f34d089a0866e1216e09dac4afaaaa93ad56b293fec5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Flight_List), @"mvc.1.0.view", @"/Views/Flight/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"31ac4d9d83e998373af9f34d089a0866e1216e09dac4afaaaa93ad56b293fec5", @"/Views/Flight/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4cc4f0c2dcfaa75fed97c667f22c787b7e269bb8b1e120828ff1bf9a7e980413", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Flight_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<flightListViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
  
    var popularClass = Model.Flights.Count>2? "popular":"";
    var flights = Model.Flights;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Categories", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 11 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
 if(flights.Count == 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
Write(await Html.PartialAsync("_noFlight"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
                                         
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">                  \r\n");
#nullable restore
#line 21 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
         foreach (var flight in flights)
        {    

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-4\">\r\n                ");
#nullable restore
#line 24 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
           Write(await Html.PartialAsync("_Flight", flight));

#line default
#line hidden
#nullable disable
            WriteLiteral("   \r\n        </div>       \r\n");
#nullable restore
#line 26 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
        }   

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 28 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Flight\List.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<flightListViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

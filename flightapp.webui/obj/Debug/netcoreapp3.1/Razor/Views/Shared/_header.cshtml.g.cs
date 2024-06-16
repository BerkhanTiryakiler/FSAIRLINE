#pragma checksum "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Shared\_header.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "682df69e35b5adbd0a0410ed147f19207536544a3c0843fbbb7477cee3ba5cf5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__header), @"mvc.1.0.view", @"/Views/Shared/_header.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"682df69e35b5adbd0a0410ed147f19207536544a3c0843fbbb7477cee3ba5cf5", @"/Views/Shared/_header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4cc4f0c2dcfaa75fed97c667f22c787b7e269bb8b1e120828ff1bf9a7e980413", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@" <header>
    <div class=""hero-content text-center"">
        <h1>SkyBlue</h1>
        <p>Experience the best journey with us</p>
        <a href=""/flights"" class=""btn btn-primary btn-lg"">Book Now</a>
    </div>
    </header>


<br>

<div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
    <ol class=""carousel-indicators"">
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
        <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
    </ol>
    <div class=""carousel-inner"">
        <div class=""carousel-item active"">
            <img class=""d-block w-100"" src=""https://visabookings.com/wp-content/uploads/2018/08/business-3268751_1280-1080x675.jpg"" alt=""First slide"">
        </div>
        <div class=""carousel-item"">
            <img class=""d-block w-100"" src=""https://www.aa.com/content/images/plan-travel/extras/hold-your-reservatio");
            WriteLiteral(@"n-banner.jpg"" alt=""Second slide"">
        </div>
        <div class=""carousel-item"">
            <img class=""d-block w-100"" src=""https://content.skyscnr.com/m/18624a05eda5e0a2/original/Summer-Article_Price-Alerts-Image-01_1225x800-__-EN-US.png?resize=1800px:1800px&quality=100"" alt=""Third slide"">
        </div>
    </div>
    <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
</div>

<section class=""featured-destinations py-5 bg-light"">
    <div class=""container"">
        <h2 class=""text-center"">Featured Destinations</h2>
        <div class=""row"">
            <div class=""col-md-4 mb-4"">");
            WriteLiteral(@"
                <div class=""card"">
                    <img src=""https://cdn.mos.cms.futurecdn.net/mqRUPPghetpzNQpcRwKJ4j-1200-80.jpg"" class=""card-img-top"" alt=""Destination 1"">
                    <div class=""card-body"">
                        <h5 class=""card-title"">Paris</h5>
                        <p class=""card-text"">The city of lights.</p>
                    </div>
                </div>
            </div>
            <div class=""col-md-4 mb-4"">
                <div class=""card"">
                    <img src=""https://cdn.mos.cms.futurecdn.net/mqRUPPghetpzNQpcRwKJ4j-1200-80.jpg"" class=""card-img-top"" alt=""Destination 2"">
                    <div class=""card-body"">
                        <h5 class=""card-title"">New York</h5>
                        <p class=""card-text"">The city that never sleeps.</p>
                    </div>
                </div>
            </div>
            <div class=""col-md-4 mb-4"">
                <div class=""card"">
                    <img src=""https://cdn.mo");
            WriteLiteral(@"s.cms.futurecdn.net/mqRUPPghetpzNQpcRwKJ4j-1200-80.jpg"" class=""card-img-top"" alt=""Destination 3"">
                    <div class=""card-body"">
                        <h5 class=""card-title"">Tokyo</h5>
                        <p class=""card-text"">The land of the rising sun.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
");
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

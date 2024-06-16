#pragma checksum "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9f687fb6545aeda7fa9850b1515bb65ac40ce7e18e2b00a018adaade20821c70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CategoryList), @"mvc.1.0.view", @"/Views/Admin/CategoryList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"9f687fb6545aeda7fa9850b1515bb65ac40ce7e18e2b00a018adaade20821c70", @"/Views/Admin/CategoryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4cc4f0c2dcfaa75fed97c667f22c787b7e269bb8b1e120828ff1bf9a7e980413", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_CategoryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategoryListViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/deletecategory"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-md-12"">
        <h1 class=""h3"">Admin Categories</h1>
        <hr>
        <a class=""btn btn-primary btn-sm"" href=""/admin/categories/create"">Add Category</a>
        <table class=""table table-bbooked mt-3"">
            <thead>
                <tr>
                    <td style=""width: 30px;"">Id</td>
                    <td>Name</td>
                    <td style=""width: 150px;""></td>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 17 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
                 if(Model.Categories.Count>0)
                {
                       

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
                        foreach (var item in Model.Categories)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 22 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
                               Write(item.CategoryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 23 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>  \r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 914, "\"", 955, 2);
            WriteAttributeValue("", 921, "/admin/categories/", 921, 18, true);
#nullable restore
#line 25 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
WriteAttributeValue("", 939, item.CategoryId, 939, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm mr-2\">Edit</a>\r\n                                    \r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9f687fb6545aeda7fa9850b1515bb65ac40ce7e18e2b00a018adaade20821c707536", async() => {
                WriteLiteral("\r\n                                        <input type=\"hidden\" name=\"categoryId\"");
                BeginWriteAttribute("value", " value=\"", 1233, "\"", 1257, 1);
#nullable restore
#line 28 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
WriteAttributeValue("", 1241, item.CategoryId, 1241, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        <button type=\"submit\" class=\"btn btn-danger btn-sm\">Delete</button>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>                        </tr>\r\n");
#nullable restore
#line 32 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
                         
                }else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-warning\">\r\n                        <h3>No Categories</h3>\r\n                    </div>\r\n");
#nullable restore
#line 37 "C:\Users\berkh\Pictures\FlightApp\flightapp.webui\Views\Admin\CategoryList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n             \r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategoryListViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b80d58ce8d023a1c6342295085b71d6044b6fe0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Details), @"mvc.1.0.view", @"/Views/User/Details.cshtml")]
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
#line 1 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\_ViewImports.cshtml"
using onlineShopSolution.AdminApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\_ViewImports.cshtml"
using onlineShopSolution.AdminApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b80d58ce8d023a1c6342295085b71d6044b6fe0", @"/Views/User/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae5da72b613bc3d466e37d63efbe58e46967b9d5", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<onlineShopSolution.ViewModel.System.Users.UserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        <!-- .content-wrapper -->
        <div class=""content-wrapper"">
            <!-- Content Header (Page header) -->
            <section class=""content-header"">
                <div class=""container-fluid"">
                    <div class=""row mb-2"">
                        <div class=""col-sm-6"">
                            <h1>CreateUser</h1>
                        </div>
                        <div class=""col-sm-6"">
                            <ol class=""breadcrumb float-sm-right"">
                                <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                                <li class=""breadcrumb-item active"">CreateUser</li>
                            </ol>
                        </div>
                    </div>
                </div><!-- /.container-fluid -->
            </section>

            <!-- Main content -->
            <section class=""content"">
                <div class=""container-fluid"">
                    <div class=""row"">
             ");
            WriteLiteral("           <div class=\"col-12\">\r\n\r\n                            <!-- /.card -->\r\n\r\n                            <div class=\"card\">\r\n                                <div class=\"card-header\">\r\n");
            WriteLiteral("                                    <br />\r\n                                    <p>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b80d58ce8d023a1c6342295085b71d6044b6fe06313", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </p>
                                </div>
                                <!-- /.card-header -->
                                <div class=""card-body"">
                                    <div class=""col-md-8"">
                                        <dl class=""row"">
                                            <dt class=""col-sm-2"">
                                                ");
#nullable restore
#line 49 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dt>\r\n                                            <dd class=\"col-sm-10\">\r\n                                                ");
#nullable restore
#line 52 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dd>\r\n                                            <dt class=\"col-sm-2\">\r\n                                                ");
#nullable restore
#line 55 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dt>\r\n                                            <dd class=\"col-sm-10\">\r\n                                                ");
#nullable restore
#line 58 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dd>\r\n                                            <dt class=\"col-sm-2\">\r\n                                                ");
#nullable restore
#line 61 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dt>\r\n                                            <dd class=\"col-sm-10\">\r\n                                                ");
#nullable restore
#line 64 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dd>\r\n                                            <dt class=\"col-sm-2\">\r\n                                                ");
#nullable restore
#line 67 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dt>\r\n                                            <dd class=\"col-sm-10\">\r\n                                                ");
#nullable restore
#line 70 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dd>\r\n                                            <dt class=\"col-sm-2\">\r\n                                                ");
#nullable restore
#line 73 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dt>\r\n                                            <dd class=\"col-sm-10\">\r\n                                                ");
#nullable restore
#line 76 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dd>\r\n                                            <dt class=\"col-sm-2\">\r\n                                                ");
#nullable restore
#line 79 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dt>\r\n                                            <dd class=\"col-sm-10\">\r\n                                                ");
#nullable restore
#line 82 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dd>\r\n                                            <dt class=\"col-sm-2\">\r\n                                                ");
#nullable restore
#line 85 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayNameFor(model => model.DOB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dt>\r\n                                            <dd class=\"col-sm-10\">\r\n                                                ");
#nullable restore
#line 88 "C:\Users\user\Desktop\DATN\Code\eShop\OnlineShopSolution\onlineShopSolution.AdminApp\Views\User\Details.cshtml"
                                           Write(Html.DisplayFor(model => model.DOB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </dd>\r\n                                        </dl>\r\n\r\n\r\n                                        <div>\r\n");
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b80d58ce8d023a1c6342295085b71d6044b6fe014957", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                                        </div>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <!-- /.card -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                    </div>
                <!-- /.container-fluid -->
            </section>
            <!-- /.content -->

        </div>
        <!-- /.content-wrapper -->


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<onlineShopSolution.ViewModel.System.Users.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b71b993e4fea118496bce43054236cdf6585a31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Test__Question), @"mvc.1.0.view", @"/Views/Test/_Question.cshtml")]
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
#line 1 "E:\source\repos\SchoolApplication\SchoolApplication\Views\_ViewImports.cshtml"
using SchoolApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\source\repos\SchoolApplication\SchoolApplication\Views\_ViewImports.cshtml"
using SchoolApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\source\repos\SchoolApplication\SchoolApplication\Views\_ViewImports.cshtml"
using SchoolApplication.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b71b993e4fea118496bce43054236cdf6585a31", @"/Views/Test/_Question.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10137d2691f0d36aac1c96a3e2d9c1c1f8d35e5a", @"/Views/_ViewImports.cshtml")]
    public class Views_Test__Question : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuestionVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<p class=\"text-center\" id=\"questionText\">");
#nullable restore
#line 2 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
                                    Write(Model.Question.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<div id=\"answers\" class=\"form-check\">\r\n");
#nullable restore
#line 4 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
     foreach (Answer answer in Model.Question.Answers)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input");
            BeginWriteAttribute("id", " id=\"", 202, "\"", 217, 1);
#nullable restore
#line 6 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
WriteAttributeValue("", 207, answer.Id, 207, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-check-input\" type=\"radio\"");
            BeginWriteAttribute("value", " value=\"", 256, "\"", 274, 1);
#nullable restore
#line 6 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
WriteAttributeValue("", 264, answer.Id, 264, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <label class=\"form-check-label\"");
            BeginWriteAttribute("for", " for=\"", 319, "\"", 335, 1);
#nullable restore
#line 7 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
WriteAttributeValue("", 325, answer.Id, 325, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 7 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
                                                    Write(answer.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        <br />\r\n");
#nullable restore
#line 9 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div>\r\n");
#nullable restore
#line 12 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
     if (Model.IsLast)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input id=\"resultButton\" type=\"button\" class=\"btn btn-dark\" value=\"Закончить тест\"/>\r\n");
#nullable restore
#line 15 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input id=\"nextQuestionButton\" type=\"button\" class=\"btn btn-dark\" value=\"Ответить\"/>\r\n");
#nullable restore
#line 19 "E:\source\repos\SchoolApplication\SchoolApplication\Views\Test\_Question.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuestionVM> Html { get; private set; }
    }
}
#pragma warning restore 1591

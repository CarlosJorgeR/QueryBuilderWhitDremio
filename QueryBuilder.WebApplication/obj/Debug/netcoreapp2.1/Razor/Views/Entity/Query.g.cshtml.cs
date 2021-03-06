#pragma checksum "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99910cf1d1f7e4fb6b8d46100d7b8c28246cc387"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Entity_Query), @"mvc.1.0.view", @"/Views/Entity/Query.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Entity/Query.cshtml", typeof(AspNetCore.Views_Entity_Query))]
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
#line 1 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\_ViewImports.cshtml"
using QueryBuilder.WebApplication;

#line default
#line hidden
#line 2 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\_ViewImports.cshtml"
using QueryBuilder.WebApplication.Models;

#line default
#line hidden
#line 1 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
using QueryBuilder.Client.Models.Interfaces;

#line default
#line hidden
#line 2 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
using QueryBuilder.WebApplication.Models.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99910cf1d1f7e4fb6b8d46100d7b8c28246cc387", @"/Views/Entity/Query.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66f5d893b184cb36f9c549d3cc1490892f60305b", @"/Views/_ViewImports.cshtml")]
    public class Views_Entity_Query : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ViewQuery>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
  
    ViewData["Title"] = "Query";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(206, 25, true);
            WriteLiteral("\r\n<h2>Query</h2>\r\n<div>\r\n");
            EndContext();
#line 11 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
     using (Html.BeginForm("Query", "Entity"))
    {
        

#line default
#line hidden
            BeginContext(295, 37, false);
#line 13 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
   Write(Html.HiddenFor(model => model.action));

#line default
#line hidden
            EndContext();
            BeginContext(334, 46, true);
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(381, 34, false);
#line 15 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
       Write(Html.LabelFor(model => model.path));

#line default
#line hidden
            EndContext();
            BeginContext(415, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(430, 69, false);
#line 16 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
       Write(Html.TextBoxFor(model => model.path, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(499, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(514, 46, false);
#line 17 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
       Write(Html.ValidationMessageFor(model => model.path));

#line default
#line hidden
            EndContext();
            BeginContext(560, 64, true);
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(625, 35, false);
#line 20 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
       Write(Html.LabelFor(model => model.query));

#line default
#line hidden
            EndContext();
            BeginContext(660, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(675, 84, false);
#line 21 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
       Write(Html.TextBoxFor(model => model.query, new { @class = "form-control", id = "query" }));

#line default
#line hidden
            EndContext();
            BeginContext(759, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(774, 47, false);
#line 22 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
       Write(Html.ValidationMessageFor(model => model.query));

#line default
#line hidden
            EndContext();
            BeginContext(821, 102, true);
            WriteLiteral("\r\n        </div>\r\n        <button type=\"submit\" class=\"btn btn-primary\">Crear tabla virtual</button>\r\n");
            EndContext();
#line 25 "D:\Doc\software\codigo\QueryBuilder\QueryBuilder.WebApplication\Views\Entity\Query.cshtml"
    }

#line default
#line hidden
            BeginContext(930, 157, true);
            WriteLiteral("    <button id=\"preview\" class=\"btn btn-primary\">Resultado</button>\r\n    <table id=\"example\"></table>\r\n    <div id=\"error_table\" role=\"grid\"></div>\r\n</div>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1106, 2980, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#example').append('<thead><tr><th></th></tr></thead><tbody></tbody>');
            var table= $('#example').DataTable({
                                destroy: true
            });
            console.log(table);
            $(""#preview"").on(""click"", function () {
               
                var query = $(""#query"").val();
                console.log(query)
                $.ajax({
                    url: ""/api/query/""+ query,
                    contentType: ""application/json; charset=utf-8"",
                    method: ""GET"",
                    data: """",
                    dataType:""json"",
                    success: function (response) {
                       
                        var html = '';
                        console.log(response);
                        
                        if (response.queryState.isCorrect) {
                            console.log('todo correcto');
                   ");
                WriteLiteral(@"         console.log(response);
                            var queryR = response.queryResult;
                            html += '<thead><tr>';
                            $.each(queryR.fields, function (_, v) {
                                html += '<th>' + v.name + '</th>';
                            });
                            html += '</tr></thead>';
                            html += '<tbody>';
                            $.each(queryR.rows, function (_, r) {
                                html += '<tr>';
                                $.each(r.values, function (_, v) {
                                    html += '<th>' + v + '</th>';
                                });
                                html += '</tr>';
                            });
                            html += '</tbody>';
                            table.destroy();
                            $('#example').empty();
                            $('#example').html(html);
                            ta");
                WriteLiteral(@"ble= $('#example').DataTable({
                                destroy: true
                            });
                            console.log(html);
                        }
                        else {
              
                            table.destroy();
                            $('#example').empty();
                            $('#example').html('<thead><tr><th></th></tr></thead><tbody></tbody>');
                            table=$('#example').DataTable({
                                    destroy: true,
                                }
                            );
                            $('#example tbody').append(""<tr class=\""odd\""><td colspan=\""1\"" class=\""dataTables_empty\"" valign=\""top\"">Fallo en parsear la cosulta</td></tr>"");
                        }
                    }
                })
                
            });
        }).change();
    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ViewQuery> Html { get; private set; }
    }
}
#pragma warning restore 1591

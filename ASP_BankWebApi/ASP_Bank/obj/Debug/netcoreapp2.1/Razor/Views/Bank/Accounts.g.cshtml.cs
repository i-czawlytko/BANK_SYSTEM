#pragma checksum "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f62d145d46830233b5ab241d0a8aea445d1989c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bank_Accounts), @"mvc.1.0.view", @"/Views/Bank/Accounts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bank/Accounts.cshtml", typeof(AspNetCore.Views_Bank_Accounts))]
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
#line 1 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
using ASP_Bank.Entitys;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f62d145d46830233b5ab241d0a8aea445d1989c", @"/Views/Bank/Accounts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Bank_Accounts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(60, 13, true);
            WriteLiteral("\r\n    <div>\r\n");
            EndContext();
            BeginContext(255, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 16 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
         if (ViewBag.AccountType == "giro")
        {

#line default
#line hidden
            BeginContext(313, 310, true);
            WriteLiteral(@"            <p>Список счетов до востребования клиента:</p>
            <table>

                <tr>
                    <th style=""width: 50px;"">ID</th>
                    <th style=""width: 200px;"">Сумма</th>
                    <th style=""width: 200px;"">Дата открытия</th>
                </tr>


");
            EndContext();
#line 28 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                 foreach (Giros acc in ViewBag.Giros)
                {

#line default
#line hidden
            BeginContext(697, 23, true);
            WriteLiteral("                    <tr");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 720, "\"", 806, 5);
            WriteAttributeValue("", 730, "location.href=\'/Handle/giro?client_type=", 730, 40, true);
#line 30 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 770, ViewBag.client_type, 770, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 790, "&acc_id=", 790, 8, true);
#line 30 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 798, acc.id, 798, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 805, "\'", 805, 1, true);
            EndWriteAttribute();
            BeginContext(807, 31, true);
            WriteLiteral(">\r\n                        <td>");
            EndContext();
            BeginContext(839, 6, false);
#line 31 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.id);

#line default
#line hidden
            EndContext();
            BeginContext(845, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(881, 10, false);
#line 32 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.amount);

#line default
#line hidden
            EndContext();
            BeginContext(891, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(927, 38, false);
#line 33 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.create_date.ToString("dd.MM.yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(965, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 35 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                }

#line default
#line hidden
            BeginContext(1018, 22, true);
            WriteLiteral("            </table>\r\n");
            EndContext();
#line 37 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
        }
        else if (ViewBag.AccountType == "deposit")
        {

#line default
#line hidden
            BeginContext(1114, 419, true);
            WriteLiteral(@"            <p>Список счетов-депозитов клиента:</p>
            <table>

                <tr>
                    <th style=""width: 50px;"">ID</th>
                    <th style=""width: 200px;"">Сумма</th>
                    <th style=""width: 50px;"">Проценты</th>
                    <th style=""width: 50px;"">Кап.</th>
                    <th style=""width: 200px;"">Дата открытия</th>
                </tr>


");
            EndContext();
#line 52 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                 foreach (Deposit acc in ViewBag.Deposits)
                {

#line default
#line hidden
            BeginContext(1612, 23, true);
            WriteLiteral("                    <tr");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1635, "\"", 1724, 5);
            WriteAttributeValue("", 1645, "location.href=\'/Handle/deposit?client_type=", 1645, 43, true);
#line 54 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 1688, ViewBag.client_type, 1688, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 1708, "&acc_id=", 1708, 8, true);
#line 54 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 1716, acc.id, 1716, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 1723, "\'", 1723, 1, true);
            EndWriteAttribute();
            BeginContext(1725, 31, true);
            WriteLiteral(">\r\n                        <td>");
            EndContext();
            BeginContext(1757, 6, false);
#line 55 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.id);

#line default
#line hidden
            EndContext();
            BeginContext(1763, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1799, 10, false);
#line 56 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.amount);

#line default
#line hidden
            EndContext();
            BeginContext(1809, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1845, 11, false);
#line 57 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.percent);

#line default
#line hidden
            EndContext();
            BeginContext(1856, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1892, 18, false);
#line 58 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(BooltoStr(acc.cap));

#line default
#line hidden
            EndContext();
            BeginContext(1910, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1946, 38, false);
#line 59 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.create_date.ToString("dd.MM.yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1984, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 61 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                }

#line default
#line hidden
            BeginContext(2037, 24, true);
            WriteLiteral("\r\n            </table>\r\n");
            EndContext();
#line 64 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
        }

        else if (ViewBag.AccountType == "credit")
        {

#line default
#line hidden
            BeginContext(2136, 355, true);
            WriteLiteral(@"            <p>Список кредитов клиента:</p>
            <table>

                <tr>
                    <th style=""width: 50px;"">ID</th>
                    <th style=""width: 200px;"">Сумма</th>
                    <th style=""width: 50px;"">Проценты</th>
                    <th style=""width: 200px;"">Дата открытия</th>
                </tr>


");
            EndContext();
#line 79 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                 foreach (Credits acc in ViewBag.Credits)
                {

#line default
#line hidden
            BeginContext(2569, 23, true);
            WriteLiteral("                    <tr");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2592, "\"", 2680, 5);
            WriteAttributeValue("", 2602, "location.href=\'/Handle/credit?client_type=", 2602, 42, true);
#line 81 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 2644, ViewBag.client_type, 2644, 20, false);

#line default
#line hidden
            WriteAttributeValue("", 2664, "&acc_id=", 2664, 8, true);
#line 81 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 2672, acc.id, 2672, 7, false);

#line default
#line hidden
            WriteAttributeValue("", 2679, "\'", 2679, 1, true);
            EndWriteAttribute();
            BeginContext(2681, 31, true);
            WriteLiteral(">\r\n                        <td>");
            EndContext();
            BeginContext(2713, 6, false);
#line 82 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.id);

#line default
#line hidden
            EndContext();
            BeginContext(2719, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2755, 10, false);
#line 83 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.amount);

#line default
#line hidden
            EndContext();
            BeginContext(2765, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2801, 11, false);
#line 84 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.percent);

#line default
#line hidden
            EndContext();
            BeginContext(2812, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2848, 38, false);
#line 85 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                       Write(acc.create_date.ToString("dd.MM.yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(2886, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 87 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                }

#line default
#line hidden
            BeginContext(2939, 24, true);
            WriteLiteral("\r\n            </table>\r\n");
            EndContext();
#line 90 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(2999, 23, true);
            WriteLiteral("            <p>Клиент: ");
            EndContext();
            BeginContext(3023, 18, false);
#line 93 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                  Write(ViewBag.ClientName);

#line default
#line hidden
            EndContext();
            BeginContext(3041, 55, true);
            WriteLiteral(". Пожалуйста, выберите тип счетов для отображения</p>\r\n");
            EndContext();
#line 94 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
        }

#line default
#line hidden
            BeginContext(3107, 20, true);
            WriteLiteral("\r\n\r\n    </div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("Menu", async() => {
                BeginContext(3142, 32, true);
                WriteLiteral("\r\n    <div class=\"acc_button\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3174, "\"", 3271, 5);
                WriteAttributeValue("", 3181, "/Bank/Accounts?client_type=", 3181, 27, true);
#line 101 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3208, ViewBag.client_type, 3208, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 3228, "&cl_id=", 3228, 7, true);
#line 101 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3235, ViewBag.client_id, 3235, 18, false);

#line default
#line hidden
                WriteAttributeValue("", 3253, "&account_type=giro", 3253, 18, true);
                EndWriteAttribute();
                BeginContext(3272, 59, true);
                WriteLiteral(">До востребования</a></div>\r\n    <div class=\"acc_button\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3331, "\"", 3431, 5);
                WriteAttributeValue("", 3338, "/Bank/Accounts?client_type=", 3338, 27, true);
#line 102 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3365, ViewBag.client_type, 3365, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 3385, "&cl_id=", 3385, 7, true);
#line 102 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3392, ViewBag.client_id, 3392, 18, false);

#line default
#line hidden
                WriteAttributeValue("", 3410, "&account_type=deposit", 3410, 21, true);
                EndWriteAttribute();
                BeginContext(3432, 52, true);
                WriteLiteral(" >Депозиты</a></div>\r\n    <div class=\"acc_button\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3484, "\"", 3583, 5);
                WriteAttributeValue("", 3491, "/Bank/Accounts?client_type=", 3491, 27, true);
#line 103 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3518, ViewBag.client_type, 3518, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 3538, "&cl_id=", 3538, 7, true);
#line 103 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3545, ViewBag.client_id, 3545, 18, false);

#line default
#line hidden
                WriteAttributeValue("", 3563, "&account_type=credit", 3563, 20, true);
                EndWriteAttribute();
                BeginContext(3584, 22, true);
                WriteLiteral(">Кредиты</a></div>\r\n\r\n");
                EndContext();
#line 105 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
     if (ViewBag.AccountType == "giro")
    {

#line default
#line hidden
                BeginContext(3654, 34, true);
                WriteLiteral("        <div class=\"add_button\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3688, "\"", 3795, 4);
                WriteAttributeValue("", 3695, "/Add/GetAccFromViewField?acc_type=giro&client_type=", 3695, 51, true);
#line 107 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3746, ViewBag.client_type, 3746, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 3766, "&client_id=", 3766, 11, true);
#line 107 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3777, ViewBag.client_id, 3777, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3796, 26, true);
                WriteLiteral(">Добавить счёт</a></div>\r\n");
                EndContext();
#line 108 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
    }
    else if (ViewBag.AccountType == "deposit")
    {

#line default
#line hidden
                BeginContext(3884, 34, true);
                WriteLiteral("        <div class=\"add_button\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 3918, "\"", 3999, 4);
                WriteAttributeValue("", 3925, "/Add/deposit?client_type=", 3925, 25, true);
#line 111 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3950, ViewBag.client_type, 3950, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 3970, "&client_id=", 3970, 11, true);
#line 111 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 3981, ViewBag.client_id, 3981, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4000, 29, true);
                WriteLiteral(">Добавить депозит</a></div>\r\n");
                EndContext();
#line 112 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
    }
    else if (ViewBag.AccountType == "credit")
    {

#line default
#line hidden
                BeginContext(4090, 34, true);
                WriteLiteral("        <div class=\"add_button\"><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 4124, "\"", 4204, 4);
                WriteAttributeValue("", 4131, "/Add/credit?client_type=", 4131, 24, true);
#line 115 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 4155, ViewBag.client_type, 4155, 20, false);

#line default
#line hidden
                WriteAttributeValue("", 4175, "&client_id=", 4175, 11, true);
#line 115 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
WriteAttributeValue("", 4186, ViewBag.client_id, 4186, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4205, 28, true);
                WriteLiteral(">Добавить кредит</a></div>\r\n");
                EndContext();
#line 116 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
    }
    else
    {

    }

#line default
#line hidden
            }
            );
        }
        #pragma warning restore 1998
#line 8 "C:\Users\sbokubant\source\repos\ASP_BankWebApi\ASP_Bank\Views\Bank\Accounts.cshtml"
                    
            string BooltoStr(bool value)
            {
                if (value) return "Да";
                else return "Нет";
            }
        

#line default
#line hidden
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

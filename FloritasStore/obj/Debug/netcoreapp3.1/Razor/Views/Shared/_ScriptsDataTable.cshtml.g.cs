#pragma checksum "D:\Projetos\fork\floritasstore\FloritasStore\Views\Shared\_ScriptsDataTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "556ed27403e0fa1837c9448be1d78ce1afcf46a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ScriptsDataTable), @"mvc.1.0.view", @"/Views/Shared/_ScriptsDataTable.cshtml")]
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
#line 1 "D:\Projetos\fork\floritasstore\FloritasStore\Views\_ViewImports.cshtml"
using FloritasStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projetos\fork\floritasstore\FloritasStore\Views\_ViewImports.cshtml"
using FloritasStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"556ed27403e0fa1837c9448be1d78ce1afcf46a0", @"/Views/Shared/_ScriptsDataTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c5aa2f3601350a299b638393722597f48a28f66", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ScriptsDataTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- DataTables -->
<script src=""/adminlte/plugins/datatables/jquery.dataTables.min.js""></script>
<script src=""/adminlte/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js""></script>
<script src=""/adminlte/plugins/datatables-responsive/js/dataTables.responsive.min.js""></script>
<script src=""/adminlte/plugins/datatables-responsive/js/responsive.bootstrap4.min.js""></script>

<script>
    $(function () {
        const tablePage = $('[wm-table]');
        tablePage.DataTable({
            ""paging"": true,
            ""lengthChange"": false,
            ""searching"": false,
            ""ordering"": true,
            ""info"": true,
            ""autoWidth"": false,
            ""responsive"": true,
            'aoColumnDefs': [
                {
                    'bSortable': false,
                    'aTargets': [-1],
                    'searchable': false,
                },
                {
                    ""width"": ""10%"",
                    ""targets"": (tablePage.find(""tr:first th"").");
            WriteLiteral(@"length - 1)
                }
            ],
            ""language"": tableOptions

        });
    });

    const tableOptions = {
        ""sEmptyTable"": ""Nenhum registro encontrado"",
        ""sInfo"": ""Mostrando de _START_ até _END_ de _TOTAL_ registros"",
        ""sInfoEmpty"": ""Mostrando 0 até 0 de 0 registros"",
        ""sInfoFiltered"": ""(Filtrados de _MAX_ registros)"",
        ""sInfoPostFix"": """",
        ""sInfoThousands"": ""."",
        ""sLengthMenu"": ""_MENU_ resultados por página"",
        ""sLoadingRecords"": ""Carregando..."",
        ""sProcessing"": ""Processando..."",
        ""sZeroRecords"": ""Nenhum registro encontrado"",
        ""sSearch"": ""Pesquisar"",
        ""oPaginate"": {
            ""sNext"": ""Próximo"",
            ""sPrevious"": ""Anterior"",
            ""sFirst"": ""Primeiro"",
            ""sLast"": ""Último""
        },
        ""oAria"": {
            ""sSortAscending"": "": Ordenar colunas de forma ascendente"",
            ""sSortDescending"": "": Ordenar colunas de forma descendente""
        ");
            WriteLiteral("}\r\n    }\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
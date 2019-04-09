$.fn.dataTableExt.sErrMode = 'throw';

var TableData = function () {

    //function to initiate DataTable
    //DataTable is a highly flexible tool, based upon the foundations of progressive enhancement,
    //which will add advanced interaction controls to any HTML table
    //For more information, please visit https://datatables.net/
    var runDataTable = function () {

        var oTable = $('#table-1').dataTable({
            "bInfo" : false
        });
        $('#table-1_wrapper .dataTables_filter input').addClass("form-control input-sm").attr("placeholder", "Search");
        // modify table search input
        //$('#sample_1_wrapper .dataTables_length select').addClass("m-wrap small");
        // modify table per page dropdown
        $('#table-1_wrapper .dataTables_length select').remove();
        $('#table-1_wrapper .dataTables_length label').remove();
        var rows= '<select class="form-control" id="selectKredit">\n' +
                  '</select>';
        $('#table-1_wrapper .dataTables_length').append(rows);

        $('#selectKredit').append("<option value='0'>Select No Kredit</option>");
        
        
  
    };
    return {
        //main function to initiate template pages
        init: function () {
            runDataTable();
        }
    };
}();
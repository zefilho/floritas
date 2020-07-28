// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function ($) {
    
    $.validator.addMethod('data-val-valid-company',
        function (value, element, params) {

            var companyCompare = $(element).attr('data-val-valid-company-field');
            if (companyCompare) {
                var valueCompare = $("#" + companyCompare + " option:selected").text();                
                let testRole = (valueCompare === "Administrador");                
                let testCompany = parseInt(value) !== 0;
                
                if (testRole && testCompany) {                                        
                    return false;
                } else if (!(testRole || testCompany)) {                   
                    return false;
                }
                else {                    
                    return true;
                }
            }

            return false;

        }, function (params, element) {            
            var msgCompare = $(element).attr('data-val-valid-company');
            if (!msgCompare) {                
                msgCompare = "A regra Administrador não deve ter empresa vinculada ou as demais regras devem possuir obrigatoriamente uma empresa.";
            }
            return msgCompare;
        });
    $.validator.unobtrusive.adapters.addBool('data-val-valid-company');
})(jQuery);
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    let errorClass = $("form[role]").data("validator").settings.errorClass;
    $("form[role]").data("validator").settings.errorClass = "is-invalid " + errorClass;
    $("form[role]").data("validator").settings.validClass = "is-valid";
    console.log($("form[role]").data("validator").settings);

    $('[wm-select]').addClass("icon-disable");

});
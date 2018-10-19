// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    //set initial state.
    $('#OneWay').val(this.checked);

    $('#OneWay').change(function () {
        if (this.checked) {
            $('#ReturnDate').prop("disabled", false);
            $(this).prop("checked", returnVal);
        }
        else {
            $('#ReturnDate').prop("disabled", true);
        }
        $('#OneWay').val(this.checked);
    });

    //$(function () {
    //    $("#OutboundDate").datepicker();
    //});
});
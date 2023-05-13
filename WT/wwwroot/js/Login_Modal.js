$(document).ready(function () {
    $('#loginModal').modal('show');
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
});
$(document).ready(function () {
    
    $('.SignUp').onClick(function () {
        $('#loginModal').dialog('hide');
        $('#signupModal').modal('show');
        return false;
    });
    //$('#signupModal').modal('show');
    //$(function () {
    //    $('[data-toggle="tooltip"]').tooltip()
    //})
});
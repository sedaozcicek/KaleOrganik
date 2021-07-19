$(document).ready(function () {
    $('input[data-val-length-max]').each(
        function (index) {
            $(this).attr('maxlength', $(this).attr('data-val-length-max'));
        });
});

$(document).ready(function () {
    $('input[data-val-length-min]').each(
        function (index) {
            $(this).attr('minlength', $(this).attr('data-val-length-min'));
        });
});
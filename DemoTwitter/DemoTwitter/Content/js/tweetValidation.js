$(document).ready(function () {
    $("#post-tweet-input").bind('input', function () {
        $(this).val(function (_, v) {
            return v.replace(/\s+/g, ' ');
        });
    });
});
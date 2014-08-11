$(function () {
    //USED for Feedback ratings
    $(".feedback").on('click', function () {
        $(this).toggleClass('icon-star-empty', 500);
        var score = $("#score").val();
        score++;
        $("#score").val(score);
    });
});
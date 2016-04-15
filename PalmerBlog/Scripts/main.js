$(document).ready(function () {
    "use strict";


    $('.toggle-menu').click(function () {
        $('.responsive-menu').stop(true, true).slideToggle();
        return false;
    });

    function EditComment() {
        $(this).parent().find(".comment-content-edit").toggle();
        $(this).parent().find(".comment-btn-edit").toggle();
        $(this).parent().find(".comment-btn-delete").toggle();
        $(this).parent().find(".comment-btn-cancel").toggle();
        $(this).parent().find(".comment-content").toggle();
    };

    $(".comment-btn-edit").on("click", EditComment);
    $(".comment-btn-cancel").on("click", EditComment);
});








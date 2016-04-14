$(document).ready(function () {

    function EditComment() {
        $(this).parent().find(".comment-content-edit").toggle();
        $(".comment-btn-edit").toggle();
        $(".comment-btn-delete").toggle();
        $(".comment-btn-cancel").toggle();
        $(".comment-content").toggle();
    };

    $(".comment-btn-edit").on("click", EditComment);
    $(".comment-btn-cancel").on("click", EditComment);
});








$(document).ready(function () {

    function EditComment() {
        $(".comment-content-edit").toggle();
        $(".comment-btn-edit").toggle();
        $(".comment-content").toggle();
    };

    $(document).on("click", ".comment-btn-edit", EditComment);
});








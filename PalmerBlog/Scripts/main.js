$(document).ready(function () {

    function EditComment() {
        $(".comment-content-edit").toggle();
        $(".comment-btn-edit").toggle();
        $(".comment-content").toggle();
        console.log("Edit Comment activated.");
    };

    $(document).on("click", ".comment-btn-edit", EditComment);
});








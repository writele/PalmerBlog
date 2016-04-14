$(document).ready(function () {

    function EditComment() {
        $("comment-content-edit").show();
        $(".comment-btn-edit").hide();
        $(".comment-content").hide();
        console.log($(this).parent().find("comment-content-edit"));
    };

    $(".comment-btn-edit").on("click", EditComment);
});








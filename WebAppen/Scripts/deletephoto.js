var deleteform = $('#deletephotoform');

deleteform.on('submit', function (e) {
    e.preventDefault();
    swal({
        title: "Ta bort bild!?",
        text: "Tryck för ta bort bild.",
        type: "warning",
        showCancelButton: true,
        closeOnConfirm: false,
        showLoaderOnConfirm: true
    },
        function () {
            start();
            $.ajax({
                url: "/Photo/Delete",
                type: "post",
                data: deleteform.serialize(),
                success: function (data) {
                    swal("Success", "Bilden är bortagen.", "success");
                    window.location.href = data;

                },
                error: function (e) {
                    swal("Error", "Gick inte ta bort bilden", "error");
                }
            });


        });
});
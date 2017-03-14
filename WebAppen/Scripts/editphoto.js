/// <reference path="sweetalert.min.js" />
$('document').ready(function (e) {
    editform.validate();
});


var editform = $('#editform');

editform.on('submit', function (e) {
    e.preventDefault();
    if (editform.valid()) {

        swal({
            title: "Uppdatera bild!?",
            text: "Tryck för att uppdatera bild.",
            type: "info",
            showCancelButton: true,
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        },
        function (e) {
            var formdata = new FormData(editform[0]);
            start();
            $.ajax({
                url: editform.attr('action'),
                method: "post",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (data) {
                    swal("Success!", "Uppdaterad", "success");
                    window.location = $('#BackToDetails').attr('href');
                },
                error: function (data) {
                    swal("Error!", "Gick inte att uppdatera", "error");
                }
            });

        });

    }
    else {
        swal("varning!", "Fel i fyllt formulär", "warning");

    }
});
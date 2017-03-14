
var form = $('#createform');

form.submit(function (e) {


    e.preventDefault();
    if (form.valid()) {
        swal({
            title: "Ladda upp bild",
            text: "Tryck för att ladda upp",
            type: "info",
            showCancelButton: true,
            closeOnConfirm: false,
            showLoaderOnConfirm: true,
        },
            function () {
                $.ajax({
                    method: "POST",
                    url: "/Photo/Create",

                    data: new FormData(form[0]),
                    success: function (data) {
                       
                        if (data.match("^Added")) {
                            uploadMoreImagesPrompt();
                        }
                        else {
                            swal("inte bra", data, "error")
                        }
                    },
                    error: function (e) {
                        swal("inte bra", "nånting gick fel!", "error")
                    },
                    processData: false,
                    contentType: false
                });
            });

    }
});

var uploadMoreImagesPrompt = function () {

    swal({
        title: "ok?!",
        text: "Ladda upp fler?",
        type: "success",
        showCancelButton: true,
        confirmButtonColor: "#779b79",
        confirmButtonText: "Yes",
        cancelButtonText: "No",
        closeOnConfirm: true,
        closeOnCancel: true
    },
function (isConfirm) {
    if (isConfirm) {
        form[0].reset();
    } else {
        window.location = $('#backbtn').attr('href');
    }
});




};



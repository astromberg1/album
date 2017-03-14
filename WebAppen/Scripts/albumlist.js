/// <reference path="sweetalert.min.js" />
var albumContainer = $("#albumlistcontainer");

$('document').ready(function (e) {

    addEventListeners();

    setInterval(reloadGalleries, 3000);




});

var addEventListeners = function () {
    deleteEvent();
    createEvent();
};

var reloadGalleries = function () {
    start();
    $.ajax({
        type: "GET",
        url: "../../Album/AlbumList",
        success: function (data) {
            $('#albumlistcontainer').html(data);
        }
    });
    SpinnerStop();
};

var deleteEvent = function () {
    albumContainer.on('click', '.albumdeletebtn', function (e) {
        e.preventDefault();
        var model = $(this).attr('albumID');
        //Sweet alert plugin <----
        swal({
            title: "Vill du verkligen ta bort albumet?",
            text: "Alla foton försvinner i det",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Du tog bort det",
            closeOnConfirm: false
        },
            function () {
                $.post("../../Album/delete",
                 { albumID: model },
                 function (data) {
                     swal("Borttaget", data, "success");
                     reloadGalleries();
                 });

            });



    });
};

var createEvent = function () {

    $('#createalbumbtn').click(function (e) {
        e.preventDefault();

        var albumModel = {
            id: "",
            albumName: "",
            DateCreated: "",
            UserID: ""
        };



        swal({
            title: "Nytt Album",
            text: "Input Album Namn",
            type: "input",
            showCancelButton: true,
            closeOnConfirm: false,
            animation: "slide-from-top",
            inputPlaceholder: "Album Namn"
        },
function (inputValue) {
    if (inputValue === false) return false;

    if (inputValue === "" || inputValue.length < 2) {
        swal.showInputError("Minst 2 bokstäver i namnet");

        return false;
    }

    albumModel.albumName = inputValue;
    $.post("../../Album/Create",
                 albumModel,
                 function (data) {
                     reloadGalleries();
                 });


    swal("bra",inputValue +"är skapat", "success");
});


    });

};
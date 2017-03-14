
$('document').ready(function (e) {
    start();
    addEventListeners();

    setInterval(reloadComments, 4000);
});
var commentsContainer = $('#commentcontainer');

var reloadComments = function (e) {
    start();
    //commentsContainer.on('load',);
    $.ajax({
        type: "GET",
        url: "../../Comment/Comments?photoID=" + $('#photoID').val(),
        success: function (data) {
            $('#commentcontainer').html(data);
        }
    });



};



var addEventListeners = function (e) {

    commentsContainer.on('click', '.deletecommentbtn', function (e) {
        e.preventDefault();
        var model = $(this).attr('id');
        //Sweet alert plugin <----
        swal({
            title: "Säker på att ta bort kommentar?",
            text: "Du kan inte få tillbaka den!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "OK ta bort!",
            closeOnConfirm: false
        },
 function () {
     $.post("../../comment/delete",
            { commentID: model },
            function (data) {
                reloadComments();
            });
     swal("Borttagen!", "Din bild är borttagen.", "success");
 });

    });


};

var form = $('#newcommentform');

form.submit(function (e) {
    e.preventDefault();
});


$('#commentsubmitbtn').click(function (e) {
    e.preventDefault();

    if (form.valid()) {

        $.post("../../Comment/NewComment",
           form.serialize(), function (data) {
               swal("Kommentar lagd");
               reloadComments();

           });
        $('#Comment').val('');
        $('#Title').val('');


    }

});


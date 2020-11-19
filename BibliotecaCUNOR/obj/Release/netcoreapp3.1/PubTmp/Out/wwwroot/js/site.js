// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

$(function () {
    var placeholderElement = $("#modal-placeholder");
    $('button[data-toggle="ajax-model"]').click(function (event) {
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    //Chosen
         $('#nombreautor_chosen').on('click', 'button[data-toggle="ajax-model"]', function (event) {
            var url = $(this).data('url');
            var decodedUrl = decodeURIComponent(url);
            $.get(decodedUrl).done(function (data) {
                placeholderElement.html(data);
                placeholderElement.find('.modal').modal('show');
            });
         });
    $('#editorial_chosen').on('click', 'button[data-toggle="ajax-model"]', function (event) {
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });
    $('#edicionLibro_chosen').on('click', 'button[data-toggle="ajax-model"]', function (event) {
        var url = $(this).data('url');
        alert(url);
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });
    $('#idasesor_chosen').on('click', 'button[data-toggle="ajax-model"]', function (event) {
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    $('a[data-toggle="ajax-model"]').click(function (event) {
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });


    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
      
        $.post(actionUrl, sendData).done(function (data) {
        var newBody = $('.modal-body', data);
            placeholderElement.find('modal-body').replaceWith(newBody);

        var isValid = newBody.find('[name="IsValid"]').val() == 'True';
        if (isValid) {
            placeholderElement.find('.modal').modal('hide');
        }
        });
    });

});
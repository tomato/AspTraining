$(function () {
    $('.list-item').on('click', function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
        selectdetails2($(this));

    });
})



function selectdetails($item) {
    var url = $item.data('url');
    $('.list-item').removeClass('selected');
    $item.addClass('selected');

    $.get(url, function (data) {
        $('#detailsDiv').html(data);
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        alert(errorThrown + jqXHR.responseText)
    });
}

function selectdetails2($item) {
    var url = $item.data('url');
    $('.list-item').removeClass('selected');
    $item.addClass('selected');

    $.getJSON(url)
        .done(function (data) {
            $('#detailsDiv #descriptionField').html(data.Description)

            $('#detailsDiv #statusField').html(data.Status.Description)
        })
        .fail(function (jqXHR, textStatus, err) {
            $('.detailsDiv #descriptionField').text('Error: ' + err);
        });
};
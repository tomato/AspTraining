$(function () {
    $('.list-item').on('click', function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
        selectdetails($(this));

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
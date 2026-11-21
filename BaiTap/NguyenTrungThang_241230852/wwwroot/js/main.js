$(function () {
    var $results = $('#hang-hoa-results');
    if (!$results.length) {
        return;
    }

    var request;
    $('.menu a[data-ma-loai]').on('click', function (event) {
        event.preventDefault();
        var $link = $(this);

        if (request) {
            request.abort();
        }

        request = $.get($results.attr('data-url'), { maLoai: $link.attr('data-ma-loai') })
            .done(function (html) {
                $results.html(html);
                $('.menu li.active').removeClass('active');
                $link.closest('li').addClass('active');
            })
            .fail(function (_, status) {
                if (status !== 'abort') {
                    alert('Không tải được danh sách hàng hóa.');
                }
            });
    });
});

$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });

    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });

    var $results = $('#tai-san-results');
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
                    alert('Không tải được danh sách tài sản.');
                }
            });
    });
});

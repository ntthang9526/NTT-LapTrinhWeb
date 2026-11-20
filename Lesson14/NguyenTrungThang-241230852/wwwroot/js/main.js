// BookHub - hiệu ứng giao diện cơ bản (nút "lên đầu trang")
$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });
    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });
    $('.search-box input').on('focus', function () { $(this).select(); });

    $('.menu a[data-ma-tl]').on('click', function (event) {
    event.preventDefault();

    var $results = $('#book-results');
    var maTl = $(this).attr('data-ma-tl');

    $.get($results.attr('data-url'), { maTl: maTl })
        .done(function (html) {
            $results.html(html);
        })
        .fail(function () {
            alert('Không tải được danh sách sách. Bạn thử lại nhé.');
        });
});
});

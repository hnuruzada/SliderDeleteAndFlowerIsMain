$(document).ready(function(){
    $('.pgwSlider').pgwSlider({
        listPosition: 'left',
        autoSlide: false,
    });

    $('.single-item').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        fade: true,
        nextArrow: `<i class="fal fa-arrow-right iconright"></i>`,
        prevArrow: `<i class="fal fa-arrow-left iconleft"></i>`,
    });

    $(window).scroll(function(e) {
        let position = $(this).scrollTop();
        if (position > 200) {
            $('#stickynavbar').css('display', 'flex');
        } else {
            $('#stickynavbar').css('display', 'none');
        }
    });
    $(window).scroll(function () {
        let scrollPx = $(window).scrollTop()
        if (scrollPx > 500) {
            $("#backToTop").fadeIn(450)
            $("#backToTop").css("display", "flex")
        } else {
            $("#backToTop").fadeOut(450)

        }

    })

    $("#backToTop").click(function () {
        $(window).scrollTop(0)
    })

})
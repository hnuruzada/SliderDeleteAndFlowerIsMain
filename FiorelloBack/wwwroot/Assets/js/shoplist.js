$(document).ready(function(){
    $('.owl-carousel').owlCarousel({
        loop:true,
        margin:10,
        nav:true,
        navText: [
            '<i class="fas fa-chevron-left left" aria-hidden="true"></i>',
            '<i class="fas fa-chevron-right right" aria-hidden="true"></i>'
        ],
        dots:false,
        autoplay:true,
        autoplayTimeout:3000,
        responsiveClass:true,
        responsive:{
            0:{
                items:1,
                nav:true
            },
            600:{
                items:3,
                nav:true
            },
            1000:{
                items:5,
                nav:true,
                loop:false
            }
        }
    })



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
    
})
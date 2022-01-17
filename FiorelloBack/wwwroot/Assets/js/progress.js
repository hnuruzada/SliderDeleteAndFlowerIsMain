$(document).ready(function () {
  $({
    countNum: $('.bars .bar1 .firstb p').html()
  }).animate({
    countNum: 95
  }, {
    duration: 3000,
    easing: 'linear',
    step: function () {
      $('.bars .bar1 .firstb p').html(Math.floor(this.countNum) + "%");
      $('.bars .bar1 .firstb .mask .loadingBar').css("width", Math.floor(this.countNum) + "%");
    },
    complete: function () {
      $('.bar1 .firstb p').html(this.countNum + "%");
      $('.bars .bar1 .firstb .mask .loadingBar').css("width", this.countNum + "%");
      
    }
  });

  $({
    countNum: $('.bars .bar2 .secondb p').html()
  }).animate({
    countNum: 80
  }, {
    duration: 3000,
    easing: 'linear',
    step: function () {
      $('.bars .bar2 .secondb p').html(Math.floor(this.countNum) + "%");
      $('.bars .bar2 .secondb .mask .loadingBar').css("width", Math.floor(this.countNum) + "%");
    },
    complete: function () {
      $('.bar2 .secondb p').html(this.countNum + "%");
      $('.bars .bar2 .secondb .mask .loadingBar').css("width", this.countNum + "%");
      
    }
  });
  $({
    countNum: $('.bars .bar3 .thirdb p').html()
  }).animate({
    countNum: 55
  }, {
    duration: 3000,
    easing: 'linear',
    step: function () {
      $('.bars .bar3 .thirdb p').html(Math.floor(this.countNum) + "%");
      $('.bars .bar3 .thirdb .mask .loadingBar').css("width", Math.floor(this.countNum) + "%");
    },
    complete: function () {
      $('.bar3 .thirdb p').html(this.countNum + "%");
      $('.bars .bar3 .thirdb .mask .loadingBar').css("width", this.countNum + "%");
     
    }
  });


})



//footerProgressBar
$(document).ready(function () {

  

  $({
    countNum: $('.barsfooter .barheader .firstb p').html()
  }).animate({
    countNum: 95
  }, {
    duration: 3000,
    easing: 'linear',
    step: function () {
      $('.barsfooter .barheader .firstb p').html(Math.floor(this.countNum) + "%");
      $('.barsfooter .barheader .firstb .mask .loadingBar').css("width", Math.floor(this.countNum) + "%");
    },
    complete: function () {
      $('.barheader .firstb p').html(this.countNum + "%");
      $('.barsfooter .barheader .firstb .mask .loadingBar').css("width", this.countNum + "%");
      
    }
  });

  $({
    countNum: $('.barsfooter .barmain .secondb p').html()
  }).animate({
    countNum: 80
  }, {
    duration: 3000,
    easing: 'linear',
    step: function () {
      $('.barsfooter .barmain .secondb p').html(Math.floor(this.countNum) + "%");
      $('.barsfooter .barmain .secondb .mask .loadingBar').css("width", Math.floor(this.countNum) + "%");
    },
    complete: function () {
      $('.barmain .secondb p').html(this.countNum + "%");
      $('.barsfooter .barmain .secondb .mask .loadingBar').css("width", this.countNum + "%");
      
    }
  });
  $({
    countNum: $('.barsfooter .barfooter .thirdb p').html()
  }).animate({
    countNum: 55
  }, {
    duration: 3000,
    easing: 'linear',
    step: function () {
      $('.barsfooter .barfooter .thirdb p').html(Math.floor(this.countNum) + "%");
      $('.barsfooter .barfooter .thirdb .mask .loadingBar').css("width", Math.floor(this.countNum) + "%");
    },
    complete: function () {
      $('.barfooter .thirdb p').html(this.countNum + "%");
      $('.barsfooter .barfooter .thirdb .mask .loadingBar').css("width", this.countNum + "%");
     
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
  
   $(window).scroll(function (e) {
        let position = $(this).scrollTop();
        if (position > 200) {
            $('#stickynavbar').css('display', 'flex');
        } else {
            $('#stickynavbar').css('display', 'none');
        }
    });
 
  
})
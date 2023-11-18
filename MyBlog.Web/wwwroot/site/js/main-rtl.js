(function ($) {
    "use strict";

    jQuery(document).ready(function ($) {

        /*-----------------------------------------
            global slick slicer control
        ------------------------------------------*/
        var globalSlickInit = $('.global-slick-init');

        if (globalSlickInit.length > 0) {
            //todo have to check slider item 

            $.each(globalSlickInit, function (index, value) {

                if ($(this).children('div').length > 1) {
                    //todo configure slider settings object
                    var sliderSettings = {};
                    var allData = $(this).data();


                    var infinite = typeof allData.infinite == 'undefined' ? false : allData.infinite;
                    var slidesToShow = typeof allData.slidestoshow == 'undefined' ? 1 : allData.slidestoshow;
                    var slidesToScroll = typeof allData.slidestoscroll == 'undefined' ? 1 : allData.slidestoscroll;
                    var speed = typeof allData.speed == 'undefined' ? '500' : allData.speed;
                    var dots = typeof allData.dots == 'undefined' ? false : allData.dots;
                    var cssEase = typeof allData.cssease == 'undefined' ? 'linear' : allData.cssease;

                    var prevArrow = typeof allData.prevarrow == 'undefined' ? '' : allData.prevarrow;
                    var nextArrow = typeof allData.nextarrow == 'undefined' ? '' : allData.nextarrow;
                    var centerMode = typeof allData.centermode == 'undefined' ? false : allData.centermode;
                    var centerPadding = typeof allData.centerpadding == 'undefined' ? false : allData.centerpadding;
                    var rows = typeof allData.rows == 'undefined' ? 1 : parseInt(allData.rows);
                    var autoplaySpeed = typeof allData.autoplayspeed == 'undefined' ? 2000 : parseInt(allData.autoplayspeed);
                    var lazyLoad = typeof allData.lazyload == 'undefined' ? false : allData.lazyload; // have to remove it from settings object if it undefined
                    var appendDots = typeof allData.appenddots == 'undefined' ? false : allData.appenddots;
                    var appendArrows = typeof allData.appendarrows == 'undefined' ? false : allData.appendarrows;
                    var asNavFor = typeof allData.asnavfor == 'undefined' ? false : allData.asnavfor;
                    var fade = typeof allData.fade == 'undefined' ? false : allData.fade;
                    var responsive = typeof $(this).data('responsive') == 'undefined' ? false : $(this).data('responsive');

                    //slider settings object setup
                    sliderSettings.infinite = infinite;
                    sliderSettings.slidesToShow = slidesToShow;
                    sliderSettings.slidesToScroll = slidesToScroll;
                    sliderSettings.speed = speed;
                    sliderSettings.dots = dots;
                    sliderSettings.cssEase = cssEase;
                    sliderSettings.prevArrow = prevArrow;
                    sliderSettings.nextArrow = nextArrow;
                    sliderSettings.rows = rows;
                    sliderSettings.autoplaySpeed = autoplaySpeed;

                    if (typeof centerMode != false) {
                        sliderSettings.centerMode = centerMode;
                    }
                    if (typeof centerPadding != false) {
                        sliderSettings.centerPadding = centerPadding;
                    }
                    if (typeof lazyLoad != false) {
                        sliderSettings.lazyLoad = lazyLoad;
                    }
                    if (typeof appendDots != false) {
                        sliderSettings.appendDots = appendDots;
                    }
                    if (typeof appendArrows != false) {
                        sliderSettings.appendArrows = appendArrows;
                    }

                    if (typeof asNavFor != false) {
                        sliderSettings.asNavFor = asNavFor;
                    }
                    if (typeof fade != false) {
                        sliderSettings.fade = fade;
                    }
                    if (typeof responsive != false) {
                        sliderSettings.responsive = responsive;
                    }
                    console.log(sliderSettings)
                    $(this).slick(sliderSettings);
                }
            });
        }


        /*----------------------------------------
            SearchBar
        ----------------------------------------*/

        $(document).ready(function () {
            $('.search-close').on('click', function () {
                $('.search-bar').removeClass('active');
            });
            $('.search-open').on('click', function () {
                $('.search-bar').toggleClass('active');
            });
        });


        /*------------------------------
            Recent Stories Slick Slider
        -------------------------------*/
        $('.popular-stories-index-01-slider-inst').slick({
            infinite: true,
            slidesToShow: 4,
            slidesToScroll: 1,
            speed: 500,
            arrows: true,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                    breakpoint: 1201,
                    settings: {
                        slidesToShow: 3,
                    }
                },
                {
                    breakpoint: 992,
                    settings: {
                        slidesToShow: 2,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                    }
                }
            ]
        });


        /*------------------------------
            Recent Stories Slick Slider
        -------------------------------*/
        $('.popular-stories-index-02-slider-inst').slick({
            infinite: true,
            slidesToShow: 3,
            slidesToScroll: 1,
            speed: 500,
            arrows: true,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                    breakpoint: 993,
                    settings: {
                        slidesToShow: 2,
                    }
                },
                {
                    breakpoint: 600,
                    settings: {
                        slidesToShow: 1,
                    }
                },
                {
                    breakpoint: 576,
                    settings: {
                        arrows: false,
                        slidesToShow: 1,
                    }
                }
            ]
        });


        /*------------------------------
            weekly highlight Slick Slider
        -------------------------------*/
        $('.weekly-highlights-index-01-slider-inst').slick({
            infinite: true,
            slidesToShow: 1,
            slidesToScroll: 1,
            speed: 500,
            arrows: true,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                breakpoint: 576,
                settings: {
                    arrows: false,
                    slidesToShow: 1,
                }
            }]
        });


        /*------------------------------
            magnific popup
        -------------------------------*/

        $('.magnific-inst').magnificPopup({
            type: 'video',
            // other options
        });

        /*------------------------------------------------------------------
            latest video index-02 Slick Slider
         -------------------------------------------------------------------*/
        $('.latest-video-index-02-slider-inst, .popular-video-index-04-slider-inst').slick({
            infinite: true,
            slidesToShow: 1,
            slidesToScroll: 1,
            speed: 500,
            arrows: true,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                breakpoint: 576,
                settings: {
                    arrows: false,
                    slidesToShow: 1,
                }
            }]
        });


        /*------------------------------------------------------------------
            popular stories index-03 Slick Slider
        -------------------------------------------------------------------*/
        $('.popular-stories-index-03-slider-inst').slick({
            infinite: true,
            slidesToShow: 4,
            slidesToScroll: 1,
            speed: 500,
            arrows: true,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                    breakpoint: 1200,
                    settings: {
                        slidesToShow: 3,
                    }
                },
                {
                    breakpoint: 992,
                    settings: {
                        slidesToShow: 3,
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 2,
                    }
                },
                {
                    breakpoint: 576,
                    settings: {
                        arrows: false,
                        slidesToShow: 1,
                    }
                }
            ]
        });


        /*------------------------------------------------------------------
            popular stories index-04 Slick Slider
         -------------------------------------------------------------------*/
        $('.popular-news-index-04-inst').slick({
            infinite: true,
            slidesToShow: 4,
            slidesToScroll: 1,
            speed: 500,
            arrows: true,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                    breakpoint: 992,
                    settings: {
                        slidesToShow: 3,
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 2,
                    }
                },
                {
                    breakpoint: 576,
                    settings: {
                        arrows: false,
                        slidesToShow: 1,
                    }
                }
            ]
        });


        /*------------------------------------------------------------------
            popular stories index-04 Slick Slider
         -------------------------------------------------------------------*/
        $('.sports-update-news-index-05-inst').slick({
            infinite: true,
            slidesToShow: 4,
            slidesToScroll: 1,
            speed: 500,
            arrows: false,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                    breakpoint: 992,
                    settings: {
                        slidesToShow: 2,
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 2,
                    }
                },
                {
                    breakpoint: 576,
                    settings: {
                        arrows: false,
                        slidesToShow: 1,
                    }
                }
            ]
        });


        /*------------------------------------------------------------------
            feature news index-04 Slick Slider
         -------------------------------------------------------------------*/
        $('.feature-news-index-04-inst').slick({
            infinite: true,
            slidesToShow: 3,
            slidesToScroll: 1,
            speed: 500,
            arrows: true,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                    breakpoint: 992,
                    settings: {
                        slidesToShow: 3,
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 2,
                    }
                },
                {
                    breakpoint: 576,
                    settings: {
                        arrows: false,
                        slidesToShow: 1,
                    }
                }
            ]
        });

        /*------------------------------------------------------------------
            feature news index-04 Slick Slider
         -------------------------------------------------------------------*/
        $('.header-recent-post-index-05-slider-inst').slick({
            infinite: true,
            slidesToShow: 3,
            slidesToScroll: 1,
            speed: 500,
            arrows: false,
            dots: false,
            autoplay: false,
            rtl: true,
            cssEase: 'linear',
            prevArrow: '<div class="prev-arrow"><i class="las la-arrow-left"></i></div>',
            nextArrow: '<div class="next-arrow"><i class="las la-arrow-right"></i></div>',

            responsive: [{
                    breakpoint: 1200,
                    settings: {
                        slidesToShow: 2,
                    }
                },
                {
                    breakpoint: 451,
                    settings: {
                        slidesToShow: 1,
                    }
                },

            ]
        });

        /*------------------------------------------------------------------
            author feedback
         -------------------------------------------------------------------*/
        $('.authors-feedback-slider').slick({
            infinite: true,
            slidesToShow: 1,
            slidesToScroll: 1,
            speed: 500,
            arrows: false,
            dots: true,
            autoplay: true,
            cssEase: 'linear',
            rtl: true,
        });

        /*------------------------------------------------------------------
            partner with
         -------------------------------------------------------------------*/
        $('.partner-with-slider').slick({
            infinite: true,
            slidesToShow: 4,
            slidesToScroll: 1,
            speed: 400,
            arrows: false,
            dots: false,
            autoplay: true,
            cssEase: 'linear',
            rtl: true,

            responsive: [{
                breakpoint: 768,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 576,
                settings: {
                    slidesToShow: 2,
                }
            },

        ]
        });

        /*------------------------------------
        search popup
        -----------------------------------*/
        $(document).on('click', '#search_icon', function (e) {
            e.preventDefault();
            $('#search_popup').addClass('show');
        });
        $(document).on('click', '#search-popup-close-btn', function (e) {
            e.preventDefault();
            $('#search_popup').removeClass('show');
        });

        /*------------------------------------
        user account
        -----------------------------------*/
        $(".navigation-button-x").on('click', function () {
            $(".user-account-widget").slideToggle("1000");
        });
        if ($(window).width() < 768) {
            $(".user-account-widget").hide();
        }

    });


    /*------------------------------
           Scroll to top
    -------------------------------*/

    $(window).scroll(function () {

        if ($(this).scrollTop() > 800) {
            $(".scroll-to-top").fadeIn();
        } else {
            $(".scroll-to-top").fadeOut();
        }
    })

    $(".scroll-to-top").click(function () {

        $("html, body").animate({
            scrollTop: 0
        }, 2000);
    })


    $(window).on('load', function () {

        /*------------------------------
           Preloader
        -------------------------------*/

        $('.preloader-inner').fadeOut(1000);
    });

}(jQuery));


/*------------------------------
       Shop View Details
-------------------------------*/

var sandwiches = document.querySelectorAll('.zoom-js-handle');

sandwiches.forEach(function (sandwich, index) {
    sandwich.addEventListener('mousemove', function (e) {
        zoomin(e)
    })
    sandwich.addEventListener('mouseleave', function (e) {
        var zoomer = e.currentTarget;
        zoomer.style.backgroundImage = '';
    })
});

function zoomin(e) {
    var zoomer = e.currentTarget;
    zoomer.style.backgroundImage = 'url(' + zoomer.getAttribute('data-src') + ')';
    e.offsetX ? offsetX = e.offsetX : offsetX = e.touches[0].pageX
    e.offsetY ? offsetY = e.offsetY : offsetX = e.touches[0].pageX
    x = offsetX / zoomer.offsetWidth * 100
    y = offsetY / zoomer.offsetHeight * 100
    zoomer.style.backgroundPosition = x + '% ' + y + '%';
}

function w3_open() {
    document.getElementById("mySidebar").style.transform = "translateX(0px)";
}

function w3_close() {
    document.getElementById("mySidebar").style.transform = "translateX(-100%)";
}
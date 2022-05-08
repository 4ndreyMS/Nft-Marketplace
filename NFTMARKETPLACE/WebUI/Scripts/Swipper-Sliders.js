var slider = tns({
    container: 'bannerSlider',
    loop: true,
    autoplay: true,
    mouseDrag: true,
    controls: false,
    navPosition: "bottom",
    nav: true,
    autoplayTimeout: 4000,
    speed: 900,
    animateIn: "fadeIn",
    animateOut: "fadeOut",
    controlsText: ['&#8592;', '&#8594;'],
    autoplayButtonOutput: false,
    gutter: 30,
    responsive: {

        992: {
            gutter: 30,
            items: 1.5
        },

    }
});

new Swiper('.swiper-container', {
    loop: true,
    slidesPerView: 1,
    paginationClickable: true,
    spaceBetween: 20,
    pagination: '.swiper-pagination',
    slidesPerView: 'auto',
    paginationClickable: true,
    spaceBetween: 0,
    centeredSlides: true,
    speed: 1500,
    nextButton: '.swiper-button-next',
    prevButton: '.swiper-button-prev',
});

var slider = tns({
    container: '.testi-slider',
    loop: true,
    autoplay: true,
    mouseDrag: true,
    controls: true,
    navPosition: "bottom",
    nav: false,
    autoplayTimeout: 4000,
    speed: 900,
    animateIn: "fadeIn",
    animateOut: "fadeOut",
    controlsText: ['&#8592;', '&#8594;'],
    autoplayButtonOutput: false,
    gutter: 30,
    responsive: {

        992: {
            gutter: 30,
            items: 3
        },

    }
});
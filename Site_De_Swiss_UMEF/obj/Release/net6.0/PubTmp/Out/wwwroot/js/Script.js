(function () {
    const Search = document.querySelector("#Search"),
        btn = document.querySelector("#RechercheBtn");

    btn.addEventListener("click", (e) => {
        if (Search.value.length <= 2) {
            e.preventDefault();
        }
    }, false);
})();

//$(function () {
//    var successMessage = '@TempData["SuccessMessage"]'
//    if (successMessage != '')
//        alertify.success(successMessage);
//});

var swiper = new Swiper(".slide-content", {
    slidesPerView: 3,
    spaceBetween: 25,
    loop: true,
    centerSlide: 'true',
    fade: 'true',
    grabCursor: 'true',
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
        dynamicBullets: true,
    },
    autoplay: {
        delay: 2500,
        disableOnInteraction:false,
        },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },

    breakpoints: {
        0: {
            slidesPerView: 1,
        },
        520: {
            slidesPerView: 2,
        },
        950: {
            slidesPerView: 3,
        },
    },
});

//const elem = document.querySelectorAll(".voirPlus");

//elem.forEach(el => {
//    el.addEventListener('click', (e) => {
//        el.parentNode.childNodes[5].style.overflow = 'visible';
        
//    })
//})

//function reveal() {
//    var reveals = document.querySelectorAll(".reveal");

//    for (var i = 0; i < reveals.length; i++) {
//        var windowHeight = window.innerHeight;
//        var elementTop = reveals[i].getBoundingClientRect().top;
//        var elementVisible = 150;

//        if (elementTop < windowHeight - elementVisible) {
//            reveals[i].classList.add("active");
//        } else {
//            reveals[i].classList.remove("active");
//        }
//    }
//}

//window.addEventListener("scroll", reveal);

$(document).ready(function () {
    $('#navbar-toggler').click(function () {
        $('#navbarSupportedContent').toggle();
    });
});
//Navbar
function humbergerClickHandler(e) {
    $('.navbar-container').toggleClass('navbar--active');
    if ($('.bg-overlay').length) {
        $('.bg-overlay').remove();
    } else {
        $(document.body).append('<div class="bg-overlay"></div>');
    }

    $('.bg-overlay').on('click', function () {
        humbergerClickHandler.call(this, e);
    });
}

//Jquery events
$('.humberger-menu').on('click', humbergerClickHandler);
$('.navbar__close-btn').on('click', humbergerClickHandler);

$('.register-btn').on('click', function (e) {
    e.preventDefault();
    $(this)
        .siblings('.dropdown-menu')
        .toggleClass('show');
});
$('.user-profile a').on('click', function (e) {
    //e.preventDefault();
    $('.user-profile')
        .find('#profile-menu')
        .toggleClass('dropdown--active');
});

//Tabs
var tabs = document.querySelectorAll('.tab');
var tabsArray = Array.prototype.slice.call(tabs);

tabsArray.forEach(tab => {
    tab.addEventListener('click', tabClickHandler);
});

function tabClickHandler(e) {
    e.preventDefault();
    var target = e.currentTarget;
    //Find the active tab
    var active = tabsArray.find(tab => /tab--active/.test(tab.className));
    active.className = active.className.replace(/tab--active/, '');
    //Active target tab
    target.className += ' tab--active';

    // Hide current select
    $('.select--active').removeClass('select--active');
    //Show Targeted select;
    let activeTarget = target.dataset['target'];
    $(activeTarget).addClass('select--active');
}

//header Search inputs
$(document).ready(function () {
    $(".NumericOnly").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

    $('.select2-selection__arrow').html(`<img src="/imgs/icons/angle-down.svg" role="presentation" alt=""/>`);

    $(".flatpicker").flatpickr();
});


$('.action.disabled').on('click', function (e) {
    e.preventDefault();
})


$("#filter-trigger-btn").on('click', toggleFilterWidget)
$(".panel-close-btn").on('click', toggleFilterWidget)
$(".filter-trigger").on('click', toggleFilterWidget)


function toggleFilterWidget(e) {
    e.preventDefault();
    var target = $('#filter-widget')
    if (target) {
        $(target).toggleClass('filter--active');
    }
}


$("#phoneVerificationModal").on('shown.bs.modal', function () {
    $('.verification-input').focus();
});

function waiting(e, m = '@Global.PleaseWait') {
    $('#' + e).block({
        message: "<div class='an-loader'><svg class='ldi-vdlo49' width='138px'  height='138px'  xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' viewBox='0 0 100 100' preserveAspectRatio='xMidYMid' style='background: none;'><!--?xml version='1.0' encoding='utf-8'?--><!--Generator: Adobe Illustrator 21.0.0, SVG Export Plug-In . SVG Version: 6.00 Build 0)--><svg version='1.1' id='圖層_1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' x='0px' y='0px' viewBox='0 0 100 100' style='transform-origin: 50px 50px 0px;' xml:space='preserve'><g style='transform-origin: 50px 50px 0px;'><g style='transform-origin: 50px 50px 0px; transform: scale(0.73);'><g style='transform-origin: 50px 50px 0px;'><g><style type='text/css' class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.9s; animation-direction: normal;'>.st0{fill:#333}.st1,.st2{stroke:#333}.st1{stroke-width:3.5;stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:10;fill:#e0e0e0}.st2{fill:#f5e6c8}.st2,.st3,.st4{stroke-width:3.5;stroke-miterlimit:10}.st3{fill:#e15b64;stroke:#333}.st4{opacity:.1;stroke:#000}.st5{fill:#fff}.st6{fill:#e0e0e0}.st7{fill:#e15b64}.st8{opacity:.1}.st10,.st9{stroke:#333;stroke-miterlimit:10}.st9{stroke-linecap:round;stroke-linejoin:round;fill:none;stroke-width:4.3153}.st10{fill:#e0e0e0;stroke-width:3.5}.st11{fill:#f5e169;stroke:#333;stroke-linecap:round}.st11,.st12,.st13{stroke-width:3.5;stroke-linejoin:round;stroke-miterlimit:10}.st12{stroke-linecap:round;fill:#f5e6c8;stroke:#333}.st13{fill:none;stroke:#fff}.st13,.st14,.st15{stroke-linecap:round}.st14{opacity:.1;stroke-width:3.5;stroke-linejoin:round;stroke-miterlimit:10;stroke:#000}.st15{fill:none;stroke:#fff}.st15,.st16,.st17{stroke-width:3.5;stroke-miterlimit:10}.st16{fill:none;stroke:#333}.st17{opacity:.2;stroke:#000;stroke-linecap:round;stroke-linejoin:round}.st18,.st19,.st20,.st21{stroke:#333;stroke-miterlimit:10}.st18{stroke-linecap:round;fill:#66503a;stroke-width:3.5}.st19,.st20,.st21{fill:#4a3827;stroke-width:3.56}.st20,.st21{fill:#66503a;stroke-width:3.5}.st21{fill:none;stroke-linecap:round}.st22{fill:#66503a}.st23{fill:#a0c8d7;stroke:#333;stroke-width:3.5;stroke-miterlimit:10}.st24,.st25{fill:none;stroke:#333;stroke-linecap:round}.st24{stroke-miterlimit:10;stroke-dasharray:9.0554,9.0554;stroke-width:3.5}.st25{stroke-width:7;stroke-linejoin:round}.st25,.st26{stroke-miterlimit:10}.st26,.st27,.st28{fill:none;stroke:#333;stroke-width:3.5;stroke-linecap:round;stroke-linejoin:round}.st28{stroke-dasharray:3.1078,6.2156}.st29{fill:none;stroke-miterlimit:10;stroke-dasharray:6,4}.st29,.st30,.st31{stroke:#333;stroke-width:3.5}.st30{stroke-miterlimit:10;fill:#fff}.st31{fill:#f8b26a}.st31,.st32,.st33{stroke-miterlimit:10}.st32{fill:#e15b64;stroke:#333;stroke-width:3.0483}.st33{stroke-width:3.048}.st33,.st34,.st35{opacity:.1;stroke:#000}.st34{stroke-miterlimit:10;stroke-width:2.983}.st35{stroke-width:2.602}.st35,.st36,.st37,.st38,.st39,.st40,.st41,.st42,.st43{stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:10}.st36{opacity:.2;stroke:#000;stroke-width:2.602}.st37,.st38,.st39,.st40,.st41,.st42,.st43{fill:#e15b64;stroke:#333;stroke-width:3.5}.st38,.st39,.st40,.st41,.st42,.st43{fill:#fff}.st39,.st40,.st41,.st42,.st43{fill:#f8b26a}.st40,.st41,.st42,.st43{fill:#f47e60}.st41,.st42,.st43{fill:#333;stroke:#fff}.st42,.st43{fill:#666;stroke:#333}.st43{fill:#a0c8d7}.st44{fill:#666}.st45,.st46{stroke:#000;stroke-width:3.5;stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:10}.st46{fill:#666;stroke:#fff}.st47{fill:#e15b64;stroke:#333;stroke-width:2}.st47,.st48,.st49,.st50{stroke-miterlimit:10}.st48{opacity:.1;stroke-linejoin:bevel;stroke:#000;stroke-width:3.5}.st49,.st50{fill:none;stroke:#fff;stroke-width:2;stroke-linecap:round}.st50{fill:#c33737;stroke:#333;stroke-width:3.5;stroke-linejoin:round}.st51{fill:#abbd81}.st52,.st53,.st54{fill:url(#SVGID_1_);stroke:#333;stroke-width:3.5;stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:10}.st53,.st54{fill:url(#SVGID_2_)}.st54{fill:url(#SVGID_3_)}</style><g class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.835714s; animation-direction: normal;'><path class='st37' d='M70,15.595L70,15.595c-11.046,0-20,8.954-20,20c0-11.046-8.954-20-20-20h0c-11.046,0-20,8.954-20,20v0.265 c0,22.091,30.335,48.545,40,48.545S90,57.951,90,35.86v-0.265C90,24.549,81.046,15.595,70,15.595z' fill='#e5292e' stroke='#e5292e' style='fill: rgb(229, 41, 46); stroke: rgb(229, 41, 46);'></path></g><g class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.771429s; animation-direction: normal;'><path class='st13' d='M20.518,47.752c0.377,0.831,0.791,1.659,1.236,2.48' stroke='rgb(255, 255, 255)' style='stroke: rgb(255, 255, 255);'></path></g><g class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.707143s; animation-direction: normal;'><path class='st13' d='M26.369,23.738C21.411,26.185,18,31.293,18,37.196v0.199' stroke='rgb(255, 255, 255)' style='stroke: rgb(255, 255, 255);'></path></g><g class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.642857s; animation-direction: normal;'><path class='st14' d='M71.737,15.683C72.555,20.882,73,26.282,73,31.833c0,18.34-4.718,35.097-12.501,47.974 C73.091,71.275,90,52.354,90,35.86v-0.265C90,25.136,81.968,16.565,71.737,15.683z' fill='#ffffff' stroke='#ffffff' style='fill: rgb(255, 255, 255); stroke: rgb(255, 255, 255);'></path></g><metadata xmlns:d='https://loading.io/stock/' class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.578571s; animation-direction: normal;'><d:name class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.514286s; animation-direction: normal;'>card</d:name><d:tags class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.45s; animation-direction: normal;'>card,poker,gambling,casino,game,suit,french deck,heart</d:tags><d:license class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.385714s; animation-direction: normal;'>cc-by</d:license><d:slug class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.321429s; animation-direction: normal;'>vdlo49</d:slug></metadata></g></g></g></g></svg></svg></div>",
        css: {
            border: 'none',
            padding: '15px',
            position: 'absolute',
            background: 'none',
            width: '0%',
            top: '35%',
            left: '35%'
        }
    });
}

function waitingDone(e) {
    $('#' + e).unblock();
}



function waitingUI(m = 'Please Wait') {
    var message = "<div class='an-loader'><svg class='ldi-vdlo49' width='138px'  height='138px'  xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' viewBox='0 0 100 100' preserveAspectRatio='xMidYMid' style='background: none;'><!--?xml version='1.0' encoding='utf-8'?--><!--Generator: Adobe Illustrator 21.0.0, SVG Export Plug-In . SVG Version: 6.00 Build 0)--><svg version='1.1' id='圖層_1' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' x='0px' y='0px' viewBox='0 0 100 100' style='transform-origin: 50px 50px 0px;' xml:space='preserve'><g style='transform-origin: 50px 50px 0px;'><g style='transform-origin: 50px 50px 0px; transform: scale(0.73);'><g style='transform-origin: 50px 50px 0px;'><g><style type='text/css' class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.9s; animation-direction: normal;'>.st0{fill:#333}.st1,.st2{stroke:#333}.st1{stroke-width:3.5;stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:10;fill:#e0e0e0}.st2{fill:#f5e6c8}.st2,.st3,.st4{stroke-width:3.5;stroke-miterlimit:10}.st3{fill:#e15b64;stroke:#333}.st4{opacity:.1;stroke:#000}.st5{fill:#fff}.st6{fill:#e0e0e0}.st7{fill:#e15b64}.st8{opacity:.1}.st10,.st9{stroke:#333;stroke-miterlimit:10}.st9{stroke-linecap:round;stroke-linejoin:round;fill:none;stroke-width:4.3153}.st10{fill:#e0e0e0;stroke-width:3.5}.st11{fill:#f5e169;stroke:#333;stroke-linecap:round}.st11,.st12,.st13{stroke-width:3.5;stroke-linejoin:round;stroke-miterlimit:10}.st12{stroke-linecap:round;fill:#f5e6c8;stroke:#333}.st13{fill:none;stroke:#fff}.st13,.st14,.st15{stroke-linecap:round}.st14{opacity:.1;stroke-width:3.5;stroke-linejoin:round;stroke-miterlimit:10;stroke:#000}.st15{fill:none;stroke:#fff}.st15,.st16,.st17{stroke-width:3.5;stroke-miterlimit:10}.st16{fill:none;stroke:#333}.st17{opacity:.2;stroke:#000;stroke-linecap:round;stroke-linejoin:round}.st18,.st19,.st20,.st21{stroke:#333;stroke-miterlimit:10}.st18{stroke-linecap:round;fill:#66503a;stroke-width:3.5}.st19,.st20,.st21{fill:#4a3827;stroke-width:3.56}.st20,.st21{fill:#66503a;stroke-width:3.5}.st21{fill:none;stroke-linecap:round}.st22{fill:#66503a}.st23{fill:#a0c8d7;stroke:#333;stroke-width:3.5;stroke-miterlimit:10}.st24,.st25{fill:none;stroke:#333;stroke-linecap:round}.st24{stroke-miterlimit:10;stroke-dasharray:9.0554,9.0554;stroke-width:3.5}.st25{stroke-width:7;stroke-linejoin:round}.st25,.st26{stroke-miterlimit:10}.st26,.st27,.st28{fill:none;stroke:#333;stroke-width:3.5;stroke-linecap:round;stroke-linejoin:round}.st28{stroke-dasharray:3.1078,6.2156}.st29{fill:none;stroke-miterlimit:10;stroke-dasharray:6,4}.st29,.st30,.st31{stroke:#333;stroke-width:3.5}.st30{stroke-miterlimit:10;fill:#fff}.st31{fill:#f8b26a}.st31,.st32,.st33{stroke-miterlimit:10}.st32{fill:#e15b64;stroke:#333;stroke-width:3.0483}.st33{stroke-width:3.048}.st33,.st34,.st35{opacity:.1;stroke:#000}.st34{stroke-miterlimit:10;stroke-width:2.983}.st35{stroke-width:2.602}.st35,.st36,.st37,.st38,.st39,.st40,.st41,.st42,.st43{stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:10}.st36{opacity:.2;stroke:#000;stroke-width:2.602}.st37,.st38,.st39,.st40,.st41,.st42,.st43{fill:#e15b64;stroke:#333;stroke-width:3.5}.st38,.st39,.st40,.st41,.st42,.st43{fill:#fff}.st39,.st40,.st41,.st42,.st43{fill:#f8b26a}.st40,.st41,.st42,.st43{fill:#f47e60}.st41,.st42,.st43{fill:#333;stroke:#fff}.st42,.st43{fill:#666;stroke:#333}.st43{fill:#a0c8d7}.st44{fill:#666}.st45,.st46{stroke:#000;stroke-width:3.5;stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:10}.st46{fill:#666;stroke:#fff}.st47{fill:#e15b64;stroke:#333;stroke-width:2}.st47,.st48,.st49,.st50{stroke-miterlimit:10}.st48{opacity:.1;stroke-linejoin:bevel;stroke:#000;stroke-width:3.5}.st49,.st50{fill:none;stroke:#fff;stroke-width:2;stroke-linecap:round}.st50{fill:#c33737;stroke:#333;stroke-width:3.5;stroke-linejoin:round}.st51{fill:#abbd81}.st52,.st53,.st54{fill:url(#SVGID_1_);stroke:#333;stroke-width:3.5;stroke-linecap:round;stroke-linejoin:round;stroke-miterlimit:10}.st53,.st54{fill:url(#SVGID_2_)}.st54{fill:url(#SVGID_3_)}</style><g class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.835714s; animation-direction: normal;'><path class='st37' d='M70,15.595L70,15.595c-11.046,0-20,8.954-20,20c0-11.046-8.954-20-20-20h0c-11.046,0-20,8.954-20,20v0.265 c0,22.091,30.335,48.545,40,48.545S90,57.951,90,35.86v-0.265C90,24.549,81.046,15.595,70,15.595z' fill='#e5292e' stroke='#e5292e' style='fill: rgb(229, 41, 46); stroke: rgb(229, 41, 46);'></path></g><g class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.771429s; animation-direction: normal;'><path class='st13' d='M20.518,47.752c0.377,0.831,0.791,1.659,1.236,2.48' stroke='rgb(255, 255, 255)' style='stroke: rgb(255, 255, 255);'></path></g><g class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.707143s; animation-direction: normal;'><path class='st13' d='M26.369,23.738C21.411,26.185,18,31.293,18,37.196v0.199' stroke='rgb(255, 255, 255)' style='stroke: rgb(255, 255, 255);'></path></g><g class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.642857s; animation-direction: normal;'><path class='st14' d='M71.737,15.683C72.555,20.882,73,26.282,73,31.833c0,18.34-4.718,35.097-12.501,47.974 C73.091,71.275,90,52.354,90,35.86v-0.265C90,25.136,81.968,16.565,71.737,15.683z' fill='#ffffff' stroke='#ffffff' style='fill: rgb(255, 255, 255); stroke: rgb(255, 255, 255);'></path></g><metadata xmlns:d='https://loading.io/stock/' class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.578571s; animation-direction: normal;'><d:name class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.514286s; animation-direction: normal;'>card</d:name><d:tags class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.45s; animation-direction: normal;'>card,poker,gambling,casino,game,suit,french deck,heart</d:tags><d:license class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.385714s; animation-direction: normal;'>cc-by</d:license><d:slug class='ld ld-breath' style='transform-origin: 50px 50px 0px; animation-duration: 0.9s; animation-delay: -0.321429s; animation-direction: normal;'>vdlo49</d:slug></metadata></g></g></g></g></svg></svg></div>";
    var newLoader = "<div class='loader-2'><span></span><span></span><span></span><span></span></div>";
    $.blockUI({
        message: newLoader,
        css: {
            border: 'none',
            background: 'none',
            centerX: true,
            centerY: true
        }
    });
}

function waitingDoneUI() {
    $.unblockUI();
}



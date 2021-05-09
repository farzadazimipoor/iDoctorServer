(function ($, w) {
    
    $('.an__tabs .tab').on('click', function (e) {
        $('.tab--active').removeClass('tab--active');
        $(this).addClass('tab--active');

        $('.an__form.form--active').removeClass('form--active');
        $('.svg--active').removeClass('svg--active');
        console.log(this);
        var target = $(this).data('target');
        var targetSvg = $(this).data('svg');
        
        if(target) {
            $(target).addClass('form--active');
            $(targetSvg).addClass('svg--active');

            if (target == "#polyclinic-form") {
                window.location.href = "/Register?active=polyclinic";
            } else if (target == "#patient-form") {
                window.location.href = "/Register";
            }
            
        }
        //window.location.search = "active=" + $(this).data('url');
    });


    var param = w.location.search.split('=')[1];
    if(param) {
        if (param.length !== -1) {
            if (param.toString().toLowerCase() === "polyclinic" || param.toString().toLowerCase() === "polyclinic&model") {
                $('.tab--active').removeClass('tab--active');
                $('.tab[data-target="#polyclinic-form"]').addClass('tab--active');
                $('.an__form.form--active').removeClass('form--active');
                var target = $('.tab--active').data('target');
                var targetSvg = $('.tab--active').data('svg');
                $('.svg--active').removeClass('svg--active');
                if(target) {
                    $(target).addClass('form--active');
                    $(targetSvg).addClass('svg--active');
                }
            } else{
    
            }
        }
    }
})(window.jQuery || $, window)
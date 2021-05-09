var afterSetDate;
$(window).load(function () {
    // setHidenValue("dateTimePicker", $("#dateTimePicker").val());
    $(".shamsiDatePicker").change(function () {
        var value = $(this).val();
        value = value.replace(/\//g, "");
        if (value.length > 7) {
            var year = value.substring(0, 4);
            var month = value.substring(4, 6);
            var day = value.substring(6, 8);
            if (parseInt(day) <= 0)
                day = "01";
            if (parseInt(month) > 12)
                month = "12";
            else if (parseInt(month) <= 0)
                month = "01";
            if (parseInt(day) > 31 && (parseInt(month) >= 1 && parseInt(month) <= 6))
                day = "31";
            else if (parseInt(day) > 31 && (parseInt(month) >= 7 && parseInt(month) <= 11))
                day = "30";
            else if (parseInt(day) > 31 && parseInt(month) == 12)
                day = "29";
            $(this).val(year + "/" + month + "/" + day);
            setHidenValue($(this).attr("id"), $(this).val());
        }
        else {
            setHidenValueEmpty($(this).attr("id"));
        }


    });
});

String.prototype.toEnglishDigits = function () {
    var charCodeZero = '۰'.charCodeAt(0);
    return parseInt(this.replace(/[۰-۹]/g, function (w) {
        return w.charCodeAt(0) - charCodeZero;
    }));
}
function setHidenValue(element, date) {
    var selectedDate = date.split("/");
    if (selectedDate[0] && selectedDate[1] && selectedDate[2]) {
        var gDate = toGregorian(parseInt(selectedDate[0].toEnglishDigits()), parseInt(selectedDate[1].toEnglishDigits()), parseInt(selectedDate[2].toEnglishDigits()));
        var chrDate = gDate.gy + "/" + gDate.gm + "/" + gDate.gd;
        $("#" + element.replace("dateTimePicker_", "")).val(chrDate);
        if (afterSetDate) {
            Awro.Function.Call(afterSetDate);
        }
    }
}
function setHidenValueEmpty(element) {
    $("#" + element.replace("dateTimePicker_", "")).val("");
    if (afterSetDate) {
        Awro.Function.Call(afterSetDate);
    }
}
Awro.GUID = {
    GenerateNew: function (Seperated = true) {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
                .toString(16)
                .substring(1);
        }
        return s4() + s4() + (Seperated ? '-' : '') + s4() + (Seperated ? '-' : '') + s4() + (Seperated ? '-' : '') +
            s4() + (Seperated ? '-' : '') + s4() + s4() + s4();
    },
    Empty: function (Seperated = true) {
        return "00000000" + (Seperated ? '-' : '') + "0000" + (Seperated ? '-' : '') + "0000" + (Seperated ? '-' : '') +
            "0000" + (Seperated ? '-' : '') + "000000000000";
    },
    RemoveLines: function (guid) {
        return guid.replace(/\-/g, '');
    }
};

Awro.Waiting = {
    Show: function (_element) {
        $(_element).block({
            message: '<div class="blockui-default-message"><i class="fa fa-circle-o-notch fa-spin"></i><h6>' + Awro.Waiting.WaitingText + '</h6></div>',
            overlayCSS: {
                background: 'rgba(142, 159, 167, 0.8)',
                opacity: 1,
                cursor: 'wait'
            },
            css: {
                width: '50%'
            },
            blockMsgClass: 'block-msg-default'
        });
    },
    Done: function (_element) {
        $(_element).unblock();
    },
    WaitingText: "Please Wait"
};

Awro.Math = {
    Random: function (min = 1, max = 10) {
        return Math.floor((Math.random() * (max - min)) + min);
    }
}

Awro.Notification = {
    Notify: function (title, text, type = 'danger', icon = 'font-icon font-icon-warning') {
        $.notify({
            icon: icon,
            title: '<strong>' + title + '</strong>',
            message: text
        },
            {
                type: type, placement: {
                    from: "top",
                    align: DirectionUnSide
                },
                animate: {
                    enter: 'animated bounceIn',
                    exit: 'animated bounceOut'
                }
            });
    },
    Read: function (id, show = false) {
        if (show) {
            var processResourceFiles = false;
            var showInsideAnotherModal = false;
            var showModal = true;
            Awro.ModalManager.LoadViewGetAsync('/Notification/Reader/' + id, 'Notification', processResourceFiles, 'modal-lg', showInsideAnotherModal, showModal, 'body', function (modalSelector) {

            });
        }
        else {
            Awro.AjaxManager.GeneralRequest('/Notification/MarkNotificationAsRead', function () { }, param = { id: id }, "Mark Notification As Read", "body", "html", alwaysDo = function () { })
        }

    }
};

Awro.Form = {
    ParseView: function (selector) {
        var forms = $(selector).find("form");
        if (forms.length) {
            $.each(forms, function (index, value) {
                $(value).find(".required-star").append(' <span class="color-red">*</span>');
                $.validator.unobtrusive.parse(value);
                $(value).on("submit", function (e) {
                    e.preventDefault();
                    var submitButton = $(this).find("button[type='submit']");
                    var needConfirm = submitButton.data("confirm");
                    var needValidation = submitButton.data("pre-submit");
                    var isValid;
                    if (needValidation) {
                        isValid = Awro.Function.Call(needValidation);
                    }
                    else {
                        isValid = true;
                    }
                    if (isValid) {
                        if (needConfirm) {
                            Awro.AjaxManager.SerializeFormWithConfirm($(this), $(this).attr("action"), submitButton.data("callback"));
                        }
                        else {
                            Awro.AjaxManager.SerializeForm($(this), $(this).attr("action"), submitButton.data("callback"));
                        }
                    }
                    return false;
                });
            });
        }
    },
    Parse: function (selector) {
        var form = $(selector);
        form.find(".required-star").append(' <span class="color-red">*</span>');
        $.validator.unobtrusive.parse(form);
        $(form).on("submit", function (e) {
            e.preventDefault();
            var submitButton = $(this).find("button[type='submit']");
            var needConfirm = submitButton.data("confirm");
            var needValidation = submitButton.data("pre-submit");
            var isValid;
            if (needValidation) {
                isValid = Awro.Function.Call(needValidation);
            }
            else {
                isValid = true;
            }
            if (isValid) {
                if (needConfirm) {
                    Awro.AjaxManager.SerializeFormWithConfirm($(this), $(this).attr("action"), submitButton.data("callback"));
                }
                else {
                    Awro.AjaxManager.SerializeForm($(this), $(this).attr("action"), submitButton.data("callback"));
                }
            }
            return false;
        });
    },
    ParseWithoutSumbit: function (selector, extraValidation, validateCallback) {
        var form = $(selector);
        form.find(".required-star").append(' <span class="color-red">*</span>');
        $.validator.unobtrusive.parse(form);
        $(form).on("submit", function (e) {
            e.preventDefault();
            var isValid;
            if (extraValidation) {
                isValid = Awro.Function.Call(extraValidation);
            }
            else {
                isValid = true;
            }

            if (isValid && form.valid()) {
                Awro.Function.Call(validateCallback, true, form);
            }
            else {
                Awro.Function.Call(validateCallback, false, form);
            }
        });
    },
    DeleteItem: function (url, param = {}, callBack = function () { }, waiting = "body") {
        Awro.AjaxManager.GeneralRequestWithConfirm(url, callBack, param, "Form - Delete Item", waiting);
    },
    ValidateImageFileUpload: function (selector, fieldName) {
        if (selector.hasClass("isRequired")) {
            var result = (selector.val() ? selector.val() != null && selector.val() != '' : false);
            // console.log(selector.closest("#imagePanel_" + selector.attr("name")).html());
            if (!result) {
                selector.closest("#imagePanel_" + selector.attr("name")).find('.fileUploadResult').html("This field is required.");
                Awro.Notification.Notify("Error", fieldName + " is required.");
            }
            else {
                selector.closest("#imagePanel_" + selector.attr("name")).find('.fileUploadResult').html("");
            }
            return result;
        }
        else
            return true;
    }
};

Awro.Url = {
    UpdateQueryString: function (uri, key, value) {
        var re = new RegExp("([?&])" + key + "=.*?(&|$)", "i");
        var separator = uri.indexOf('?') !== -1 ? "&" : "?";
        if (uri.match(re)) {
            return uri.replace(re, '$1' + key + "=" + value + '$2');
        }
        else {
            return uri + separator + key + "=" + value;
        }
    }
};

Awro.Initializer = {
    Select2: function (selector) {
        $(selector).find(".select2:not(.ignore-search):not(.tag)").select2({ width: '100%'});
        $(selector).find(".select2.ignore-search:not(.tag)").select2({ minimumResultsForSearch: -1, width: '100%' });
        $(selector).find(".select2.tag").select2({
            tags: true,
            tokenSeparators: [',', ' '],
            width:'100%'
        });
    },
    FlatPicker: function (selector, options, returnSelector = false) {
        $(selector).each(function () {
            $(this).attr("autocomplete", "off");
            if ($(this).val() == "0001-01-01T00:00:00.000" || $(this).val() == "0001/01/01 12:00:00 AM") {
                $(this).val("");
            }
        });
        var result = $(selector).flatpickr(options);
        if (returnSelector) {
            return result;
        }
    },
    IsWeekend: function (date) {
        var weekDayNumber = date.getDay();
        var isWeekend = (weekDayNumber == 5 || weekDayNumber == 6);
        var isHoliday = Awro.Initializer.ExistInHolidayList(date) != -1;
        return (isWeekend || isHoliday);
    },
    IsExistInWeekDays: function (date, weekDays) {
        var weekDayNumber = date.getDay();
        var isExist = jQuery.inArray(weekDayNumber, weekDays) != -1;
        return (isExist);
    },
    IsHoliday: function (date, holiydayList) {
        var isHoliday = jQuery.inArray(Awro.Initializer.FormatDate(date), holiydayList) != -1;
        return (isHoliday);
    },
    FormatDate: function (date) {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;

        return [year, month, day].join('/');
    },
    FroalaEditor: function (selector, minHeight = 500) {
        $.FroalaEditor.DefineIcon('insertCustomImage', { NAME: 'image' });
        $.FroalaEditor.RegisterCommand('insertCustomImage', {
            title: 'Insert Image',
            focus: true,
            undo: true,
            refreshAfterCallback: true,
            callback: function () {
                FroalaCustomSelector = this;
                Awro.AjaxManager.GeneralRequest("/Common/GlobalUploder", function (result) {
                    $("#globalUploaderHelper").html(result);
                }, { uploadType: "image" }, "", "body", "html");
            }
        });
        $.FroalaEditor.DefineIcon('insertCustomFile', { NAME: 'file' });
        $.FroalaEditor.RegisterCommand('insertCustomFile', {
            title: 'Insert File',
            focus: true,
            undo: true,
            refreshAfterCallback: true,
            callback: function () {
                FroalaCustomSelector = this;
                Awro.AjaxManager.GeneralRequest("/Common/GlobalUploder", function (result) {
                    $("#globalUploaderHelper").html(result);
                }, { uploadType: "file" }, "", "body", "html");
            }
        });
        $(selector).froalaEditor({
            heightMin: minHeight,
            toolbarSticky: false,
            imageManagerLoadURL: '/Common/RichTextLoadImages',
            imageManagerPageSize: 10,
            imageUploadURL: '/Common/RichTextImages',
            fileUploadURL: '/Common/RichTextFiles',
            imageManagerPreloader: '/images/fancybox_loading.gif',
            imageManagerDeleteURL: '/Common/RichTextImages_Delete',
            toolbarButtons: ['Cored', 'italic', 'underline', 'strikeThrough', 'subscript', 'superscript', '|', 'fontFamily', 'fontSize', 'color', 'inlineStyle', 'paragraphStyle', '|', 'paragraphFormat', 'align', 'formatOL', 'formatUL', 'outdent', 'indent', 'quote', '-', 'insertLink', 'insertCustomImage', 'insertCustomFile', 'insertTable', '|', 'emoticons', 'specialCharacters', 'insertHR', 'selectAll', 'clearFormatting', '|', 'print', 'help', 'html', '|', 'undo', 'redo', "|", 'draft', 'Generaldraft']
            /*}).on('froalaEditor.image.beforeUpload', function (e, editor, images) {
                // Return false if you want to stop the image upload.
            })
                .on('froalaEditor.image.uploaded', function (e, editor, response) {
                    // Image was uploaded to the server.
    
                    console.log(uploadUrl, uploadParam, uploadParams);
                    console.log('Image uploaded');
                    console.log(e);
                    console.log(editor);
                    console.log(response);
                })
                .on('froalaEditor.image.inserted', function (e, editor, $img, response) {
                    // Image was inserted in the editor.
                    console.log('Image inserted');
                    console.log(e);
                    console.log(editor);
                    console.log($img);
                    console.log(response);
                })
                .on('froalaEditor.image.replaced', function (e, editor, $img, response) {
                    // Image was replaced in the editor.
                })
                */
        })
            .on('froalaEditor.image.error', function (e, editor, error, response) {
                Awro.Notification.Notify("Uploading Error", JSON.parse(response).message);
            })
            .on('froalaEditor.file.error', function (e, editor, error, response) {
                Awro.Notification.Notify("Uploading Error", JSON.parse(response).message);
            });

        //Delete image after delete from editor
        $(selector).on('froalaEditor.image.removed', function (e, editor, $img) {
            $.ajax({
                method: 'POST',
                url: '/Common/RichTextImages_Delete',
                data: {
                    src: $img.attr('src')
                }
            });
        });
        //Delete File after unlink from editor
        $(selector).on('froalaEditor.file.unlink', function (e, editor, file) {
            $.ajax({
                method: 'POST',
                url: '/Common/RichTextImages_Delete',
                data: {
                    src: file.getAttribute('href')
                }
            });
        });
    },
    FilterInfo: function (selector = null) {
        if (selector) {
            Awro.AjaxManager.GeneralRequest("/University/ChooseBasicInfo/GetChosenItemsForWidget", function (result) {
                $(selector).html(result);
            }, {}, caption = "Update Filter Info", waiting = (selector ? selector : "body"), dataType = "html");
        }
        else {
            if ($(".filter-holder .filter-data").length) {
                Awro.AjaxManager.GeneralRequest("/University/ChooseBasicInfo/GetChosenItemsForWidget", function (result) {
                    $(".filter-holder .filter-data").each(function () {
                        $(this).html(result)
                    });
                }, {}, caption = "Update Filter Info", waiting = (selector ? selector : "body"), dataType = "html");
            }
        }
    },
    ContextMenu: function (selector, template) {
        $(selector).unbind("contextmenu");
        $(selector).bind("contextmenu", function (e) {
            e.preventDefault();
            $(template).css("left", e.pageX);
            $(template).css("top", e.pageY);
            $(template).fadeIn(200);
            SelectedContextMenu = this;
        });
    }
};

Awro.Converter = {
    ToDecimal: function (number, decimalPoint = 2, seperator = "") {
        return $.number(number, decimalPoint, '.', seperator);
    },
    ToTwoNumberFormat: function (number) {
        if (number.toString().length < 2) {
            return "0" + number;
        }
        else {
            return number;
        }
    }
};

Awro.FilterEvents = {
    JustNumber: function (selector) {
        var numberSelector = $(selector).find(".number-only");
        numberSelector.each(function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
        $(numberSelector).off("input");
        $(numberSelector).on("input", function () {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    }
}


Awro.ImageViewer = {
    Show: function (selector) {
        var imgSelector = $(selector);
        if (imgSelector.is("img")) {
            var pswpElement = document.querySelectorAll('.pswp')[0];
            var items = [
                {
                    src: imgSelector.attr("src"),
                    w: imgSelector[0].naturalWidth,
                    h: imgSelector[0].naturalHeight
                }
            ];
            var options = {
                index: 0,
                zoomEl: true,
                shareEl: false,
            };
            var gallery = new PhotoSwipe(pswpElement, PhotoSwipeUI_Default, items, options);
            gallery.init();
        }
        else {
            Awro.Notification.Notify("Error", "Please select valid image element", 'danger');
        }
    }
};

Awro.Report = {
    Open: function (url) {
        var win = window.open(url, '_blank');
        win.focus();
    }
};

Awro.Print = {
    Area: function (selector, resources = "") {
        var params = [
            'height=' + screen.height,
            'width=' + screen.width,
            'fullscreen=yes',
            'scrollbars=yes'// only works in IE, but here for completeness
        ].join(',');
        w = window.open(null, 'popup_window', params);
        var myStyle = '<link href="/lib/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />';
        myStyle += resources;
        myStyle += '<link href="/css/main.css" rel="stylesheet" />';
        myStyle += '<link href="/css/print.css" rel="stylesheet" />';
        w.document.write(myStyle + $(selector).html());
        w.document.close();
        //w.print();
        w.moveTo(0, 0);
    },
    OutterArea: function (selector, resources = "") {
        var params = [
            'height=' + screen.height,
            'width=' + screen.width,
            'fullscreen=yes',
            'scrollbars=yes'// only works in IE, but here for completeness
        ].join(',');
        w = window.open(null, 'popup_window', params);
        var myStyle = '<link href="/lib/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />';
        myStyle += resources;
        myStyle += '<link href="/css/main.css" rel="stylesheet" />';
        myStyle += '<link href="/css/print.css" rel="stylesheet" />';
        w.document.write(myStyle + $(selector).clone().wrap('<div>').parent().html());
        w.document.close();
        //w.print();
        w.moveTo(0, 0);
    },
    Html: function (html, resources = "") {
        var params = [
            'height=' + screen.height,
            'width=' + screen.width,
            'fullscreen=yes',
            'scrollbars=yes'// only works in IE, but here for completeness
        ].join(',');
        w = window.open(null, 'popup_window', params);
        var myStyle = '<link href="/lib/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" />';
        myStyle += resources;
        myStyle += '<link href="/css/main.css" rel="stylesheet" />';
        myStyle += '<link href="/css/print.css" rel="stylesheet" />';
        w.document.write(myStyle + html);
        w.document.close();
        //w.print();
        w.moveTo(0, 0);
    }
};

Awro.Utility = {
    MediaQuereySize: function () {
        if ($(".viewport-check").length == 0) {
            $("body").append("<div style='display:none;' class='viewport-check'><span class='d-block'></span><span class='d-sm-block'></span><span class='d-md-block'></span><span class='d-lg-block'></span><span class='d-xl-block'></span></div>");
        }
        var mediaQueryXs = Awro.Utility.CheckIfBlock('.viewport-check .d-block');
        var mediaQuerySm = Awro.Utility.CheckIfBlock('.viewport-check .d-sm-block');
        var mediaQueryMd = Awro.Utility.CheckIfBlock('.viewport-check .d-md-block');
        var mediaQueryLg = Awro.Utility.CheckIfBlock('.viewport-check .d-lg-block');
        var mediaQueryXl = Awro.Utility.CheckIfBlock('.viewport-check .d-xl-block');
        var viewPort = "xs";
        if (mediaQueryXs) {
            viewPort = "xs";
        }
        if (mediaQuerySm) {
            viewPort = "sm";
        }
        if (mediaQueryMd) {
            viewPort = "md";
        }
        if (mediaQueryLg) {
            viewPort = "lg";
        }
        if (mediaQueryXl) {
            viewPort = "xl";
        }
        return viewPort;
    },
    MediaQueryChangeEvent(registerFunction) {
        $(window).resize(function () {
            var mediaSize = Awro.Utility.MediaQuereySize();
            if (mediaSize != Awro.Utility.LastMediaSize) {
                Awro.Utility.LastMediaSize = mediaSize;
                Awro.Function.Call(registerFunction, mediaSize);
            }
        });
        //return intialSize;
        Awro.Function.Call(registerFunction, Awro.Utility.MediaQuereySize());
    },
    CheckIfBlock: function (target) {
        var target = $(target).css('display') == 'block';
        return target;
    },
    LastMediaSize: ""
}

Awro.Function = {
    Call: function () {
        var isObject = false;
        var objectSpliter;
        var callBack = arguments[0];

        var callBackObj;
        if (typeof callBack == "string") {
            callBackObj = window[callBack];
        }
        else {
            callBackObj = callBack;
        }
        if (!callBackObj) {
            objectSpliter = callBack.split(".");
            callBackObj = eval(objectSpliter[0]);
            isObject = true;
        }
        if (isObject) {
            if (callBackObj[objectSpliter[1]].length == 0) {
                return callBackObj[objectSpliter[1]]();
            }
            else if (callBackObj[objectSpliter[1]].length == 1) {
                return callBackObj[objectSpliter[1]](arguments[1]);
            }
            else if (callBackObj[objectSpliter[1]].length == 2) {
                return callBackObj[objectSpliter[1]](arguments[1], arguments[2]);
            }
            else if (callBackObj[objectSpliter[1]].length == 3) {
                return callBackObj[objectSpliter[1]](arguments[1], arguments[2], arguments[3]);
            }
            else if (callBackObj[objectSpliter[1]].length == 4) {
                return callBackObj[objectSpliter[1]](arguments[1], arguments[2], arguments[3], arguments[4]);
            }
            else if (callBackObj[objectSpliter[1]].length == 5) {
                return callBackObj[objectSpliter[1]](arguments[1], arguments[2], arguments[3], arguments[4], arguments[5]);
            }
        }
        else {
            if (callBackObj.length == 0) {
                return callBackObj();
            }
            else if (callBackObj.length == 1) {
                return callBackObj(arguments[1]);
            }
            else if (callBackObj.length == 2) {
                return callBackObj(arguments[1], arguments[2]);
            }
            else if (callBackObj.length == 3) {
                return callBackObj(arguments[1], arguments[2], arguments[3]);
            }
            else if (callBackObj.length == 4) {
                return callBackObj(arguments[1], arguments[2], arguments[3], arguments[4]);
            }
            else if (callBackObj.length == 5) {
                return callBackObj(arguments[1], arguments[2], arguments[3], arguments[4], arguments[5]);
            }
        }
    }
}


$.fn.serializeFormJSON = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

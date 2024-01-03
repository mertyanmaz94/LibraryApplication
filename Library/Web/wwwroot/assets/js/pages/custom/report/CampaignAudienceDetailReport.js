
$(function () {
    // enable clear button
    $('#lastroamingdatepicker, #lastroamingdatepicker_validate').datepicker({
        rtl: KTUtil.isRTL(),
        todayBtn: "linked",
        clearBtn: true,
        todayHighlight: true,
        templates: arrows,
        orientation: "bottom right"
    });

    // enable clear button for modal demo
    $('#lastroamingdatepicker_modal').datepicker({
        rtl: KTUtil.isRTL(),
        todayBtn: "linked",
        clearBtn: true,
        todayHighlight: true,
        templates: arrows,
        orientation: "bottom right"
    });

    var arrows;
    if (KTUtil.isRTL()) {
        arrows = {
            leftArrow: '<i class="la la-angle-right"></i>',
            rightArrow: '<i class="la la-angle-left"></i>'
        }
    } else {
        arrows = {
            leftArrow: '<i class="la la-angle-left"></i>',
            rightArrow: '<i class="la la-angle-right"></i>'
        }
    }
});

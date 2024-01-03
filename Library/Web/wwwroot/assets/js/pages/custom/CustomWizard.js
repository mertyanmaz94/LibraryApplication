$(function () {
    $('#divgender').css("display", "none");
    $('#divage').css("display", "none");
    $('#divmarital').css("display", "none");
    $('#diveducation').css("display", "none");
    $('#divprofession').css("display", "none");
    $('#divteam').css("display", "none");
    $('#divcountry').css("display", "none");
    $('#divlastRoamedCountries').css("display", "none");
    $('#divInvoiceAddress').css("display", "none");
    $('#divMostLivedAddress').css("display", "none");
    $('#divWeekDayMostLivedAddress').css("display", "none");
    $('#divWeekNightMostLivedAddress').css("display", "none");
    $('#divpaymenttypes').css("display", "none"); 
    $('#divtariffs').css("display", "none"); 
    $('#divbandsegments').css("display", "none"); 
    $('#divclubs').css("display", "none");
    $('#divinterests').css("display", "none");
    $('#divpredefaudiences').css("display", "none");
    $('#divpredefaudiencesboolean').css("display", "none");
    $('#divmobileapplications').css("display", "none");
    $('#divmonthlyDataUsages').css("display", "none");
    $('#divservices').css("display", "none"); 
    $('#divInvoiceAddressAdd').css("display", "none"); 
    $('#divMostLivedAddressAdd').css("display", "none"); 
    $('#divWeekDayMostLivedAddressAdd').css("display", "none");
    $('#divWeekNightMostLivedAddressAdd').css("display", "none");
    $('#divchkequipmentManufacturerGroup').css("display", "none");
    $('#divsubscriberType').css("display", "none");

    $('#chkgender').on('switchChange.bootstrapSwitch', function (event, state)
    {
        if (state) {
            $('#divgender').css("display", "block");
        }
        else {
            $('#divgender').css("display", "none");
        }
    }); 

    $('#chkage').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divage').css("display", "block");
        }
        else {
            $('#divage').css("display", "none");
        }
    }); 

    $('#chkmaritalstatus').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divmarital').css("display", "block");
        }
        else {
            $('#divmarital').css("display", "none");
        }
    }); 

    $('#chkeducation').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#diveducation').css("display", "block");
        }
        else {
            $('#diveducation').css("display", "none");
        }
    }); 

    $('#chkprofession').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divprofession').css("display", "block");
        }
        else {
            $('#divprofession').css("display", "none");
        }
    }); 

    $('#chkteam').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divteam').css("display", "block");
        }
        else {
            $('#divteam').css("display", "none");
        }
    });

    $('#chkcountry').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divcountry').css("display", "block");
        }
        else {
            $('#divcountry').css("display", "none");
        }
    }); 

    $('#chklastRoamedCountries').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divlastRoamedCountries').css("display", "block");
        }
        else {
            $('#divlastRoamedCountries').css("display", "none");
        }
    }); 

    $('#chkInvoiceAddress').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divInvoiceAddress').css("display", "block");
            $('#divInvoiceAddressAdd').css("display", "block");
        }
        else {
            $('#divInvoiceAddress').css("display", "none");
            $('#divInvoiceAddressAdd').css("display", "none");
        }
    });

    $('#chkInvoiceAddress').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divInvoiceAddress').css("display", "block");
            $('#divInvoiceAddressAdd').css("display", "block");
        }
        else {
            $('#divInvoiceAddress').css("display", "none");
            $('#divInvoiceAddressAdd').css("display", "none");
        }
    });

    $('#chkMostLivedAddress').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divMostLivedAddress').css("display", "block");
            $('#divMostLivedAddressAdd').css("display", "block");
        }
        else {
            $('#divMostLivedAddress').css("display", "none");
            $('#divMostLivedAddressAdd').css("display", "none");
        }
    });

    $('#chkWeekDayMostLivedAddress').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divWeekDayMostLivedAddress').css("display", "block");
            $('#divWeekDayMostLivedAddressAdd').css("display", "block");
        }
        else {
            $('#divWeekDayMostLivedAddress').css("display", "none");
            $('#divWeekDayMostLivedAddressAdd').css("display", "none");
        }
    });

    $('#chkWeekNightMostLivedAddress').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divWeekNightMostLivedAddress').css("display", "block");
            $('#divWeekNightMostLivedAddressAdd').css("display", "block");
        }
        else {
            $('#divWeekNightMostLivedAddress').css("display", "none");
            $('#divWeekNightMostLivedAddressAdd').css("display", "none");
        }
    });

    $('#chkpaymenttypes').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divpaymenttypes').css("display", "block");
        }
        else {
            $('#divpaymenttypes').css("display", "none");
        }
    });

    $('#chktariffs').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divtariffs').css("display", "block");
        }
        else {
            $('#divtariffs').css("display", "none");
        }
    });

    $('#chkbandsegments').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divbandsegments').css("display", "block");
        }
        else {
            $('#divbandsegments').css("display", "none");
        }
    });

    $('#chkclubs').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divclubs').css("display", "block");
        }
        else {
            $('#divclubs').css("display", "none");
        }
    });

    $('#chkinterests').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divinterests').css("display", "block");
        }
        else {
            $('#divinterests').css("display", "none");
        }
    });

    $('#chkpredefaudiences').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divpredefaudiences').css("display", "block");
        }
        else {
            $('#divpredefaudiences').css("display", "none");
        }
    });

    $('#chkpredefaudiencesboolean').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divpredefaudiencesboolean').css("display", "block");
        }
        else {
            $('#divpredefaudiencesboolean').css("display", "none");
        }
    });

    $('#chkmobileapplications').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divmobileapplications').css("display", "block");
        }
        else {
            $('#divmobileapplications').css("display", "none");
        }
    });

    $('#chkmonthlyDataUsages').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divmonthlyDataUsages').css("display", "block");
        }
        else {
            $('#divmonthlyDataUsages').css("display", "none");
        }
    });

    $('#chkservices').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divservices').css("display", "block");
        }
        else {
            $('#divservices').css("display", "none");
        }
    });   

    $('#chkequipmentManufacturerGroup').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divchkequipmentManufacturerGroup').css("display", "block");
        }
        else {
            $('#divchkequipmentManufacturerGroup').css("display", "none");
        }
    });

    $('#chksubscriberType').on('switchChange.bootstrapSwitch', function (event, state) {
        if (state) {
            $('#divsubscriberType').css("display", "block");
        }
        else {
            $('#divsubscriberType').css("display", "none");
        }
    });
    // enable clear button
    $('#lastroamingdatepicker, #lastroamingdatepicker_validate').datepicker({
        rtl: KTUtil.isRTL(),
        todayBtn: "linked",
        clearBtn: true,
        todayHighlight: true,
        templates: arrows
    });

    // enable clear button for modal demo
    $('#lastroamingdatepicker_modal').datepicker({
        rtl: KTUtil.isRTL(),
        todayBtn: "linked",
        clearBtn: true,
        todayHighlight: true,
        templates: arrows
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


   

    var dualListBoxgender = new DualListbox('#genders', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListBoxmaritals = new DualListbox('#maritals', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListBoxeducations = new DualListbox('#educations', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListBoxprofessions = new DualListbox('#professions', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListBoxteams = new DualListbox('#teams', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListBoxcountries = new DualListbox('#countries', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListBoxlastRoamedCountries = new DualListbox('#lastRoamedCountries', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListPaymentTypes = new DualListbox('#paymentTypes', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListTariffs = new DualListbox('#tariffs', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListBandSegments = new DualListbox('#bandSegments', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListclubs = new DualListbox('#clubs', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListinterests = new DualListbox('#interests', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });


    var dualListpreDefAudiences = new DualListbox('#preDefAudiences', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListpreDefAudiencesBoolean = new DualListbox('#preDefAudiencesBoolean', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });


    var dualListmobileApplications = new DualListbox('#mobileApplications', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListmonthlyDataUsages = new DualListbox('#monthlyDataUsages', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListservices = new DualListbox('#services', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });

    var dualListequipmentManufacturerGroup = new DualListbox('#equipmentManufacturerGroup', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });
    var dualListsubscriberType = new DualListbox('#subscriberType', {
        addEvent: function (value) {
        },
        removeEvent: function (value) {
        }
    });
});

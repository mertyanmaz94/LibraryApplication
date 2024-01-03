

// Class definition
var KTUserAdd = function () {
    // Base elements
    var wizardEl;
    var formEl;
    var validator;
    var wizard;
    var avatar;

    // Private functions
    var initWizard = function () {
        // Initialize form wizard
        wizard = new KTWizard('kt_user_add_user', {
            startStep: 1, // initial active step number
            clickableSteps: true  // allow step clicking
        });

        // Validation before going to next page
        wizard.on('beforeNext', function (wizardObj) {
            if (validator.form() !== true) {
                wizardObj.stop();  // don't go to the next step
            }
        })

        // Change event
        wizard.on('change', function (wizard) {
            KTUtil.scrollTop();
        });
    }

    var initValidation = function () {
        validator = formEl.validate({
            // Validate only visible fields
            ignore: ":hidden",

            // Validation rules
            rules: {
                // Step 1
                profile_avatar: {
                    //required: true
                },
                profile_first_name: {
                    required: true
                },
                profile_last_name: {
                    required: true
                },
                profile_phone: {
                    required: true
                },
                profile_email: {
                    required: true,
                    email: true
                }
            },

            // Display error
            invalidHandler: function (event, validator) {
                KTUtil.scrollTop();

                swal.fire({
                    "title": "",
                    "text": "There are some errors in your submission. Please correct them.",
                    "type": "error",
                    "buttonStyling": false,
                    "confirmButtonClass": "btn btn-brand btn-sm btn-bold"
                });
            },

            // Submit valid form
            submitHandler: function (form) {

            }
        });
    }

    var initSubmit = function () {
        var btn = formEl.find('[data-ktwizard-type=\"action-submit\"]');

        btn.on('click', function (e) {
            e.preventDefault();

            if (validator.form()) {
                // See: src\\js\\framework\\base\\app.js
                KTApp.progress(btn);
                //KTApp.block(formEl);

                // See: http://malsup.com/jquery/form/#ajaxSubmit
                formEl.ajaxSubmit(options);
            }
        });
    }

    var initUserForm = function () {
        avatar = new KTAvatar('kt_user_add_avatar');
    }

    return {
        // public functions
        init: function () {
            formEl = $('#kt_user_add_form');

            initWizard();
            initValidation();
            initSubmit();
            initUserForm();
        }
    };
}();


var options = {
    target: '#output2',   // target element(s) to be updated with server response
    beforeSubmit: showRequest,  // pre-submit callback
    success: showResponse, // post-submit callback

    // other available options:
    url: '/AdminUser/Save',         // override for form's 'action' attribute
    //type:      type        // 'get' or 'post', override for form's 'method' attribute
    dataType: 'json'        // 'xml', 'script', or 'json' (expected server response type)
    //clearForm: true        // clear all form fields after successful submit
    //resetForm: true        // reset the form after successful submit

    // $.ajax options can be used here too, for example:
    //timeout:   3000
};
function showRequest(formData, jqForm, options) {
    // formData is an array; here we use $.param to convert it to a string to display it
    // but the form plugin does this for you automatically when it submits the data
    var queryString = $.param(formData);

    // jqForm is a jQuery object encapsulating the form element.  To access the
    // DOM element for the form do this:
    // var formElement = jqForm[0];
    //Uncomment this for debugging
    //alert('About to submit: \n\n' + queryString);

    // here we could return false to prevent the form from being submitted;
    // returning anything other than false will allow the form submit to continue
    return true;
}

function showResponse(responseText, statusText, xhr, $form) {
    // for normal html responses, the first argument to the success callback
    // is the XMLHttpRequest object's responseText property

    // if the ajaxSubmit method was passed an Options Object with the dataType
    // property set to 'xml' then the first argument to the success callback
    // is the XMLHttpRequest object's responseXML property

    // if the ajaxSubmit method was passed an Options Object with the dataType
    // property set to 'json' then the first argument to the success callback
    // is the json data object returned by the server
    var formEl = $('#kt_user_add_form');
    var btn = formEl.find('[data-ktwizard-type=\"action-submit\"]');

    if (responseText == 'Succesful Condition') {
        swal.fire({
            "title": "",
            "text": "The user has been succesfully submitted!",
            "type": "success",
            "confirmButtonClass": "btn btn-secondary"
        }).then(function () {
            window.location.href = baseUrl + 'AdminUser/List';
        });
    }
    else {
        KTApp.progress(btn);
        $("#MessageSpot").text("Kullanici bilgileri guncellenmeye calisirken bir hata olustu.");
        $("#divMessage").css('display', 'block');
        $("#divMessage").addClass("alert-danger");
        KTApp.unprogress(btn);
    }
}
jQuery(document).ready(function () {
    KTUserAdd.init();
});
//# sourceURL=webpack:///../src/assets/js/pages/custom/user/add-user.js?");


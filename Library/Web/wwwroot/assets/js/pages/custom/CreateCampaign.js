var j = 1;
var selectedItems = [];
var carousel1 = $('#kt_earnings_widget .kt-widget30__head .owl-carousel');
var carousel2 = $('#kt_earnings_widget .kt-widget30__body .owl-carousel');


function arrayRemove(arr, value) {
    return arr.filter(function (ele) {
        return ele !== value;
    });
}

var dualListboxAudiences = new DualListbox('#audiences', {
    addEvent: function (value) {
        for (i = 0; i < dualListboxAudiences.selected.length; i++) {
            if (value === dualListboxAudiences.selected[i].dataset.id) {
                selectedItems.push(value);
                carousel1.trigger('add.owl.carousel', [`<div class="carousel" data-position="${j}" data-value="${value}"><span>${dualListboxAudiences.selected[i].innerText}</span></div>`]).trigger('refresh.owl.carousel');
                CreateCarouselItem(dualListboxAudiences.selected[i].innerText, j, value);
                j++;
            }
        }
    },
    removeEvent: function (value) {
        index = 0;
        index = selectedItems.indexOf(value);
        position = 0;
        if (index >= 0) {
            carousel1.trigger('remove.owl.carousel', [index]).trigger('refresh.owl.carousel');
            selectedItems.splice(index, 1)
            carousel1.find('.carousel').each(function (carouselIndex) {
                if (index < $(this).attr('data-position')) {
                    $(this).attr('data-position', $(this).attr('data-position') - 1);
                }
            });
            carousel2.trigger('remove.owl.carousel', [index]).trigger('refresh.owl.carousel');
        }
        j--;
    }
});

$('#campaignName').keyup(function () {
    $('#lblcampaignName').html(this.value);
});

$('#agencyID').change(function () {
    var selectedText = $(this).find("option:selected").text();
    $('#lblagencyName').html(selectedText);
});

$('#brandID').change(function () {
    var selectedText = $(this).find("option:selected").text();
    $('#lblbrandName').html(selectedText);
});

$(document).ready(function () {

    carousel1.owlCarousel({
        rtl: KTUtil.isRTL(),
        items: 2,
        loop: true,
        center: true,
    });

    carousel2.owlCarousel({
        rtl: KTUtil.isRTL(),
        items: 1,
        animateIn: 'fadeIn(100)',
        loop: true
    });



    $(document).on('click', '.carousel', function () {
        console.log("click");
        var index = $(this).attr('data-position');
        if (index) {
            ChangeCarouselPosition(carousel1, index);
            ChangeCarouselPosition(carousel2, index);
        }
    });

    carousel1.on('changed.owl.carousel', function () {
        console.log("do nothing changed.owl.carousel1");
    });

    carousel2.on('changed.owl.carousel', function () {
        console.log("do nothing changed.owl.carousel2");
    });

    carousel1.on('dragged.owl.carousel', function () {
        console.log("dragged.owl.carousel1");
        var index = $(this).find('.owl-item.active').find('.carousel').attr('data-position');
        if (index) {
            ChangeCarouselPosition(carousel1, index);
            ChangeCarouselPosition(carousel2, index);
        }
    });

    carousel2.on('dragged.owl.carousel', function () {
        console.log("dragged.owl.carousel2");
        var index = $(this).find('.owl-item.active').find('.carousel').attr('data-position');
        if (index) {
            ChangeCarouselPosition(carousel1, index);
            ChangeCarouselPosition(carousel2, index);
        }
    });
});


function ReviewPlatformWriter(obj) {
    var id = obj.getAttribute('id');
    var value = obj.value;
    id = id.replace("Platform_", "");
    var element = $('#hidPlatform_' + id).val(value);
    console.log(element);
    console.log(element.val());
    console.log(value);
}

function ChangeCarouselPosition(carousel, index) {
    carousel.trigger('to.owl.carousel', index);
}

function CreateCarouselItem(name, index, value) {
    var html = '<input type="hidden" id="hidPlatform_' + value + '" name="hidPlatform_' + value + '">';
    var area = $('#hid_values');
    area.append(html);

    html = '<input type="hidden" id="hidScriptText_' + value + '" name="hidScriptText_' + value + '">';
    area.append(html);

    carousel2.trigger('add.owl.carousel', [`<div class="carousel" data-position="${index}">
       <div class="form-group">
            <label for="exampleTextarea">Platform : </label>
            <select name="Platform_${value}" id="Platform_${value}" class="form-control"  onchange="ReviewPlatformWriter(this);">
                <option value="0" selected="selected">Lütfen seçiniz</option>
                <option value="1">Appnexus</option>
                <option value="2">Google</option>
                <option value="3">Adform</option>
            </select>
        </div>
        <div class="form-group">
            <label for="exampleTextarea">Ad Serve JS Tag - ${name} - Audience : 320x50</label>
            <textarea class="form-control" id="ScriptText_1_${value}" name="ScriptText_1_${value}" rows="3"></textarea>
            <span class="form-text text-muted">Please input SCRIPT code for mapping</span>
        </div>
        <br/>
        <hr />
        <br/>
        <div class="form-group">
            <label for="exampleTextarea">Ad Serve JS Tag - ${name} - Audience: 320x100</label>
            <textarea class="form-control" id="ScriptText_2_${value}" name="ScriptText_2_${value}" rows="3"></textarea>
            <span class="form-text text-muted">Please input SCRIPT code for mapping</span>
        </div>
        <br/>
        <hr />
        <br/>
        <div class="form-group">
            <label for="exampleTextarea">Ad Serve JS Tag - ${name} - Audience: 300x250</label>
            <textarea class="form-control" id="ScriptText_3_${value}" name="ScriptText_3_${value}" rows="3"></textarea>
            <span class="form-text text-muted">Please input SCRIPT code for mapping</span>
        </div>
        <br/>
        <hr />
        <br/>
        <div class="form-group">
            <label for="exampleTextarea">Ad Serve JS Tag - ${name} - Audience: 728x90</label>
            <textarea class="form-control" id="ScriptText_4_${value}" name="ScriptText_4_${value}" rows="3"></textarea>
            <span class="form-text text-muted">Please input SCRIPT code for mapping</span>
        </div>
        <br/>
        <hr />
        <br/>
        <div class="form-group">
            <label for="exampleTextarea">Ad Serve JS Tag - ${name} - Audience: 160x600</label>
            <textarea class="form-control" id="ScriptText_5_${value}" name="ScriptText_5_${value}" rows="3"></textarea>
            <span class="form-text text-muted">Please input SCRIPT code for mapping</span>
        </div>
    </div>`]).trigger('refresh.owl.carousel');

}




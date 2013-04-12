function fixJqForm(formName, partialLoad) {
    if (partialLoad) {
        fixSelect($(formName));
        $(formName).jqTransform({ imgPath: 'images/' });
    }
}

function fixSelect(selector) {
    selectedVal = $(selector).children(':selected').val();
    $(selector).children('option').removeAttr('selected');
    $(selector).children('option[value="' + selectedVal + '"]').attr('selected', 'selected');

    $(selector).removeClass('jqTransformHidden');
    $(selector).css('display', 'block');
    $(selector).prev('ul').remove();
    $(selector).prev('div.selectWrapper').remove();

    var selectElm = $(selector).closest('.jqTransformSelectWrapper').html();

    $(selector).closest('.jqTransformSelectWrapper').after(selectElm);
    $(selector).closest('.jqTransformSelectWrapper').remove();

    $(selector).closest('form').removeClass('jqtransformdone');
    $(selector).closest('form').jqTransform();
}

function changeControlVisibility(controlName, visibility) {
    if (visibility == "hide") {        
        $('#' + controlName).hide();
    }

    if (visibility == "show") {
        $('#' + controlName).removeClass("invisible");
        $('#' + controlName).show();
    }
}
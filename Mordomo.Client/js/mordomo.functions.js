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

function showForm(personType, hdnField) {
    changeControlVisibility("pnlForm", "show");        
    changeControlVisibility("pnlPerson", "hide");
    changeControlVisibility("pnlForm", "show");

    if (personType == "legal") {
        changeControlVisibility("pnlPhysicalPerson", "hide");
        changeControlVisibility("pnlLegalPerson", "show");
    }
    else if (personType == "physical") {
        changeControlVisibility("pnlLegalPerson", "hide");
        changeControlVisibility("pnlPhysicalPerson", "show");
    }

    $(hdnField).val(personType);
    $('.pro_form').jqTransform({ imgPath: 'images/' });
}

function changePerson() {
    //Reset Form
    changeControlVisibility("pnlPerson", "show");
    changeControlVisibility("pnlForm", "hide");
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

function loadFormDropDownLists(state, city, andressType, hdnCity, hdnAndressType) {    
    loadDropDown("/WebService/LoadFormData.asmx", "GetStates2", state, "", "promptText: 'Selecionar...'");    
    loadDropDown("/WebService/LoadFormData.asmx", "GetCities2", city, "cityLoading", "stateId: '0', promptText: 'Selecionar...'");
    loadDropDown("/WebService/LoadFormData.asmx", "GetAndressTypes", andressType, "", "promptText: 'Selecionar...'");
    
    $(state).change(function () {
        var value = $(state + ' option:selected').val();
        $(city).html("");
        changeControlVisibility("cityLoading", "show")
        $(city).removeAttr('disabled');
        loadDropDown("/WebService/LoadFormData.asmx", "GetCities2", city, "cityLoading", "stateId: '" + value + "', promptText: 'Selecionar...'");        
    });

    $(city).change(function () {
        var value = $(city + ' option:selected').val();
        $(hdnCity).val(value);
    });

    $(andressType).change(function () {
        var value = $(andressType + ' option:selected').val();
        $(hdnAndressType).val(value);
    });
}

function loadDropDown(service, method, controlId, loadingId, params) {        
    $.ajax({
        type: "POST",
        url: service + "/" + method,
        data: "{" + params + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            bindDropDown(msg.d, controlId, loadingId);
        }
    });
}

function bindDropDown(msg, controlId, loadingId) {    
    
    $.each(msg, function () {
        $(controlId).append($("<option></option>").val(this['ID']).html(this['Name']));
    });
    changeControlVisibility(loadingId, "hide");
}
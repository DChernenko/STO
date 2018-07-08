//$(function () {
//    $('#TypeCar').change(function () {
//        GetTypeCar();
//    });
//    GetTypeCar();
//});

$(function () {
    $('#TypeCar').change(function () {
        GetCarTypeView();
    });
    GetCarTypeView();
});

function GetCarTypeView() {
    var listItem = GetListItemSelectedVal();
    $("#typeCar").load(listItem, function (data) {
        setValidation();
    });
};


setValidation = function () {
    $("form").each(function () { $.data($(this)[0], 'validator', false); });
    $.validator.unobtrusive.parse("form");
}
function GetListItemSelectedVal() {
    return $("#TypeCar option:selected").val();
};

/*
var response = {};
function GetTypeCar() {
    $.ajax({
        url: '/Home/GetServices/' + GetListItemSelectedVal(),
        type: 'GET',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //console.log(data);
            WriteResponse(data);
        }
    });
};

function GetListItemSelectedVal() {
    return $("#TypeCar option:selected").val();
};

function ClearStaticField() {
    $(".form-horizontal").children().not("div[id='baseControls']").remove();//поправить
};

function GetNumberCarVal() {
    return $("#NumberCar").val();
}

function WriteResponse(data) {
    if (data) {
        ClearStaticField();
        var form = $(".form-horizontal");
        var jsonDatas = JSON.parse(data);
        response = JSON.parse(data);
        for (var i = 0; i < jsonDatas.length; i++) {
            var inputName = 'Services' + i;
            var divControlGroup = $("<div/>").addClass('form-group row');
            var label = $("<label/>")
                .addClass('col-sm-4 col-form-label')
                .attr("for", inputName)
                .text(jsonDatas[i].Service.Name);

            var divControls = $("<div/>").addClass('col-sm-6');
            var input =
                jsonDatas[i].Service.IsAddService ?
                    $('<input/>').attr({ type: 'checkbox', name: inputName }) :
                    $('<input/>').attr({ type: 'text', name: inputName })
                        .addClass("form-control text-right");
            divControls.append(input);
            divControlGroup.append(label);
            divControlGroup.append(divControls);
            form.append(divControlGroup);
        }
        var button = $('<button/>')
            .attr({ type: 'button', value: 'Добавить' })
            .addClass("btn btn-lg btn-primary").text("Добавить").click(function () {
                var service = {
                    TypeCarId: GetListItemSelectedVal(),
                    NumberCar: GetNumberCarVal(),
                    Services: []
                };
                $(arguments[0].currentTarget.form).find('input').not($("#NumberCar")).each(function (index, item) {
                    switch (item.type) {
                        case "text":
                            service.Services.push({
                                key: response[index].ServiceId,
                                value: parseInt($(item).val() ? $(item).val() : "0")
                            });
                            break;
                        case "checkbox":
                            service.Services.push({
                                key: response[index].ServiceId,
                                value: $(item).prop('checked') ? 1 : 0
                            });
                            break;
                        default: break;
                    }
                });
                $.ajax({
                    url: '/Car/AddData',
                    type: 'POST',
                    dataType: "json",
                    data: JSON.stringify(service),
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        console.log(data);
                    }
                });
            });
        form.append(button);
    }
};*/
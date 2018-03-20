$(function () {
    $('#TypeCar').change(function () {
        GetTypeCar()
    });

});
var response = {};
var getListItemSelectedVal = function () {
    return $("#TypeCar option:selected").val();
};

function GetTypeCar() {
    $.ajax({
        url: '/Home/GetServices/' + getListItemSelectedVal(),
        type: 'GET',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //console.log(data);
            WriteResponse(data);
        }
    });

};
function ClearStaticField() {
    $(".form-horizontal").children().not("div[class='form-group row']:first").remove();
};

function WriteResponse(data) {
    if (data) {

        ClearStaticField();
        var form = $(".form-horizontal");
        var jsonDatas = JSON.parse(data);
        response = JSON.parse(data);
        for (var i = 0; i < jsonDatas.length; i++) {
            var divControlGroup = $("<div/>").addClass('form-group row');
            var lable = $("<lable/>").addClass('col-sm-2 col-form-label').text(jsonDatas[i].Service.Name);
            var divControls = $("<div/>").addClass('col-3');
            var input =
                jsonDatas[i].Service.IsAddService ?
                    $('<input/>').attr({ type: 'checkbox', name: 'Services' + i }) :
                    $('<input/>').attr({ type: 'text', name: 'Services' + i }).addClass("form-control text-right");

            divControls.append(input);
            divControlGroup.append(lable);
            divControlGroup.append(divControls);
            form.append(divControlGroup);
        }
        var button = $('<button/>')
            .attr({ type: 'button', value: 'Добавить' })
            .addClass("btn btn-lg btn-primary").text("Добавить").click(function () {
                var service = {
                    TypeCarId: getListItemSelectedVal(),
                    Services: []
                };

                $(arguments[0].currentTarget.form).find('input').each(function (index, item) {
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
};
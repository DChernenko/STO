$(function () {
    $('#TypeCar').change(function () {
        GetTypeCar()
    });

});


function GetTypeCar() {
    $.ajax({
        url: '/Home/GetServices/' + $("#TypeCar option:selected").val(),
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
        for (var i = 0; i < jsonDatas.length; i++) {
            var divControlGroup = $("<div/>").addClass('form-group row');
            var lable = $("<lable/>").addClass('col-sm-2 col-form-label').text(jsonDatas[i].Service.Name);
            var divControls = $("<div/>").addClass('col-3');
            var input =
                jsonDatas[i].Service.IsAddService ?
                    $('<input/>').attr({ type: 'checkbox', name: 'Services' }):
                    $('<input/>').attr({ type: 'text', name: 'Services' }).addClass("form-control text-right");

            divControls.append(input);
            divControlGroup.append(lable);
            divControlGroup.append(divControls);
            form.append(divControlGroup);
        }
        var button = $('<button/>')
            .attr({ type: 'submit', value: 'Добавить' })
            .addClass("btn btn-lg btn-primary").text("Добавить");
        form.append(button);
    }
};
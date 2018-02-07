$(function () {

    console.log("ready!");
    console.log($("#TypeCar option:selected").text());

    //$("#TypeCars").;
    //GetTypeCar();
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
        //accepts: {
        //    text: "application/x-books"
        //},
        success: function (data) {
            //console.log(data);
            WriteResponse(data);
        }
    });
    //url: @Url.RouteUrl(new { controller = "Home", action = "GetServices", id =$("#TypeCars option:selected").val() }),
};
function ClearStaticField() {
    $(".form-horizontal").children().not(".control-group:first").remove();
};

function WriteResponse(data) {
    if (data) {
        ClearStaticField();
        var form = $(".form-horizontal");
        var jsonDatas = JSON.parse(data);
        for (var i = 0; i < jsonDatas.length; i++) {
            var divControlGroup = $("<div/>").addClass('control-group');
            var lable = $("<lable/>").addClass('control-lable').text(jsonDatas[i].Service.Name);
            var divControls = $("<div/>").addClass('controls');
            var input
                =
                jsonDatas[i].Service.IsAddService ?
                    $('<input/>').attr({ type: 'checkbox', name: 'Services' }) :
                    $('<input/>').attr({ type: 'text', name: 'Services' });           
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
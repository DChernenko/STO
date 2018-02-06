$(function () {

    console.log("ready!");
    console.log($("#TypeCars option:selected").text());

    //$("#TypeCars").;
    //GetTypeCar();
    $('#TypeCars').change(function () {
        GetTypeCar()
    });

});


function GetTypeCar() {
    $.ajax({
        url: '/Home/GetServices/' + $("#TypeCars option:selected").val(),
        type: 'GET',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        //accepts: {
        //    text: "application/x-books"
        //},
        success: function (data) {
            console.log(data);
            WriteResponse(data);
        }
    });
    //url: @Url.RouteUrl(new { controller = "Home", action = "GetServices", id =$("#TypeCars option:selected").val() }),
};
function WriteResponse(data) {
    if (data) {
        var form = $(".form-horizontal");
        jsonDatas = JSON.parse(data);


        for (var i = 0; i < jsonDatas.length; i++) {
            var divControlGroup = $("<div/>").addClass('control-group');
            var lable = $("<lable/>").addClass('control-lable').text(jsonDatas[i].Service.Name);
            var divControls = $("<div/>").addClass('controls');
            var input =
                jsonDatas[i].Service.IsAddservices ?
                    $('<input/>').attr({ type: 'checkbox', name: 'chk' }):
            $('<input/>').attr({ type: 'text', name: 'text', value: 'text' });

            //if (!jsonDatas[i].Service.IsAddservices) {
            //    input= $('<input/>').attr({ type: 'text', name: 'text', value: 'text' });
            //}
            //else {
            //    input= $('<input/>').attr({ type: 'checkbox', name: 'chk' });
            //}


            divControlGroup.append(lable);
            form.append(divControlGroup);
        }



        var lable

    }

};
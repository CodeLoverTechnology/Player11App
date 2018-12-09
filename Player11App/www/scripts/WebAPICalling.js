function GetAllTeamInfo()
{
    debugger;
    $.getJSON("api/TeamInfoMaster/GetM_TeamInfoMaster",
        function (Data) {
            $.each(Data, function (key, val) {
                var str = val.name + ': $' + val.cost;
                $('<li/>', { text: str })
                    .appendTo($('#items'));
            });
        });
};



function show() {

    var Id = $('#itId').val();

    $.getJSON("api/items/" + Id,

        function (Data) {

            var str = Data.name + ': $' + Data.cost;

            $('#items').text(str);

        })

        .fail(

        function (jqXHR, textStatus, err) {

            $('#items').text('Error: ' + err);

        });

}
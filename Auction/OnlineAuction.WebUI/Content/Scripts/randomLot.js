$(document).ready(function () {

    var imgList = $('#img-container');
    var textList = $('#text-container');

    setInterval(function () {

        $.ajax({
            type: "POST",
            url: "../Pages/Common/Main.aspx/RandomLotImg",
            data: "{}",
            contentType: "application/json; charset:utf-8",
            dataType: "json",
            success: function (msg) {

                var str = msg.d.split('*/*');


                $(imgList).empty();
                var img = $('<img/>', {
                    width: 120,
                    src: '/DataBase/Images/' + str[0]
                });

                $(imgList).append(img);

                $(textList).empty();
                var text = $('<a/>', {
                    href: str[1],
                    text: str[2]
                });

                $(textList).append(text);
            }

        });


    }, 5000);
});

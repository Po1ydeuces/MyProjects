$(document).ready(function () {


    var fileInput = $('#filefield');

    var imgList = $('#img-container');


    function displayFiles(files) {
        var imageType = /image.*/;

        $.each(files, function (i, file) {

            $(imgList).empty();
            var img = $('<img/>').appendTo(imgList);
            imgList.get(0).file = file;

            var reader = new FileReader();
            reader.onload = (function (aImg) {
                return function (e) {
                    aImg.attr('src', e.target.result);
                    aImg.attr('width', 150);
                };
            })(img);

            reader.readAsDataURL(file);
        });
    }

    fileInput.bind({
        change: function () {
            displayFiles(this.files);
        }
    });



});

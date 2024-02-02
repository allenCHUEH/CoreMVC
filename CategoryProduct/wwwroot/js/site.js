function previewImage(inputFile, img) {
    if (inputFile.files != null && inputFile.files[0] != null) {
        var allowtype = "image.*";
        if (inputFile.files[0].type.match(allowtype)) {
            var reader = new FileReader();
            reader.onload = function (e) {
                img.attr("src", e.target.result);
                img.attr("title", inputFile.files[0].name);
                $(".btn").prop('disabled',false)
            };
            reader.readAsDataURL(inputFile.files[0]);
        }
        else {
            //alert("不支援的檔案上傳格式!");
            $(".btn").prop('disabled', true)
        }
    }
}
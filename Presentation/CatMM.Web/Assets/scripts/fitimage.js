var getHandler = function () {
    var getWrapSize = function () {
        return {
            width: parseInt($("#txt-width").val()),
            height: parseInt($("#txt-height").val())
        };
    };

    var getImgParams = function () {
        var width = parseInt($("#txt-img-width").val()),
            height = parseInt($("#txt-img-height").val()),
            url = $("#txt-url").val(),
            urlWithParams = url;

        if (width > 0 && height > 0) {
            urlWithParams += "?width={0}&height={1}&mode=crop".formatWith(width, height);
        }

        return {
            width: width,
            height: height,
            url: urlWithParams
        };
    }
    var $wraper = $(".fit-container"),
        $img = $wraper.find("img");

    function reflashWrap() {
        var size = getWrapSize();
        $wraper.css({ width: size.width, height: size.height });
    }

    function reflashImg() {
        var params = getImgParams();
        $img.attr("src", params.url);



    }

    function getImageSize(url, callback) {
        var img = new Image(),
            size,
            response = {
                error: false,
                loadSuccess: false
            }
        img.src = url;
        img.onerror = function () {
            response.error = true;
        };

        img.onload = function () {
            response.loadSuccess = true;
        };

        utility.await(function () {
            return response.error || response.loadSuccess;
        }, function () {
            if (response.loadSuccess) {
                size = {
                    width: img.width,
                    height: img.height
                };
                console.log(size);
            }
        });
    }

    return {
        reflashWrap: reflashWrap,
        reloadImg: reflashImg,
        getImageSize: getImageSize
    }
};

var PageHandler = {
    handler: null,
    init: function () {
        this.handler = getHandler();
        this.initData();
        this.initEvent();
    },
    initData: function () {
        var _this = this,
            handler = _this.handler;
        handler.reflashWrap();
        handler.reloadImg();
    },
    initEvent: function () {
        var _this = this;
        $(".container")
        .on("click", "#btn-resetwrap", function () {
            _this.handler.reflashWrap();
            $("img.fit-image").fitimage("fit");
        })
        .on("click", "#btn-reloadimg", function () {
            _this.handler.reloadImg();
            var url = $("#img").attr("src");
            $("img.fit-image").fitimage("setImageSrc", url);
        });

        $("img.fit-image").fitimage();
    }
}

$(function () {
    PageHandler.init();
})
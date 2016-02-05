$(function () {
    var $elem = $("#offsetTest");
    $(window).on("resize", function () {
        var wHeight = $(window).height(),
            bHeight = $(document.body).height(),
            dHeight = $(document).height(),
            hHeight = $("html").height();



        //console.log("WindowsHeight:" + wHeight + "  ;BodyHeight:" + bHeight + "  ;documentHeight:" + dHeight + "  ;HtmlHeight:" + hHeight);

        var offset = $elem.offset();
        console.log("offsetTop:" + offset.top + "  ;offsetLeft:" + offset.left);
        console.log("outerHeight:" + $elem.outerHeight(true) + "   ;innerHeight:" + $elem.innerHeight() + "   ;height:" + $elem.height()+"  ;cssHeight:"+$elem.css("height"));
    });
});
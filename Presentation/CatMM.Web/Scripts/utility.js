//String extensions
String.prototype.formatWith = function () {
    if(arguments.length>0)
    var str = this;
    for (var i = 0, len = arguments.length; i < len; i++) {
        str = str.replace('{' + i + '}', arguments[i]);
    }
    return str;
};

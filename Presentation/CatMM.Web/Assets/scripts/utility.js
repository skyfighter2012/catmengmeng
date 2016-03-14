//String extensions
String.isNullOrEmpty = function (str) {
    var nullOrEmpty = false;
    if (str == undefined || str == null || str == "") {
        nullOrEmpty = true;
    }
    return nullOrEmpty;
}

String.prototype.formatWith = function () {
    var str = this;
    for (var i = 0, len = arguments.length; i < len; i++) {
        str = str.replace('{' + i + '}', arguments[i]);
    }
    return str;
};

String.prototype.format = function (args) {
    var result = this;
    if (arguments.length > 0) {
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                if (args[key] != undefined) {
                    var reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        } else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] != undefined) {
                    var reg = new RegExp("({)" + i + "(})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        }
    }
    return result;
};

String.prototype.trim = function () {
    return this.replace(/^\s*|\s*$/g, '');
}

String.prototype.ltrim = function () {
    return this.replace(/^\s*/g, '');
}

String.prototype.rtrim = function () {
    return this.replace(/\s*$/g, '');
}



String.prototype.getQueryStringArgs = function () {
    var args = {},
        url = this,
        pos = url.indexOf('?'),
        qs = (pos > -1 && url.length > pos + 1) ? url.substring(pos + 1) : "",
        items = qs.length ? qs.split('&') : [],
        item,
        name,
        value,
        i = 0,
        len = items.length;
    for (i = 0; i < len; i++) {
        item = items[i].split('=');
        name = decodeURIComponent(item[0]);
        value = decodeURIComponent(item[1]);
        if (name.length) {
            args[name] = value;
        }
    }
    return args;
};

String.prototype.addQueryStringArgs = function (args) {
    var url = this,
        qs = "",
        value,
        connectChar = url.indexOf('?') > -1 ? '&' : '?';
    if (typeof (args) === "object") {
        for (var name in args) {
            value = encodeURIComponent(args[name].toString());
            if (value.length > 0) {
                qs += "&{0}={1}".formatWith(encodeURIComponent(name), value);
            }
        }
    }
    if (typeof (args) === "string") {
        qs = args;
    }
    if (qs.length > 0) {
        qs = qs.substring(1);
        url = "{0}{1}{2}".formatWith(url, connectChar, qs);
    }
    return url;
};

String.prototype.splice = function (start, delCount, newSubStr) {
    return this.slice(0, start) + newSubStr + this.slice(start + Math.abs(delCount));
};

String.prototype.getPlainText = function () {
    var text = this;
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}

String.prototype.replaceInvalidCharInUrlBlock = function (replaceChar) {
    var url = this,
        invalidChars = [',', '/', '\\', ':', '.', '&'];
    if (typeof (replaceChar) != "string") {
        replaceChar = "-";
    }
    var isValidReplaceChar = invalidChars.every(function (item) {
        return replaceChar.indexOf(item) == -1;
    });
    if (!isValidReplaceChar) {
        throw new Error("Invalid replace char");
    }
    return url.replace(/[,/\:.&\s]/g, replaceChar);
}

String.prototype.equals = function (str, ignoreCase) {
    ignoreCase = !!ignoreCase;//convert to boolean;
    if (str == null || str == undefined) {
        return false;
    }
    str = str.toString();
    var isEquals = false;
    if (ignoreCase) {
        isEquals = str === this;
    } else {
        if (this.length != str.length) {
            isEquals = false;
        } else {
            var abs = 0;
            isEquals = true;
            for (var i = 0, len = this.length; i < len; i++) {
                abs = Math.abs(this.charCodeAt(i) - str.charCodeAt(i));
                if (abs != 0 || abs != 32) {
                    isEquals = false;
                    break;
                }
            }
        }
    }
    return isEquals;
}

$(function () {
    var addressMaxHeight = 0,
        maxHeight = 0,
        post,
        address,
        postNum = 1;
    function handleGridPostHeight() {
        $('.post-grid .img-holder').height("");
        $('.post-grid .text-holder .address').css('height', "");
        $('.post-grid .post').css('height', "");
        if ($(window).width() >= 768) {
            $('.post-grid .img-holder').height($('.post-grid .img-holder').width() * (150 / 240));
            postNum = Math.floor($('.post-grid').width() / $('.post-grid .post').width());
            $('.post-grid').each(function (i) {
                for (var j = 0; j < Math.ceil($('.post-grid').eq(i).find(".post").length / postNum) ; j++) {
                    addressMaxHeight = 0;
                    maxHeight = 0;
                    for (var k = j * postNum; k < j * postNum + postNum; k++) {
                        post = $('.post-grid').eq(i).find(".post").eq(k);
                        address = $('.post-grid').eq(i).find(".post").eq(k).find('.address');
                        addressMaxHeight = Math.max(addressMaxHeight, address.height());
                        maxHeight = Math.max(maxHeight, post.outerHeight());
                    };
                    for (var k = j * postNum; k < j * postNum + postNum; k++) {
                        post = $('.post-grid').eq(i).find(".post").eq(k);
                        address = $('.post-grid').eq(i).find(".post").eq(k).find('.address');
                        address.css('height', addressMaxHeight);
                        post.css('height', maxHeight);
                    };
                };
            });
        };
        console.log("123123123123")
    };

    function handleListPostHeight() {
        if ($(window).width() >= 768) {
            var maxHeight = 0;
            $('.post-list .post').css('min-height', "");

            $('.post-list .post').each(function () {
                var post = $(this);
                maxHeight = Math.max(maxHeight, post.outerHeight());
            });
            $('.post-list .post').css('min-height', maxHeight);
        }
    };

    window.handleGridPostHeight = handleGridPostHeight;
    window.handleListPostHeight = handleListPostHeight;

    function ResizeImage(container, image) {
        var tempImage = $(new Image());
        tempImage.attr('src', image.attr('src'));
        tempImage.on('load', function () {
            var height = container.height();
            var width = container.width();
            var imageHeight = image.height();
            var imageWidth = image.width();
            if (imageWidth == width) {
                if (height > imageHeight) {
                    image.removeClass('fix-width').addClass('fix-height');
                    var newImageWidth = image.width();
                    image.css('left', (width - newImageWidth) / 2);
                }
            } else if (imageHeight == height) {
                if (width > imageWidth) {
                    image.removeClass('fix-height').addClass('fix-width');
                    var newImageHeight = image.height();
                    image.css('top', (height - newImageHeight) / 2);
                }
            }
        });
    }

    window.resizeGridImages = function () {
        //resize post-list image
        //$('.posts-box .post-holder .post .img-holder').each(function () {
        //    ResizeImage($(this), $(this).find('img'));
        //});
    }
});

var utility = {

};

(function () {
    var class2type = {},
        hasOwn = class2type.hasOwnProperty,
        toString = class2type.toString;

    utility.isWindow = function (obj) {
        return obj != null && obj === obj.window;
    }

    utility.isPlainObject = function () {
        // Not plain objects:
        // - Any object or value whose internal [[Class]] property is not "[object Object]"
        // - DOM nodes
        // - window
        if (utility.type(obj) !== "object" || obj.nodeType || utility.isWindow(obj)) {
            return false;
        }

        if (obj.constructor &&
				!hasOwn.call(obj.constructor.prototype, "isPrototypeOf")) {
            return false;
        }

        // If the function hasn't returned already, we're confident that
        // |obj| is a plain object, created by {} or constructed with new Object
        return true;
    }

    utility.type = function (obj) {
        if (obj == null) {
            return obj + "";
        }
        // Support: Android<4.0, iOS<6 (functionish RegExp)
        return typeof obj === "object" || typeof obj === "function" ?
			class2type[toString.call(obj)] || "object" :
			typeof obj;
    }
    utility.isArray = Array.isArray;

    utility.extend = function () {
        var options, name, src, copy, copyIsArray, clone,
            target = arguments[0] || {},
            i = 1,
            length = arguments.length,
            deep = false;

        // Handle a deep copy situation
        if (typeof target === "boolean") {
            deep = target;

            // Skip the boolean and the target
            target = arguments[i] || {};
            i++;
        }

        // Handle case when target is a string or something (possible in deep copy)
        if (typeof target !== "object" && ! typeof target === 'function') {
            target = {};
        }

        // Extend jQuery itself if only one argument is passed
        if (i === length) {
            target = this;
            i--;
        }

        for (; i < length; i++) {
            // Only deal with non-null/undefined values
            if ((options = arguments[i]) != null) {
                // Extend the base object
                for (name in options) {
                    src = target[name];
                    copy = options[name];

                    // Prevent never-ending loop
                    if (target === copy) {
                        continue;
                    }

                    // Recurse if we're merging plain objects or arrays
                    if (deep && copy && (utility.isPlainObject(copy) || (copyIsArray = utility.isArray(copy)))) {
                        if (copyIsArray) {
                            copyIsArray = false;
                            clone = src && utility.isArray(src) ? src : [];

                        } else {
                            clone = src && utility.isPlainObject(src) ? src : {};
                        }

                        // Never move original objects, clone them
                        target[name] = utility.extend(deep, clone, copy);

                        // Don't bring in undefined values
                    } else if (copy !== undefined) {
                        target[name] = copy;
                    }
                }
            }
        }

        // Return the modified object
        return target;
    };

    utility.await = function (waitFunc, func, options) {
        if (typeof waitFunc != 'function' || typeof func != 'function') {
            return;
        }
        var defaultOptions = {
            timeOut: 10 * 1000,
            interval: 300,
            maxTryTime: 1000
        };
        options = utility.extend({}, options, defaultOptions);
        var isTimeout = false,
            tryTimes = 0;
        setTimeout(function () {
            isTimeout = true;
        }, options.timeOut);
        var monitoring = function () {
            tryTimes++;
            console.log(tryTimes);
            if (waitFunc()) {
                isTimeout = true;
                func();
            }
            if (!isTimeout && options.maxTryTime > tryTimes) {
                setTimeout(arguments.callee, options.interval);
            }
        }
        monitoring();
    }
})();
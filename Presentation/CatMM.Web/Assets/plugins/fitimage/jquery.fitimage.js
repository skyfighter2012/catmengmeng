/*!
 * Fit image 1.0.0.0 
 */
if (typeof jQuery === 'undefined') {
	throw new Error('requires jQuery');
}
(function ($) {
	'use strict';

	// Will extend it later
	var alignPos = {
		leftTop: "leftTop",
		rightTop: "rightTop",
		rightBottom: "rightBottom",
		leftBottom: "leftBottom",
		center: "center"
	};

	function FitImage(element, options) {
		this.$element = $(element);
		this.$wrapper = $(element).parent();
		this.options = $.extend({}, FitImage.DEFAULTS, options);
		this.hasLoad = false;
		this.imageSize = null;
		this.init(element);
	}

	FitImage.prototype.setImageSrc = function (url) {
		var _this = this;
		this.hasLoad = false;
		this.imageSize = null;
		_this.$element.removeClass("fit-complete");
		_this.$element.off("load.fitimage")
					  .off("error.fitimage");

		var img = new Image();
		img.src = url;
		img.onload = function () {
			_this.imageSize = {
				width: img.width,
				height: img.height
			};

			_this.$element
				.removeAttr("src")
				.attr("src", url)
				.on("load.fitimage", function () {
					_this.hasLoad = true;
					_this.fit();
				})
				.on("error.fitimage", function () {
					if (typeof _this.options.onLoadFailed == "function") {
						_this.options.onLoadFailed();
					}
				});
		}
	}

	FitImage.prototype.fit = function () {
		if (!this.hasLoad) {
			return;
		}
		var _this = this;
		var wWidth = _this.$wrapper.width(),
			wHeight = _this.$wrapper.height(),
			tarWidth, tarHeight,
			stretchDirection = "",
			top, left;
		if (_this.imageSize.width / _this.imageSize.height > wWidth / wHeight) {
			// Stretch vertical
			stretchDirection = "vertical";
			tarHeight = wHeight;
			tarWidth = tarHeight * _this.imageSize.width / _this.imageSize.height;
		} else {
			// Stretch horization
			stretchDirection = "horizontal";
			tarWidth = wWidth;
			tarHeight = tarWidth * _this.imageSize.height / _this.imageSize.width;
		}
		
		// Set image align
		switch (_this.options.align) {
			default:
				// Default center
				if (stretchDirection == "horizontal") {
					top = -(tarHeight - wHeight) / 2;
					left = 0;
				} else {
					left = -(tarWidth - wWidth) / 2;
					top = 0;
				}
		}
		_this.$element.css({ width: tarWidth, height: tarHeight });
		_this.$element.css({ left: left, top: top });
		_this.$element.addClass("fit-complete");
	}

	FitImage.prototype.init = function (element) {
		var src = $(element).attr("src");
		this.setImageSrc(src);
	}

	FitImage.DEFAULTS = {
		align: alignPos.center
	};

	function Plugin(option) {
		var args = arguments;
		return this.each(function () {
			var $this = $(this),
			    data = $this.data('realnext.fitimage'),
				options = typeof option == 'object' && option,
				isImg = $this[0].tagName.toLowerCase() == "img";
			// Check valid;
			if (isImg) {
				if (!data) $this.data('realnext.fitimage', (data = new FitImage(this, options)))
				// Invoke instance method
				if (typeof option == 'string') {
					var fun = data[option];
					if (typeof fun == "function") {
						fun.apply(data, Array.prototype.slice.call(args, 1));
					}
				}
			}
		})
	}

	$.fn.fitimage = Plugin;
})(jQuery);
webpackJsonp([1],{

/***/ 55:
/***/ function(module, exports, __webpack_require__) {

	var map = {
		"./AmendmentBroker": 56,
		"./AmendmentBroker.js": 56,
		"./AmendmentsView": 48,
		"./AmendmentsView.js": 48,
		"./AppView": 1,
		"./AppView.js": 1,
		"./AreaView": 46,
		"./AreaView.js": 46,
		"./AtomView": 40,
		"./AtomView.js": 40,
		"./BlockEditorView": 37,
		"./BlockEditorView.js": 37,
		"./ComponentViewFactory": 39,
		"./ComponentViewFactory.js": 39,
		"./ContainerView": 42,
		"./ContainerView.js": 42,
		"./DomHelper": 33,
		"./DomHelper.js": 33,
		"./EditTemplateView": 30,
		"./EditTemplateView.js": 30,
		"./HomeView": 27,
		"./HomeView.js": 27,
		"./LoadingView": 5,
		"./LoadingView.js": 5,
		"./MaskView": 34,
		"./MaskView.js": 34,
		"./PropertiesView": 50,
		"./PropertiesView.js": 50,
		"./PropertyView": 52,
		"./PropertyView.js": 52,
		"./StateBroker": 51,
		"./StateBroker.js": 51,
		"./ToolboxView": 58,
		"./ToolboxView.js": 58,
		"./WidgetView": 44,
		"./WidgetView.js": 44,
		"./WysiwygComponentView": 32,
		"./WysiwygComponentView.js": 32,
		"./WysiwygEditorView": 31,
		"./WysiwygEditorView.js": 31,
		"./appView1": 77,
		"./appView1.js": 77
	};
	function webpackContext(req) {
		return __webpack_require__(webpackContextResolve(req));
	};
	function webpackContextResolve(req) {
		return map[req] || (function() { throw new Error("Cannot find module '" + req + "'.") }());
	};
	webpackContext.keys = function webpackContextKeys() {
		return Object.keys(map);
	};
	webpackContext.resolve = webpackContextResolve;
	module.exports = webpackContext;
	webpackContext.id = 55;


/***/ },

/***/ 77:
/***/ function(module, exports, __webpack_require__) {

	var Backbone = __webpack_require__(2);
	var template = __webpack_require__(78);
	
	module.exports = Backbone.View.extend({
	    el: '#app',
	
	    template: template,
	
	    render: function () {
	        this.$el.html(this.template());
	
	        return this;
	    }
	});


/***/ },

/***/ 78:
/***/ function(module, exports, __webpack_require__) {

	var Handlebars = __webpack_require__(7);
	module.exports = (Handlebars["default"] || Handlebars).template({"compiler":[7,">= 4.0.0"],"main":function(container,depth0,helpers,partials,data) {
	    return "<h1>The Application!</h1>\r\n";
	},"useData":true});

/***/ }

});
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vLi9hcHAvdmlld3MgXlxcLlxcLy4qJCIsIndlYnBhY2s6Ly8vLi9hcHAvdmlld3MvYXBwVmlldzEuanMiLCJ3ZWJwYWNrOi8vLy4vYXBwL3RlbXBsYXRlcy9BcHBUZW1wbGF0ZS5oYnMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6Ijs7Ozs7QUFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxrQ0FBaUMsdURBQXVEO0FBQ3hGO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOzs7Ozs7OztBQ3ZEQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0EsRUFBQzs7Ozs7Ozs7QUNiRDtBQUNBLGtFQUFpRTtBQUNqRTtBQUNBLEVBQUMsZ0JBQWdCLEUiLCJmaWxlIjoiMS5rb2xhLmpzIiwic291cmNlc0NvbnRlbnQiOlsidmFyIG1hcCA9IHtcblx0XCIuL0FtZW5kbWVudEJyb2tlclwiOiA1Nixcblx0XCIuL0FtZW5kbWVudEJyb2tlci5qc1wiOiA1Nixcblx0XCIuL0FtZW5kbWVudHNWaWV3XCI6IDQ4LFxuXHRcIi4vQW1lbmRtZW50c1ZpZXcuanNcIjogNDgsXG5cdFwiLi9BcHBWaWV3XCI6IDEsXG5cdFwiLi9BcHBWaWV3LmpzXCI6IDEsXG5cdFwiLi9BcmVhVmlld1wiOiA0Nixcblx0XCIuL0FyZWFWaWV3LmpzXCI6IDQ2LFxuXHRcIi4vQXRvbVZpZXdcIjogNDAsXG5cdFwiLi9BdG9tVmlldy5qc1wiOiA0MCxcblx0XCIuL0Jsb2NrRWRpdG9yVmlld1wiOiAzNyxcblx0XCIuL0Jsb2NrRWRpdG9yVmlldy5qc1wiOiAzNyxcblx0XCIuL0NvbXBvbmVudFZpZXdGYWN0b3J5XCI6IDM5LFxuXHRcIi4vQ29tcG9uZW50Vmlld0ZhY3RvcnkuanNcIjogMzksXG5cdFwiLi9Db250YWluZXJWaWV3XCI6IDQyLFxuXHRcIi4vQ29udGFpbmVyVmlldy5qc1wiOiA0Mixcblx0XCIuL0RvbUhlbHBlclwiOiAzMyxcblx0XCIuL0RvbUhlbHBlci5qc1wiOiAzMyxcblx0XCIuL0VkaXRUZW1wbGF0ZVZpZXdcIjogMzAsXG5cdFwiLi9FZGl0VGVtcGxhdGVWaWV3LmpzXCI6IDMwLFxuXHRcIi4vSG9tZVZpZXdcIjogMjcsXG5cdFwiLi9Ib21lVmlldy5qc1wiOiAyNyxcblx0XCIuL0xvYWRpbmdWaWV3XCI6IDUsXG5cdFwiLi9Mb2FkaW5nVmlldy5qc1wiOiA1LFxuXHRcIi4vTWFza1ZpZXdcIjogMzQsXG5cdFwiLi9NYXNrVmlldy5qc1wiOiAzNCxcblx0XCIuL1Byb3BlcnRpZXNWaWV3XCI6IDUwLFxuXHRcIi4vUHJvcGVydGllc1ZpZXcuanNcIjogNTAsXG5cdFwiLi9Qcm9wZXJ0eVZpZXdcIjogNTIsXG5cdFwiLi9Qcm9wZXJ0eVZpZXcuanNcIjogNTIsXG5cdFwiLi9TdGF0ZUJyb2tlclwiOiA1MSxcblx0XCIuL1N0YXRlQnJva2VyLmpzXCI6IDUxLFxuXHRcIi4vVG9vbGJveFZpZXdcIjogNTgsXG5cdFwiLi9Ub29sYm94Vmlldy5qc1wiOiA1OCxcblx0XCIuL1dpZGdldFZpZXdcIjogNDQsXG5cdFwiLi9XaWRnZXRWaWV3LmpzXCI6IDQ0LFxuXHRcIi4vV3lzaXd5Z0NvbXBvbmVudFZpZXdcIjogMzIsXG5cdFwiLi9XeXNpd3lnQ29tcG9uZW50Vmlldy5qc1wiOiAzMixcblx0XCIuL1d5c2l3eWdFZGl0b3JWaWV3XCI6IDMxLFxuXHRcIi4vV3lzaXd5Z0VkaXRvclZpZXcuanNcIjogMzEsXG5cdFwiLi9hcHBWaWV3MVwiOiA3Nyxcblx0XCIuL2FwcFZpZXcxLmpzXCI6IDc3XG59O1xuZnVuY3Rpb24gd2VicGFja0NvbnRleHQocmVxKSB7XG5cdHJldHVybiBfX3dlYnBhY2tfcmVxdWlyZV9fKHdlYnBhY2tDb250ZXh0UmVzb2x2ZShyZXEpKTtcbn07XG5mdW5jdGlvbiB3ZWJwYWNrQ29udGV4dFJlc29sdmUocmVxKSB7XG5cdHJldHVybiBtYXBbcmVxXSB8fCAoZnVuY3Rpb24oKSB7IHRocm93IG5ldyBFcnJvcihcIkNhbm5vdCBmaW5kIG1vZHVsZSAnXCIgKyByZXEgKyBcIicuXCIpIH0oKSk7XG59O1xud2VicGFja0NvbnRleHQua2V5cyA9IGZ1bmN0aW9uIHdlYnBhY2tDb250ZXh0S2V5cygpIHtcblx0cmV0dXJuIE9iamVjdC5rZXlzKG1hcCk7XG59O1xud2VicGFja0NvbnRleHQucmVzb2x2ZSA9IHdlYnBhY2tDb250ZXh0UmVzb2x2ZTtcbm1vZHVsZS5leHBvcnRzID0gd2VicGFja0NvbnRleHQ7XG53ZWJwYWNrQ29udGV4dC5pZCA9IDU1O1xuXG5cblxuLyoqKioqKioqKioqKioqKioqXG4gKiogV0VCUEFDSyBGT09URVJcbiAqKiAuL2FwcC92aWV3cyBeXFwuXFwvLiokXG4gKiogbW9kdWxlIGlkID0gNTVcbiAqKiBtb2R1bGUgY2h1bmtzID0gMVxuICoqLyIsInZhciBCYWNrYm9uZSA9IHJlcXVpcmUoJ2JhY2tib25lJyk7XHJcbnZhciB0ZW1wbGF0ZSA9IHJlcXVpcmUoJ2FwcC90ZW1wbGF0ZXMvQXBwVGVtcGxhdGUuaGJzJyk7XHJcblxyXG5tb2R1bGUuZXhwb3J0cyA9IEJhY2tib25lLlZpZXcuZXh0ZW5kKHtcclxuICAgIGVsOiAnI2FwcCcsXHJcblxyXG4gICAgdGVtcGxhdGU6IHRlbXBsYXRlLFxyXG5cclxuICAgIHJlbmRlcjogZnVuY3Rpb24gKCkge1xyXG4gICAgICAgIHRoaXMuJGVsLmh0bWwodGhpcy50ZW1wbGF0ZSgpKTtcclxuXHJcbiAgICAgICAgcmV0dXJuIHRoaXM7XHJcbiAgICB9XHJcbn0pO1xyXG5cblxuXG4vKioqKioqKioqKioqKioqKipcbiAqKiBXRUJQQUNLIEZPT1RFUlxuICoqIC4vYXBwL3ZpZXdzL2FwcFZpZXcxLmpzXG4gKiogbW9kdWxlIGlkID0gNzdcbiAqKiBtb2R1bGUgY2h1bmtzID0gMVxuICoqLyIsInZhciBIYW5kbGViYXJzID0gcmVxdWlyZShcIkM6XFxcXHByb2plY3RzXFxcXGtvbGFcXFxcc3JjXFxcXEtvbGEuQ2xpZW50XFxcXG5vZGVfbW9kdWxlc1xcXFxoYW5kbGViYXJzXFxcXHJ1bnRpbWUuanNcIik7XG5tb2R1bGUuZXhwb3J0cyA9IChIYW5kbGViYXJzW1wiZGVmYXVsdFwiXSB8fCBIYW5kbGViYXJzKS50ZW1wbGF0ZSh7XCJjb21waWxlclwiOls3LFwiPj0gNC4wLjBcIl0sXCJtYWluXCI6ZnVuY3Rpb24oY29udGFpbmVyLGRlcHRoMCxoZWxwZXJzLHBhcnRpYWxzLGRhdGEpIHtcbiAgICByZXR1cm4gXCI8aDE+VGhlIEFwcGxpY2F0aW9uITwvaDE+XFxyXFxuXCI7XG59LFwidXNlRGF0YVwiOnRydWV9KTtcblxuXG4vKioqKioqKioqKioqKioqKipcbiAqKiBXRUJQQUNLIEZPT1RFUlxuICoqIC4vYXBwL3RlbXBsYXRlcy9BcHBUZW1wbGF0ZS5oYnNcbiAqKiBtb2R1bGUgaWQgPSA3OFxuICoqIG1vZHVsZSBjaHVua3MgPSAxXG4gKiovIl0sInNvdXJjZVJvb3QiOiIifQ==
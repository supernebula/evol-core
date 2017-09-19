// JavaScript Document
var mySwiper = new Swiper('.swiper-container', {
    speed: 30,
    freeMode: true,
    freeModeSticky: true,
    //freeModeMomentumRatio: 1,
    shortSwipes: false,

    freeModeMomentumVelocityRatio: 5,
    freeModeMomentumBounce : false,
    slidesPerView: 3,
    slideToClickedSlide: true,
	  centeredSlides : true,
	  watchSlidesProgress: true,
	  pagination : '.swiper-pagination',
      //paginationClickable: true, //分页器
      //onTransitionEnd: function (swiper) {
      //    alert("onTransitionEnd:" + swiper.activeIndex);
      //  //console.log(swiper.activeIndex) //切换结束时，告诉我现在是第几个slide
      //},
      onSlideChangeEnd: function(swiper){
      //    console.log(swiper.activeIndex); //回调函数，swiper从一个slide过渡到另一个slide结束时执行。
          //alert("onSlideChangeEnd:" + swiper.activeIndex);
       },
	  onProgress: function(swiper){
        for (var i = 0; i < swiper.slides.length; i++){
          var slide = swiper.slides[i];
          var progress = slide.progress;
		  scale = 1 - Math.min(Math.abs(progress * 0.2), 1);
        
         es = slide.style;
         es.opacity = 1 - Math.min(Math.abs(progress / 2), 1) + 0.7;
        
         es.webkitTransform = es.MsTransform = es.msTransform = es.MozTransform = es.OTransform = es.transform = 'translate3d(0px,' + (-Math.abs(progress * 20)) + 'px,'+(-Math.abs(progress*200))+'px)';

        }
      },

     onSetTransition: function(swiper, speed) {
      	for (var i = 0; i < swiper.slides.length; i++) {
				es = swiper.slides[i].style;
				es.webkitTransitionDuration = es.MsTransitionDuration = es.msTransitionDuration = es.MozTransitionDuration = es.OTransitionDuration = es.transitionDuration = speed + 'ms';
		}

      }
  });
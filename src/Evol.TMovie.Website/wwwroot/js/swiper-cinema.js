// JavaScript Document
var mySwiper = new Swiper('.swiper-container', {
    speed: 3000,
    freeMode: true,
    freeModeSticky: true,
    freeModeMomentumVelocityRatio: 5,
	  slidesPerView : 'auto',
	  centeredSlides : true,
	  watchSlidesProgress: true,
	  pagination : '.swiper-pagination',
	  paginationClickable: true,

      onSlideChangeEnd: function(swiper){
        //console.log(swiper.activeIndex) //切换结束时，告诉我现在是第几个slide
      },
      onTouchEnd: function(swiper){
        console.log(swiper.activeIndex) //回调函数，当释放slider时执行。
        },
	  onProgress: function(swiper){
        for (var i = 0; i < swiper.slides.length; i++){
          var slide = swiper.slides[i];
          var progress = slide.progress;
		  scale = 1 - Math.min(Math.abs(progress * 0.2), 1);
        
         es = slide.style;
		 es.opacity = 1 - Math.min(Math.abs(progress/2),1) + 0.7;
				es.webkitTransform = es.MsTransform = es.msTransform = es.MozTransform = es.OTransform = es.transform = 'translate3d(0px,0,'+(-Math.abs(progress*150))+'px)';

        }
      },

     onSetTransition: function(swiper, speed) {
      	for (var i = 0; i < swiper.slides.length; i++) {
				es = swiper.slides[i].style;
				es.webkitTransitionDuration = es.MsTransitionDuration = es.msTransitionDuration = es.MozTransitionDuration = es.OTransitionDuration = es.transitionDuration = speed + 'ms';
		}

      }
  });
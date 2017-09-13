var list = document.querySelector('.counters');
console.log(list)
list.addEventListener('mouseout',function(event){
// event.target.style.display='none';

})
list.addEventListener('mouseover', function (event) {
  var x = setInterval(function () {
    console.log(event.target)
  var myelement=event.target.parentNode.children[1].children[2];
  var enddate =myelement.getAttribute('time');
  var countDownDate = new Date(enddate).getTime();
  var now = new Date().getTime();

  var distance = countDownDate - now;
  
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);
    myelement.innerHTML = days + "d " + hours + "h " + minutes + "m " + seconds + "s ";
    if (distance < 0) {
      clearInterval(x);
      myelement.innerHTML = "Event Ended";
    }
  }, 100);
})




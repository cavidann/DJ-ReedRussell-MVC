var musicList=document.querySelector('.music-list');
var stop=document.querySelectorAll('.stp');

musicList.addEventListener('click',function(e){
    console.log(e.target.className)
    if(e.target.className=='info-btn'){
        e.target.parentNode.children[0].style.height='100%';
    }
    if(e.target.className=='fa fa-times'){
        e.target.parentNode.style.height='0px';
    }
    if(e.target.className=='fa fa-play'){
        for(var i=0;i<stop.length;i++){
            stop[i].pause();
            stop[i].parentNode.children[2].className='fa fa-play';
        }
        e.target.parentNode.children[1].play();
        e.target.className='fa fa-pause';
    }
    else if(e.target.className=='fa fa-pause'){
        e.target.parentNode.children[1].pause();
        e.target.className='fa fa-play';
    }
})

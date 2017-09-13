function PLayer(className) {
var width=document.getElementById('width');
var left= document.getElementById('container');
var stop=document.querySelectorAll(".mytrack"); 

    var self = this;
    var mytrack;
    var barSize = width.children[0].children[0].offsetWidth;
    var currentTime;
    var progressBar;
    var bar;
    console.log(width.children[0].children[0].offsetWidth);

    self.tabs = document.querySelector("." + className);

    self.tabs.addEventListener('click', function (event) {
        var clicked_class = event.target.getAttribute("class");

        if (clicked_class == 'playButton') {
            mytrack = event.target.parentNode.parentNode.parentNode.parentNode.children[0];
            currentTime = event.target.parentNode.parentNode.children[1].children[0];
            progressBar = event.target.parentNode.parentNode.parentNode.children[0].children[0];
            bar = event.target.parentNode.parentNode.parentNode.children[0];
            bar.addEventListener('click', clikedBar, false);
            console.log(bar.offsetLeft);
            playOrPause();
            
        } 
        else if (clicked_class == 'muteButton') {
            mytrack = event.target.parentNode.parentNode.parentNode.parentNode.children[0];
            muteOrUnmute();
        }
        if (clicked_class == 'defaultBar') {
            mytrack = event.target.parentNode.parentNode.children[0];
            currentTime = event.target.parentNode.children[1].children[1].children[0];
            progressBar = event.target.children[0];
            bar = event.target;
            clikedBar(event);
            console.log(clicked_class);
        }



        // functions start
        function playOrPause() {
            if (!mytrack.paused && !mytrack.ended) {
                mytrack.pause();
                event.target.style.backgroundImage = 'url(/Public/img/play.png)';
                window.clearInterval(updateTime);
            }
            else {
                for(var i=0;i<stop.length;i++){
                    stop[i].pause();
                    stop[i].parentNode.children[1].children[1].children[2].children[1].style.backgroundImage = 'url(/Public/img/play.png)';
                }
                mytrack.play();
                event.target.style.backgroundImage = 'url(/Public/img/pause.png)';
                updateTime = setInterval(update, 100);
            }
        }

        function muteOrUnmute() {
            if (mytrack.muted == true) {
                mytrack.muted = false;
                event.target.style.backgroundImage = 'url(/Public/img/speaker.png)';
            }
            else {
                mytrack.muted = true;
                event.target.style.backgroundImage = 'url(/Public/img/mute.png)';
            }
        }

        function update() {
            if (!mytrack.ended) {
                var playedMinutes = parseInt(mytrack.currentTime / 60);
                var playedSeconds = parseInt(mytrack.currentTime % 60);
                if(playedSeconds<10){
                currentTime.innerHTML = playedMinutes + ':0' + playedSeconds;
                }
                else if(!playedSeconds<=10){
                    currentTime.innerHTML = playedMinutes + ':' + playedSeconds;
                }

                var size = parseInt(mytrack.currentTime * barSize / mytrack.duration);
                progressBar.style.width = size + 'px';
                progressBar.style.transition = 10 + 'ms';
            }
            else {
                progressBar.style.width = 100 + '%';
                event.target.style.backgroundImage = 'url(/Public/img/reload.png)';
            }
        }

        function clikedBar(e) {
            if (!mytrack.ended) {
                var mouseX = e.pageX - container.offsetLeft;
                var newtime = mouseX * mytrack.duration / barSize;
                mytrack.currentTime = newtime;
                progressBar.style.width = mouseX + 'px';
                update();
            }
        }



    });

}
var object_name2 = new PLayer("wrapper");

$(document).ready(function () {

    $('#sidebar-btn').click(function () {
        console.log($('#sidebar').width());
        $('#sidebar-btn').toggleClass('visible1');
        $('#sidebar').toggleClass('visible');
    });
    
    var accordion = document.querySelector('#sidebar');
    accordion.addEventListener('click', function (event) {
        var item = event.target;
        if (item.nextElementSibling.style.display == 'block') {
            $(".galery").hide(1000);
            $(".blog").hide(1000);
        } else {
            $(".galery").hide(1000);
            $(".blog").hide(1000);
            if(item.nextElementSibling.className=="blog"){
            $(".blog").show(1000);
            }
            else if(item.nextElementSibling.className=="galery"){
            $(".galery").show(1000);
            }
            console.log(item.nextElementSibling.className)
        }
    });

    $('.daire').click(function(){
        $('html, body').animate({ scrollTop: 0 }, "slow")
        return false;
    })

    $(window).scroll(function () {
        scroll = $(window).scrollTop();
        console.log(scroll)
        if (scroll >= 500) {
            $(".daire").css({
                "position": "fixed",
                "bottom": 40,
                "right": 10
            });
        } else {
            $(".daire").css({
                "position": "absolute",
                "right": "10px",
                "bottom": "-500px"
            });
        }
    });

    var userFeed = new Instafeed({
        get: 'user',
        userId: '1428923967',
        limit: 10,
        resolution: 'standard_resolution',
        accessToken: '1428923967.1677ed0.ae718fd853f44f80a606ff9815938cab',
        sortBy: 'most-recent',
        template: '<div class="instaimg"><a href="{{image}}" title="{{caption}}" target="_blank"><img src="{{image}}" alt="{{caption}}" class="img-fluid"/><i class="fa fa-search" aria-hidden="true"></i></a></div>',
    });


    userFeed.run();


    // This will create a single gallery from all elements that have class "gallery-item"
    $('.gallery').magnificPopup({
        type: 'image',
        delegate: 'a',
        gallery: {
            enabled: true
        }
    });




});


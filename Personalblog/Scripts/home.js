var iframe = document.querySelector('iframe');
var player = new Vimeo.Player(iframe);

player.on('loaded', function (data) {
    $(".background-img").remove();
});
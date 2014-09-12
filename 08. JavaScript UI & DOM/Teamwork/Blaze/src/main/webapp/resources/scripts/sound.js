/*
 *   Initializes a new instance of the Sounds class.
 */
function Sound(url, volume, isLoop)
{
    this.sound = new Howl({
        urls:  [url],
        loop: isLoop || false,
        volume: volume
    });
}

/*
 *   Corrects the constructor pointer.
 */
Sound.prototype.constructor = Sound;

/*
 *   Sound call play method
 */
Sound.prototype.play = function(){
    this.sound.play();
};

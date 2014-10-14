(function() {
  $.fn.gallery = function(col) {
    var $images, $selected, $this, colCount, getNextImage, getPreviousImage, width;
    getPreviousImage = function(index) {
      if (index > 0) {
        return $images.get(index - 1);
      } else {
        return $images.last();
      }
    };
    getNextImage = function(index) {
      if ($images.length > (index + 1)) {
        return $images.get(index + 1);
      } else {
        return $images.first();
      }
    };
    $this = this;
    $selected = $this.find(".selected");
    $images = $this.find(".gallery-list").find("img");
    colCount = (col ? col : 4);
    width = 95 / colCount;
    $this.addClass("gallery");
    $this.find(".image-container").addClass("gallery");
    $this.find(".image-container").css("width", width + "%");
    $selected.hide();
    $this.on("click", "img", function() {
      var $clickedImage, $currentImageContainer, $gallery, $nextImageContainer, $previousImageContainer, currentImage, imageIndex;
      $clickedImage = $(this);
      $currentImageContainer = $selected.find(".current-image");
      $previousImageContainer = $selected.find(".previous-image");
      $nextImageContainer = $selected.find(".next-image");
      $gallery = $this.find(".gallery-list");
      imageIndex = $clickedImage.data("info") - 1;
      currentImage = $($images.get(imageIndex));
      $gallery.parent().addClass("disabled-background");
      if ($clickedImage.data("info") === $currentImageContainer.find("img").data("info")) {
        $selected.hide();
        $gallery.removeClass("blurred");
      } else {
        $selected.show();
        $gallery.addClass("blurred");
      }
      $currentImageContainer.children().remove();
      $previousImageContainer.children().remove();
      $nextImageContainer.children().remove();
      $currentImageContainer.append(currentImage.clone());
      $previousImageContainer.append($(getPreviousImage(imageIndex)).clone());
      $nextImageContainer.append($(getNextImage(imageIndex)).clone());
    });
  };

}).call(this);

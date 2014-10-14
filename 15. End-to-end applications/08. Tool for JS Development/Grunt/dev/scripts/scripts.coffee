$.fn.gallery = (col) ->
  # 95% divided by the given column count
  getPreviousImage = (index) ->
    if index > 0
      $images.get index - 1
    else
      $images.last()
  getNextImage = (index) ->
    if $images.length > (index + 1)
      $images.get index + 1
    else
      $images.first()
  $this = this
  $selected = $this.find(".selected")
  $images = $this.find(".gallery-list").find("img")
  colCount = (if col then col else 4)
  width = 95 / colCount
  $this.addClass "gallery"
  $this.find(".image-container").addClass "gallery"
  $this.find(".image-container").css "width", width + "%"
  $selected.hide()
  $this.on "click", "img", ->
    $clickedImage = $(this)
    $currentImageContainer = $selected.find(".current-image")
    $previousImageContainer = $selected.find(".previous-image")
    $nextImageContainer = $selected.find(".next-image")
    $gallery = $this.find(".gallery-list")
    imageIndex = $clickedImage.data("info") - 1
    currentImage = $($images.get(imageIndex))
    $gallery.parent().addClass "disabled-background"
    if $clickedImage.data("info") is $currentImageContainer.find("img").data("info")
      $selected.hide()
      $gallery.removeClass "blurred"
    else
      $selected.show()
      $gallery.addClass "blurred"
    $currentImageContainer.children().remove()
    $previousImageContainer.children().remove()
    $nextImageContainer.children().remove()
    $currentImageContainer.append currentImage.clone()
    $previousImageContainer.append $(getPreviousImage(imageIndex)).clone()
    $nextImageContainer.append $(getNextImage(imageIndex)).clone()
    return

  return
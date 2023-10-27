$(document).ready(function () {
    let isDragging = false;
    const $selectionRectangle = $("#selection-rectangle");
    const $image = $("#selected-image");
    const $visibleRectangle = $("#visible-rectangle");
    const $coordinates = $("#coordinates");
    const $htmlBody = $("html, body");

    let originalContainerHeight;

    $(document).on("mousedown", function (e) {
        isDragging = true;
        const left = Math.max(0, Math.min($image.width(), e.clientX - $image.offset().left));
        const top = Math.max(0, Math.min($image.height(), e.clientY - $image.offset().top));

        $selectionRectangle.css({
            left,
            top,
            width: 0,
            height: 0,
        });

        $visibleRectangle.css({
            left,
            top,
        });

        $htmlBody.css("overflow", "hidden");
        originalContainerHeight = $image.parent().height();
    });

    $(document).on("mousemove", function (e) {
        if (isDragging) {
            const left = Math.max(0, Math.min($image.width(), e.clientX - $image.offset().left));
            const top = Math.max(0, Math.min($image.height(), e.clientY - $image.offset().top));
            const width = left - parseFloat($selectionRectangle.css('left'));
            const height = top - parseFloat($selectionRectangle.css('top'));

            $selectionRectangle.css({
                width: Math.min($image.width() - parseFloat($selectionRectangle.css('left')), width),
                height: Math.min($image.height() - parseFloat($selectionRectangle.css('top')), height),
            });

            $visibleRectangle.css({
                width: Math.min($image.width() - parseFloat($selectionRectangle.css('left')), width),
                height: Math.min($image.height() - parseFloat($selectionRectangle.css('top')), height),
            });

            return false;
        }
    });

    $(document).on("mouseup", function () {
        isDragging = false;
        updateCoordinates();

        $htmlBody.css("overflow", "auto");
        $image.parent().css("height", originalContainerHeight);

        // Hide the selection rectangle
        $selectionRectangle.css({
            width: 0,
            height: 0,
        });
        $visibleRectangle.css({
            width: 0,
            height: 0,
        });
    });

    function updateCoordinates() {
        const left = parseFloat($selectionRectangle.css('left'));
        const top = parseFloat($selectionRectangle.css('top'));
        const right = left + parseFloat($selectionRectangle.css('width'));
        const bottom = top + parseFloat($selectionRectangle.css('height'));

        $("#top-left").text(`(${left}, ${top})`);
        $("#top-right").text(`(${right}, ${top})`);
        $("#bottom-left").text(`(${left}, ${bottom})`);
        $("#bottom-right").text(`(${right}, ${bottom})`);
    }
});

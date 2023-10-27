// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    let isDragging = false;
    let startX, startY;
    const $selectionRectangle = $("#selection-rectangle");
    const $image = $("#selected-image");
    const $coordinates = $("#coordinates");

    $image.on("mousedown", function (e) {
        isDragging = true;
        startX = e.clientX - $image.offset().left;
        startY = e.clientY - $image.offset().top;

        $selectionRectangle.css({
            left: startX,
            top: startY,
            width: 0,
            height: 0,
        });
    });

    $(document).on("mousemove", function (e) {
        if (isDragging) {
            const width = e.clientX - $image.offset().left - startX;
            const height = e.clientY - $image.offset().top - startY;

            $selectionRectangle.css({
                width,
                height,
            });
        }
    });

    $(document).on("mouseup", function () {
        isDragging = false;
        updateCoordinates();
    });

    function updateCoordinates() {
        const imageOffset = $image.offset();
        const left = startX;
        const top = startY;
        const right = startX + $selectionRectangle.width();
        const bottom = startY + $selectionRectangle.height();

        $("#top-left").text(`(${left}, ${top})`);
        $("#top-right").text(`(${right}, ${top})`);
        $("#bottom-left").text(`(${left}, ${bottom})`);
        $("#bottom-right").text(`(${right}, ${bottom})`);
    }
});
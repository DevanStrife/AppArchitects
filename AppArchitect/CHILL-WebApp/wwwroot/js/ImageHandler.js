/* Declare references and variables */
const canvas = document.getElementById("myCanvas");
const ctx = canvas.getContext("2d");
const coordinatesDiv = document.getElementById("coordinates");
const image = document.getElementById("img");
let isDrawing = false;
let startX, startY, endX, endY;

/* Event Listener for the image file */
image.addEventListener("change", () => {
    const image = new Image();
    const file = image.files[0];
    const reader = new FileReader();
/* Load image */
    reader.onload = (e) => {
        image.src = e.target.result;
        image.onload = () => {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            ctx.drawImage(image, 0, 0, canvas.width, canvas.height);
        };
    };

    reader.readAsDataURL(file);
});
/* Event listeners for mouse functions */
canvas.addEventListener("mousedown", (e) => {
    isDrawing = true;
    startX = e.clientX - canvas.getBoundingClientRect().left;
    startY = e.clientY - canvas.getBoundingClientRect().top;
});

canvas.addEventListener("mousemove", (e) => {
    if (!isDrawing) return;
    endX = e.clientX - canvas.getBoundingClientRect().left;
    endY = e.clientY - canvas.getBoundingClientRect().top;

    ctx.clearRect(0, 0, canvas.width, canvas.height);
    ctx.drawImage(image, 0, 0, canvas.width, canvas.height);
    drawRectangle();
});

canvas.addEventListener("mouseup", () => {
    isDrawing = false;
    getRectangleCoordinates();
});
/* Function to draw the rectangle the user creates over the image/canvas */
function drawRectangle() {
    ctx.beginPath();
    ctx.rect(startX, startY, endX - startX, endY - startY);
    ctx.strokeStyle = "blue";
    ctx.lineWidth = 2;
    ctx.stroke();
}
/* Gets the pairs ofcoordinates of the user drawn rectangle's 4 corners */
function getRectangleCoordinates() {
    const topLeft = { x: startX, y: startY };
    const topRight = { x: endX, y: startY };
    const bottomLeft = { x: startX, y: endY };
    const bottomRight = { x: endX, y: endY };

/* Round up to 2 decimals */
    const roundedTopLeft = { x: topLeft.x.toFixed(2), y: topLeft.y.toFixed(2) };
    const roundedTopRight = { x: topRight.x.toFixed(2), y: topRight.y.toFixed(2) };
    const roundedBottomLeft = { x: bottomLeft.x.toFixed(2), y: bottomLeft.y.toFixed(2) };
    const roundedBottomRight = { x: bottomRight.x.toFixed(2), y: bottomRight.y.toFixed(2) };
/* store on page */
    document.getElementById("x1").value = roundedTopLeft.x;
    document.getElementById("y1").value = roundedTopLeft.y;
    document.getElementById("x2").value = roundedTopRight.x;
    document.getElementById("y2").value = roundedTopRight.y;
    document.getElementById("x3").value = roundedBottomLeft.x;
    document.getElementById("y3").value = roundedBottomLeft.y;
    document.getElementById("x4").value = roundedBottomRight.x;
    document.getElementById("y4").value = roundedBottomRight.y;

}
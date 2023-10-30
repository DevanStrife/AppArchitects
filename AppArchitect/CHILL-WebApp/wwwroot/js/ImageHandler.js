const canvas = document.getElementById("myCanvas");
const ctx = canvas.getContext("2d");
const coordinatesDiv = document.getElementById("coordinates");
const image = document.getElementById("img");
let isDrawing = false;
let startX, startY, endX, endY;

image.addEventListener("change", () => {
    const image = new Image();
    const file = image.files[0];
    const reader = new FileReader();

    reader.onload = (e) => {
        image.src = e.target.result;
        image.onload = () => {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
            ctx.drawImage(image, 0, 0, canvas.width, canvas.height);
        };
    };

    reader.readAsDataURL(file);
});

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

function drawRectangle() {
    ctx.beginPath();
    ctx.rect(startX, startY, endX - startX, endY - startY);
    ctx.strokeStyle = "blue";
    ctx.lineWidth = 2;
    ctx.stroke();
}

function getRectangleCoordinates() {
    const topLeft = { x: startX, y: startY };
    const topRight = { x: endX, y: startY };
    const bottomLeft = { x: startX, y: endY };
    const bottomRight = { x: endX, y: endY };

    const roundedTopLeft = { x: topLeft.x.toFixed(2), y: topLeft.y.toFixed(2) };
    const roundedTopRight = { x: topRight.x.toFixed(2), y: topRight.y.toFixed(2) };
    const roundedBottomLeft = { x: bottomLeft.x.toFixed(2), y: bottomLeft.y.toFixed(2) };
    const roundedBottomRight = { x: bottomRight.x.toFixed(2), y: bottomRight.y.toFixed(2) };

    coordinatesDiv.innerHTML = `
                Top Left: (${roundedTopLeft.x}, ${roundedTopLeft.y})<br>
                Top Right: (${roundedTopRight.x}, ${roundedTopRight.y})<br>
                Bottom Left: (${roundedBottomLeft.x}, ${roundedBottomLeft.y})<br>
                Bottom Right: (${roundedBottomRight.x}, ${roundedBottomRight.y})
            `;
}
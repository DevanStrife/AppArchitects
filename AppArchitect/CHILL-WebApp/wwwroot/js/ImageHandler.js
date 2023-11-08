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
    document.getElementById("x1").value = roundedTopLeft.x; // ERROR: THIS SHIT BREAKS
    console.log("Trying to access element x1");
    const x1Element = document.getElementById("x1");
    console.log(x1Element);

    document.getElementById("y1").value = roundedTopLeft.y;
    console.log("Trying to access element y1");
    const y1Element = document.getElementById("y1");
    console.log(y1Element);

    document.getElementById("x2").value = roundedTopRight.x;
    document.getElementById("y2").value = roundedTopRight.y;
    document.getElementById("x3").value = roundedBottomLeft.x;
    document.getElementById("y3").value = roundedBottomLeft.y;
    document.getElementById("x4").value = roundedBottomRight.x;
    document.getElementById("y4").value = roundedBottomRight.y;

}


document.addEventListener("DOMContentLoaded", function () {
    const labelButtons = document.querySelectorAll(".column-button");

    labelButtons.forEach(function (button) {
        button.addEventListener("click", function (event) {
            event.preventDefault(); // Prevent form submission

            // Get the label ID from the data-label-id attribute
            const labelId = button.getAttribute("data-label-id");

            // Set the selectedLabelId input field
            document.getElementById("selectedLabelId").value = labelId;

            // Get and set the coordinates for the selected label
            /*document.getElementById("x1").value = startX; // Set the correct values
            document.getElementById("y1").value = startY; // Set the correct values
            document.getElementById("x2").value = endX;   // Set the correct values
            document.getElementById("y2").value = startY; // Set the correct values
            document.getElementById("x3").value = startX; // Set the correct values
            document.getElementById("y3").value = endY;   // Set the correct values
            document.getElementById("x4").value = endX;   // Set the correct values
            document.getElementById("y4").value = endY;   // Set the correct values*/
        });
    });

    // Handle the "Bevestig" button click
    const confirmButton = document.querySelector(".confirm-btn");
    confirmButton.addEventListener("click", function (event) {
        event.preventDefault(); // Prevent form submission

        const imageId = document.getElementById("imageId").value;
        const labelId = document.getElementById("selectedLabelId").value; // Get the labelId

        // Create a new FormData object to send the data as form data
        const formData = new FormData();
        formData.append("imageId", imageId);
        formData.append("x1", document.getElementById("x1").value);
        formData.append("y1", document.getElementById("y1").value);
        formData.append("x2", document.getElementById("x2").value);
        formData.append("y2", document.getElementById("y2").value);
        formData.append("x3", document.getElementById("x3").value);
        formData.append("y3", document.getElementById("y3").value);
        formData.append("x4", document.getElementById("x4").value);
        formData.append("y4", document.getElementById("y4").value);
        formData.append("labelId", labelId);

        // Send the data to the server using an AJAX request with the correct content type
        fetch("/Photos/ImageDbUpdate", {
            method: "POST",
            body: formData,  // Use the FormData object
        })
            .then(function (response) {
                // Handle the response from the server
                if (response.ok) {
                    // Handle success
                    alert("Labeling completed successfully! Loading next image.");
                    window.location.reload();
                } else {
                    // Handle error
                    alert("Labeling failed. Please try again.");
                }
            })
            .catch(function (error) {
                console.error("Error:", error);
                alert("An error occurred. Please try again.");
            });
    });
});

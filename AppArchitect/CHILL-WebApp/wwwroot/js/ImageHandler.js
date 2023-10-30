var c1 = document.getElementById("c1"), c2 = document.getElementById("c2");
var ctx1 = c1.getContext("2d"), ctx2 = c2.getContext("2d");
ctx2.setLineDash([5, 5]);
var origin = null;
window.onload = () => { ctx1.drawImage(document.getElementById("img"), 0, 0); }
c2.onmousedown = e => { origin = { x: e.offsetX, y: e.offsetY }; };
window.onmouseup = e => { origin = null; };
c2.onmousemove = e => {
    if (!!origin) {
        ctx2.strokeStyle = "#ff0000";
        ctx2.clearRect(0, 0, c2.width, c2.height);
        ctx2.beginPath();
        ctx2.rect(origin.x, origin.y, e.offsetX - origin.x, e.offsetY - origin.y);
        ctx2.stroke();
    }
};
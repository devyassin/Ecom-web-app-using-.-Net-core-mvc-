// category.js

// Function to change the background color of a button when clicked
function changeButtonColor() {
    const button = document.getElementById("myButton");

    if (button) {
        // Add a click event listener to the button
        button.addEventListener("click", function (e) {
            e.preventDefault();
            const colors = ["red", "green", "blue", "orange", "purple"];
            const currentColor = button.style.backgroundColor;
            const randomColor = colors[Math.floor(Math.random() * colors.length)];

            // Ensure that the new color is different from the current color
            if (currentColor !== randomColor) {
                button.style.backgroundColor = randomColor;
            }
        });
    }
}

    changeButtonColor();


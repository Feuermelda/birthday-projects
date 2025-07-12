document.addEventListener("DOMContentLoaded", () => { // waits until the full html is loaded, so we don't run js before the DOM exists
    const front = document.querySelector(".card-front"); // the front face of the card
    const inside = document.querySelector(".card-inside"); // the birthday message hidden inside
    const button = document.querySelector(".card-action");
    const balloonContainer = document.getElementById("balloon-container"); // the div that holds all the floating balloons
    const audio = document.getElementById("bday-audio"); // querySelector("#bday-audio") works as well and is more flexible yet slightly slower,

    button.addEventListener("click", () => { // waits for the button to be clicked 
        front.classList.add("hidden"); // hides the front
        inside.classList.remove("hidden"); // reveals the message inside
        releaseBalloons(); // start releasing the balloons
        if (audio) {
            audio.play();
        } else {
            console.error("Audio element not found!");
        }
    });

    function releaseBalloons() { // declares a function that creates multiple balloons
        console.log("Releasing balloons!"); // logs to console - for debugging

        for (let i = 0; i < 15; i++) { // loop 15 times to create 15 balloons

            const balloon = document.createElement("div"); // makes a div and gives it the balloon class - which automatically gives it style + animation from css
            balloon.classList.add("balloon");

            const color = ["#FF6B6B", "#FFD93D", "#6BCB77", "#4D96FF", "#B983FF"][Math.floor(Math.random() * 5)]; // chooses a random color from the list using Math.random() and Math.floor()
            balloon.style.backgroundColor = color; // applies it to the balloon's background, backgroundColor = background-color in css

            balloon.style.left = `${Math.random() * 90 + 5}%`; // random horizontal position within 5-95% of the screen width, `` template literals like python f-strings
            balloon.style.animationDuration = `${Math.random() * 3 + 4}s`; // randomizes animation speed (between 4 and 7 seconds) so balloons don't all move the same, adds natural, chaotic floatiness

            // fade-out removal after animation ends
            balloon.addEventListener("animationend", () => { // ()=>{} - arrow function, () - parameters the functions takes, empty means no arguments, => do this next, defines functions behavior, {} - the code block to execute when the function is called
                balloon.remove();
            });

            balloonContainer.appendChild(balloon); // adds the balloon to the page inside the container, without it, balloon only exists in memory but doesn't appear on screen

            // Optional: remove balloon after animation, removes the balloon after 10 seconds to prevent clutter
            //setTimeout(() => {
            //  balloon.remove();
            //}, 10000);

        }
    }
});

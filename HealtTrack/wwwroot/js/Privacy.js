const execBtn = document.getElementById("execBtn");
const dietBtn = document.getElementById("dietBtn");
const execVideos = document.getElementById("execVideos");
const dietVideos = document.getElementById("dietVideos");

execBtn.addEventListener("click", () => {
    dietVideos.classList.remove("dietasShow")
    dietVideos.classList.add("dietasHidden")

    execVideos.classList.remove("exerciciosHidden")
    execVideos.classList.add("exerciciosShow")

    dietBtn.classList.remove("activeTabBtn")
    dietBtn.classList.add("desactiveTabBtn")

    execBtn.classList.remove("desactiveTabBtn")
    execBtn.classList.add("activeTabBtn")
});

dietBtn.addEventListener("click", () => {
    execVideos.classList.remove("exerciciosShow")
    execVideos.classList.add("exerciciosHidden")

    dietVideos.classList.remove("dietasHidden")
    dietVideos.classList.add("dietasShow")

    execBtn.classList.remove("activeTabBtn")
    execBtn.classList.add("desactiveTabBtn")

    dietBtn.classList.remove("desactiveTabBtn")
    dietBtn.classList.add("activeTabBtn")
});
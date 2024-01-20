// It seems doesn't work
// window.addEventListener("appinstalled", () => {
//     console.log("App installed");
//     location.href = "/home"
// });

if (location.href != "/home" && window.matchMedia("(display-mode: browser)").matches) {
    const AppInstalledInterval = setInterval(() => {
        if (window.matchMedia('(display-mode: standalone)').matches) {
            console.log("App installed");
            location.href = "/home"
            clearInterval(AppInstalledInterval);
        }
    }, 500);
}
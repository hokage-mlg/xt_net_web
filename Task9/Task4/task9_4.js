var Pause = false;
(function startTimer() {
    var Timer = document.getElementById("Timer");
    var time = Timer.innerHTML;
    if (time == 0) {
        switch (document.title) {
            case "First Page":
                document.location.href = "/Task4/task9_4_2.html";
                break;
            case "Second Page":
                document.location.href = "/Task4/task9_4_3.html";
                break;
            case "Third Page":
                question();
                return;
            default:
                break;
        }
        return;
    } else {
        if (!Pause) {
            Timer.innerHTML = time - 1;
        }
    }
    setTimeout(startTimer, 1000);
}());
var ButtonGoBack = document.getElementById("GoBack");
ButtonGoBack.onclick = function GoBack() {
    switch (document.title) {
        case "Second Page":
            document.location.href = "/Task4/task9_4_1.html";
            break;
        case "Third Page":
            document.location.href = "/Task4/task9_4_2.html";
            break;
        default:
            break;
    }
}
var ButtonPauseTimer = document.getElementById("PauseTimer");
ButtonPauseTimer.onclick = function PauseTimer() {
    Pause = !Pause;
}
var ButtonRestartTimer = document.getElementById("RestartTimer");
ButtonRestartTimer.onclick = function RestartTimer() {
    if (document.title == "Third Page") {
        document.location.href = "/Task4/task9_4_3.html";
    }
    Pause = false;
    Timer.innerHTML = 5
}

function question() {
    if (window.location.href == "/Task4//Task4/task9_4_1.html" || (window.location.href == "/Task4//Task4/task9_4_2.html" || (window.location.href == "/Task4//Task4/task9_4_3.html"))) {
            confirm("Начать сначала?") ? window.location.href = "/Task4/task9_4_1.html" : window.open('', '_self')
                .close();
        }
    }
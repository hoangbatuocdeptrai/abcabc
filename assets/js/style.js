
function scrollFunction() {

    let currentPosition = document.documentElement.scrollTop;

    if (currentPosition > 20 || document.documentElement.scrollTop > 20) {

        document.querySelector("#logo-white").style.display = "none";
        document.querySelector("#logo-black").style.display = "block";
        document.querySelector(".abc").style.background = "#fff";
        document.querySelector(".btn0").style.color = "green";
        document.querySelector(".btn0").style.border = "1px solid green";
        document.querySelector(".btn1").style.border = "none";
        document.querySelector(".btn1").style.background = "green";

    } else {

        document.querySelector("#logo-white").style.display = "block";
        document.querySelector("#logo-black").style.display = "none";
        document.querySelector(".abc").style.background = "none";
        document.querySelector(".btn0").style.color = "white";
        document.querySelector(".btn0").style.border = "1px solid white";
        document.querySelector(".btn1").style.border = "1px solid #fff";
        document.querySelector(".btn1").style.background = "none";
    }


}




window.onscroll = function () {
    scrollFunction();
};
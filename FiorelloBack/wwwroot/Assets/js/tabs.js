let btn = document.querySelectorAll(".buton")


btn.forEach((button) => {
    button.onclick = function () {
        let dataid = button.getAttribute("data-id")
        btn.forEach((btn)=>{
            btn.classList.remove("active")

        })
        let content = document.getElementById(dataid)

        let contents = document.querySelectorAll(".content")
        contents.forEach((cont) => {
            cont.classList.add("d-none")
        })
        button.classList.add("active")
       
        content.classList.remove("d-none")
    }
})
let btnSecond = document.querySelectorAll(".butons")


btnSecond.forEach((button) => {
    button.onclick = function () {
        let dataid = button.getAttribute("data-id")
        btnSecond.forEach((btn)=>{
            btn.classList.remove("activeSecond")

        })
        let Content = document.getElementById(dataid)

        let Contents = document.querySelectorAll(".Content")
        Contents.forEach((cont) => {
            cont.classList.add("d-none")
        })
        button.classList.add("activeSecond")

        Content.classList.remove("d-none")
    }
})


let btnmain = document.querySelectorAll(".butonmain")

btnmain.forEach((button) => {
    button.onclick = function () {
        let dataid = button.getAttribute("data-id")
        btnmain.forEach((btn)=>{
            btn.classList.remove("activemain")

        })
        let contentmain = document.getElementById(dataid)

        let contentsmain = document.querySelectorAll(".contentmain")
        contentsmain.forEach((cont) => {
            cont.classList.add("d-none")
        })
        button.classList.add("activemain")

        contentmain.classList.remove("d-none")
    }
})
let btnfooter = document.querySelectorAll(".butonfooter")

btnfooter.forEach((button) => {
    button.onclick = function () {
        let dataid = button.getAttribute("data-id")
        btnfooter.forEach((btn)=>{
            btn.classList.remove("activefooter")

        })
        let contentfooter = document.getElementById(dataid)

        let contentsfooter = document.querySelectorAll(".contentfooter")
        contentsfooter.forEach((cont) => {
            cont.classList.add("d-none")
        })
        button.classList.add("activefooter")

        contentfooter.classList.remove("d-none")
    }
})
$(document).ready(function(){
    $(window).scroll(function (e) {
        let position = $(this).scrollTop();
        if (position > 200) {
            $('#stickynavbar').css('display', 'flex');
        } else {
            $('#stickynavbar').css('display', 'none');
        }
    });



    $(window).scroll(function () {
        let scrollPx = $(window).scrollTop()
        if (scrollPx > 500) {
            $("#backToTop").fadeIn(450)
            $("#backToTop").css("display", "flex")
        } else {
            $("#backToTop").fadeOut(450)

        }

    })

    $("#backToTop").click(function () {
        $(window).scrollTop(0)
    })
    
})
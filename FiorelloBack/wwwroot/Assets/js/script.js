$("div#cards div.row > div").mouseenter(function () {
    $(this).find("p:first-child").css({
        "transform": "translateX(-30px)",
        "transition": "transform 0.5s"
    })
    $(this).find("p:last-child").css({
        "transform": "translateX(200px)",
        "transition": "transform 0.5s"
    })
})
$("div#cards div.row > div").mouseleave(function () {
    $(this).find("p:first-child").css({
        "transform": "translateX(-220px)",
        "transition": "transform 0.5s"
    })
    $(this).find("p:last-child").css({
        "transform": "translateX(0)",
        "transition": "transform 0.5s"
    })
})

$("div#options ul li").click(function (ev) {
    ev.preventDefault();
    let category = $(this).attr("data-category");
    let node = $("div#cards div.row > div");
    let cards = Array.from(node);
    for (i = 0; i < cards.length; i++) {
        if ((cards[i].classList.contains(category) == true) == true) {
            $(cards[i]).css({
                "display": "block",
                "margin-right": "40px"
            });
            $("div#cards div.row").css("justify-content", "flex-start")
        } else {
            $(cards[i]).css("display", "none")
        }
    }
    for (i = 0; i < $(this).length; i++) {
        if (($(this).children("a").attr("class") == "clickedColor") != true) {
            $("div#options ul li").find("a.clickedColor").removeClass("clickedColor");
            $(this).children("a").addClass("clickedColor");
        }
    }
})
$(document).ready(function () {
    $("#categoryEvent .all").click(function () {
        let category = $(this).attr("id")
        if (category == "All") {
            $(".card").addClass("hide")
            setTimeout(function () {
                $(".card").removeClass("hide")
            }, 250)
        } else {
            $(".card").addClass("hide")
            setTimeout(function () {
                $("." + category).removeClass("hide")
            }, 250)
        }
    })
    let image = document.getElementById('loop')

    let images = ['./Assets/images/h3-slider-background.jpg', './Assets/images/h3-slider-background-2.jpg', './Assets/images/h3-slider-background-3.jpg']

    $(image).css("opacity", "100")




    setInterval(function () {
        let random = Math.floor(Math.random() * 3);
        image.src = images[random]


    }, 3000);

    $(".clickright").click(function () {
        let random = Math.floor(Math.random() * 3);
        image.src = images[random]
    })
    $(".clickleft").click(function () {
        let random = Math.floor(Math.random() * 3);
        image.src = images[random]
    })

    $('.parallax-window').parallax({
        imageSrc: '../Assets/images/h3-background-img.jpg'
    });

    $('.owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        navText: [
            '<i class="bi bi-arrow-left preleft" aria-hidden="true"></i>',
            '<i class="bi bi-arrow-right nextright" aria-hidden="true"></i>'
        ],
        autoplay: true,
        autoplayTimeout: 7000,
        dots: false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })
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
    $(window).scroll(function (e) {
        let position = $(this).scrollTop();
        if (position > 200) {
            $('#stickynavbar').css('display', 'flex');
        } else {
            $('#stickynavbar').css('display', 'none');
        }
    });

})


$(document).ready(function () {
    let AdtoCard = document.querySelectorAll("#buy")
    let Products = document.querySelector(".shopping-cart-dropdown")

    AdtoCard.forEach(btn => {

        btn.onclick = function (ev) {
            ev.preventDefault()
            let ID = this.parentNode.parentNode.parentNode.getAttribute("data-id")
            let top = this.parentNode.parentNode.parentNode.children[0]
            let Img=top.children[0].getAttribute("src")
            let Name = this.parentNode.parentNode.children[0].innerText;
            let Price1 = this.parentNode.children[1]
            let Price=Price1.children[1].innerText
            console.log(Price);
            
            

            if (localStorage.getItem("basket") == null) {
                localStorage.setItem("basket", JSON.stringify([]))
            }
            let basket = JSON.parse(localStorage.getItem("basket"))
            let exsistProduct = basket.find((p) => p.id == ID)
            if (exsistProduct === undefined) {
                let product = {
                    id: ID,
                    img: Img,
                    name: Name,
                    price: Price,
                    count: 1
                }
                basket.push(product)
                getProductbody(product)

            } else {
                // let Count=document.getElementById(`${exsistProduct.id}`)
                // +Count.innerHTML++;
                exsistProduct.count++;

            }

            localStorage.setItem("basket", JSON.stringify(basket))
            calcCount()
            TotalPrice()

            getProducts()
        }
    })

    calcCount()

    function calcCount() {
        if (localStorage.getItem("basket") == null) {
            localStorage.setItem("basket", JSON.stringify([]))
        }
        let countProduct = document.querySelector(".bag span")

        let basket = JSON.parse(localStorage.getItem("basket"))
        countProduct.innerHTML = basket.length
    }
    TotalPrice()

    function TotalPrice() {
        if (localStorage.getItem("basket") == null) {
            localStorage.setItem("basket", JSON.stringify([]))
        }
        getProducts()

        // let Price=document.querySelector(".count-price .price")
        // let pricetext = $(Price).text()
        let basket = JSON.parse(localStorage.getItem("basket"))

        let totalpr =document.querySelector("#total-price")


        let total = basket.reduce((totall, p) => {
            totall = parseInt(totall)
            price = p.price
            count = parseInt(p.count)
            return totall += price * count
            
        }, 0)
        

        $(totalpr).text(`(${total})`) 

    }

    getProducts()

    function getProducts() {
        let basket = JSON.parse(localStorage.getItem("basket"))

        let baskettop = document.querySelector(".shopping-cart-dropdown")
        baskettop.innerHTML = ""
        basket.forEach((p) => {
            getProductbody(p)
        })
    }

    function getProductbody(product) {

        Products.innerHTML += `
<ul>
 <li id="${product.id}">
<div class="item-image-holder">
    <img src="${product.img}">
</div>
<div class="info-holder">
    <h6 class="product-title"><a>${product.name}</a></h6>
    <span id="${product.id}" class="quantity">${product.count} x</span>
    <span class="amount">${product.price}</span>
    <a><span class="icon-arrows-remove"  >
    <i class="fas fa-times" onclick=removeProduct(this)></i>
    </span></a>
</div>
</li>
</ul>
                            
`

    }
})

function removeItem(id) {
    let basket = JSON.parse(localStorage.getItem("basket"))
    const newItemSet = basket.filter((i) => i.id !== id)
    localStorage.setItem("basket", JSON.stringify(newItemSet))
}

function removeProduct(e) {
    removeItem(e.parentElement.parentElement.parentElement.parentElement.getAttribute("data-id"))
    e.parentElement.parentElement.parentElement.parentElement.remove();
    // calcCount()
    // TotalPrice()
}
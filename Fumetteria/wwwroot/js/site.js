function valida()
{
    if (document.getElementById("tit").value.length < 2 || document.getElementById("tit").value.length > 190)
    {
        alert("Titolo non valido");
        return false;
    }
    if (document.getElementById("tes").value.length < 2 || document.getElementById("tes").value.length > 140)
    {
        alert("Testata non valido");
        return false;
    }
    if (document.getElementById("casaed").value.length < 2 || document.getElementById("casaed").value.length > 240)
    {
        alert("Casa Editrice non valido");
        return false;
    }
    if (parseInt(document.getElementById("num").value) < 1 || document.getElementById("num").value.length < 1)
    {
        alert("Numero non valido");
        return false;
    }
    return true;
}

// Quando clicco sull'icona del pennello...
$('#themeMenu').on('click', function () {
    // aggiungo o rimuovo le classi per cambiare colore all'icona del pennello
    $('#themeMenu').toggleClass('text-primary shadow-primary');
    // aggiungo o rimuovo la classe hidden (che contiene solo display: none) per mostrare o nascondere il menu dei temi
    $('#themeContainer').toggleClass('hidden');
    gsap.fromTo(
        '#themeContainer',
        {
            opacity: 0,
        },
        {
            opacity: 1,
            duration: 0.5,
            ease: "power2.inOut"
        }
    )
});

// Quando clicco su un colore del tema...
$('.theme').on('click', function () {
    // prendo l'id del colore
    let theme = $(this).attr('id');
    // creo un oggetto con i colori dei temi associando l'id del colore al colore stesso in esadecimale (si puo fare anche con rgb/rgba/hsl/hsla)
    let themes = {
        'violet': '#9A70CC',
        'red': '#FF6F61',
        'blue': '#00A8CC',
        'green': '#00CC99',
        'yellow': '#FFD662',
        'orange': '#ff7c4d',
        'pink': '#FF99C8',
    }
    // cambio la variabile CSS --primary con il colore del tema selezionato
    document.documentElement.style.setProperty('--primary', themes[theme]);
    // cambio la variabile CSS --primary-subtle con il colore del tema selezionato + 39% di opacità (63 in esadecimale)
    document.documentElement.style.setProperty('--primary-subtle', themes[theme] + "63");
});

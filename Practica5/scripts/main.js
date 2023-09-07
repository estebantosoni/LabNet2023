const puntuacionBase = 10
const nroMaximo = 20
const puntosPorAcertar = 3

const Puntuacion = {
    puntuacion : puntuacionBase,
    puntuacionAlta : 0,
    nroParaAdivinar : 0
}

function GenerateRandomNumber() {
    return Math.floor(Math.random() * nroMaximo) + 1
}

Puntuacion.nroParaAdivinar = GenerateRandomNumber()

let obtenerResultadoSpan = null;

const puntuacionSpan = document.getElementById("puntuacionSpan");
const puntuacionAltaSpan = document.getElementById("puntuacionAltaSpan");
puntuacionSpan.textContent = Puntuacion.puntuacion.toString()
puntuacionAltaSpan.textContent = Puntuacion.puntuacionAlta.toString();

const probarBtn = document.getElementById("probarBtn");
const reiniciarBtn = document.getElementById("reiniciarBtn");

const nroMaximoSpan = document.getElementById("nroMaximo");
nroMaximoSpan.textContent = nroMaximo.toString();

const puntuacionBaseSpan = document.getElementById("puntuacionBase");
puntuacionBaseSpan.textContent = puntuacionBase.toString();

const puntosPorAcertarSpan = document.getElementById("puntosPorAcertar");
puntosPorAcertarSpan.textContent = puntosPorAcertar.toString();

function logicaPartidaPerdida(obtenerResultadoSpan,puntuacionAltaSpan){
    obtenerResultadoSpan.textContent = "Perdiste... :(";
    probarBtn.disabled = true;
    puntuacionAltaSpan.textContent = Puntuacion.puntuacionAlta.toString();
    puntuacionSpan.textContent = Puntuacion.puntuacion.toString();
}

probarBtn.addEventListener("click",function(){

    const numeroInput = document.getElementById("numeroInput");
    const numero = parseInt(numeroInput.value)
    numeroInput.value = "";

    obtenerResultadoSpan = document.getElementById("resultadoSpan");

    if(Puntuacion.puntuacion > Puntuacion.puntuacionAlta){
        Puntuacion.puntuacionAlta = Puntuacion.puntuacion
    }

    if(Puntuacion.puntuacion == 0){
        logicaPartidaPerdida(obtenerResultadoSpan,puntuacionAltaSpan);
    }
    else if(numero < Puntuacion.nroParaAdivinar){
        
        obtenerResultadoSpan.textContent = "Muy bajo";
        Puntuacion.puntuacion -= 1;
        
        if(Puntuacion.puntuacion == 0){
            logicaPartidaPerdida(obtenerResultadoSpan,puntuacionAltaSpan);
        }
        else{
            puntuacionSpan.textContent = Puntuacion.puntuacion.toString();
        }
    }
    else if(numero > Puntuacion.nroParaAdivinar){
        
        obtenerResultadoSpan.textContent = "Muy alto";
        Puntuacion.puntuacion -= 1
        
        if(Puntuacion.puntuacion == 0){
            logicaPartidaPerdida(obtenerResultadoSpan,puntuacionAltaSpan);
        }
        else{
            puntuacionSpan.textContent = Puntuacion.puntuacion.toString();
        }
    }
    else if(numero == Puntuacion.nroParaAdivinar){
        
        obtenerResultadoSpan.textContent = "¡Numero correcto! Se ha generado un numero numero para adivinar.";
        
        Puntuacion.puntuacion += puntosPorAcertar
        Puntuacion.nroParaAdivinar = GenerateRandomNumber()
        puntuacionSpan.textContent = Puntuacion.puntuacion.toString();
        
    }

})

reiniciarBtn.addEventListener("click", function(){
    
    probarBtn.disabled = false;

    if(Puntuacion.puntuacion > Puntuacion.puntuacionAlta){
        Puntuacion.puntuacionAlta = Puntuacion.puntuacion
        puntuacionAltaSpan.textContent = Puntuacion.puntuacionAlta.toString()
    }

    Puntuacion.puntuacion = puntuacionBase;
    puntuacionSpan.textContent = Puntuacion.puntuacion.toString();
    Puntuacion.nroParaAdivinar = GenerateRandomNumber()

    numeroInput.value = "";

    if(obtenerResultadoSpan != null){
        obtenerResultadoSpan.textContent = ""
    }
})

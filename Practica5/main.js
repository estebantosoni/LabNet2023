let puntuacion = 10;
let puntuacionAlta = 0;
let nroParaAdivinar = Math.floor(Math.random() * 20) + 1;
let obtenerResultadoSpan = null;

const puntuacionSpan = document.getElementById("puntuacionSpan");
const puntuacionAltaSpan = document.getElementById("puntuacionAltaSpan");
const probarBtn = document.getElementById("probarBtn");
const reiniciarBtn = document.getElementById("reiniciarBtn");

function logicaPartidaPerdida(obtenerResultadoSpan,puntuacionAltaSpan){
    obtenerResultadoSpan.textContent = "Perdiste... :(";
    probarBtn.disabled = true;
    puntuacionAltaSpan.textContent = puntuacionAlta.toString();
    puntuacionSpan.textContent = puntuacion.toString();
}

probarBtn.addEventListener("click",function(){

    const numeroInput = document.getElementById("numeroInput");
    const numero = parseInt(numeroInput.value)
    numeroInput.value = "";

    obtenerResultadoSpan = document.getElementById("resultadoSpan");

    if(puntuacion > puntuacionAlta){
        puntuacionAlta = puntuacion
    }

    if(puntuacion == 0){
        logicaPartidaPerdida(obtenerResultadoSpan,puntuacionAltaSpan);
    }
    else if(numero < nroParaAdivinar){
        
        obtenerResultadoSpan.textContent = "Muy bajo";
        puntuacion = puntuacion - 1;
        
        if(puntuacion == 0){
            logicaPartidaPerdida(obtenerResultadoSpan,puntuacionAltaSpan);
        }
        else{
            puntuacionSpan.textContent = puntuacion.toString();
        }
    }
    else if(numero > nroParaAdivinar){
        
        obtenerResultadoSpan.textContent = "Muy alto";
        puntuacion = puntuacion - 1
        
        if(puntuacion == 0){
            logicaPartidaPerdida(obtenerResultadoSpan,puntuacionAltaSpan);
        }
        else{
            puntuacionSpan.textContent = puntuacion.toString();
        }
    }
    else if(numero == nroParaAdivinar){
        
        obtenerResultadoSpan.textContent = "¡Numero correcto! Se ha generado un numero numero para adivinar.";
        puntuacion = puntuacion + 5
        nroParaAdivinar = Math.floor(Math.random() * 20) + 1;
        puntuacionSpan.textContent = puntuacion.toString();
        
    }

})

reiniciarBtn.addEventListener("click", function(){
    probarBtn.disabled = false;
    if(puntuacion > puntuacionAlta){
        puntuacionAlta = puntuacion
        puntuacionAltaSpan.textContent = puntuacionAlta
    }
    puntuacion = 10;
    puntuacionSpan.textContent = puntuacion;
    nroParaAdivinar = Math.floor(Math.random() * 20) + 1;
    numeroInput.value = "";
    if(obtenerResultadoSpan != null){
        obtenerResultadoSpan.textContent = ""
    }
})

//window.onload = cargarBarra()
let sw = 0;

function cargarBarra() {
    console.log('asd')   
}

function mostrarNotificaciones() {
    
    if (sw == 0) {
        $('#divNotificaciones').fadeIn(200)
        sw++;
    }
    else {
        sw = 0;
        $('#divNotificaciones').fadeOut(200)
    }
    
}
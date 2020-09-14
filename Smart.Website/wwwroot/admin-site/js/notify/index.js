'use strict';
//var notify = $.notify('<i class="fa fa-angle-right"></i><strong>Loading</strong> page Do not close this page...', {
//    type: 'theme',
//    allow_dismiss: true,
//    delay: 2000,
//    showProgressbar: true,
//    timer: 300,
//    animate:{
//        enter:'animated fadeInDown',
//        exit:'animated fadeOutUp'
//    }
//});

setTimeout(function() {
   // notify.update('message', '<i class="fa fa-angle-right" aria-hidden="true"></i><strong>Loading</strong> Inner Data.');
}, 1000);

function MessageNotify(title, message, type, delay) {
    var mess = '<i class="icofont icofont-save" style="padding-top:10px;padding-bottom:10px"></i> ' + message;
    var type = "success";
    delay = 1000;
    switch (title) {
        
        case "SAVE":
            mess = '<i class="icofont icofont-save" style="padding-top:10px;padding-bottom:10px"></i> ' + message;
            break;
        case "ERROR":
            mess = '<i class="icofont icofont-error" style="padding-top:10px;padding-bottom:10px"></i>' + message;
            break;
    }
   
    $.notify(mess, {
        type: type,
        allow_dismiss: false,
        delay: delay,
        showProgressbar: true,
        timer: 300,
        animate: {
            enter: 'animated fadeInDown',
            exit: 'animated fadeOutUp'
        },
        allow_duplicates : false,
    });
}


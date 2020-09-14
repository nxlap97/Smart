"use strict";


function testAnim(x) {
    $('.modal .modal-dialog').attr('class', 'modal-dialog  ' + x + '  animated');
};
var modal_animate_custom = {
    init: function() {
        $('#popup-modal-common').on('show.bs.modal', function (e) {
            var anim = "rollIn"//$('#entrance').val();
            testAnim(anim);
        })
        $('#popup-modal-common').on('hide.bs.modal', function (e) {
            var anim = "rollOut"//$('#exit').val();
            testAnim(anim);
        })
        $("a").tooltip();
    }
};
(function($) {
    "use strict";
    modal_animate_custom.init()
})(jQuery);
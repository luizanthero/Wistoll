/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/** ******  Acordeom  *********************** **/
// Close ibox function
$('.close-link').click(function () {
    var content = $(this).closest('div.x_panel');
    content.remove();
});

// Collapse ibox function
$('.collapse-link').click(function () {
    var x_panel = $(this).closest('div.x_panel');
    var button = $(this).find('i');
    var content = x_panel.find('div.x_content');
    content.slideToggle(200);
    (x_panel.hasClass('fixed_height_390') ? x_panel.toggleClass('').toggleClass('fixed_height_390') : '');
    (x_panel.hasClass('fixed_height_320') ? x_panel.toggleClass('').toggleClass('fixed_height_320') : '');
    button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
    setTimeout(function () {
        x_panel.resize();
    }, 50);
});
/** ******  /Acordeon  *********************** **/

/** ******  CheckBox  *********************** **/
if ($("input.flat")[0]) {
    $(document).ready(function () {
        $('input.flat').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        });
    });
}
/** ******  /CheckBox  *********************** **/

/** ******  CheckBox Asp  *********************** **/
if ($('.iCheckAsp')[0]) {
    $(document).ready(function () {
        $('.iCheckAsp').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        });
    });
}
/** ******  /CheckBox Asp  *********************** **/

/** ******  input mask  ********************** **/
$(document).ready(function () {
    $(":input").inputmask();
});
/** ******  /input mask  ********************** **/

/** *******  Diminuir e Aumentar textos  ********* **/
var ie4 = document.all && !document.getElementById
var ns4
var DOM2 = document.getElementById

if (ns4) document.write('<ilayer id="zoomerns"><layer id="zoomerns_sub" left=0 top=0></layer></ilayer>')

var index = 10
var mais = 1
var menos = 0

if (DOM2) {
    document.getElementById("zoomer").style.fontSize = index * 10 + 0 + "%";
} else if (ie4) {
    document.all.zoomer.style.fontSize = index * 10 + 0 + "%";
} else if (ns4) {
    document.zoomerns.document.zoomerns_sub.document.write(comments);
    document.zoomerns.document.zoomerns_sub.document.close()
}

function zoom(how) {
    var arr_to_zoom = new Array("texto", "id1", "id2");//Aqui você irá colocar a id onde deve ser alterada a letra!
    if ((index <= 20) && (how == 1)) index++
    if ((index > 8) && (how == 0)) index--
    document.getElementById("percent").value = 1 * (index * 10 + 0) + "%"
    if (DOM2) {
        //alert("DOM2");
        for (i = 0; i < arr_to_zoom.length ; i++) {
            try {
                document.getElementById(arr_to_zoom[i]).style.fontSize = index * 10 + 1 + "%";
            } catch (e) {
            }
        }
    } else if (ie4) {
        //alert("IE4");
        for (i = 0; i < arr_to_zoom.length() ; i++) {
            document.getElementById(arr_to_zoom[i]).style.fontSize = index * 10 + 1 + "%";
        }
        document.all.zoomer.style.fontSize = index * 10 + 0 + "%";
    } else if (ns4) {
        //alert("ns4");
        document.zoomerns.document.zoomerns_sub.document.write(comments);
        document.zoomerns.document.zoomerns_sub.document.close();
    }
}
/** ********  Diminuir e Aumentar textos  ********** **/
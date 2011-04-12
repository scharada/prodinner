<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="doggy">
</div>
<div id="tip">
    <div id="tipcontent">
    hi, I'm going to tell you random stuff about this site
    </div>
</div>
<%
    var c = ViewContext.RouteData.Values["Controller"].ToString().ToLower();
    var a = ViewContext.RouteData.Values["Action"].ToString().ToLower();
%>
<script type="text/javascript">
    $(function () {
        var x = Math.random() * 5000

        if (getCookie("showdoggy") != "false")
            setTimeout("showTip()", x);

        setTimeout("doSomething()", x + 5000);

        $('#doggy').draggable({
            drag: function (event, ui) {
                var dl = parseFloat($('#doggy').css('left'));
                var dt = parseFloat($('#doggy').css('top'));
                $('#tip').css('left', (dl-130) + "px").css('top', (dt-100) + 'px');                
            }
        });

        $('#tip').click(showTip);

        $('#doggy').click(function (e) {
            if (!$('#tip').is(':visible')) {
                setCookie("showdoggy", true, 10);
                $('#tip').fadeIn();
            }
            else {
                setCookie("showdoggy", false, 10);
                $('#tip').fadeOut();
            }
        });
    });

    function doSomething() {
        if($('#tip').is(':visible')) showTip();
        setTimeout('doSomething()', Math.random() * 5000 + 5000);
    }
    
    function showTip() {
        $.post('<%=Url.Action("tell","doggy") %>',
        { c: '<%=c %>', a: '<%=a %>' },
        function (d) {
            $('#tipcontent').html(d.o);
            $('#tip').show();            
        });
    }
    
    //http://www.w3schools.com/JS/js_cookies.asp
    function setCookie(c_name, value, exdays) {
        var exdate = new Date();
        exdate.setDate(exdate.getDate() + exdays);
        var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
        document.cookie = c_name + "=" + c_value;
    }

    function getCookie(c_name) {
        var i, x, y, ARRcookies = document.cookie.split(";");
        for (i = 0; i < ARRcookies.length; i++) {
            x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
            y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
            x = x.replace(/^\s+|\s+$/g, "");
            if (x == c_name) {
                return unescape(y);
            }
        }
    }

</script>


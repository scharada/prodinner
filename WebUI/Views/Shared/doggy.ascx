<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="doggy">
</div>
<div id="tip">
    <div id="tipcontent">
    </div>
</div>
<%
    var c = ViewContext.RouteData.Values["Controller"].ToString().ToLower();
    var a = ViewContext.RouteData.Values["Action"].ToString().ToLower();
%>
<script type="text/javascript">
    var ascl = false;
    $(function () {
        
        var x = Math.random() * 5000
        setTimeout("showTip()", x);
        setTimeout("doSomething()", x+5000);
        $('#doggy').draggable({
            drag: function (event, ui) {
                $("#tip").position({
                    my: "right bottom",
                    at: "left top",
                    offset: "0 30",
                    of: $('#doggy'),
                    collision: "fit"
                });
            }
        });

        $('#tip').click(showTip);

        $('#doggy').click(function (e) {
            if (!$('#tip').is(':visible')) {
                showTip();
            }
            else {
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
            $('#tip').fadeIn();

        });
    }
</script>

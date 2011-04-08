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

        $('#doggy').draggable({
            drag: function (event, ui) {

                var p = $('#doggy').position();
                $('#tip').css('left', p.left - 120);
                $('#tip').css('top', p.top - 100);
            }
        });

        $('#tip').click(showTip);

        $('#doggy').click(function (e) {
            ascl = !ascl;
            if (ascl) {
                showTip();
            }
            else {
                $('#tip').fadeOut();
            }
        });
    });

    function showTip() {
        $.post('<%=Url.Action("tell","doggy") %>',
        { c: '<%=c %>', a: '<%=a %>' },
        function (d) {
            $('#tipcontent').html(d.o);
            $('#tip').fadeIn();

        });
    }
</script>


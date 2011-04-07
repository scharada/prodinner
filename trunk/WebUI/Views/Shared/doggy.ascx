<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="assistent">
<div class="doggy" id="doggy">
</div>
<div class="tip" id="tip">
<div class="tipcontent" id="tipcontent">
hi!
</div>
</div>
</div>

<script type="text/javascript">
    var ascl = false;
    $(function () {
        $('#assistent').draggable();
        $('#assistent').click(function (e) {
            if (e.target.id == "tip") { showTip(); return; }
            ascl = !ascl;
            if (ascl) {
                showTip();
            }
            else {
                $('.tip').fadeOut();
            }
        });
    });

    function showTip() {
        $.post('<%=Url.Action("tell","doggy") %>',
        { c: 'a', a: 'a' },
        function (d) {
            $('.tipcontent').html(d.o);
            $('.tip').fadeIn();
        });
    }
</script>


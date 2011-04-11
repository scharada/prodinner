<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<h2>
    <%=Mui.Meals%></h2>

<%=Html.MakePopup("ChangePicture",new[]{"id"}, fullScreen:true) %>
<script type="text/javascript">

    $(function () {
        $(document).ajaxComplete(adjustMeals);
        $(window).resize(adjustMeals);
    });

    function adjustMeals() {
        if ($.support.cors)
            $(".notcool").hide();
        else
            $(".cool").hide();

        var w = $('#main').width();
        var space = w % 492;
        var cat = (w - space) / 492;
        var u = (space / cat);
        var nw = 449.5 + u;
        $('.meal').width(nw);
        $('.comments').css('width', $('.comments:first').parent().width() - $('.comments:first').prev().width() - 20);
    }
</script>

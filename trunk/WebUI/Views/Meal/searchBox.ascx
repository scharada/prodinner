<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%= Mui.Search %>: <input type='text' name='search' />
<link href='<%= Url.Content("~/Content/jquery.Jcrop.css")%>' rel="stylesheet" type="text/css" />
<script type="text/javascript" src='<%=Url.Content("~/Scripts/jquery.Jcrop.min.js")%>' ></script> 
<br class="cbt"/>
<%=Html.MakePopup("Cp",new[]{"id"},fullScreen:true) %>
<script type="text/javascript">
    $(function () {
        $(document).ajaxComplete(adjustMeals);
        $(window).resize(adjustMeals);
    });

    function adjustMeals() {
        var w = $('#main').width();        
        var space = w % 492;        
        var cat = (w - space) / 492;        
        var u = (space / cat);          
        var nw = 449.5 + u;        
        $('.meal').width(nw);        
        $('.comments').css('width', $('.comments:first').parent().width() - $('.comments:first').prev().width() - 20);
    }
</script>

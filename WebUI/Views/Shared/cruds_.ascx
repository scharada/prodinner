<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    var c = ViewContext.RouteData.Values["Controller"].ToString();
    var create = Mui.Create;
    var h = 300;
    if (c == "country") h = 200;
    var he = h;
    var f = false;
    if (c == "Dinner")
    {
        f = true;
        create = Mui.host_a_dinner;
    }
%>
<%=Html.Partial("header")%>
<% if(!HttpContext.Current.User.IsInRole("admin")){%>
<%=Html.Confirm(Mui.confirm_delete)%>
<%} %>
<%=Html.MakePopupForm("create", successFunction: "create", height: h, fullScreen:f)%>
<%=Html.MakePopupForm("Edit", new[] { "id" }, successFunction: "edit", height: he)%>
<script type="text/javascript">
    var page = 1;
    function addStart(d) { $(d).css('opacity', 0).prependTo("#list").animate({ opacity: 1 }, 600, 'easeInCubic'); }
    function addEnd(d) { $(d).css('opacity', 0).appendTo("#list").animate({ opacity: 1 }, 300, 'easeInCubic'); }

    function create(o) { $.get('<%=Url.Action("row")%>', { id: o.Id }, function (d) { addStart(d); }); }
    function edit(o) { $.get('<%=Url.Action("row")%>', { id: o.Id, ie8: Math.random() }, function (d) { $("#o" + o.Id).before(d).remove(); $("#o" + o.Id).hide().fadeIn('slow'); }); }
    var lfm;
    $(function () {
        regForm();
        $(this).ajaxComplete(regForm);
        $('#more').click(more);
        $('#sform').ajaxForm({ success: function (d) {
            $("#list").html(d.rows);
            page = 1;
            if (d.more) $('#more').show(); else $('#more').hide();
            lfm = $('#sform').formSerialize();
        }
        }).submit();

        $('#sform input[type="text"]').keyup(function () { $('#sform').submit(); });
        $('#sform input[type="hidden"], .ae-array').change(function () { $('#sform').submit(); });
    });

    function regForm() {
    <% if(HttpContext.Current.User.IsInRole("admin")){%>
        $(".fconfirm").ajaxForm({ success: edit });
    <%} else{%>
        $(".fconfirm").ajaxForm({ success: function (d) { $('#o' + d.Id).fadeOut('slow', function () { $(this).remove(); styleup(); }); } });
    <%} %>
    
        $(".frestore").ajaxForm({ success: edit });
    }

    function more() {
        page++;
        $.post('<%= Url.Action("search")%>', lfm + '&page=' + page, function (d) {
            addEnd(d.rows);
            if (d.more) $('#more').show(); else $('#more').fadeOut('slow');
        });
    }        
</script>
<form id="sform" action="<%=Url.Action("search")%>" method="post">
<%=Html.Partial("searchbox")%>
</form>
<br />
<%=Html.PopupFormActionLink("create", create, htmlAttributes: new { @class = "abtn" })%>
<br />
<br />
<%if (ViewBag.UseList != null)
  {%>
<ul id="list">
</ul>
<%}
  else
  {%>
<table class="atbl">
    <thead>
        <%=Html.Partial("hrow")%>
    </thead>
    <tbody id="list">
    </tbody>
</table>
<%} %>
<br class="cbt" />
<a id="more" class="abtn" style="display: none;">
    <%=Mui.more%></a> 
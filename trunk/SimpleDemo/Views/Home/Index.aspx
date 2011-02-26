<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="SimpleDemo.Controllers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Confirm </h2>
    <p>
        <%:ViewData["msg"] %></p>

    <%=Html.Confirm("do you?") %>
    <form action="<%=Url.Action("Ido") %>">
    <input type="submit" value="do" class="confirm" />
    </form>
    <br />
    <h2>Popup Form</h2>
    <%=Html.MakePopupForm<HomeController>(o => o.PopupForm(0,0), width:500, height:400, title:"lookup and ajax dropdown") %>
    <%=Html.PopupFormActionLink<HomeController>(o => o.PopupForm(2, 1)) %>
    <br />
    <%=Html.MakePopupForm<HomeController>(o => o.Hi(), height:200, successFunction:"hey") %>
    <script type="text/javascript">
        function hey(o) {
            alert('hi ' + o.name);
        }
    </script>
    <%=Html.PopupFormActionLink<HomeController>(o => o.Hi()) %>
    
    <h2>Ajax Dropdown</h2>
    <%=Html.AjaxDropdown("Hobby", prefix:"m") %>

    <h2>Lookup</h2>
    <%=Html.Lookup("Country", prefix:"m", height: 300, width:400) %>
    
    <br >
    <h2>Autocomplete</h2>
    Hobby:
    <%=Html.Autocomplete("HobbyA",controller:"HobbyAutocomplete", delay:0) %>
    (try typing one letter: 'a', 'o', 'e')


    <h2>Pager </h2>
    <%=Html.ActionLink("pager","index", "PagerDemo") %>
    
    <h2>Popup</h2>
    <%=Html.MakePopup("SayHi") %>
    <%=Html.PopupActionLink("SayHi") %>
</asp:Content>

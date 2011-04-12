<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Dinner>>" %>
<% foreach (var o in Model)
   {%>
<li id='o<%=o.Id%>' class="dinner">
    <div class="fl">
        <%=o.Name%></div>
    <div class="fr">
        <%=o.Chef.FirstName%>
        <%=o.Chef.LastName%>
        <%=Mui.from%>
        <%=o.Chef.Country.Name%>
        <%=Mui.is_cooking%></div>
    <br class="cbt" />
    <% foreach (var m in o.Meals.Where(v => !string.IsNullOrEmpty(v.Picture)))
       {%>
    <img src='<%=Url.Content("~/pictures/Meals/s" +   m.Picture ) %>' class="sthumb" alt='<%=m.Name%>' />
    <% } %>
    <br class="cbt" />
    <div class="fl">
        <%=o.Country.Name%>,
        <%=o.Address%></div>
    <div class="fr">
        <%=Html.Partial("deletebtn",o)%></div>
    <div class="fr" style="padding: 0.5em; margin-right: 1em;">
        <%= o.Date.ToShortDateString()%></div>
    <br class="cbt" />
</li>
<% }%>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Dinner>>" %>
<% foreach (var o in Model)
   {%>
<li id='o<%=o.Id%>' class="dinner">
<div class="fr">    
        <%=Html.Partial("deletebtn",o)%></div>
    <div class="fl">
        <%=o.Name%></div>
    <div class="fr">
        <%=o.Chef.FirstName%>
        <%=o.Chef.LastName%>
        <%=Mui.from%>
        <%=o.Chef.Country.Name%>
        <%=Mui.is_cooking%>&nbsp;</div>
        
    <br class="cbt" />
    <% foreach (var m in o.Meals)
       {%>       

    <img src='<%=Url.Content("~/pictures/Meals/s" +   (m.Picture ?? "0.jpg") ) %>' class="sthumb" alt='<%=m.Name%>' />
    <% } %>
    <br class="cbt" />    
    <div class="fl">
        <%=o.Country.Name%>,
        <%=o.Address%></div>        
        <div class="fr"><%= Html.PopupFormActionLink("Edit", Mui.Edit, parameters: new object[] { o.Id }, htmlAttributes: new { @class = "abtn", style = "padding:0.3em 1em" })%></div>    
    <div class="fr" style="padding: 0.5em; margin-right: 1em;">
       <%=Mui.Start %> <%= o.Start%> <%=Mui.End %> <%=o.End %></div> 
    <br class="cbt" />
    
</li>
<% }%>

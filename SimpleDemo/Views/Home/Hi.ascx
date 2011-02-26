<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<% using (Html.BeginForm())
   {%>
   <label for="Name">Name:</label>
   <%=Html.TextBox("Name") %>
   <%} %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SimpleDemo.Models.Country>" %>
<li data-value="<%=Model.Id %>">
    <%:Model.Name %>
</li>

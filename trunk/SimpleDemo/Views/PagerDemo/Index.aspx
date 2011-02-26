<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IPageable<SimpleDemo.Models.Hobby>>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">

<%foreach (var hobby in Model.Page)
{
  %>
  <%:hobby.Name %><br />
  <%
} %>
<%=Html.Pagination() %>
</asp:Content>

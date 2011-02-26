<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%= Html.Lookup(ViewData.TemplateInfo.GetFullHtmlFieldName(""), ViewData.TemplateInfo.FormattedModelValue) %>


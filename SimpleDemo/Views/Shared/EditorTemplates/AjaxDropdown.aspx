<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%= Html.AjaxDropdown(ViewData.TemplateInfo.GetFullHtmlFieldName(""), ViewData.TemplateInfo.FormattedModelValue) %>

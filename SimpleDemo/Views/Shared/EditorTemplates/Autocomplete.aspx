<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>
<%= Html.Autocomplete(ViewData.TemplateInfo.GetFullHtmlFieldName(""), ViewData.TemplateInfo.FormattedModelValue, generatePropId:false) %>

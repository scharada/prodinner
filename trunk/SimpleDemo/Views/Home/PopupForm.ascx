<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SimpleDemo.Models.Person>" %>
<% using (Html.BeginForm())
   {%>
   <h2>Lookup</h2>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Country) %>
</div>
<div class="editor-field" style="float: left;">
    <%: Html.EditorFor(model => model.Country) %>
    <%: Html.ValidationMessageFor(model => model.Country) %>
</div>
<br class="cbt" />
<h2>Ajax dropdown</h2>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Hobby) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.Hobby) %>
    <%: Html.ValidationMessageFor(model => model.Hobby) %>
</div>
<%}%>
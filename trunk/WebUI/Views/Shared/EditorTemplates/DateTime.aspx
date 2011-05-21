<%@ Page Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage<DateTime?>" %>
<%@ Import Namespace="Omu.ProDinner.WebUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Data" runat="server">
    <%= Html.TextBox("", Model.HasValue ? Model.Value.ToShortDateString() : "") %>
        <script type="text/javascript">
            $(function () {
                $("#<%=ViewData.TemplateInfo.GetFullHtmlFieldId(string.Empty)%>").datepicker({ dateFormat: '<%= Html.ConvertDateFormat() %>' });
            });
	</script>
</asp:Content>
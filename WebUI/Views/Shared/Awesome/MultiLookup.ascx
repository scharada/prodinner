<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Omu.Awesome.Mvc.Helpers.LookupInfo>" %>
<%@ Import Namespace="Omu.Awesome.Mvc" %>
<%
    var o = AwesomeTools.MakeId(Model.Prop, Model.Prefix);
%>
<script type="text/javascript">     
    $(function () {  
        var o = '<%=o %>';     
        ae_loadMultiLookupDisplay(o,'<%=Url.Action("GetMultiple", Model.Controller) %>');
        $("."+o+"ie8").remove();
        $("#lp"+o).addClass(o+"ie8");
        ae_popup('lp'+o, <%=Model.Width %>, <%=Model.Height %>, '<%=AwesomeTools.JsEncode(Model.Title) %>', true, 'center', true, {'<%=AwesomeTools.JsEncode(Model.ChooseText) %>': function () {ae_multiLookupChoose(o, '<%=Url.Action("GetMultiple", Model.Controller) %>', '<%=Model.Prop %>');},'<%=AwesomeTools.JsEncode(Model.CancelText) %>': function () { $(this).dialog('close'); }}, <%=Model.Fullscreen.ToString().ToLower() %>);
        
        var lck<%=o %> = null;        
        ae_lookupPopupOpenClick(o, lck<%=o %>, '<%=Url.Action("index", Model.Controller) %>', <%=Model.Paging.ToString().ToLower() %>, <%=Model.Multiselect.ToString().ToLower() %>, [<%=Model.Data  != null ? AwesomeTools.MakeJsArray(Model.Data.Keys) :""%>], [<%=Model.Data != null ? AwesomeTools.MakeIdJsArray(Model.Data.Values) :""%>]);        
        <%if(Model.ClearButton){%>
        ae_multiLookupClear(o);
        <%} %>        
    });  
</script>
<ul id="ld<%=o %>" <%=Model.HtmlAttributes %>>
</ul>
<a class="ae-lookup-openbtn" id="lpo<%=o %>" ></a>
<%if (Model.ClearButton)
  {%>
<a class="ae-lookup-clearbtn" id="lc<%=o %>" ></a>
<%} %>
<div id='lp<%=o %>'>
</div>
<div id="<%=o %>" style='display:none;' class='ae-array'>
    <% if (Model.Value != null && Model.Value is IEnumerable) foreach (var oo in Model.Value as IEnumerable){%>
    <input type="hidden" name="<%=Model.Prop %>" value="<%=oo %>" />
    <%} %>
</div>

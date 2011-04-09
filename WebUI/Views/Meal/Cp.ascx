<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Omu.ProDinner.Core.Model.Meal>" %>

<img id="dasPicture" src='<%=Url.Content("~/pictures/meals/" + (string.IsNullOrEmpty(Model.Picture) ? "0.jpg": Model.Picture)) %>' alt="das picture" />

<div style="width: 200px; height: 150px; overflow: hidden;float:left;">
    <img src='' id="preview" alt="thumb" />
</div>

<div class="fl" style="width:640; height:480;">
    <img id="cropbox" src="" alt="image to crop" />
</div>

<form id="cropform" method="post" action='<%=Url.Action("crop") %>'>
<input type="hidden" id="x" name="x" />
<input type="hidden" id="y" name="y" />
<input type="hidden" id="w" name="w" />
<input type="hidden" id="h" name="h" />
<input type="hidden" id="id" name="id" value="<%=Model.Id %>" />
<input type="hidden" id="filename" name="filename" />
<input type="submit" value="select image" />
</form>

<form id="file_upload" action="<%=Url.Action("upload") %>" method="post" enctype="multipart/form-data">
<input type="file" name="file" />
<button>
    Incarca</button>
<div>
    Incarca fisier</div>
</form>
<table id="files">
</table>

<script type="text/javascript">
    $(function () {
        $('#cropform').ajaxForm(function (o) {
            $('#dasPicture').attr('src', '<%=Url.Content("~/pictures/meals/") %>' + o.name + '?'+Math.random());
        });
        $('#file_upload').fileUploadUI({
            uploadTable: $('#files'),
            downloadTable: $('#files'),
            buildUploadRow: function (files, index) {
                return $('<tr><td>' + files[index].name + '<\/td>' +
                    '<td class="file_upload_progress"><div><\/div><\/td>' +
                    '<td class="file_upload_cancel">' +
                    '<button class="ui-state-default ui-corner-all" title="Cancel">' +
                    '<span class="ui-icon ui-icon-cancel">Cancel<\/span>' +
                    '<\/button><\/td><\/tr>');
            },
            buildDownloadRow: function (file) {
                $('#cropbox, #preview').attr('src', '<%=Url.Content("~/pictures/meals/temp/") %>' + file.name);
                $('#filename').val(file.name);
                $('#cropbox').width(file.w).height(file.h);
                dw = file.w;
                dh = file.h;
                docrop();
                return $('');
            },
            addNode: function (parentNode, node, callBack) {
                parentNode.empty();
                parentNode.append(node);
                if (typeof callBack === 'function') {
                    callBack();
                }
            }
        });
    });

    var api;
    function docrop() {
        
        if (api) api.destroy();

        api = $.Jcrop('#cropbox', {
            setSelect: [0, 0, 200, 150],
            onChange: showPreview,
            onSelect: showPreview,
            aspectRatio: 1.333
        });        
    }
        
         function updateCoords(c) {
		        $('#x').val(c.x);
		        $('#y').val(c.y);
		        $('#w').val(c.w);
		        $('#h').val(c.h);
		    }

        function showPreview(coords) {
        updateCoords(coords);
        
            if (parseInt(coords.w) > 0) {
                var rx = 200 / coords.w;
                var ry = 150 / coords.h;

                $('#preview').css({
                    width: Math.round(rx * dw) + 'px',
                    height: Math.round(ry * dh) + 'px',
                    marginLeft: '-' + Math.round(rx * coords.x) + 'px',
                    marginTop: '-' + Math.round(ry * coords.y) + 'px'
                });
            }
        }
</script>

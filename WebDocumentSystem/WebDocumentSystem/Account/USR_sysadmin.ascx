<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="USR_sysadmin.ascx.cs"
    Inherits="SSproject.USR_sysadmin" %>
<form method="post" action="">
<asp:Label Text="This is SysAdmin Page" runat="server" ID="lbl_display"></asp:Label>

<script type="text/javascript" language="javascript">
    function registerChange(obj) {
        //alert(obj.id+"test");
        var obj_hdf = document.getElementById("MainContent_MainContent_hdf_changed");
        var obj_value = document.getElementById(obj.id).value;
        var oID = obj.id;
        var ind = oID.indexOf("icnt-");
        var val_change = oID.substring(ind + 5, oID.length) + "$" + obj_value;
        obj_hdf.value = obj_hdf.value + "|" + val_change;
        //alert(obj_hdf.value + "test2");
    }
    function registerChangeApprove(obj) {
        var obj_hdf = document.getElementById("MainContent_MainContent_hdf_changed_approve");
        var obj_value = document.getElementById(obj.id).value;
        var oID = obj.id;
        var ind = oID.indexOf("icnt-");
        var val_change = oID.substring(ind + 5, oID.length) + "$" + obj_value;
        obj_hdf.value = obj_hdf.value + "|" + val_change;
        //alert(obj_hdf.value);
    }
    function pud() {
        alert("test");
    }
</script>

<asp:GridView ID="grv_main_request" runat="server" OnRowDataBound="grv_request_list_RowDataBound"></asp:GridView>
<asp:DropDownList ID="ddl_page_no" runat="server"></asp:DropDownList>
<table>
    <tr>
        <td>
            <asp:Button Text="Save Changes" ID="btn_save" runat="server" OnClick="btn_save_Click" />
        </td>
        
    </tr>
</table>
<asp:HiddenField ID="hdf_changed" runat="server" Value=""/>
<asp:HiddenField ID="hdf_changed_approve" runat="server" Value=""/>
</form>

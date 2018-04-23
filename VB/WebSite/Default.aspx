<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v11.2, Version=11.2.10.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript">
	function MenuItemPopUpHandle(s, e) {
		if (pivotGrid.cpAllowedFields) {
			var str = new String(pivotGrid.cpAllowedFields);
			var arr = str.split('|');
			for (var i = 0; i < arr.length; i++) {
				if (arr[i] == pivotGrid.fieldMenuFieldID) {
					e.item.menu.GetItemByName('Filter').SetVisible(false)
					break;
				}
			}
			var count = 0;
			for (var i = 0; i < e.item.menu.GetItemCount(); i++) {
				if (e.item.menu.GetItem(i).GetVisible())
					count++;
			}
			if (count == 0)
				s.Hide();
		}
	}
	function MenuItemCloseUpHandle(s, e) {
		e.item.menu.GetItemByName('Filter').SetVisible(true)
	}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
	</div>
	<dxwpg:ASPxPivotGrid ID="ASPxPivotGrid1" ClientInstanceName="pivotGrid" runat="server"
		DataSourceID="AccessDataSource1" OnCustomCallback="ASPxPivotGrid1_CustomCallback"
		OnPopupMenuCreated="ASPxPivotGrid1_PopupMenuCreated">
		<ClientSideEvents PopupMenuItemClick="function(s, e) {
	pivotGrid.PerformCallback( &quot;MenuItemClick|&quot; + e.MenuItemName+ &quot;|&quot; + e.FieldID + &quot;|&quot; + e.FieldValueIndex );
}" />
		<Fields>
			<dxwpg:PivotGridField ID="fieldProductName" AreaIndex="0" FieldName="ProductName">
			</dxwpg:PivotGridField>
			<dxwpg:PivotGridField ID="fieldCompanyName" Area="RowArea" AreaIndex="0" FieldName="CompanyName">
			</dxwpg:PivotGridField>
			<dxwpg:PivotGridField ID="fieldOrderDate" Area="ColumnArea" AreaIndex="0" FieldName="OrderDate"
				GroupInterval="DateYear">
			</dxwpg:PivotGridField>
			<dxwpg:PivotGridField ID="fieldAmountSum" Caption="Sum" Area="DataArea" AreaIndex="0"
				FieldName="ProductAmount">
			</dxwpg:PivotGridField>
			<dxwpg:PivotGridField ID="fieldAmountAvearge" Caption="Average" Area="DataArea" AreaIndex="0"
				FieldName="ProductAmount">
			</dxwpg:PivotGridField>
		</Fields>
	</dxwpg:ASPxPivotGrid>
	<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
		SelectCommand="SELECT * FROM [CustomerReports]"></asp:AccessDataSource>
	</form>
</body>
</html>
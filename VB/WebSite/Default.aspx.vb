Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports DevExpress.Web.ASPxPivotGrid

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) AndAlso (Not IsCallback) Then
			Dim stb As New StringBuilder()
			For Each field As PivotGridField In ASPxPivotGrid1.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea)
				stb.Append(field.ID)
				stb.Append("|")
			Next field
			ASPxPivotGrid1.JSProperties("cpAllowedFields") = stb.ToString()
		End If
	End Sub
	Protected Sub ASPxPivotGrid1_PopupMenuCreated(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxPivotGrid.PivotPopupMenuCreatedEventArgs)
		If e.MenuType = DevExpress.Web.ASPxPivotGrid.PivotGridPopupMenuType.FieldValueMenu Then
			Dim item As DevExpress.Web.MenuItem = e.Menu.Items.Add("Filter By This Value", "Filter")
			item.BeginGroup = True
			e.Menu.ClientSideEvents.PopUp = "function ASPxClientMenuItemEventHandler(s, e) { MenuItemPopUpHandle(s, e); }"
			e.Menu.ClientSideEvents.CloseUp = "function ASPxClientMenuItemEventHandler(s, e) { MenuItemCloseUpHandle(s, e); }"
		End If
	End Sub
	Protected Sub ASPxPivotGrid1_CustomCallback(ByVal sender As Object, ByVal e As PivotGridCustomCallbackEventArgs)
		 If String.IsNullOrEmpty(e.Parameters) Then
			Return
		 End If

		Dim args() As String = e.Parameters.Split("|"c)
		If args(0) = "MenuItemClick" Then
			Select Case args(1)
				Case "Filter"
					Dim field As PivotGridField = ASPxPivotGrid1.Fields(args(2))
					Dim itemIndex As Integer = Int32.Parse(args(3))
					Dim filterValue As Object = ASPxPivotGrid1.GetFieldValueByIndex(field, itemIndex)
					field.FilterValues.ValuesIncluded = New Object() { filterValue }
			End Select



		End If

	End Sub
End Class

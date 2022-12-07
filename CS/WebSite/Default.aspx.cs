using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DevExpress.Web.ASPxPivotGrid;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !IsCallback)
        {
            StringBuilder stb = new StringBuilder();
            foreach (PivotGridField field in ASPxPivotGrid1.GetFieldsByArea(DevExpress.XtraPivotGrid.PivotArea.DataArea))
            {
                stb.Append(field.ID);
                stb.Append("|");
            }
            ASPxPivotGrid1.JSProperties["cpAllowedFields"] = stb.ToString();
        }
    }
    protected void ASPxPivotGrid1_PopupMenuCreated(object sender, DevExpress.Web.ASPxPivotGrid.PivotPopupMenuCreatedEventArgs e)
    {
        if (e.MenuType == DevExpress.Web.ASPxPivotGrid.PivotGridPopupMenuType.FieldValueMenu)
        {
            DevExpress.Web.MenuItem item = e.Menu.Items.Add("Filter By This Value", "Filter");
            item.BeginGroup = true;
            e.Menu.ClientSideEvents.PopUp = "function ASPxClientMenuItemEventHandler(s, e) { MenuItemPopUpHandle(s, e); }";
            e.Menu.ClientSideEvents.CloseUp = "function ASPxClientMenuItemEventHandler(s, e) { MenuItemCloseUpHandle(s, e); }";
        }
    }
    protected void ASPxPivotGrid1_CustomCallback(object sender, PivotGridCustomCallbackEventArgs e)
    {
         if ( String.IsNullOrEmpty(e.Parameters) )
            return;
        
        String[] args  = e.Parameters.Split('|');
        if (args[0] == "MenuItemClick")
        {
            switch (args[1])
            {
                case "Filter":
                    PivotGridField field = ASPxPivotGrid1.Fields[args[2]];
                    int itemIndex = Int32.Parse(args[3]);
                    Object filterValue = ASPxPivotGrid1.GetFieldValueByIndex(field, itemIndex);
                    field.FilterValues.ValuesIncluded = new Object[] { filterValue };
                    break;
            }

                    
            
        }
	
    }
}

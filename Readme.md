<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to show custom popup context menu items only for certain fields
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3909/)**
<!-- run online end -->


<p>This is an extended version of the <a href="https://www.devexpress.com/Support/Center/p/E2727">How to add a custom popup menu item</a> example. It demonstrates how to hide certain context menu items using the client-side <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxMenuScriptsASPxClientMenuBase_PopUptopic">ASPxClientMenuBase.PopUp </a> and <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxMenuScriptsASPxClientMenuBase_CloseUptopic">ASPxClientMenuBase.CloseUp </a> events. It is possible to use the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_JSPropertiestopic">ASPxPivotGrid.JSProperties</a> dictionary to pass additional information for client side processing.<br /><br /></p>
<p>To get the ID of a target <a href="https://documentation.devexpress.com/#AspNet/CustomDocument3597">Field Value</a> item use the <strong>pivotGrid.fieldMenuFieldID property</strong>.<br />If the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument3586">Header</a> menu is shown, you can get the ID using the <strong>pivotGrid.headerMenuFieldID property.</strong></p>
<p><br /><br /></p>

<br/>



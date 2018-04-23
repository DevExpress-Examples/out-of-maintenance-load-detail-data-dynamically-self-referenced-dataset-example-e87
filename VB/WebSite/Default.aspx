<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v7.3" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v7.3" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Load detail data dynamically (self-referenced dataset example)</title>
</head>
<body>
	<form id="form1" runat="server">

	<div>
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False"
			Width="511px">
			<Columns>
				<dxwgv:GridViewDataTextColumn FieldName="ID" VisibleIndex="0">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="ParentID" VisibleIndex="1">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
				</dxwgv:GridViewDataTextColumn>
			</Columns>
			<SettingsDetail ShowDetailRow="True" />
			<Templates>
				<DetailRow>
					<dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
			Width="511px" KeyFieldName="ID" OnDataBinding="ASPxGridView2_DataBinding">
			<Columns>
				<dxwgv:GridViewDataTextColumn FieldName="ID" VisibleIndex="0">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="ParentID" VisibleIndex="1">
				</dxwgv:GridViewDataTextColumn>
				<dxwgv:GridViewDataTextColumn FieldName="Name" VisibleIndex="2">
				</dxwgv:GridViewDataTextColumn>
			</Columns>
						<SettingsDetail IsDetailGrid="True" />
		</dxwgv:ASPxGridView>
				</DetailRow>
			</Templates>
		</dxwgv:ASPxGridView>

	</div>
	</form>
</body>
</html>

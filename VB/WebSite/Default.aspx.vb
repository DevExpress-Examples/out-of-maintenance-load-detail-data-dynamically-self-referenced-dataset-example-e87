Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private ds As DataSet
	Private table As DataTable

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ds = New DataSet()
		table = ds.Tables.Add("People")
		table.Columns.Add("ID", GetType(Integer))
		table.Columns.Add("ParentID", GetType(Integer))
		table.Columns.Add("Name", GetType(String))
		table.PrimaryKey = New DataColumn() { table.Columns("ID") }

		table.Rows.Add(New Object() { 1, DBNull.Value, "Bill" })
		table.Rows.Add(New Object() { 2, DBNull.Value, "John" })
		table.Rows.Add(New Object() { 3, DBNull.Value, "Clive" })
		table.Rows.Add(New Object() { 4, 1, "Ann" })
		table.Rows.Add(New Object() { 5, 1, "Tom" })
		table.Rows.Add(New Object() { 6, 3, "Jane" })

		ds.Relations.Add("ParentChildren", table.Columns("ID"), table.Columns("ParentID"))

		Dim dv As DataView = New DataView(table)
		dv.RowFilter = "[ParentID] Is Null"

		ASPxGridView1.KeyFieldName = "ID"
		ASPxGridView1.DataSource = dv
		ASPxGridView1.DataBind()
	End Sub

	Protected Sub ASPxGridView2_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		Dim detailGrid As ASPxGridView = CType(sender, ASPxGridView)
		Dim id As Object = detailGrid.GetMasterRowKeyValue()
		Dim detailData As DataView = New DataView(table)
		detailData.RowFilter = String.Format("[ParentID] = {0}", id)
		detailGrid.DataSource = detailData
	End Sub
End Class

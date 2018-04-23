using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;

public partial class _Default : System.Web.UI.Page {
    DataSet ds;
    DataTable table;

    protected void Page_Load(object sender, EventArgs e) {
        ds = new DataSet();
        table = ds.Tables.Add("People");
        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("ParentID", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };

        table.Rows.Add(new object[] { 1, DBNull.Value, "Bill" }) ;
        table.Rows.Add(new object[] { 2, DBNull.Value, "John" });
        table.Rows.Add(new object[] { 3, DBNull.Value, "Clive" });
        table.Rows.Add(new object[] { 4, 1, "Ann" });
        table.Rows.Add(new object[] { 5, 1, "Tom" });
        table.Rows.Add(new object[] { 6, 3, "Jane" });

        ds.Relations.Add("ParentChildren", table.Columns["ID"], table.Columns["ParentID"]);

        DataView dv = new DataView(table);
        dv.RowFilter = "[ParentID] Is Null";

        ASPxGridView1.KeyFieldName = "ID";
        ASPxGridView1.DataSource = dv;
        ASPxGridView1.DataBind();
    }

    protected void ASPxGridView2_DataBinding(object sender, EventArgs e) {
        ASPxGridView detailGrid = (ASPxGridView)sender;
        object id = detailGrid.GetMasterRowKeyValue();
        DataView detailData = new DataView(table);
        detailData.RowFilter = String.Format("[ParentID] = {0}", id);
        detailGrid.DataSource = detailData;
    }
}

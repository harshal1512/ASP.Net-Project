using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace Asp.net
{
    public partial class frmEmployeeMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                showGrid();
                txtempid.Focus();
                ViewState.Add("FoundFlag", false); /// FoundFlag is key name that why we are not initializes
            }
        }

        protected void txtempid_TextChanged(object sender, EventArgs e)
        {

            /*if (txtempid.Text == "1")
                txtempname.Text = "Monali";
            else if (txtempid.Text == "2")
                txtempname.Text = "Shreya";
            else if (txtempid.Text == "3")
                txtempname.Text = "kanchan";
            txtgrosal.Focus();
            */
            DAL d = new DAL();
            SqlDataReader rdr = d.getreader("select * from employeemaster where empid=" + Common.Cint(txtempid.Text));
            if(rdr!=null && rdr.HasRows)
            {
                // hdnfnd.Value = "true";
                ViewState["FoundFlag"] = true;
                rdr.Read();
                txtempname.Text = rdr["empname"].ToString();
                ddesignation.Text = rdr["designation"].ToString();
                txtgrosal.Text = rdr["grosssal"].ToString();
                txtdeduct.Text = rdr["deductions"].ToString();
                txtnetsal.Text = rdr["netsal"].ToString();
                if (rdr["isactive"].ToString()=="Y")
                {
                    chckisactive.Checked = true;
                }
                else
                {
                    chckisactive.Checked = false;
                }
            }
            else
            {
                ViewState["FoundFlag"] = false;
                hdnfnd.Value="false";
                txtempname.Text = "";
                ddesignation.SelectedIndex = 0;
                txtgrosal.Text = "";
                txtdeduct.Text = "";
                txtnetsal.Text = "";
                chckisactive.Checked = false;

            }
            txtempid.Focus();
        }

        protected void txtdeduct_TextChanged(object sender, EventArgs e)
        {
           
            double netsal = Common.Cdouble(txtgrosal.Text) - Common.Cdouble(txtdeduct.Text);
            txtnetsal.Text=netsal.ToString("0.00");
            chckisactive.Focus();
        }

       public void showGrid()
        {
            DAL d = new DAL();
            DataTable dt = d.gettable("select * from employeemaster");
            grddata.DataSource = dt;
            grddata.DataBind();
            
        }

        protected void grddata_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onclick", "ShowRecords(this);");
                e.Row.Style.Add("cursor:pointer;cursor:hand", "");
                e.Row.Attributes.Add("onmouseover", "SetColors(this,'Yellow');");
                e.Row.Attributes.Add("onmouseout", "SetColors(this,'White');");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Response.Write(hdnfnd.Value); //use for hidden field
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("empid",Common.Cint(txtempid.Text).ToString());
            d.addParameters("empname",txtempname.Text.ToString());
            d.addParameters("designation",ddesignation.Text.ToString());
            d.addParameters("grosssal", txtgrosal.Text);
            d.addParameters("deductions",txtdeduct.Text);
            d.addParameters("netsal",txtnetsal.Text);
            d.addParameters("isactive", chckisactive.Checked ? "Y" : "N");
            d.isProCall = true;
            if ((bool)ViewState["FoundFlag"])
            {
                d.addParameters("action", "update");
            }
            else
            {
                d.addParameters("action", "insert");

            }
            int res = d.ExecuteQuery("pr_empmaster1");
            if(res>0)
            {
                Response.Write("record saved sucessfully");
            }
            else
            {
                Response.Write("record not saved ");
            }
            showGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
              hdnfnd.Value = "false"; //use for hidden field
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DAL d = new DAL();
            d.ClearParameters();
            d.addParameters("empid", Common.Cint(txtempid.Text).ToString());
            d.isProCall=true;
            d.addParameters("action","delete");
            int res = d.ExecuteQuery("pr_empmaster1");
            if (res > 0)
            {
                Response.Write("record delete sucessfully");
                txtempname.Text = "";
                ddesignation.SelectedIndex = 0;
                txtgrosal.Text = "";
                txtdeduct.Text = "";
                txtnetsal.Text = "";
                chckisactive.Checked = false;
            }
            else
            {
                Response.Write("record not delete");
            }
            showGrid();


        }
    }
}
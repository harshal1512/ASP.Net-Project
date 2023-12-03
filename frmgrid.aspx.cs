using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.net
{
    public partial class frmgrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             if(!IsPostBack)
             {
                showgrid();
             }
        }
        
        public void showgrid()
        {
            DAL d=new DAL();
            DataTable dt = d.gettable("select * from employeemaster");
            ViewState["dt"] = dt;
            grddata.DataSource = dt;
            grddata.DataBind();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            for(int i=0;i<grddata.Rows.Count;i++)
            {
                CheckBox grd_chck_save =(CheckBox) grddata.Rows[i].FindControl("grd_chck_save");


                if(grd_chck_save!=null && grd_chck_save.Checked )
                {
                    TextBox grd_txt_empid = (TextBox)grddata.Rows[i].FindControl("grd_txt_empid");

                    HiddenField grd_hdn_empid = (HiddenField)grddata.Rows[i].FindControl("grd_hdn_empid");

                    TextBox grd_txt_empname = (TextBox)grddata.Rows[i].FindControl("grd_txt_empname");
                    DropDownList grd_cmbdesignation = (DropDownList)grddata.Rows[i].FindControl("grd_cmbdesignation");
                    TextBox grd_txt_grossal = (TextBox)grddata.Rows[i].FindControl("grd_txt_grossal");
                    TextBox grd_txt_deduct = (TextBox)grddata.Rows[i].FindControl("grd_txt_deduct");
                    TextBox grd_txt_netsal = (TextBox)grddata.Rows[i].FindControl("grd_txt_netsal");
                    CheckBox grd_chckisactive = (CheckBox)grddata.Rows[i].FindControl("grd_chckisactive");

                    DAL d = new DAL();
                    d.ClearParameters();
                    d.addParameters("empid",Common.Cint(grd_txt_empid.Text).ToString());
                    d.addParameters("empname", grd_txt_empname.Text.ToString());
                    d.addParameters("designation", grd_cmbdesignation.SelectedValue);
                    d.addParameters("grosssal", grd_txt_grossal.Text);
                    d.addParameters("deductions", grd_txt_deduct.Text);
                    d.addParameters("netsal", grd_txt_netsal.Text);
                    d.addParameters("isactive", grd_chckisactive.Checked?"Y":"N");

                    d.isProCall = true;
                    if (Common.Cint(grd_hdn_empid.Value)>0)  //hidden field value means empid which is available 
                    {
                        d.addParameters("action", "update");
                    }

                    else
                    {
                        d.addParameters("action", "insert");
                    }
                    int res = d.ExecuteQuery("pr_empmaster1");
                    Response.Write("record saved successfully!");


                }
            }

            showgrid();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grddata.Rows.Count; i++)
            {
                CheckBox grd_chck_save = (CheckBox)grddata.Rows[i].FindControl("grd_chck_save");

                if (grd_chck_save != null && grd_chck_save.Checked)
                {
                    TextBox grd_txt_empid = (TextBox)grddata.Rows[i].FindControl("grd_txt_empid");

                    DAL d = new DAL();
                    d.ClearParameters();
                    d.addParameters("empid", Common.Cint(grd_txt_empid.Text).ToString());
                    d.addParameters("action", "delete");

                    d.isProCall = true;
                    int res = d.ExecuteQuery("pr_empmaster1");

                    Response.Write("record deleted successfully!!");
                    
                }
            }
            showgrid();
        }

        protected void btn_add_row_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            DataRow dr = dt.NewRow();
            dr["empid"] = 0;
            dr["designation"] = "developer";
            dt.Rows.Add(dr);
            grddata.DataSource = dt;
            grddata.DataBind();
        }

        protected void grddata_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onkeyup","CalculateTotal(this);");
            }
        }
    }
}
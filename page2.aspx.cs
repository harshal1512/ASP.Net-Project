using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.net
{
    public partial class page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //session
           /* if (!IsPostBack && Session["userid"] != null)
            {
                txtuserid.Text = Session["userid"].ToString();
            }
           */

            if (!IsPostBack)
            {
                if (Request.Cookies.Count > 0 && Request.Cookies["mydata"] != null)
                {
                    txtuserid.Text = Request.Cookies["mydata"]["userid"];
                    txtpwd.Text = Request.Cookies["mydata"]["pass"];
                }
            }
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
           /* if (Session["userid.Text"] == null)
                Session.Add("userid",txtuserid.Text);
            else
                Session["userid"]=txtuserid.Text;
            Response.Redirect("page1.aspx");*/
        }
    }
}
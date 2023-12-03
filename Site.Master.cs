using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.net
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                lbluser.Text = Session["userid"].ToString();
            }
            if (Application["name"]!=null)
                lblcompany.Text = Application["name"].ToString();   
        }
    }
}
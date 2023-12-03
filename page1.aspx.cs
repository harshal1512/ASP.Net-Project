using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.net
{
    public partial class page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* if(!IsPostBack && Session["userid"]!=null)
             {
                   txtuserid.Text = Session["userid"].ToString();
             }
            */
            //using query string
            //querstring
           /* if (!IsPostBack)
            {
                if(Request.QueryString.Count>0 && Request.QueryString["userid"]!=null)
                {
                    txtuserid.Text = Request.QueryString["userid"];
                    txtpwd.Text = Request.QueryString["pass"];
                }
            }*/
        }

        protected void Btnnextpage_Click(object sender, EventArgs e)
        {
            /* session
             if (Session["userid.Text"] == null)
                 Session.Add("userid", txtuserid.Text);
             else
                 Session["userid"] = txtuserid.Text;
             Response.Redirect("page2.aspx");
            */
            //querstring
            //  Response.Redirect("page2.aspx?userid="+txtuserid.Text+"&pass="+txtpwd.Text);

            HttpCookie mydata = new HttpCookie("mydata");
            mydata["userid"]=txtuserid.Text;
            mydata["pass"]=txtpwd.Text;
            Response.Cookies.Add(mydata);

            //global asax file
            Session["userid"] = txtuserid.Text;


            Response.Redirect("page2.aspx");
        }
    }
}
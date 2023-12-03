using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asp.net
{
    public partial class AddNumber : System.Web.UI.Page
    {
        int inc = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (!IsPostBack)
                lblnm.Text = "page loaded for 1 time";
            else
                lblnm.Text = "page is not loaded for 1 time";*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //inc++;
            //TextBox1.Text=inc.ToString();//asp textbox
            //using tryparse
            int x = 0;
            int.TryParse(TextBox1.Text, out x);
            x++;
            TextBox1.Text = x.ToString();

            int z = 0;
            int.TryParse(Text1.Value, out z);
            z++;
            Text1.Value = z.ToString();

          
        }
    }
}
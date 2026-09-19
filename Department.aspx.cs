using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationExam
{
    public partial class Department : System.Web.UI.Page
    {
        ConnectionClass clsob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "insert into Department_Tab values('" + TextBox1.Text + "')";
            int i = clsob.fun_ExecNonQuery(s);
            if(i==1)
            {
                Label2.Text = "Dept Inserted";
            }
            else
            {
                Label2.Text = "Dept not Inserted";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationExam
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectionClass clsob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string l = "select count(Reg_id) from Login_Tab where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
            string cid = clsob.fun_ExecScalar(l);
            if (cid == "1")
            {
                
                string log = "select Log_Type from Login_Tab where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
                string logtype = clsob.fun_ExecScalar(log);
                if (logtype == "admin")
                {
                    Response.Redirect("AdminProfile.aspx");
                }
                else if(logtype=="doctor")
                {
                    Response.Redirect("DoctorProfile.aspx");
                }
            }

        }
    }
}
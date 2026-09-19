using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationExam
{
    public partial class AdminReg : System.Web.UI.Page
    {
        ConnectionClass clsob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string sel = "select max(Reg_id) from Login_Tab";
            string maxid = clsob.fun_ExecScalar(sel);
            int reg_id = 0;
            if (maxid == "")
            {
                reg_id = 1;
            }
            else
            {
                reg_id = Convert.ToInt32(maxid) + 1;
            }
            string ins = "insert into AdminReg_Tab values("+reg_id+",'"+txtname.Text+ "','" + txtemail.Text + "')";
            int i = clsob.fun_ExecNonQuery(ins);
            if (i == 1)
            {
                string inslog = "insert into Login_Tab values("+reg_id+",'"+txtuna.Text+ "','" + txtpwd.Text + "','admin','active')";
                int j = clsob.fun_ExecNonQuery(inslog);
                if (j == 1)
                {
                    Label1.Text = "Registration successful";
                }
                else
                {
                    Label1.Text = "Registration failed";
                }
            }
        }
    }
}
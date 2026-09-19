using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace WebApplicationExam
{
    public partial class DoctorReg : System.Web.UI.Page
    {
        ConnectionClass clsob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s= "select Dept_id,Dept_name from Department_Tab";
                DataSet ds=clsob.fun_DataAdapter_dataset(s);
                ddldept.DataSource = ds;
                ddldept.DataTextField = "Dept_name";
                ddldept.DataValueField = "Dept_id";
                ddldept.DataBind();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
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
            string path = "~/Photo/"+fuPhoto.FileName;
            fuPhoto.SaveAs(MapPath(path));
            string ins = "insert into Doc_Reg_tab values(" + reg_id + ",'" + ddldept.SelectedItem.Value + "','" + txtname.Text + "'," + txtage.Text + "," +
                "'" + txtph.Text + "','"+path+"')";
            int i = clsob.fun_ExecNonQuery(ins);
            if (i == 1)
            {
                string inslog = "insert into Login_Tab values(" + reg_id + ",'" + txtuna.Text + "','" + txtpwd.Text + "','doctor','active')";
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
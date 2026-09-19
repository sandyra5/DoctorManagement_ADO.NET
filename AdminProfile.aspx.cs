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
    public partial class AdminProfile : System.Web.UI.Page
    {
        ConnectionClass clsob = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string sel = "select dr.Name,dr.Age,dr.Phone,dt.Dept_name,dr.Photo from Doc_Reg_tab dr join Department_Tab dt on dr.Dept_id=dt.Dept_id " +
                "where dt.Dept_name='"+TextBox1.Text+"'";
            DataSet ds = clsob.fun_DataAdapter_dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}
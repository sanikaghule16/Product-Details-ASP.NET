using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Product_qty
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT * FROM Product WHERE Name LIKE @name + '%'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", TextBox1.Text);

                con.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();

                con.Close();
            }
        
    }
    }
    
}

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VJOMS
{
    public class clsModelM
    {
        private SqlConnection con;
        public clsModelM()
        {
            string strCon = "Data Source=sgcserver, 16900; Initial Catalog=VJOR; User ID = redbaron; Password=m@gi3";
            con = new SqlConnection(strCon);
        }
        public DataTable getAllModel()
        {
            string s = "SELECT * FROM VehicleList WHERE VSTATUS != 'INACTIVE'";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "Model");
            con.Close();
            DataTable dt = ds.Tables["Model"];
            return dt;
        }
        public DataTable getJOListById(clsModel m)
        {
            string s = "SELECT * FROM JOLIST WHERE JOPLATE = @plate";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@plate", m.plate);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            con.Open();
            ada.Fill(ds, "JO");
            con.Close();
            DataTable dt = ds.Tables["JO"];
            return dt;
        }
        public void getModelById(clsModel m)
        {
            string s = "SELECT * FROM VehicleList WHERE VID = @modelid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@modelid", m.vId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                m.brand = rdr["VBRAND"].ToString();
                m.model = rdr["VMODEL"].ToString();
                m.year = rdr["VYEAR"].ToString();
                m.color = rdr["VCOLOR"].ToString();
                m.plate = rdr["VPLATE"].ToString();
                m.company = rdr["VCOMPANY"].ToString();
                m.assigned = rdr["VASSIGNED"].ToString();
                m.owner = rdr["VOWNER"].ToString();
                m.status = rdr["VSTATUS"].ToString();
                m.remarks = rdr["VREMARKS"].ToString();
                m.registration = rdr["VREGISTRATION"].ToString();


            }
            con.Close();
        }
        public void deleteModel(clsModel m)
        {
            string s = "UPDATE VehicleList SET VSTATUS = 'INACTIVE' WHERE VID = @modelid";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@modelid", m.vId);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void addModel(clsModel m)
        {
            string s = "INSERT INTO [dbo].[VehicleList([VBRAND],[VMODEL],[VYEAR],[VCOLOR],"+
                "[VPLATE],[VCOMPANY],[VASSIGNED],[VOWNER],[VSTATUS],[VREMARKS],[VREGISTRATION])VALUES(@VID,@VBRAND,"+
                "@VMODEL, @VYEAR, @VCOLOR, @VPLATE, @VCOMPANY, @VASSIGNED, @VOWNER, @VSTATUS, @VREMARKS, @VREGISTRATION";
            SqlCommand cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@VBRAND", m.brand);
            cmd.Parameters.AddWithValue("@VMODEL", m.model);
            cmd.Parameters.AddWithValue("@VYEAR", m.year);
            cmd.Parameters.AddWithValue("@VCOLOR", m.color);
            cmd.Parameters.AddWithValue("@VPLATE", m.plate);
            cmd.Parameters.AddWithValue("@VCOMPANY", m.company);
            cmd.Parameters.AddWithValue("@VASSIGNED", m.assigned);
            cmd.Parameters.AddWithValue("@VOWNER", m.owner);
            cmd.Parameters.AddWithValue("@VSTATUS", m.status);
            cmd.Parameters.AddWithValue("@VREMARKS", m.remarks);
            cmd.Parameters.AddWithValue("@VREGISTRATION", m.registration);
            con.Open();
           try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully added model.", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message, "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public Int64 getMaxId()
        {
            string s = "SELECT MAX(MAXID) FROM JOLIST";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
            Int64 id = Convert.ToInt64(cmd.ExecuteScalar());
            con.Close();
            return id;

        }
    }
}

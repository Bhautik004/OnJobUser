using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using OnJobEntity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using OnJobEntity.JobSeeker;

namespace OnJob_DAL
{
    public class UserDL
    {


        SqlConnection con = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString));
        public int AddUserDetails(User ObjUser) // passing Bussiness object Here  
        {
            try
            {
                /* Because We will put all out values from our (UserRegistration.aspx) To in Bussiness object and then Pass it to Bussiness logic and then to DataAcess  this way the flow carry on*/
                SqlCommand cmd = new SqlCommand("RegistrionUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", ObjUser.FirstName);
                cmd.Parameters.AddWithValue("@LastName", ObjUser.LastName);
                cmd.Parameters.AddWithValue("@Email", ObjUser.Email);
                cmd.Parameters.AddWithValue("@Password", ObjUser.Password);
                con.Open();
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
               
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    cmd.Dispose();
                    con.Close();
                    return 1;
                }
                else
                {   
                    cmd.Dispose();
                    con.Close();
                    return 0;
                }
            }
            catch
            {
                con.Close();
                throw;
                
            }
        }

       



    }
}

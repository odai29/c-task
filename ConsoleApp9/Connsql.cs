using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class Connsql
    {
         internal static void execute(string query)
        {


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2O0E8N7\SQLEXPRESS;Initial Catalog=school1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();



        }
        internal static SqlDataReader readsql(string query)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2O0E8N7\SQLEXPRESS;Initial Catalog=school1;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader reader = cmd.ExecuteReader();
            
            return reader;
        }
    }
}

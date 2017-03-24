using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class UserInfo
    {
        const string source = "Data Source =.; Initial Catalog = EHandel; Integrated Security = True";

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Companyname { get; set; }
        public int DeliveryadressID { get; set; }
        public int BillingadressID { get; set; }

        public UserInfo(string firstname, string lastname, string phone, string companyname, int deliveryadressID, int billingadressID)
        {
            Firstname = firstname;
            Lastname = lastname;
            Phone = phone;
            Companyname = companyname;
            DeliveryadressID = deliveryadressID;
            BillingadressID = billingadressID;
        }

        public UserInfo()
        {

        }

        public void AddUserInfo(string firstname, string lastname, string phone, string companyname, int deliveryadressID, int billingadressID)
        {
            SqlConnection myConnection = new SqlConnection(source);
            int newID = 0;

                SqlConnection myConnection = new SqlConnection(source);

                try
                {
                    myConnection.Open();

                    SqlCommand myCommand = new SqlCommand("AddUser", myConnection);
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter newEmail = new SqlParameter("@email", SqlDbType.VarChar);
                    newEmail.Value = email;

                    SqlParameter newPassword = new SqlParameter("@password", SqlDbType.VarChar);
                    newPassword.Value = password;

                    SqlParameter newUserID = new SqlParameter("@newID", SqlDbType.VarChar);
                    newUserID.Direction = ParameterDirection.Output;

                    myCommand.Parameters.Add(newEmail);
                    myCommand.Parameters.Add(newPassword);
                    myCommand.Parameters.Add(newUserID);

                    myCommand.ExecuteNonQuery();

                    newID = (int)newUserID.Value;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    myConnection.Close();
                }
        }

        public void AddUserInfo(UserInfo userInfo)
        {

        }

        public void UpdateContactInfo()
        {

        }

    }

}

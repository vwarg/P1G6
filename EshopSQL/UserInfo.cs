using System;
using System.Collections.Generic;
using System.Data;
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

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("AddUserInfo", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newFirstName = new SqlParameter("@firstname", SqlDbType.VarChar);
                newFirstName.Value = firstname;

                SqlParameter newLastName = new SqlParameter("@lastname", SqlDbType.VarChar);
                newLastName.Value = lastname;

                SqlParameter newPhone = new SqlParameter("@phone", SqlDbType.VarChar);
                newPhone.Value = phone;

                SqlParameter newCompanyName = new SqlParameter("@companyname", SqlDbType.VarChar);
                newCompanyName.Value = companyname;

                SqlParameter newDeliveryAdressId = new SqlParameter("@deliveryadressID", SqlDbType.VarChar);
                newDeliveryAdressId.Value = deliveryadressID;

                SqlParameter newBillingAdressId = new SqlParameter("@billingAdressID", SqlDbType.VarChar);
                newBillingAdressId.Value = billingadressID;

                SqlParameter newUserInfoId = new SqlParameter("@userinfoID ", SqlDbType.VarChar);
                newUserInfoId.Direction = ParameterDirection.Output;

                myCommand.Parameters.Add(newFirstName);
                myCommand.Parameters.Add(newLastName);
                myCommand.Parameters.Add(newPhone);
                myCommand.Parameters.Add(newCompanyName);
                myCommand.Parameters.Add(newDeliveryAdressId);
                myCommand.Parameters.Add(newBillingAdressId);
                myCommand.Parameters.Add(newUserInfoId);

                myCommand.ExecuteNonQuery();

                newID = (int)newUserInfoId.Value;

            }
            catch (Exception ex) {Console.WriteLine(ex.Message);}
            finally {myConnection.Close();}
        }

        public void AddUserInfo(UserInfo userinfo)
        {
            //TODO
        }

        public static void UpdateUserInfo(int id, string firstname, string lastname, string phone, string companyname, int deliveryadressID, int billingadressID)
        {
            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"update UserInfo set firstname = '{firstname}', lastname = '{lastname}', phone = '{phone}', companyname = '{companyname}', deliveryadressID = '{deliveryadressID}', billingadressID = '{billingadressID}' where ID={id} ", myConnection);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex){ Console.WriteLine(ex.Message);}
            finally { myConnection.Close(); }
        }



    }

}

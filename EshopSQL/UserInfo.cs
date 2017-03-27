using EshopSQL;
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
        private Adress da;
        private Adress ba;
        public Adress DeliveryAdress
        {
            get
            {
                return da ?? (da = SQL.GetAdressByID(DeliveryadressID));
            }
        }
        public Adress BillingAdress
        {
            get
            {
                return ba ?? (ba = SQL.GetAdressByID(BillingadressID));
            }
        }


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

        public static int AddUserInfo(string firstname, string lastname, string phone, string companyname, int deliveryadressID, int billingadressID)
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

                SqlParameter newDeliveryAdressId = new SqlParameter("@deliveryadressID", SqlDbType.Int);
                newDeliveryAdressId.Value = deliveryadressID;

                SqlParameter newBillingAdressId = new SqlParameter("@billingAdressID", SqlDbType.Int);
                newBillingAdressId.Value = billingadressID;

                SqlParameter newUserInfoId = new SqlParameter("@userinfoID ", SqlDbType.Int);
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
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return newID;
        }

        public static int AddUserInfo(UserInfo userinfo)
        {
            return AddUserInfo(userinfo.Firstname, userinfo.Lastname, userinfo.Phone, userinfo.Companyname, userinfo.DeliveryadressID, userinfo.BillingadressID);
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
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }

        public override string ToString()
        {
            var nl = Environment.NewLine;
            var str = "UserInfo: "+nl;
            str += $"ID: {ID}" + nl;
            str += $"FirstName: {Firstname}" + nl;
            str += $"LastName: {Lastname}" + nl;
            str += $"Phone: {Phone}" + nl;
            str += $"CompanyName: {Companyname}" + nl;
            str += $"DeliveryAdress: {DeliveryAdress.ToString()}" + nl;
            str += $"BillingAdress: {BillingAdress.ToString()}" + nl;
            return str;
        }

    }

}

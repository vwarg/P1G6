using HeftITGemer;
using PasswordLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSQL
{
    /// <summary>
    /// SQL
    /// </summary>
    public class SQL
    {
        const string source = "Data Source =.; Initial Catalog = EHandel; Integrated Security = True";

        public static Adress GetAdressByID(int adressId)
        {
            Adress a = null;
            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand getAdress = new SqlCommand($"select * from Adress where ID = '{adressId}'", myConnection);
                SqlDataReader myReader = getAdress.ExecuteReader();

                while (myReader.Read())
                {
                    a = new Adress(myReader["country"].ToString(), myReader["city"].ToString(), myReader["street"].ToString(), myReader["zip"].ToString(), myReader["phone"].ToString(), myReader["department"].ToString());
                    a.ID = adressId;
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return a;
        }

        public static User GetUserByEmail(string email)
        {
            User user = null;

            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand getUser = new SqlCommand($"select * from Users where email = '{email}'", myConnection);
                SqlDataReader myReader = getUser.ExecuteReader();

                while (myReader.Read())
                {
                    user = new User((int)myReader["ID"], myReader["email"].ToString(),
                        myReader["password"].ToString(), (int)myReader["contactinfo"], (byte)myReader["isCompany"],
                        (int)myReader["status"]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return user;
        }

        public static UserInfo GetUserInfoByID(int userInfoID)
        {
            UserInfo ui = null;

            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand getContactInfo = new SqlCommand($"select * from UserInfo where ID = {userInfoID}", myConnection);
                SqlDataReader ciReader = getContactInfo.ExecuteReader();
                while (ciReader.Read())
                {
                    ui = new UserInfo();
                    ui.Firstname = ciReader["firstname"].ToString();
                    ui.Lastname = ciReader["lastname"].ToString();
                    ui.ID = (int)ciReader["ID"];
                    ui.Phone = ciReader["phone"].ToString();
                    ui.Companyname = ciReader["companyname"].ToString();
                    ui.DeliveryadressID = (int)ciReader["deliveryadressID"];
                    ui.BillingadressID = (int)ciReader["billingadressID"];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return ui;
        }

        public static bool DoesUserExist(string email)
        {
            SqlConnection myConnection = new SqlConnection(source);
            SqlDataReader myReader = null;
            bool result = false;
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"select email from Users where email = '{email}'", myConnection);
                myReader = myCommand.ExecuteReader();
                result = myReader.HasRows;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return result;

        }

        public static int AddUser(string email, string password, int userInfo = -1)
        {
            int newID = 0;

            // Om email inte existerar, skapa ny användare
            if (!DoesUserExist(email))
            {
                SqlConnection myConnection = new SqlConnection(source);

                try
                {
                    myConnection.Open();

                    SqlCommand myCommand = new SqlCommand("AddUser", myConnection);
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter newEmail = new SqlParameter("@email", SqlDbType.VarChar);
                    newEmail.Value = email;

                    SqlParameter contactID = new SqlParameter("@contactID", SqlDbType.Int);
                    contactID.Value = userInfo;

                    SqlParameter newPassword = new SqlParameter("@password", SqlDbType.VarChar);
                    newPassword.Value = password;

                    SqlParameter newUserID = new SqlParameter("@newID", SqlDbType.Int);
                    newUserID.Direction = ParameterDirection.Output;

                    myCommand.Parameters.Add(newEmail);
                    myCommand.Parameters.Add(newPassword);
                    myCommand.Parameters.Add(contactID);
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
            return newID;
        }

        public static int UpdateUser(User u)
        {
            SqlConnection myConnection = new SqlConnection(source);
            int affectedRows = 0;
            

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"update Users set status = {u.Status}, contactinfo = {u.Contactinfo}, where email = {u.Email}", myConnection);
                affectedRows = myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return affectedRows;
        }

        private static int ChangeUserStatus(string email, int status)
        {
            SqlConnection myConnection = new SqlConnection(source);
            int affectedRows = 0;

            if (status < 0 || status > 2)
            {
                return 0;
            }

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"update Users set status = {status} where email = '{email}'", myConnection);
                affectedRows = myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return affectedRows;
        }

        public static int InactivateUser(string email)
        {
            return ChangeUserStatus(email, 0);
        }

        public static int ActivateUser(string email)
        {
            return ChangeUserStatus(email, 1);
        }

        public static int UserIsAdmin(string email)
        {
            return ChangeUserStatus(email, 2);
        }

        public static User AddUser(string email, string password, UserInfo ui = null)
        {
            User toAdd = new User();
            toAdd.Email = email;
            toAdd.Password = PasswordHelper.GetHash(password);
            UserInfo userInfo = ui;
            if(userInfo == null)
            {
                userInfo = new UserInfo("", "", "", "", -1, -1);
                Adress a = new Adress("", "", "", "", "", "");
                int aid = Adress.AddAdress(a);
                userInfo.BillingadressID = aid;
                userInfo.DeliveryadressID = aid;
            }
            else
            {
                if (userInfo.DeliveryadressID < 0)
                {
                    Adress a = new Adress("", "", "", "", "", "");
                    int aid = Adress.AddAdress(a);
                    userInfo.DeliveryadressID = aid;
                }
                if (userInfo.BillingadressID < 0)
                {
                    Adress a = new Adress("", "", "", "", "", "");
                    int aid = Adress.AddAdress(a);
                    userInfo.BillingadressID = aid;
                }
            }
            int uiid = UserInfo.AddUserInfo(userInfo);
            toAdd.Contactinfo = uiid;
            int uid = AddUser(toAdd.Email, toAdd.Password, toAdd.Contactinfo);
            toAdd.ID = uid;

            return toAdd;
        }

        public static bool Login(User u, string enteredPassword)
        {
            return PasswordHelper.MatchesHash(u.Password, enteredPassword);
        }

        public static bool TryLogin(string email, string password)
        {
            User u = GetUserByEmail(email);
            if(u == null)
            {
                return false;
            }
            return Login(u, password);
        }

    }
}

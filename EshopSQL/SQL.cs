using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EshopSQL
{
    public class SQL
    {
        const string source = "Data Source =.; Initial Catalog = EHandel; Integrated Security = True";

        public static User GetUserByEmail(string email)
        {
            User user = null;

            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"select * from Users where email = '{email}'", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

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


    }
}

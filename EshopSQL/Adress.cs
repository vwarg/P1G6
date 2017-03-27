using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    /// <summary>
    /// Adress
    /// </summary>
    public class Adress
    {
        const string source = "Data Source =.; Initial Catalog = EHandel; Integrated Security = True";

        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }

        public Adress(string country, string city, string street, string zip, string phone, string department)
        {
            Country = country;
            City = city;
            Street = street;
            Zip = zip;
            Department = department;
            Phone = phone;
        }

        public Adress()
        {

        }

        public static int AddAdress(Adress a)
        {
            return AddAdress(a.Country, a.City, a.Street, a.Zip, a.Phone, a.Department);
        }

        public static int AddAdress(string country, string city, string street, string zip, string phone, string department)
        {
            int newAdressID = 0;

            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("AddAdress", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newCountry = new SqlParameter("@country", SqlDbType.VarChar);
                newCountry.Value = country;

                SqlParameter newCity = new SqlParameter("@city", SqlDbType.VarChar);
                newCity.Value = city;

                SqlParameter newStreet = new SqlParameter("@street", SqlDbType.VarChar);
                newStreet.Value = street;

                SqlParameter newZip = new SqlParameter("@zip", SqlDbType.VarChar);
                newZip.Value = zip;

                SqlParameter newPhone = new SqlParameter("@phone", SqlDbType.VarChar);
                newPhone.Value = phone;

                SqlParameter newDepartment = new SqlParameter("@department", SqlDbType.VarChar);
                newDepartment.Value = department;

                SqlParameter adressID = new SqlParameter("@adressID", SqlDbType.Int);
                adressID.Direction = ParameterDirection.Output;

                myCommand.Parameters.Add(newCountry);
                myCommand.Parameters.Add(newCity);
                myCommand.Parameters.Add(newStreet);
                myCommand.Parameters.Add(newZip);
                myCommand.Parameters.Add(newPhone);
                myCommand.Parameters.Add(newDepartment);
                myCommand.Parameters.Add(adressID);

                myCommand.ExecuteNonQuery();

                newAdressID = (int)adressID.Value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return newAdressID;
        }

        public static void UpdateAdress(int id, string country, string city, string street, string zip, string phone, string department)
        {
            //Uppdaterar en adress. Ange id till billingAdressId eller deliveryAdressId
            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand($"UPDATE Adress SET country = '{country}', city = '{city}', street = '{street}', zip = '{zip}', phone = '{phone}', department = '{department}' WHERE ID = '{id}'", myConnection);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }

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
    }
}



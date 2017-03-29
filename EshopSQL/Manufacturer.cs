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
    /// Category
    /// </summary>
    public class Manufacturer
    {
        const string source = "Data Source =.; Initial Catalog = EHandel; Integrated Security = True";

        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Manufacturer(int id, string name, string url)
        {
            ID = id;
            Name = name;
            Url = url;
        }

        public string ToJson()
        {
            var json = "{";
            json += $"\"ID\": \"{ID}\",";
            json += $"\"Name\": \"{Name}\",";
            json += $"\"Url\": \"{Url}\"";
            json += "}";
            return json;
        }

        public Manufacturer() { }

        public static Manufacturer GetManufacturerById(int manufacturerId)
        {
            Manufacturer manufacturer = null;

            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"select * from Manufacturer where ID = {manufacturerId}", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    manufacturer = new Manufacturer((int)myReader["ID"], myReader["name"].ToString(), myReader["url"].ToString());
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return manufacturer;
        }

        public static int AddManufacturer(string name, string url)
        {
            int newManufactId = 0;

            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("AddManufacturer", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newName = new SqlParameter("@name", SqlDbType.VarChar);
                newName.Value = name;

                SqlParameter newUrl = new SqlParameter("@url", SqlDbType.Text);
                newUrl.Value = url;

                SqlParameter manufacturerId = new SqlParameter("@newManufactId", SqlDbType.Int);
                manufacturerId.Direction = ParameterDirection.Output;

                myCommand.Parameters.Add(newName);
                myCommand.Parameters.Add(newUrl);
                myCommand.Parameters.Add(manufacturerId);

                myCommand.ExecuteNonQuery();

                newManufactId = (int)manufacturerId.Value;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return newManufactId;
        }

        public static int AddManufacturer(Manufacturer m)
        {
            return AddManufacturer(m.Name, m.Url);
        }

        public static void UpdateManufacturer(int id, string name, string url)
        {
            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand($"UPDATE Manufacturer SET name = '{name}', url = '{url}' WHERE ID = '{id}'", myConnection);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }

    }
}

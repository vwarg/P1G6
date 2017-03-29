using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeftITGemer
{
    public class Category
    {
        // this is a comment
        const string source = "Data Source =.; Initial Catalog = EHandel; Integrated Security = True";

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ParentCategory { get; set; }

        public Category(int id, string name, string description, int parentCategory)
        {
            ID = id;
            Name = name;
            Description = description;
            ParentCategory = parentCategory;
        }

        public Category() { }

        public static List<int> GetCategoryById(int categoryId)
        {
            List<int> categoryList = new List<int>();

            Category category = null;


            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"select * from Category where ID = {categoryId}", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    category = new Category((int)myReader["ID"], myReader["name"].ToString(), myReader["description"].ToString(), (int)myReader["parentCategory"]);
                }

                SqlCommand parentCommand = new SqlCommand($"select * from Category where parentCategory = {category.ParentCategory}", myConnection);
                SqlDataReader parentReader = parentCommand.ExecuteReader();

                while (parentReader.Read())
                {
                    int pCId = (int)parentReader["parentCategory"];

                    categoryList.Add(pCId);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return categoryList;
        }

        public static int AddCategory(string name, string description, int parentCategory)
        {
            int newCtgryId = 0;

            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("AddCategory", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newName = new SqlParameter("@name", SqlDbType.VarChar);
                newName.Value = name;

                SqlParameter newDescription = new SqlParameter("@description", SqlDbType.VarChar);
                newDescription.Value = description;

                SqlParameter newParentCategory = new SqlParameter("@parentCategory", SqlDbType.Int);
                newParentCategory.Value = parentCategory;

                SqlParameter newCategoryId = new SqlParameter("@newCategoryId", SqlDbType.Int);
                newCategoryId.Direction = ParameterDirection.Output;

                myCommand.Parameters.Add(newName);
                myCommand.Parameters.Add(newDescription);
                myCommand.Parameters.Add(newParentCategory);
                myCommand.Parameters.Add(newCategoryId);

                myCommand.ExecuteNonQuery();

                newCtgryId = (int)newCategoryId.Value;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return newCtgryId;
        }

        public static int AddCategory(Category c)
        {
            return AddCategory(c.Name, c.Description, c.ParentCategory);
        }

        public static void UpdateCategory(int id, string name, string description, int parentCategory)
        {
            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"UPDATE Category SET name = '{name}', description = '{description}', parentCategory = '{parentCategory}' WHERE ID = '{id}'", myConnection);
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
        }

        public string ToJson()
        {
            var json = "{";
            json += $"\"ID\": \"{ID}\",";
            json += $"\"Name\": \"{Name}\",";
            json += $"\"Description\": \"{Description}\",";
            json += $"\"ParentCategory\": \"{ParentCategory}\"";
            json += "}";
            return json;
        }
    }
}

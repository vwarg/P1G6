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
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        const string source = "Data Source =.; Initial Catalog = EHandel; Integrated Security = True";

        public int ID { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int ParentProduct { get; set; }
        public float Price { get; set; }
        public int CountPerUnit { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public int Status { get; set; }
        public int ManufacturerID { get; set; }
        public string ManufacturerProductNumber { get; set; }
        public int CategoryID { get; set; }

        //Konstruktor för alla parametrar i klassen       
        public Product(int id, string name, string shortDescription, string description, int parentProduct, float price, int countPerUnit, int quantity, string comment, string image, string video, int status, int manufacturerID, string manufacturerProductNumber, int categoryID)
        {
            ID = id;
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            ParentProduct = parentProduct;
            Price = price;
            CountPerUnit = countPerUnit;
            Quantity = quantity;
            Comment = comment;
            Image = image;
            Video = video;
            Status = status;
            ManufacturerID = manufacturerID;
            ManufacturerProductNumber = manufacturerProductNumber;
            CategoryID = categoryID;
        }

        public Product() { }

        public static Product GetProductById(int productId)
        {
            Product product = null;

            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"select * from Product where ID = {productId}", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    product = new Product((int)myReader["ID"], myReader["name"].ToString(), myReader["short_description"].ToString(),
                            myReader["description"].ToString(), (int)myReader["parentProduct"], (float)myReader["price"],
                            (int)myReader["countPerUnit"], (int)myReader["quantity"], myReader["comment"].ToString(),
                            myReader["image"].ToString(), myReader["video"].ToString(), (int)myReader["status"], (int)myReader["manufacturerID"],
                            myReader["manufacturer_productnumber"].ToString(), (int)myReader["categoryID"]);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return product;
        }

        public static int AddProduct(string name, string shortDescription, string description, int parentProduct, float price, int countPerUnit, int quantity, string comment, string image, string video, int status, int manufacturerID, string manufacturerProductNumber, int categoryID)
        {
            int newID = 0;


            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("AddProduct", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newName = new SqlParameter("@name", SqlDbType.VarChar);
                newName.Value = name;

                SqlParameter newShortDescription = new SqlParameter("@short_description", SqlDbType.VarChar);
                newShortDescription.Value = shortDescription;

                SqlParameter newDescription = new SqlParameter("@description", SqlDbType.Text);
                newDescription.Value = description;

                SqlParameter newParentProduct = new SqlParameter("@parentProduct ", SqlDbType.Int);
                newParentProduct.Value = parentProduct;

                SqlParameter newPrice = new SqlParameter("@price", SqlDbType.Float);
                newPrice.Value = price;

                SqlParameter newCountPerUnit = new SqlParameter("@countPerUnit", SqlDbType.Int);
                newCountPerUnit.Value = countPerUnit;

                SqlParameter newQuantity = new SqlParameter("@quantity", SqlDbType.Int);
                newQuantity.Value = quantity;

                SqlParameter newComment = new SqlParameter("@comment", SqlDbType.Text);
                newComment.Value = comment;

                SqlParameter newImage = new SqlParameter("@image", SqlDbType.Text);
                newImage.Value = image;

                SqlParameter newVideo = new SqlParameter("@video", SqlDbType.Text);
                newVideo.Value = video;

                SqlParameter newStatus = new SqlParameter("@status", SqlDbType.Int);
                newStatus.Value = status;

                SqlParameter newManufacturerId = new SqlParameter("@manufacturerID", SqlDbType.Int);
                newManufacturerId.Value = manufacturerID;

                SqlParameter newManufacturerProductNumber = new SqlParameter("@manufacturer_productnumber", SqlDbType.VarChar);
                newManufacturerProductNumber.Value = manufacturerProductNumber;

                SqlParameter newCategoryId = new SqlParameter("@categoryID", SqlDbType.Int);
                newCategoryId.Value = categoryID;

                SqlParameter newProductId = new SqlParameter("@newProductId", SqlDbType.Int);
                newProductId.Direction = ParameterDirection.Output;

                myCommand.Parameters.Add(newName);
                myCommand.Parameters.Add(newShortDescription);
                myCommand.Parameters.Add(newDescription);
                myCommand.Parameters.Add(newParentProduct);
                myCommand.Parameters.Add(newPrice);
                myCommand.Parameters.Add(newCountPerUnit);
                myCommand.Parameters.Add(newQuantity);
                myCommand.Parameters.Add(newComment);
                myCommand.Parameters.Add(newImage);
                myCommand.Parameters.Add(newVideo);
                myCommand.Parameters.Add(newStatus);
                myCommand.Parameters.Add(newManufacturerId);
                myCommand.Parameters.Add(newManufacturerProductNumber);
                myCommand.Parameters.Add(newCategoryId);
                myCommand.Parameters.Add(newProductId);

                myCommand.ExecuteNonQuery();

                newID = (int)newProductId.Value;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
            SQL.UpdateProductCache();
            return newID;
        }

        public static int AddProduct(Product p)
        {
            return AddProduct(p.Name, p.ShortDescription, p.Description, p.ParentProduct, p.Price, p.CountPerUnit, p.Quantity, p.Comment, p.Image, p.Video, p.Status, p.ManufacturerID, p.ManufacturerProductNumber, p.CategoryID);
        }

        private static int ChangeProductStatus(int id, int status)
        {
            SqlConnection myConnection = new SqlConnection(source);
            int affectedRows = 0;

            if (status < 0 || status > 1)
            {
                return 0;
            }

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"update User set status = {status} where ID = {id}", myConnection);
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
            SQL.UpdateProductCache();
            return affectedRows;
        }

        public static int InactivateProduct(int id)
        {
            return ChangeProductStatus(id, 0);
        }

        public static int ActivateProduct(int id)
        {
            return ChangeProductStatus(id, 1);
        }

        public static void UpdateProduct(int id, string name, string shortDescription, string description, int parentProduct, float price, int countPerUnit, int quantity, string comment, string image, string video, int status, int manufacturerID, string manufacturerProductNumber, int categoryID)
        {
            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand($"UPDATE Products SET  name = '{name}', shortDescription = '{shortDescription}', description = '{description}', parentProduct = '{parentProduct}', price = '{price}', countPerUnit = '{countPerUnit}', quantity = '{quantity}', comment = '{comment}', image = '{image}', video = '{video}', status = '{status}, 'manufacturerID = '{manufacturerID}', manufacturerProductNumber = '{manufacturerProductNumber}', categoryID = '{categoryID}' WHERE ID = '{id}'", myConnection);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
            SQL.UpdateProductCache();
        }

        public static void UpdateProduct(Product p)
        {
            UpdateProduct(p.ID, p.Name, p.ShortDescription, p.Description, p.ParentProduct, p.Price, p.CountPerUnit, p.Quantity, p.Comment, p.Image, p.Video, p.Status, p.ManufacturerID, p.ManufacturerProductNumber, p.CategoryID);
        }
    }
}
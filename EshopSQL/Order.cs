﻿using EshopSQL;
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
    /// Order
    /// </summary>
    public class Order
    {
        const string source = "Data Source =.; Initial Catalog = EHandel; Integrated Security = True";

        public int ID { get; set; }
        public int UserID { get; set; }
        public int BillingAdressID { get; set; }
        public int DeliveryAdressID { get; set; }
        public float TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateProcessed { get; set; }
        public DateTime? DateFulfilled { get; set; }
        public int Status { get; set; }

        public Order (int id, int userId, int billingAdressID, int deliveryAdressID, float totalPrice, DateTime dateCreated, DateTime? dateProcessed, DateTime? dateFulfilled, int status)
        {
            ID = id;
            UserID = userId;
            BillingAdressID = billingAdressID;
            DeliveryAdressID = deliveryAdressID;
            TotalPrice = totalPrice;
            DateCreated = dateCreated;
            DateProcessed = dateProcessed;
            DateFulfilled = dateFulfilled;
            Status = status;
        }

        public Order() { }

        public static int AddOrder (User user)
        {
            SqlConnection myConnection = new SqlConnection(source);
            int newOrdrId = 0;

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("AddOrder", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newUserId = new SqlParameter("@userId", SqlDbType.Int);
                newUserId.Value = user.ID;

                SqlParameter newBillingAdressId = new SqlParameter("@billingAdressId", SqlDbType.Int);
                newBillingAdressId.Value = user.Info.BillingadressID;

                SqlParameter newDeliveryAdressID = new SqlParameter("@deliveryAdressId", SqlDbType.Int);
                newDeliveryAdressID.Value = user.Info.DeliveryadressID;

                SqlParameter newOrderId = new SqlParameter("@newOrderId ", SqlDbType.Int);
                newOrderId.Direction = ParameterDirection.Output;

                myCommand.Parameters.Add(newUserId);
                myCommand.Parameters.Add(newBillingAdressId);
                myCommand.Parameters.Add(newDeliveryAdressID);
                myCommand.Parameters.Add(newOrderId);

                myCommand.ExecuteNonQuery();

                newOrdrId = (int)newOrderId.Value;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return newOrdrId;
        }

        public static void AddProductToOrder(int productId, int orderId, int quantity)
        {
            SqlConnection myConnection = new SqlConnection(source);
            
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("AddProductToOrder", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newProductId = new SqlParameter("@productId", SqlDbType.Int);
                newProductId.Value = productId;

                SqlParameter newOrderId = new SqlParameter("@orderId", SqlDbType.Int);
                newOrderId.Value = orderId;

                SqlParameter newQuantity = new SqlParameter("@quantity", SqlDbType.Int);
                newQuantity.Value = quantity;

                myCommand.Parameters.Add(newProductId);
                myCommand.Parameters.Add(newOrderId);
                myCommand.Parameters.Add(newQuantity);

                myCommand.ExecuteNonQuery();

                SqlCommand updateOTP = new SqlCommand($"UPDATE OrderToProduct SET price = {SQL.GetAllProducts().First(p => p.ID == productId).Price.ToString().Replace(',', '.')} WHERE productID = {productId} AND orderID = {orderId}", myConnection);

                updateOTP.ExecuteNonQuery();

                SqlCommand updateOrder = new SqlCommand($"UPDATE Orders SET total_price += {Product.GetProductById(productId).Price} WHERE ID = {orderId}", myConnection);

                updateOrder.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }
            
        }


        public static void IncreaseQuantityOfProduct(int productId, int orderId, int quantityToAdd)
        {
            SqlConnection myConnection = new SqlConnection(source);

            try
            {
                myConnection.Open();

                SqlCommand updateOTP = new SqlCommand($"UPDATE OrderToProduct SET quantity += {quantityToAdd}, price += {Product.GetProductById(productId).Price.ToString().Replace(',','.')} WHERE productID = {productId} AND orderID = {orderId}", myConnection);

                updateOTP.ExecuteNonQuery();

                SqlCommand updateOrder = new SqlCommand($"UPDATE Orders SET total_price += {Product.GetProductById(productId).Price} WHERE ID = {orderId}", myConnection);

                updateOrder.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

        }

        /*public static void UpdateOrder(int orderId)
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
        */

        #region ORDER STATUS
        private static int ChangeOrderStatus(int id, int status)
        {

            //0=skapad, 1=proccesed, 2=fullfilled OBS Förslag
            SqlConnection myConnection = new SqlConnection(source);
            int affectedRows = 0;

            if (status < 0 || status > 3)
            {
                return 0;
            }

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand($"update Orders set status = {status} where ID = {id}", myConnection);
                affectedRows = myCommand.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return affectedRows;
        }

        public static int OrderProcessed(int id, DateTime dateProcessed)
        {
            SqlConnection myConnection = new SqlConnection(source);
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand($"update Orders set dateProcessed = {dateProcessed} where ID = {id}", myConnection);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return ChangeOrderStatus(id, 1);
        }

        public static int OrderFulfilled(int id, DateTime dateFulfilled)
        {
            SqlConnection myConnection = new SqlConnection(source);
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand($"update Orders set dateFulfilled = {dateFulfilled} where ID = {id}", myConnection);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { myConnection.Close(); }

            return ChangeOrderStatus(id, 2);

        }
        #endregion

        public string ToJson(bool withProducts = false)
        {
            var json = "{";
            json += $"\"ID\": {ID},";
            json += $"\"UserID\": {UserID},";
            json += $"\"BillingAdressID\": {BillingAdressID},";
            json += $"\"DeliveryAdressID\": {DeliveryAdressID},";
            json += $"\"DateCreated\": \"{DateCreated}\",";
            json += $"\"DateProcessed\": \"{DateProcessed}\",";
            json += $"\"DateFulfilled\": \"{DateFulfilled}\",";
            json += $"\"NumProducts\": {SQL.GetProductsInOrder(this).Count},";
            json += $"\"Status\": {Status}";
            var tp = 0.0f;
            if (withProducts)
            {
                json += ",";
                json += "\"Products\": [";
                var pList = SQL.GetProductsInOrder(ID);
                var pDict = new Dictionary<Product, int>();
                foreach (var p in pList)
                {
                    if(pDict.Keys.Count(y => y.ID == p.ID) == 0)
                    {
                        pDict.Add(p, pList.Count(x => x.ID == p.ID));
                    }

                }
                bool isFirst = true;
                foreach (var qq in pDict)
                {
                    var p = qq.Key;
                    if (isFirst)
                    {
                        isFirst = false;
                    }
                    else
                    {
                        json += ",";
                    }
                    json += p.ToJson(qq.Value);
                    tp += p.Price;
                }
                json += "],";
            }

            json += $"\"TotalPrice\": \"{tp}\"";
            json += "}";
            return json;
        }
    }
}

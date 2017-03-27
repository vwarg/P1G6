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
        public DateTime DateProcessed { get; set; }
        public DateTime DateFulfilled { get; set; }
        public int Status { get; set; }

        public Order (int id, int userId, int billingAdressID, int deliveryAdressID, float totalPrice, DateTime dateCreated, DateTime dateProcessed, DateTime dateFulfilled, int status)
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
                newUserId.Value = user;

                SqlParameter newBillingAdressId = new SqlParameter("@billingAdressId", SqlDbType.Int);
                newBillingAdressId.Value = user.Info.BillingadressID;

                SqlParameter newDeliveryAdressID = new SqlParameter("@deliveryAdressID", SqlDbType.Int);
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
            int newOrdrId = 0; 

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("AddOrder", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter newUserId = new SqlParameter("@userId", SqlDbType.Int);
                newUserId.Value = user;

                SqlParameter newBillingAdressId = new SqlParameter("@billingAdressId", SqlDbType.Int);
                newBillingAdressId.Value = user.Info.BillingadressID;

                SqlParameter newDeliveryAdressID = new SqlParameter("@deliveryAdressID", SqlDbType.Int);
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

        #region ORDER STATUS
        private static int ChangeOrderStatus(int id, int status)
        {

            //0=skapad, 1=proccesing, 2=paid 3=shipped OBS Förslag
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

        public static int OrderCreated(int id)
        {
            return ChangeOrderStatus(id, 0);
        }

        public static int OrderProcessing(int id)
        {
            return ChangeOrderStatus(id, 1);
        }

        public static int OrderPaid(int id)
        {
            return ChangeOrderStatus(id, 2);
        }

        public static int OrderShipped(int id)
        {
            return ChangeOrderStatus(id, 3);
        }
        #endregion
    }
}

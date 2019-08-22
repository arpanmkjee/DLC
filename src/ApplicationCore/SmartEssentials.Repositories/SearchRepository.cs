using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SmartEssentials.Repositories
{
    public class SearchRepository
    {
        public const string connection = "Server=SAI\\SQLEXPRESS;Database=sm-it;Trusted_Connection=True;";

        public JArray Search(string searchKey)
        {
            JArray searchResults = new JArray();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand sqlComm = new SqlCommand("DBO.CUSTOMER_SEARCH", con);
                sqlComm.Parameters.AddWithValue("@SEARCH_KEY", searchKey);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                searchResults.Add((JObject)JsonConvert.DeserializeObject(dr["JSON_DATA"].ToString()));
            }

            #region commented
            //for (int i = 0; i < 5; i++)
            //{

            //    dynamic product = new JObject();
            //    product.name = "Tom Moody";
            //    product.address = "78160 Clyde Gallagher Street";
            //    product.meterNumber = "O33942812";

            //    dynamic customer = new JObject();
            //    customer.name = "Tom Moody";
            //    customer.address = "78160 Clyde Gallagher Street";
            //    customer.meterNumber = "O33942812";

            //    product.customer = customer;
            //    array.Add(product);
            //} 
            #endregion

            return searchResults;
        }

        //this will be moved to its own app repository and tenant id will be added.
        public JObject ControlData()
        {
            JObject controlData = new JObject();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(connection))
            {
                SqlCommand sqlComm = new SqlCommand("SELECT DATA_SCHEMA FROM [dbo].[COMPANY]", con);
                sqlComm.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }
            controlData = (JObject)JsonConvert.DeserializeObject(ds.Tables[0].Rows[0]["DATA_SCHEMA"].ToString());
            return controlData;
        }

    }
}

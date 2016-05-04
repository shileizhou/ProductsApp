using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using C = System.Data.SqlClient;  // System.Data.dll
using D = System.Data;

namespace ProductsApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public string  GetIcon(int PlaceId)
        {
            string ss = "";
            using (var connection = new C.SqlConnection(
                                      "Server=tcp:livemap.database.windows.net,1433;Database=livemap;User ID=livemap@livemap;Password=Zhuzhu88;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                connection.Open();

                using (var command = new C.SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = D.CommandType.Text;
                    command.CommandText = @"
                SELECT
                    PlaceID,
                    Icon
                FROM Table1
                Where PlaceId = 1";

                    C.SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ss = reader.GetString(1);
                    }
                }

            }

            return ss;

        }
    }
}

////https://poistorage.blob.core.windows.net/pois/Canadian_Museum_of_History.png
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ado.net___homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=LROO;Initial Catalog=Northwind;Integrated Security=True";

            SqlConnection sql = new SqlConnection(connectionString);


            List<dynamic> customers = new List<dynamic>();

            try
            {
                using (sql)
                {
                    sql.Open();

                    SqlCommand query = new SqlCommand("SELECT [CustomerId], [CompanyName], [Address], [City], [Region], [Country] FROM [dbo].[Customers] ", sql);

                    SqlDataReader dataReader = query.ExecuteReader();

                    while (dataReader.Read())
                    {
                        customers.Add(new { CustomerId = dataReader[0], CompanyName = dataReader[1], Address = dataReader[2], City = dataReader[3], Region = dataReader[4], Country = dataReader[5] });
                    }
                    
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (dynamic item in customers)
            {

                Console.WriteLine($"CustomerId: {item.CustomerId} CompanyName: { item.CompanyName}  \nAddress: { item.Address}  City: { item.City}  Region: { item.Region}  Country: { item.Country} \n------");
            }
        }
    }
}

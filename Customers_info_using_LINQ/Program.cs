using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ado.net___homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=LROO;Initial Catalog=Northwind;Integrated Security=True";

            SqlConnection sql = new SqlConnection(connectionString);


            List<Customers> customers = new List<Customers>();

            try
            {
                using (sql)
                {
                    sql.Open();

                    SqlCommand query = new SqlCommand("SELECT [CustomerId], [CompanyName], [Address], [City], [Region], [Country] FROM [dbo].[Customers] ", sql);

                    SqlDataReader dataReader = query.ExecuteReader();

                    while (dataReader.Read())
                    {
                        customers.Add (new Customers(dataReader[0].ToString(),dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString()));
                    }
                    
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            

            var result = customers.Select((Customers p) => { return new { p.CustomerId, p.CompanyName, p.Address, p.City, p.Country}; });




            foreach (var item in result)
            {
                Console.WriteLine($"CustomerId: {item.CustomerId}, CompanyName: {item.CompanyName}, Address: {item.Address}, City: {item.City}, Country: {item.Country} ");

            }


        }
    }
}

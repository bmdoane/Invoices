using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> products = new List<object>();

            string query = @"
SELECT 
  p.IdProduct, 
  p.Name, 
  p.Description, 
  pt.Name Type
FROM Product p 
LEFT JOIN ProductType pt ON p.IdProductType = pt.IdProductType
";

            using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\bmdoa\\workspace\\Invoice\\Invoice\\Invoices.mdf\";Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Check is the reader has any rows at all before starting to read.
                    if (reader.HasRows)
                    {
                        // Read advances to the next row.
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}, {1}, {2}, {3}",
                                reader[0], reader[1], reader[2], reader[3]);
                        }

                    }
                }
            }
        }
    }
}

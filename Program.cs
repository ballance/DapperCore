using System;
using Dapper;
using MySql.Data.MySqlClient;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Connecting for database listing...");
            try
            {
                var connectionString = "Server=127.0.0.1;Database=adventureworks;Uid=dapper;Pwd=DapDap1$";
                using (var connection = new MySqlConnection(connectionString))
                {
                    var simpleResult = connection.Query("SELECT CustomerID, TerritoryId, AccountNumber, CustomerType, ModifiedDate FROM customer LIMIT 10;");
                    foreach (var result in simpleResult)
                    {
                        Console.WriteLine($"{result.CustomerID} - {result.CustomerID} - {result.AccountNumber}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to connect {ex}");
            }

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ChinookConsoleApp
{
    public class UpdateEmployee
    {
        public void Update()
        {
            

            var employeeList = new ListEmployees();
            Console.WriteLine();
            var updateEmployeeID = employeeList.List("Choose an employee for name change: ");
            Console.Write("Change this employee's last name to: ");
            var newLastName = Console.ReadLine();


            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {


                try
                {
                    connection.Open();

                    var rowsAffected = connection.Execute("update Employee " +
                                                          "set LastName = @changedLastName " +
                                                          "where EmployeeId = @selectedID",
                                       new { changedLastName = newLastName, selectedID = updateEmployeeID });

                   
                    Console.WriteLine(rowsAffected != 1 ? "Update Failed" : "Success!");

                    Console.WriteLine("Press <enter> to return to the menu.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ex.Message");
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
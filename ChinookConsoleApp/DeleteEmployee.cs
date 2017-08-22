using Dapper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChinookConsoleApp
{
    public class DeleteEmployee
    {
        public void Delete()
        {
            var employeeList = new ListEmployees();
            Console.WriteLine();
            var firedEmployee = employeeList.List("Pick an employee to transition:");

            using (var connection = new SqlConnection("Server = (local)\\SqlExpress; Database=chinook;Trusted_Connection=True;"))
            {
              

                try
                {
                    connection.Open();

                    var deletedEmp = connection.Execute("Delete from Employee where EmployeeId = @thisEmployee", new { thisEmployee = firedEmployee });
                    
                        if (deletedEmp == 1)
                        {
                            Console.WriteLine("Success");
                        }
                        else if (deletedEmp > 1)
                        {
                            Console.WriteLine("AAAAHHHHHHHH!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to find a matching ID");
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press <enter> to return to the menu");
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
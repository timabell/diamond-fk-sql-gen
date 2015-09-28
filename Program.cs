using System;
using System.Data.SqlClient;
using Dapper;

namespace diamondFkSqlGen
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sqlConnection = new SqlConnection("server=.;database=diamond_enforcer;integrated security=true"))
            {
                sqlConnection.Open();
                var routes = sqlConnection.Query<Route>("select id, path from tpa.route");
                foreach (var route in routes)
                {
                    Console.Out.WriteLine(route.path);
                }
            }
            Console.In.Read(); // pause
        }
    }
}

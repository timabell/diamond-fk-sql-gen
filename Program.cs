using System;
using System.Data.SqlClient;
using System.Linq;
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
                var routes = sqlConnection.Query<Route>("select id, path, firstTableId, lastTableId from tpa.route");
                var routeSets = routes.GroupBy(r => r.firstTableId, r => r.lastTableId);//.Where(g => g.Count() > 1);
                foreach (var routeSet in routeSets)
                {
                    Console.Out.WriteLine(routeSet.Key);
                    Console.Out.WriteLine(routeSet.Count());
                }
            }
            Console.In.Read(); // pause
        }
    }
}

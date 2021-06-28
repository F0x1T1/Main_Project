using Dapper;
using Main_Project.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Main_Project.Data.Data
{
    class Dapperrep
    {
        public async Task<List<Vikladach>> GetAllS()
        {
            string SQLRequest = "SELECT * FROM Student;";
            var teachers = new List<Vikladach>();
            using (var connection = new SqlConnection("Server = COMPUTER\\SQLEXPRESS;Database = Shag;Integrated Security = True;Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"))
            {
                return (List<Vikladach>)connection.Query<Vikladach>(SQLRequest);
            }
        }
    }
}

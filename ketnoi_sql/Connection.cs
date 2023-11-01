using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ketnoi_sql
{
    class Connection
    {
        private static string stringConnect = @"Data Source=A209PC43\CSSQL08;Initial Catalog=QL_NV;Integrated Security=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(stringConnect);
        }
    }
}

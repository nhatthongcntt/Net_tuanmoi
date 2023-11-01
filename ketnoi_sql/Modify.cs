﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ketnoi_sql
{
    class Modify
    {
        public Modify()
        {

        }
        SqlDataAdapter _dataAdapter;
        SqlCommand _sqlCommand;
        DataTable _dataTable;
        public DataTable Table(string query)
        {
            _dataTable = new DataTable();
            using(SqlConnection sqlcon = Connection.getConnection()){
                sqlcon.Open();
                _dataAdapter = new SqlDataAdapter(query,sqlcon);
                _dataAdapter.Fill(_dataTable);
                sqlcon.Close();
            }
            return _dataTable;
        }

        public void Command(string query)
        { 
            //them
            using (SqlConnection sqlcon = Connection.getConnection())
            {
                sqlcon.Open();
                _sqlCommand = new SqlCommand(query,sqlcon);
                _sqlCommand.ExecuteNonQuery();
                sqlcon.Close();
            }
        }

    }
}

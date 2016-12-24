using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL
{
    public class GetData
    {
             /// <summary>
             /// 获取datatable
             /// </summary>
             /// <returns> datatable</returns>
            public DataTable GetDataTable()
            {
                   DataTable dataTable = new DataTable();
                   using (SqlConnection conn = new SqlConnection(@"Data Source =" + HttpContext.Current.Server.MapPath("~/example.db") + ";"))
                  {
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "select * from users";
                        cmd.CommandType = CommandType.Text;
 
                        if (conn.State != ConnectionState .Open)
                        {
                              conn.Open();
                        }
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior .CloseConnection);
                        dataTable.Load(dr);
                  }
                  return dataTable;
            }
 
             /// <summary>
             /// 根据DataTable生成Json
             /// </summary>
             /// <param name="table"> datatable</param>
             /// <returns> json</returns>
            public string DataTableToJson(DataTable table)
            {
                  if (table == null || table.Rows.Count == 0)
                  {
                         return string .Empty;
                  }
 
                  var sb = new StringBuilder();
                  sb.Append( "[");
 
                  string[] columnName = new string[table.Columns.Count];//列名数组
                  for (int i = 0; i < table.Columns.Count; i++)
                  {
                        columnName[i] = table.Columns[i].ColumnName.ToLower();//列名小写
                  }
                  //拼接列
                  for (int i = 0; i < table.Rows.Count; i++)
                  {
                        sb.Append( "{");
                        for (int j = 0; j < columnName.Length; j++)
                        {
                              sb.Append( "\"" + columnName[j] + "\":\"" + table.Rows[i][j].ToString() + "\"" );
                              if (j < columnName.Length - 1)
                              {
                                    sb.Append( ",");
                              }
                        }
                        sb.Append( "}");
                        if (i < table.Rows.Count - 1)
                        {
                              sb.Append( ",");
                        }
                  }
                  sb.Append( "]");
 
                  table = null;
                  return sb.ToString();
            }
    }
}

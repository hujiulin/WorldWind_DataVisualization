/************************************************************************/
/* Author: Jiulin Hu*/
/* Description : main funciton*/
/************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using System.Text.RegularExpressions;

using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Visitors;
using MySql.Data.MySqlClient;

/*
 * TODO: save attribute info
 */

namespace DBEngine
{
    class Program
    {
        #region database
        static private string _database = "datavisualization";
        static private string _dataSource = "localhost";
        static private string _userId = "root";
        static private string _password = "root";
        static private string _charset = "utf8";
        static private string _pooling = "true";
        static private int _number = 10;
        #endregion

        [STAThread]
        static void Main(string[] args)
        {
            MysqlHelper _mysqlHelper = null;
            // Filter: .doc and vaild file path
            if (null == _mysqlHelper)
            {
                _mysqlHelper = new MysqlHelper("Database='" + _database + "';" +
                                                "Data Source='" + _dataSource + "';" +
                                                "User Id='" + _userId + "';" +
                                                "Password='" + _password + "';" +
                                                "charset='" + _charset + "';" +
                                                "pooling=" + _pooling + "");
                if (null == _mysqlHelper.Conn)
                {
                    Trace.WriteLine("Error: can not connect to mysql database.");
                    return;
                } 
            }
            string sqlFiles = "select id, value from data2d";
            DataTable dataTable = _mysqlHelper.ExecuteDataTable(sqlFiles, null);
            double[] array = new double[_number];
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                array[i++] = (double)row[1];
            }
            // return array;
        }
    }
}

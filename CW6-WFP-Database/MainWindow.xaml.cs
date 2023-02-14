/*
 * Jackson Horton - 2/14/23
 * CW6 WPF Database Assignment
 * 
 * In this project, the WPF application runs SQL queries on an
 * Access database and will display the results to the GUI.
 */
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CW6_WFP_Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"|DataDirectory|\\CW6 Database.accdb\"");
            InitializeComponent();
        }

        private void SeeAssetsButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[1] + ": " + read[2] + " -> EID" + read[0] +  "\n";
            }
            AssetTextBlock.Text = data;
            cn.Close();
        }

        private void ShowEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "EID" + read[0] + ": " + read[1] + " " + read[2] + "\n";
            }
            EmployeeTextBlock.Text = data;
            cn.Close();
        }
    }
}

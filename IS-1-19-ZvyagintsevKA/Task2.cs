using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_1_19_ZvyagintsevKA
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }
        class Soedinenie // создание класса "Соединение"
        {
            //Создаётся поле содержащее в себе строку подключения
            public string connect = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";

            
            public void ConnectInfo()          //
            {                                  // Метод выводит информации о строке подключения
                MessageBox.Show(connect);      //  
            }                                  //
        }
        // Метод кнопки открывает соединение в DB при помощи строки подключения
        private void button1_Click(object sender, EventArgs e)
        {
            Soedinenie con = new Soedinenie(); // Создание экземпляра класса, описанный ранее
            
            MySqlConnection conn = new MySqlConnection(con.connect); //Позволяет открыть соединения при помощи строки подключения из экземпляра класса
            bool result = true;  // переменная отвечает за исход операции открытия соединения 
            try
            {
                conn.Open(); //Метод соединения с DB
            }
            catch
            {
                result = false; 
            }
            finally
            {
                if (result == true)
                {  // исход успешного соединения
                    MessageBox.Show("Работает");
                }
                else
                { // исход не успешного соединения
                    MessageBox.Show("Ошибка соединения");
                }
                conn.Close(); // "подключение закрыть"
            }
        }
    }
}
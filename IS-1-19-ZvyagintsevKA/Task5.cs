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
using ConnectDB;

namespace IS_1_19_ZvyagintsevKA
{
    public partial class Task5 : Form
    {
        public Task5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаём экземпляр класса, добавленного из другого проекта того же репозитория
            Connector_DB conn4 = new Connector_DB();
            MySqlConnection connect = new MySqlConnection(conn4.stringconn_DB); //создаём соединение 
            string fioStud = textBox1.Text;  // Поле для студента 
            string dateitimeStudFinal = textBox2.Text; // Поле даты заполняется по шаблону "yyyy-MM-dd hh:mm:ss"
            string sql = $"INSERT INTO t_PraktStud (fioStud, datetimeStud)  VALUES ('{fioStud}','{dateitimeStudFinal}');";
            int counter = 0;
            try
            {
                connect.Open(); // Открываем соединение

                MySqlCommand command1 = new MySqlCommand(sql, connect); //Создаём экземпляр для изменения DB
                counter = command1.ExecuteNonQuery(); //Выполняет команду выше

            }
            catch
            {
                MessageBox.Show("Ощибка"); //При ощибке :)№""№):
            }
            finally
            {
                connect.Close(); //Закрытие соединения

                if (counter != 0) //По условию если больше нуля , то всё прошло успешно..
                {
                    MessageBox.Show("Введённые данные были добавлены в БД");
                }
            }
        }
    }
}

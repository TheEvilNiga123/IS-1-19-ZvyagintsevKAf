using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;    //Подключили библиотеку MySQL(Привязанную по ссылке)
using ConnectDB;                 //Добавили свою библиотеку с классом из другого проекта(Привязанную по ссылке) 
namespace IS_1_19_ZvyagintsevKA
{
    public partial class Task4 : Form
    {
        public Task4()
        {
            InitializeComponent();
        }

        string id_rows5 = "0";
        //Метод вывода информации по нажатию ЛКМ по  dataGridView1
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left)) // определяет нажали ли мы на поле dataGridView1 и если ЛКМ
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex]; //Определяет строку

                dataGridView1.CurrentRow.Selected = true; //Выделение

                string index_rows5;

                index_rows5 = dataGridView1.SelectedCells[0].RowIndex.ToString(); //Уникальный индекс для переменной 

                id_rows5 = dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString();//Замена
                DateTime x = DateTime.Today; //Берётся сегодняшняя дата для x
                DateTime y = Convert.ToDateTime(dataGridView1.Rows[Convert.ToInt32(index_rows5)].Cells[2].Value.ToString()); //Дата берётся из таблицы для y
                string resultDays = (x - y).ToString(); //Подсчёт прошедших дней
                MessageBox.Show("День рождение было" + resultDays.Substring(0, resultDays.Length - 9) + " день назад"); //Вывод информации уже с подсчётом
            }
        }

        private void Task4_Load_1(object sender, EventArgs e)
        {
            // Создаём экземпляр класса, добавленного из другого проекта того же репозитория
            Connector_DB conn4 = new Connector_DB();
            MySqlConnection connect = new MySqlConnection(conn4.stringconn_DB);
            string sql = $"SELECT idStud, fioStud, drStud FROM t_datetime";  // Запрос на вывод столбцов из  t_datetime
            try
            {
                connect.Open(); //Открываем соединения 

                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);
                
                DataSet dataset = new DataSet(); // Создание виртуальной таблицы

                IDataAdapter.Fill(dataset); //Заполнение таблицы
                dataGridView1.DataSource = dataset.Tables[0]; //Переносим таблицу в  dataGridView1
            }
            catch
            {
                MessageBox.Show("error"); //Если что-то не так, то только вот так
            }
            finally
            {
                connect.Close(); //Закрываем соединение
            }
        }
    }

}

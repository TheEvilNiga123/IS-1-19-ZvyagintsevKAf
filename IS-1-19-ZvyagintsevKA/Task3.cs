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
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }
        //Метод  отвечающий за загрузку формы -- Method responsible for loading the form
        private void Task3_Load(object sender, EventArgs e)
        {
            //Создание экземпляра класса
            ConnectorPcs conn = new ConnectorPcs();
            MySqlConnection connect = new MySqlConnection(conn.connectM); //Создание и инициализация соединение с DB со строкой соединения из экземпляра conn -- Create and initialize a DB connection with a connection string from a conn instance
            string sql = $"SELECT id, fio, theme_kurs FROM t_stud";  // Запрос SQL на вывод информации из t_stud -- SQL query to display information from t_stud
            try
            {
                connect.Open(); //Открываем соединение -- Opening a connection

                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);

                DataSet dataset = new DataSet(); // Создание таблицы -- Creating a table

                IDataAdapter.Fill(dataset); //Заполнение таблицы -- Populating the table
                dataGridView1.DataSource = dataset.Tables[0]; //Передача таблицы в dataGridView1 -- Passing table to dataGridView1
            }
            catch
            {
                MessageBox.Show("ошибка"); //При возникшей ошибки -- When an error occurs
            }
            finally
            {
                connect.Close(); //Закрыть соединение -- close connection
            }   
        }
        string id_rows = "0";

        //Метод вывода информации (Таблицы) по нажатию ЛКМ по  dataGridView1 -- Method for displaying information (Tables) by clicking LMB on dataGridView1
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left)) // определяет нажали ли мы на поле dataGridView1 и если ЛКМ -- determines whether we clicked on the dataGridView1 field and if LMB
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex]; //Определяет строку -- Defines a string

                dataGridView1.CurrentRow.Selected = true; //Выделение -- Highlighting

                string index_rows;

                index_rows = dataGridView1.SelectedCells[0].RowIndex.ToString(); //Уникальный индекс для переменной -- Unique index for a variable

                id_rows = dataGridView1.Rows[Convert.ToInt32(index_rows)].Cells[1].Value.ToString(); //Замена -- Replacement
                MessageBox.Show(id_rows);
            }
        }      
    }
   
}

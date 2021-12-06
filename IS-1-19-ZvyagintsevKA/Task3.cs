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
        //Метод  отвечающий за загрузку формы ..
        private void Task3_Load(object sender, EventArgs e)
        {
            //Создание экземпляра класса
            ConnectorPcs conn = new ConnectorPcs();
            MySqlConnection connect = new MySqlConnection(conn.connectM); //Создание и инициализация соединение с DB со строкой соединения из экземпляра conn
            string sql = $"SELECT id, fio, theme_kurs FROM t_stud";  // Запрос SQL на вывод информации из t_stud ..
            try
            {
                connect.Open(); //Открываем соединение 

                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, connect);

                DataSet dataset = new DataSet(); // Создание таблицы

                IDataAdapter.Fill(dataset); //Заполнение таблицы
                dataGridView1.DataSource = dataset.Tables[0]; //Передача таблицы в dataGridView1
            }
            catch
            {
                MessageBox.Show("ошибка"); //При возникшей ошибки
            }
            finally
            {
                connect.Close(); //Закрыть соединение
            }
            
        }
        string id_rows = "0";

        //Метод вывода информации (Таблицы) по нажатию ЛКМ по  dataGridView1
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left)) // определяет нажали ли мы на поле dataGridView1 и если ЛКМ
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex]; //Определяет строку

                dataGridView1.CurrentRow.Selected = true; //Выделение

                string index_rows;

                index_rows = dataGridView1.SelectedCells[0].RowIndex.ToString(); //Уникальный индекс для переменной 

                id_rows = dataGridView1.Rows[Convert.ToInt32(index_rows)].Cells[1].Value.ToString(); //Замена
                MessageBox.Show(id_rows);
            }
        }

        
    }
   
}

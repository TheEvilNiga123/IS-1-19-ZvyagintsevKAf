using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_1_19_ZvyagintsevKA
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Task1 zadanie1 = new Task1(); // переход на форму №2 (Задание 1)..
            zadanie1.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide(); // прячет форму №1
            Task2 zadanie2 = new Task2(); // переход на форму №3 (Задание 2)
            zadanie2.ShowDialog();
            Close(); // закрывает все формы
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Task3 zadanie3 = new Task3(); // переход на форму №4 (Задание 3)
            zadanie3.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Task4 zadanie4 = new Task4(); // переход на форму №5 (Задание 4)
            zadanie4.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide(); // прячет форму №1
            Task5 zadanie5 = new Task5(); // переход на форму №6 (Задание 5)
            zadanie5.ShowDialog();
            Close(); // закрывает все формы
        }
    }
}

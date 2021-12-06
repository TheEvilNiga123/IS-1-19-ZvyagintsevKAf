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
    public partial class Task1 : Form
    {
        abstract class Complectuishie<ABA> //Создаём абстрактный класс "Комплектующие" с обобщённым типом
        {

            protected ABA artikul;  //поле артикула
            protected int price;    //поле цена
            protected int date;     //поле дата


            public Complectuishie(ABA ART, int PRC, int DaTa)  // конструктор - инициализация полей класса
            {
                artikul = ART;
                price = PRC;
                date = DaTa;
            }
            // абстрактный метод, будет использован в наследниках 
            abstract public void DisplayInfo(ListBox L);

        }
        class CPU<ABA> : Complectuishie<ABA> //дочерний класс 
        {
            
            int cpu_fr; // индивидуальные поля дочернего класса "CPU" частота процессора 
            int numb_Cor; // индивидуальные поля дочернего класса "CPU" количество ядер
            int numb_th; // индивидуальные поля дочернего класса "CPU" количество потоков
            int CPU_fr { get { return cpu_fr; } set { cpu_fr = value; } }               //
            int Numb_Cor { get { return numb_Cor; } set { numb_Cor = value; } }         // Возможность внедрять подолнительную логику при работе с полями
            int Numb_th { get { return numb_th; } set { numb_th = value; } }            //


            
            public CPU(ABA ART, int PRC, int DaTa, int FRE, int COR, int THR) // конструктор - инициализирующий поля класса, материнские и дочерние
               : base(ART, PRC, DaTa) // base отправляет унаследованные параментры в конструктор материнского класса 
            {
                CPU_fr = FRE;    //частота процессора
                Numb_Cor = COR; //количество ядер
                Numb_th = THR; //количество потоков
            }
            // Переопределённый метод материнского абстрактного класса, выводит указанную информацию в Listbox1
            public override void DisplayInfo(ListBox L)
            {
                L.Items.Clear();
                L.Items.Add($"Артикул - {artikul}");
                L.Items.Add($"Дата изготовления - {date}");
                L.Items.Add($"Цена - {price}");
                L.Items.Add($"Частота - {CPU_fr}");
                L.Items.Add($"Количество ядер - {Numb_Cor}");
                L.Items.Add($"Количество потоков - {Numb_th}");
            }


        }
        class Videocard<ABA> : Complectuishie<ABA> //дочерний класс 

        {

            int gpu_fr; //поле Частота GPU
            string maker; //поле Производитель
            int memory;     //поле Объём памяти

            public int GPU_fr { get { return gpu_fr; } set { gpu_fr = value; } }  //
            public string Maker { get { return maker; } set { maker = value; } }  // Возможность внедрять подолнительную логику при работе с полями
            public int Memory { get { return memory; } set { memory = value; } }  //

            public Videocard(ABA ART, int PRC, int DaTa, int FRE, string MAK, int MEM) // конструктор - инициализирующий поля класса, материнские и дочерние
               : base(ART, PRC, DaTa) // base отправляет унаследованные параментры в конструктор материнского класса 
            {
                GPU_fr = FRE; // Частота GPU
                Maker = MAK; // Производитель
                Memory = MEM; // Объём памяти
            }

            public override void DisplayInfo(ListBox L) // Переопределённый метод материнского абстрактного класса, выводит указанную информацию в Listbox1
            {
                L.Items.Clear();
                L.Items.Add($"Артикул - {artikul}");
                L.Items.Add($"Дата изготовления - {date}");
                L.Items.Add($"Цена - {price}");
                L.Items.Add($"Частота - {GPU_fr}");
                L.Items.Add($"Производитель - {Maker}");
                L.Items.Add($"Объём памяти - {Memory}");
            }


        }
        public Task1()
        {
            InitializeComponent();
        }
        //Метод кнопки, необходим для инициализация экземпляра класса процессора
        private void button1_Click(object sender, EventArgs e)
        {
            //создаёт переменные для дальнейшей передачи в качестве параметров в конструктор при создании экземпляра
            int t1 = Convert.ToInt32(textBox1.Text);
            int t2 = Convert.ToInt32(textBox2.Text);
            int t3 = Convert.ToInt32(textBox3.Text);
            int t4 = Convert.ToInt32(textBox4.Text);
            int t5 = Convert.ToInt32(textBox5.Text);
            int t6 = Convert.ToInt32(textBox6.Text);

            CPU<int> cp = new CPU<int>(t1, t2, t3, t4, t5, t6);
            cp.DisplayInfo(listBox1); // Метод класса выводит информацию об экземпляре в ListBox1
        }
        //Метод кнопки, необходим для инициализация экземпляра класса видяхи
        private void button2_Click(object sender, EventArgs e)
        {
            int t1 = Convert.ToInt32(textBox12.Text);
            int t2 = Convert.ToInt32(textBox11.Text);
            int t3 = Convert.ToInt32(textBox10.Text);
            int t4 = Convert.ToInt32(textBox9.Text);
            string t5 = textBox8.Text;
            int t6 = Convert.ToInt32(textBox7.Text);

            Videocard<int> vid = new Videocard<int>(t1, t2, t3, t4, t5, t6);
            vid.DisplayInfo(listBox1); // Метод класса выводит информацию об экземпляре в ListBox1
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задача_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text); //жюри
            int m = Convert.ToInt32(textBox2.Text); //фигуристы
            double[,] a = new double[m, n]; //создаем вещественный массив для выставления оценок
            Random otsenka = new Random(); //создаем рандом, чтобы оценки выставлялись автоматически
            dataGridView1.RowCount = m; //присваиваем строкам фигуристов
            dataGridView1.ColumnCount = n+1; //присваиваем столбцам жюри (+1 для добавления еще одного столбца для нумерации фигуристов)
            double sum = 0; //создаем переменную для суммы
            double rez; //в этой переменной будет результат
            int numer = n; //для нумерации фигуристов
            if (n > 2 && n < 11) //делаем условие, чтобы жюри соответствовало условию задачи
            {
                for (int i = 0; i < m; i++) //запускаем цикл для заполнения строк
                {
                    for (int j = 0; j < n; j++) //запускаем цикл для заполнения столбцов
                    {
                        a[i, j] = Convert.ToDouble(otsenka.Next(0, 100) / 10.0); //заполняем массив вещественными числами
                        dataGridView1.Rows[i].Cells[j].Value = a[i, j]; //выводим результат в dataGridView1
                    }
                }
                for (int i = 0; i < dataGridView1.RowCount; i++) //запускаем цикл для нумерации фигуристов
                {
                    dataGridView1.Rows[i].Cells[numer].Value = i + 1; //заполняем массив (столбец) этой нумерацией
                }
                for (int i = 0; i < m; i++) //запускаем цикл для поиска max и min результатов
                {
                    double max = 0; //переменная для записи максимального (каждый раз возвращает 0 значение)
                    double min = a[i, 0]; //переменная для записи минимального
                    for (int j = 0; j < n; j++) //цикл для поиска max и min результатов
                    {
                        sum += a[i, j]; //складываем все элементы строки
                        if (a[i, j] > max) //условие для поиска max
                        {
                            max = a[i, j]; //max принимает значение элемента, если условие оказалось истинным
                        }
                        if (a[i, j] < min)//условие для поиска min
                        {
                            min = a[i, j]; //min принимает значение элемента, если условие оказалось истинным
                        }
                    }
                    rez = (sum - min - max) / (n - 2); /*присваивание результатной переменной,
                    соответствующее критериям условия (вычитаются значения max и min из общей суммы 
                    и делятся на все количество судей, но минус 2, т.к. их оценки были убраны */
                    listBox1.Items.Add(String.Format("Результат {0}-го фигуриста: ", i + 1) + Math.Round(rez, 1)); //вывод результата в listBox1 с одним знаком после запятой
                    sum = 0; //сброс суммы для дальнейших операций
                }
            }
            else { if (n ==0) MessageBox.Show("Без жюри мы не можем начать чемпионат!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); /* Если условие является ложным, то в зависимости от 
            количества жюри будет всплывать окно с ошибкой*/
                else if (n < 3) MessageBox.Show("Слишком маленькое количество жюри!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("Слишком большое количество жюри!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); //очистка старых результатов, чтобы не путать с новыми вычислениями
        }
    }
}

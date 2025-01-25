using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zadaniedomowe2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = CreateString(tablica);
        }
        int[] tablica = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        Stopwatch stopwatch = new Stopwatch();

        Random rnd = new Random();

        public void GenerateArray(int[] tab, int i)
        {
            for (int j = 0; j <= i; j++)
            {
                tab[j] = rnd.Next(0, 100);
            }
        }

        public void InsertSort(int[] tab)
        {
            for (int i = tab.Length - 1; i > 0; i--)
            {
                for (int j = tab.Length - 1; j > 0; j--)
                {
                    if (tab[j] < tab[j - 1])
                    {
                        int pamiec = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = pamiec;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public string CreateString(int[] tab)
        {
            string Napis = "";
            for (int i = 0; i < tab.Length && i < 15; i++)
            {
                Napis = Napis + tab[i] + ", ";
            }
            return Napis;
        }

        public int[] MergeSort(int[] array, int p, int r)
        {
            if (p < r)
            {
                int q = p + (r - p) / 2;
                MergeSort(array, p, q);
                MergeSort(array, q + 1, r);
                MergeArray(array, p, q, r);
            }
            return array;
        }

        public void MergeArray(int[] array, int p, int q, int r)
        {
            var leftArrayLength = q - p + 1;
            var rightArrayLength = r - q;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[p + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[q + 1 + j];
            i = 0;
            j = 0;
            int k = p;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }

        public void QuickSort(int[] tab, int p, int o)
        {
            if (p < o)
            {
                int i = Divide(tab, p, o);
                QuickSort(tab, p, i - 1);
                QuickSort(tab, i + 1, o);
            }
        }

        public int Divide(int[] tab, int p, int o)
        {
            int i = p + (o - p) / 2;
            int temp = tab[i];
            Swap(tab, i, o);
            int a = p;
            for (int j = p; j <= o - 1; j++)
            {
                if (tab[j] < temp)
                {
                    Swap(tab, j, a);
                    a++;
                }
            }
            Swap(tab, a, o);
            return a;
        }

        public void Swap(int[] tab, int i1, int i2)
        {
            if (i1 != i2)
            {
                int pamiecSwap = tab[i1];
                tab[i1] = tab[i2];
                tab[i2] = pamiecSwap;
                return;
            }
        }

        public static int GetMaxVal(int[] tab, int size)
        {
            var maxVal = tab[0];
            for (int i = 1; i < size; i++)
                if (tab[i] > maxVal)
                    maxVal = tab[i];
            return maxVal;
        }

        public int[] CountingSort(int[] tab)
        {
            var size = tab.Length;
            var max = GetMaxVal(tab, size);
            var ile = new int[max + 1];

            for (int i = 0; i < max + 1; i++)
            {
                ile[i] = 0;
            }
            for (int i = 0; i < size; i++)
            {
                ile[tab[i]]++;
            }
            for (int i = 0, j = 0; i <= max; i++)
            {
                while (ile[i] > 0)
                {
                    tab[j] = i;
                    j++;
                    ile[i]--;
                }
            }
            return tab;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            if (radioButton1.Checked == true)
            {
                InsertSort(tablica);
                textBox1.Text = CreateString(tablica);
            }
            if (radioButton2.Checked == true)
            {
                textBox1.Text = CreateString(MergeSort(tablica, 0, tablica.Length - 1));
            }
            if (radioButton3.Checked == true)
            {
                textBox1.Text = CreateString(CountingSort(tablica));
            }
            if (radioButton4.Checked == true)
            {
                QuickSort(tablica, 0, tablica.Length - 1);
                textBox1.Text = CreateString(tablica);
            }
            else
            {
                textBox1.Text = CreateString(tablica);
            }
            stopwatch.Stop();
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            TimeSpan time = stopwatch.Elapsed;
            label3.Text = "Czas wykonywania pracy: " + time.ToString();
            stopwatch.Reset();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int i = Decimal.ToInt32(numericUpDown1.Value);
            int[] tablica2 = new int[i];
            GenerateArray(tablica2, i - 1);
            textBox1.Text = CreateString(tablica2);
            tablica = tablica2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string userInput = textBox2.Text;
            string[] stringList = userInput.Split(' ');
            int[] numberList = new int[stringList.Count()];
            for (int i = 0; i < stringList.Count(); i++)
            {
                numberList[i] = Int32.Parse(stringList[i]);
            }
            tablica = numberList;
            textBox1.Text = CreateString(tablica);
        }
    }
}

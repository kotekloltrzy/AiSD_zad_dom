using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NWP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            int n = FirstLabel.Text.Length;
            int m = SecondLabel.Text.Length;
            int[,] matrix = new int[n+1, m+1];
            for (int i = 0; i <= n; i++)
            {
                matrix[i, 0] = 0;
            }
            for (int j = 0; j <= m; j++)
            {
                matrix[0, j] = 0;
            }
            var a = FirstLabel.Text;
            var b = SecondLabel.Text;
            for(int i=1; i <= n; i++)
            {
                for(int j=1; j <= m; j++)
                {
                    if(a[i-1] == b[j-1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1]+1;
                    }
                    else
                    {
                        if (matrix[i - 1,j] > matrix[i, j - 1])
                        {
                            matrix[i, j] = matrix[i - 1, j];
                        }
                        else
                        {
                            matrix[i, j] = matrix[i, j - 1];
                        }
                    }
                }
            }
            Length.Text = matrix[n,m].ToString();
            Length.Visible = true;
            int x = n;
            int y = m;
            var wynik = "";
            while(x>0 && y > 0)
            {
                if (matrix[x-1,y] == matrix[x,y])
                {
                    x--;
                }
                if(matrix[x, y - 1] == matrix[x, y])
                {
                    y--;
                }
                else
                {
                    wynik = b[y-1] + wynik;
                    x--;
                    y--;
                }
            }
            NWP.Text = wynik;
            NWP.Visible = true;
        }
    }
}

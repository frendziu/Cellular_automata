using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

       
        Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            pictureBox1.Image = bitmap;
        }

        public class CA
        {
            int y1, y2;

            private void periodicCondition(int j, int vertical_cells_num)
            {
                if (j == 0)
                    y1 = vertical_cells_num - 1;
                else
                    y1 = j - 1;
                if (j == vertical_cells_num - 1)
                    y2 = 0;
                else
                    y2 = j+1;
            }


        
            public int[,] rule30(int horizontal_cells_num, int vertical_cells_num)
            {
                int[,] cells_status = new int[horizontal_cells_num, vertical_cells_num];
                cells_status[0, vertical_cells_num / 2] = 1;

                for (int i = 0; i < horizontal_cells_num - 1; i++)
                {
                    for (int j = 0; j < vertical_cells_num; j++)
                    {
                        periodicCondition(j, vertical_cells_num);
                        if ((cells_status[i, y1] != cells_status[i, j] && cells_status[i, y2] == 0)
                    || (cells_status[i, y1] == 0 && cells_status[i, j] == 1 && cells_status[i, y2] == 1)
                    || (cells_status[i, y1] == 0 && cells_status[i, j] == 0 && cells_status[i, y2] == 1))
                            cells_status[i + 1, j] = 1;
                        else
                            cells_status[i + 1, j] = 0;
                    }
                }
                return cells_status;
            }

            public int[,] rule60(int horizontal_cells_num, int vertical_cells_num)
            {
                int[,] cells_status = new int[horizontal_cells_num, vertical_cells_num];
                cells_status[0, vertical_cells_num / 2] = 1;

                for (int i = 0; i < horizontal_cells_num - 1; i++)
                {
                    for (int j = 0; j < vertical_cells_num; j++)
                    {
                        periodicCondition(j, vertical_cells_num);

                        if ((cells_status[i, y1] == 1 && cells_status[i, j] == 0 && cells_status[i, y2] == 1) 
                            || (cells_status[i, y1] == 1 && cells_status[i, j] == 0 && cells_status[i, y2] == 0) 
                            || (cells_status[i, y1] == 0 && cells_status[i, j] == 1 && cells_status[i, y2] == 1) 
                            || (cells_status[i, y1] == 0 && cells_status[i, j] == 1 && cells_status[i, y2] == 0))
                            cells_status[i + 1, j] = 1;
                        else
                            cells_status[i + 1, j] = 0;
                    }
                }
                return cells_status;
            }

            public int[,] rule90(int horizontal_cells_num, int vertical_cells_num)
            {
                int[,] cells_status = new int[horizontal_cells_num, vertical_cells_num];
                cells_status[0, vertical_cells_num / 2] = 1;

                for (int i = 0; i < horizontal_cells_num - 1; i++)
                {
                    for (int j = 0; j < vertical_cells_num; j++)
                    {
                        periodicCondition(j, vertical_cells_num);

                        if (cells_status[i, y1] != cells_status[i, y2])
                        cells_status[i + 1, j] = 1;
                        else
                            cells_status[i + 1, j] = 0;
                    }
                }
                return cells_status;
            }

            public int[,] rule120(int horizontal_cells_num, int vertical_cells_num)
            {
                int[,] cells_status = new int[horizontal_cells_num, vertical_cells_num];
                cells_status[0, vertical_cells_num / 2] = 1;

                for (int i = 0; i < horizontal_cells_num - 1; i++)
                {
                    for (int j = 0; j < vertical_cells_num; j++)
                    {
                        periodicCondition(j, vertical_cells_num);
                        if((cells_status[i, y1] == 1 && cells_status[i, j] == 1 && cells_status[i, y2] == 0) 
                            || (cells_status[i, y1] == 1 && cells_status[i, j] == 0 && cells_status[i, y2] == 1) 
                            || (cells_status[i, y1] == 1 && cells_status[i, j] == 0 && cells_status[i, y2] == 0) 
                            || (cells_status[i, y1] == 0 && cells_status[i, j] == 1 && cells_status[i, y2] == 1))
                            cells_status[i + 1, j] = 1;
                        else
                            cells_status[i + 1, j] = 0;
                    }
                }
                return cells_status;
            }

            public int[,] rule225(int horizontal_cells_num, int vertical_cells_num)
            {
                int[,] cells_status = new int[horizontal_cells_num, vertical_cells_num];
                cells_status[0, vertical_cells_num / 2] = 1;

                for (int i = 0; i < horizontal_cells_num - 1; i++)
                {
                    for (int j = 0; j < vertical_cells_num; j++)
                    {
                        periodicCondition(j, vertical_cells_num);
                        if ((cells_status[i, y1] == 1 && ((cells_status[i, j] + cells_status[i, y2]) == 1)) 
                            || ((cells_status[i, y1] + cells_status[i, j] + cells_status[i, y2]) == 0) 
                            || ((cells_status[i, y1] + cells_status[i, j] + cells_status[i, y2]) == 3))
                            cells_status[i + 1, j] = 1;
                        else
                            cells_status[i + 1, j] = 0;
                    }
                }
                return cells_status;
            }
        }
            private void Form1_Load(object sender, EventArgs e)
        {
            Graphics g;
            g = Graphics.FromImage(bitmap);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

          
         }

   

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeComboBox()
        {
            string[] lista = new string[] { "rule 30", "rule 60", "rule 90", "rule 120", "rule 225" };
            comboBox1.Items.AddRange(lista);
            this.Controls.Add(this.comboBox1);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox1_SelectedIndexChanged);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            int step_num = int.Parse(textBox2.Text);
            float n_f = (float)n;                           //rzutowanie w celu uzyskania dokladnej wartosci
            float step_num_f = (float)step_num;

            float bound1 = (float)pictureBox1.Size.Width / n_f;                 //wielkosc pojedynczej komorki
            float bound2 = (float)pictureBox1.Size.Height / step_num_f;
            Graphics g;
            g = Graphics.FromImage(bitmap);

            SolidBrush blackBrush = new SolidBrush(Color.Black);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            CA ca = new CA();

            string tekst = comboBox1.SelectedItem.ToString();

            if (tekst == "rule 30")
            {
                g.Clear(Color.DarkGray);
                int[,] tab = new int[step_num, n];
                tab = ca.rule30(step_num, n);
                for (int i = 0; i < step_num; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (tab[i, j] == 1)
                            g.FillRectangle(blackBrush, j * bound1, i * bound2, bound1, bound2);
                        else
                            g.FillRectangle(whiteBrush, j * bound1, i * bound2, bound1, bound2);
                    }
                }

            }

            else if (tekst == "rule 60")
            {
                g.Clear(Color.DarkGray);
                int[,] tab = new int[step_num, n];
                tab = ca.rule60(step_num, n);
                for (int i = 0; i < step_num; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (tab[i, j] == 1)
                            g.FillRectangle(blackBrush, j * bound1, i * bound2, bound1, bound2);
                        else
                            g.FillRectangle(whiteBrush, j * bound1, i * bound2, bound1, bound2);
                    }
                }

            }

            else if (tekst == "rule 90")
            {
                g.Clear(Color.DarkGray);
                int[,] tab = new int[step_num, n];
                tab = ca.rule90(step_num, n);
                for (int i = 0; i < step_num; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (tab[i, j] == 1)
                            g.FillRectangle(blackBrush, j * bound1, i * bound2, bound1, bound2);
                        else
                            g.FillRectangle(whiteBrush, j * bound1, i * bound2, bound1, bound2);
                    }
                }

            }

            else if (tekst == "rule 120")
            {
                g.Clear(Color.DarkGray);
                int[,] tab = new int[step_num, n];
                tab = ca.rule120(step_num, n);
                for (int i = 0; i < step_num; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (tab[i, j] == 1)
                            g.FillRectangle(blackBrush, j * bound1, i * bound2, bound1, bound2);
                        else
                            g.FillRectangle(whiteBrush, j * bound1, i * bound2, bound1, bound2);
                    }
                }

            }

            else if (tekst == "rule 225")
            {
                g.Clear(Color.DarkGray);
                int[,] tab = new int[step_num, n];
                tab = ca.rule225(step_num, n);
                for (int i = 0; i < step_num; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (tab[i, j] == 1)
                            g.FillRectangle(blackBrush, j * bound1, i * bound2, bound1, bound2);
                        else
                            g.FillRectangle(whiteBrush, j * bound1, i * bound2, bound1, bound2);
                    }
                }


            }

            pictureBox1.Image = bitmap;
            g.Dispose();

        }

    }
}

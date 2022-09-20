using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPO_1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double a, b, n = 10, h, res, res1 = 0, res2;
            double x;
            double eps;
            double an = 0;

            chart1.Series[0].Points.Clear();




            if ((textBox1.Text == "") || (textBox2.Text == "") || (Convert.ToDouble(textBox1.Text) < 0) ||
                (textBox3.Text == ""))
            {
                MessageBox.Show("Некоректные данные");
            }
            else
            {
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                eps = Convert.ToDouble(textBox3.Text);


                do
                {
                    h = (b - a) / n;
                    x = a;
                    res = 0;
                    while (x + h <= b)
                    {
                        res += h * ((Math.Log(x) * Math.Log(x))/x + (Math.Log(x + h) * Math.Log(x + h)) / x) / 2;
                        x += h;
                        chart1.Series[0].Points.AddXY(x, res);
                    }

                    res2 = res;
                    n++;

                    an = Math.Abs(res2 - res1);
                    res1 = res;
                } while (an > eps);

                //label2.Text = Convert.ToString(res) + " h = " + h;
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                //for (x = a; x <= b; x += h)
                //{
                //    res += h * (Math.Log(x) * Math.Log(x) + Math.Log(x + h) * Math.Log(x + h)) / 2.0;
                //    chart1.Series[0].Points.AddXY(x, res);
                //}



            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafizaOyunuOdev
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
            "!", ",", "A", "B", "C", "D", "E", "F", "G", "H","I","J","K","L","+","M","N","O","U","S",
            "!", ",", "A", "B", "C", "D", "E", "F", "G", "H","I","J","K","L","+","M","N","O","U","S",
        };

        Random rnd = new Random();
        int randomindex;
        Timer t = new Timer(); 
        Timer t2 = new Timer();
        Timer t3 = new Timer(); 
        private bool allowButtonClick = false; 
        private Timer startTimer = new Timer();
        Button first = new Button();
        Button second = new Button();
        private int sureSayaci = 8;

        public Form1()
        {
            InitializeComponent();
            t.Tick += T_Tick; 
            t.Start();
            t.Interval = 5000;
            show();
            t2.Tick += T2_Tick;
            t2.Start();
            label7.Text = "Birinci Oyuncunun Sırası!";
            label7.BackColor = Color.Blue;
        }

        private void T2_Tick(object sender, EventArgs e) 
        {
            t2.Stop();
            if (first != null && second != null) 
            {
                first.ForeColor = first.BackColor; 
                second.ForeColor = second.BackColor;
                first = null;
                second = null;
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    item.ForeColor = item.BackColor; 
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t3.Interval = 1000; 
            t3.Tick += T3_Tick;


            labelSure.Text = sureSayaci.ToString();
            labelSure.Text = sureSayaci.ToString();


            startTimer.Interval = 5000;
            startTimer.Tick += (s, ev) => 
            {
                allowButtonClick = true; 
                startTimer.Stop();
            };
            startTimer.Start();

        }

        private void T3_Tick(object sender, EventArgs e)
        {
            if (sureSayaci > 0)
            {
                sureSayaci--;
                labelSure.Text = sureSayaci.ToString();
            }
            else
            {
                t3.Stop();
                MessageBox.Show("Süre doldu.Sıra diğer oyuncuda");
                kullaniciDegistir();
                labelSure.Text = sureSayaci.ToString();
            }
        }
        private void show()
        {
            Button btn;
            Random rnd = new Random();

            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    btn = control as Button;

                    if (icons.Count > 0) 
                    {
                        int randomIndex = rnd.Next(icons.Count);

                        btn.Text = icons[randomIndex]; 
                        btn.ForeColor = Color.Black;
                        icons.RemoveAt(randomIndex); 
                    }
                }
            }
        }

        private void kullaniciDegistir()
        {
            if (label7.Text == "İkinci Oyuncunun Sirasi!")
            {
                label7.Text = "Birinci Oyuncunun Sirasi!";
                label7.BackColor = Color.Blue;
                t3.Stop();
                sureSayaci = 8;
                labelSure.Text = sureSayaci.ToString();
            }
            else
            {
                label7.Text = "İkinci Oyuncunun Sirasi!";
                label7.BackColor = Color.Azure;
                t3.Stop();
                sureSayaci = 8;
                labelSure.Text = sureSayaci.ToString();
            }
        }
        int puan1 = 0;
        int puan2 = 0;
        private void puanArttir()
        {

            if (label7.Text == "İkinci Oyuncunun Sirasi!")
            {
                puan1++;
                label3.Text = Convert.ToString(puan1);
            }
            else
            {
                puan2++;
                label5.Text = Convert.ToString(puan2);
            }
        }
        private void kazanan()
        {
            if (puan1 == 11)
            {
                MessageBox.Show("İkinci Oyuncu Kazandi!");

            }
            else if (puan2 == 11)
            {
                MessageBox.Show("Birinci Oyuncu Kazandi!");

            }
        }
        private bool TumButonlarAcikMi()
        {
            foreach (Control control in Controls)
            {
                if (control is Button btn && btn.ForeColor != Color.Black)
                {
                    return false;
                }
            }
            return true;
        }
        private void OyunuBitir()
        {
            if (puan1 > puan2)
            {
                MessageBox.Show("Birinci Oyuncu Kazandi!");
            }
            else if (puan2 > puan1)
            {
                MessageBox.Show("İkinci Oyuncu Kazandi!");
            }
            else
            {
                MessageBox.Show("Berabere!");
            }
        }    
        private void button_click(object sender, EventArgs e)
        {
                t3.Start();
                Button btn = sender as Button;
                if (!btn.Enabled)
                    return;
                if (!allowButtonClick)
                {
                    MessageBox.Show("Oyun baslamadan butonlara basamazsiniz!");
                    return;
                }

                if (first == null) 
                {
                    first = btn;
                    first.ForeColor = Color.Black;
                    first.Enabled = false; 
                    return;
                }
                second = btn; 
                second.ForeColor = Color.Black;
                second.Enabled = false;
                if (first.Text == second.Text)
                {
                    puanArttir();
                    first.Enabled = false;
                    second.Enabled = false;
                    first.ForeColor = Color.Black;
                    second.ForeColor = Color.Black;
                    first = null;
                    second = null;
                    kazanan();
                }
                else
                {
                    t2.Start();
                    t2.Interval = 300; 
                    kullaniciDegistir();
                    first.Enabled = true;
                    second.Enabled = true;
                }

                if (TumButonlarAcikMi())
                {
                    OyunuBitir();
                
                }
            }
        }
    }
    


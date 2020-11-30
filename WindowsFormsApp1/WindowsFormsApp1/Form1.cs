using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Projekt : Form
    {
        public Projekt()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //czyszczenie pola
        {
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e) //czyszczenie pola
        {
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e) //czyszczenie pola
        {
            textBox3.Clear();
        }

        private void button6_Click(object sender, EventArgs e) //czyszczenie pól
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        public string Ascii(string asc)
        {
            char x = ' ';
            byte[] byte1 = Encoding.ASCII.GetBytes(textBox1.Text); //pobranie wprowadzanego tekstu do tablicy 
            string[] podzielone = asc.Split(x); //dzielenie
            int a = podzielone.Length;

            foreach (string b in podzielone) //usuwanie 
            {
                b.Remove(0);
                b.Remove(8);
                b.Remove(9);
            }

            string lecimy_dalej = string.Join("", podzielone);

            int słowa = lecimy_dalej.Length;
            int elementy = (słowa - 1) / 7;
            List<Byte> byte2 = new List<Byte>();
            int d = 6;
            for (int c = 0; c < lecimy_dalej.Length; c = c + d) //od 0 co 0 + 6
                byte2.Add(Convert.ToByte(lecimy_dalej.Substring(c, d), 2));
            byte[] byte3 = new byte[byte2.Count];
            byte2.CopyTo(byte3);
            return Encoding.ASCII.GetString(byte3);
        }
        public string Bin(string bin) //dodawanie bitów startu i stopu
        {
            StringBuilder bla = new StringBuilder();
            foreach (char p in bin.ToString())
            {
                bla.Append(Convert.ToString(p, 2));

                bla.Append(11);
                bla.Append(" ");
                bla.Append(0);

            }
            bla.Insert(0, 0);
            string n;
            n = bla.ToString();
            int x = n.Length;
            return n.Remove(x - 2);
        }

        private static string Tekst(String ofc)
        {
            int x = 8;
            List<Byte> byte1 = new List<Byte>();
            for (int a = 0; a < ofc.Length; a = a + x) //Od 0 co 8
                byte1.Add(Convert.ToByte(ofc.Substring(a, x), 2));
            byte[] bytes2 = new byte[byte1.Count];
            byte1.CopyTo(bytes2);
            return Encoding.UTF8.GetString(bytes2); //zamiana na znaki
        }

        public string pamietaj()
        {
            byte[] byte1 = Encoding.ASCII.GetBytes(textBox1.Text);
            string zapamiętane = Encoding.ASCII.GetString(byte1);
            return zapamiętane;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string wysyłane = textBox1.Text;//pobieranie
            char y = ' ';
            string[] sklejanie = wysyłane.Split(y);//dzielenie co 1

            int długość = sklejanie.Length; //cenzura
            string[] brzydkie = { "kurwa", "pizda", "szmata", "jebie", "chuj", "huj", "pierdol", "Kurwa", "Pizda",
                "Szmata", "Jebie", "Chuj", "Huj", "Pierdol", };
            int length = brzydkie.Length;
            for (int i = 0; i <= długość - 1; i++)
            {
                for (int j = 0; j <= length - 1; j++)
                {
                    if (sklejanie[i].Contains(brzydkie[j])) //porównywanie (nie widzi enterów (jeśli słowo wulgarne nie jest oddzielone 
                        //spacją to traktowane jest jako jedno długie słowo razem z nieoddzielonym wyrazem i oba są zamieniane na "*"))
                    {
                        string słowo = sklejanie[i];
                        string wulgaryzm = brzydkie[j];
                        string sprawdzanie = sklejanie[i];
                        foreach (char u in słowo)
                        {
                            char w = '*';       //zastępowanie wulgaryzmów przez "*"
                            sprawdzanie = sprawdzanie.Replace(u, w);
                            sklejanie[i] = sklejanie[i].Replace(sklejanie[i], sprawdzanie);
                        }
                        sklejanie[i].Replace(sklejanie[i], sprawdzanie);
                        string poprawianie = string.Join(",", sklejanie);
                        textBox3.Text = sprawdzanie;
                    }
                    else
                        textBox3.Text = textBox1.Text;

                    string nowość = string.Join(" ", sklejanie);
                    textBox1.Text = nowość;
                    textBox3.Text = nowość;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)//zamiana na binarne
        {
            textBox2.Text = Bin(textBox1.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }























































       /*public void sprawdzanie(string g)
       {
           char h = ' ';
           string wysyłane = textBox1.Text;
           string[] sklejanie = wysyłane.Split(h);

           int długość = sklejanie.Length;
           string[] brzydkie = { "kurwa", "pizda" };
           int length = brzydkie.Length;
           for (int i = 0; i <= długość - 1; i++)
           {
               for (int j = 0; j <= length - 1; j++)
               {
                   if (sklejanie[i].Contains(brzydkie[j]))
                   {
                       string słowo = sklejanie[i];
                       string wulgaryzm = brzydkie[j];
                       string sprawdzanie = sklejanie[i];
                       foreach (char u in słowo)
                       {
                           char w = '*';
                           sprawdzanie = sprawdzanie.Replace(u, w);
                           sklejanie[i] = sklejanie[i].Replace(sklejanie[i], sprawdzanie);
                       }
                       sklejanie[i].Replace(sklejanie[i], sprawdzanie);
                       string poprawianie = string.Join(",", sklejanie);
                       textBox3.Text = sprawdzanie;
                   }
                   else
                       textBox3.Text = textBox1.Text;

                   string nowość = string.Join(" ", sklejanie);
                   textBox1.Text = nowość;
               }

           }
       }*/
    }
}

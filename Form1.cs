using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace odev3
{    
    
    // MessageBox.Show(OgrenciAd[2].ToString());

    /*foreach (String i in OgrenciAd)
    {
        MessageBox.Show(i);
    }*/
          
    public partial class Form1 : Form
    {
        ArrayList OgrenciAd = new ArrayList();
        ArrayList OgrenciNo = new ArrayList();
        ArrayList OgrenciBolum = new ArrayList();
        ArrayList Ders1 = new ArrayList();
        ArrayList Not1 = new ArrayList();
        ArrayList Ders2 = new ArrayList();
        ArrayList Not2 = new ArrayList();
        ArrayList Ders3 = new ArrayList();
        ArrayList Not3 = new ArrayList();
        
        int ogrsay = 0;
        int ara = 0, araort = 0, araindeks = -1;
        public Form1()
        {
            InitializeComponent();
        }

        public void ogrencikaydet()
        {
            foreach (var item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    if (txt.Text == "")
                    {
                        MessageBox.Show("Bütün alanalrı doldurunuz..");
                        return;
                    }
                }
                else if (item is ComboBox)
                {
                    ComboBox cmbox = (ComboBox)item;
                    if (cmbox.SelectedIndex == -1)
                    {
                        MessageBox.Show("Lütfen Ders Seçin");
                        return;
                    }
                }
            }

            if (comboBox1.SelectedIndex == comboBox2.SelectedIndex || comboBox1.SelectedIndex == comboBox3.SelectedIndex || comboBox2.SelectedIndex == comboBox3.SelectedIndex)
            {
                MessageBox.Show("Aynı Ders Seçilemez");
                return;
            }
            OgrenciAd.Add(textBox2.Text.ToString());
            Ders1.Add(comboBox1.SelectedItem.ToString());
            Ders2.Add(comboBox2.SelectedItem.ToString());
            Ders3.Add(comboBox3.SelectedItem.ToString());
            Not1.Add(textBox4.Text);
            Not2.Add(textBox5.Text);
            Not3.Add(textBox6.Text);
            OgrenciNo.Add(textBox1.Text.ToString());
            OgrenciBolum.Add(textBox3.Text.ToString());
        }

        public void bolumara()
        {
            int toplamogr = 0, toplamnot=0 ;
            String aranacak = textBox9.Text.ToLower();
            foreach (String bol in OgrenciBolum)
            {
                araindeks++;
                if (bol.ToLower().Equals(aranacak))
                {
                    toplamogr++;
                    toplamnot += Convert.ToInt32(Not1[araindeks]) + Convert.ToInt32(Not2[araindeks]) + Convert.ToInt32(Not3[araindeks]);
                }
            }
            
            MessageBox.Show("Bölümde toplam "+toplamogr+" Öğrenci vardır"+Environment.NewLine+
                            "Bölüm Ortalaması : " + toplamnot/toplamogr/3);
            araindeks=-1;                    
        }

        public void noyagoreara()
        {
            String adbul=textBox7.Text.ToLower();
            int ort = 0;
            foreach (String nobul in OgrenciNo)
            {
                araindeks++;
                if (nobul.Equals(textBox8.Text))
                {
                    if (adbul.ToLower().Equals(OgrenciAd[araindeks].ToString().ToLower()))
                    {
                        ort = Convert.ToInt32(Not1[araindeks]) + Convert.ToInt32(Not2[araindeks]) + Convert.ToInt32(Not3[araindeks]);
                        MessageBox.Show("Adı : "+adbul+Environment.NewLine+
                                        "Öğrenci no : "+ OgrenciNo[araindeks]+Environment.NewLine+
                                        "Aldığı 1. Ders :"+Ders1[araindeks]+" Notu :"+Not1[araindeks]+Environment.NewLine+
                                        "Aldığı 2. Ders :"+Ders2[araindeks]+" Notu :"+Not2[araindeks]+Environment.NewLine+
                                        "Aldığı 3. Ders :"+Ders3[araindeks]+" Notu :"+Not3[araindeks]+Environment.NewLine+
                                        "Ortalama :"+ort/3
                                        );
                    }
                }
            }
            araindeks = -1;
        }

        public void arama()
        {
            

            foreach (string d1 in Ders1)
            {
                araindeks++;
                if (comboBox4.SelectedItem == d1)
                {
                    ara++;
                    araort += Convert.ToInt32(Not1[araindeks]);
                }
            }
            araindeks = -1;
            foreach (string d2 in Ders2)
            {
                araindeks++;
                if (comboBox4.SelectedItem == d2)
                {
                    ara++;
                    araort += Convert.ToInt32(Not2[araindeks]);
                }
            }
            araindeks = -1;
            foreach (string d3 in Ders3)
            {
                araindeks++;
                if (comboBox4.SelectedItem == d3)
                {
                    ara++;
                    araort += Convert.ToInt32(Not3[araindeks]);
                }
            }
         
            araort /= ara;
            MessageBox.Show("Derse "+ara+" Kişi Kaydolmuştur");
            MessageBox.Show("Dersin Ortalaması :"+ araort.ToString());
            ara = 0; araort = 0; araindeks = -1;
        }

        public void enyukseknotlar()
        {
            int yuksek1 = 0, yuksek2 = 0, yuksek3 = 0, yuksek4 = 0, yuksek5 = 0;
            String ad1 = "", ad2 = "", ad3 = "", ad4 = "", ad5 = "";
            foreach (string d1 in Ders1)
            {
                araindeks++;
                if (d1 == "Matematik")
                {
                    if (Convert.ToInt32(Not1[araindeks]) > yuksek1)
                    {
                        yuksek1 = Convert.ToInt32(Not1[araindeks]);
                        ad1 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d1 == "Fizik")
                {
                    if (Convert.ToInt32(Not1[araindeks]) > yuksek2)
                    {
                        yuksek2 = Convert.ToInt32(Not1[araindeks]);
                        ad2 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d1 == "Kimya")
                {
                    if (Convert.ToInt32(Not1[araindeks]) > yuksek3)
                    {
                        yuksek3 = Convert.ToInt32(Not1[araindeks]);
                        ad3 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d1 == "Biyoloji")
                {
                    if (Convert.ToInt32(Not1[araindeks]) > yuksek4)
                    {
                        yuksek4 = Convert.ToInt32(Not1[araindeks]);
                        ad4 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d1 == "Geometri")
                {
                    if (Convert.ToInt32(Not1[araindeks]) > yuksek5)
                    {
                        yuksek5 = Convert.ToInt32(Not1[araindeks]);
                        ad5 = OgrenciAd[araindeks].ToString();
                    }
                }
            }
            araindeks = -1;
            foreach (string d2 in Ders2)
            {
                araindeks++;
                if (d2 == "Matematik")
                {
                    if (Convert.ToInt32(Not2[araindeks]) > yuksek1)
                    {
                        yuksek1 = Convert.ToInt32(Not2[araindeks]);
                        ad1 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d2 == "Fizik")
                {
                    if (Convert.ToInt32(Not2[araindeks]) > yuksek2)
                    {
                        yuksek2 = Convert.ToInt32(Not2[araindeks]);
                        ad2 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d2 == "Kimya")
                {
                    if (Convert.ToInt32(Not2[araindeks]) > yuksek3)
                    {
                        yuksek3 = Convert.ToInt32(Not2[araindeks]);
                        ad3 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d2 == "Biyoloji")
                {
                    if (Convert.ToInt32(Not2[araindeks]) > yuksek4)
                    {
                        yuksek4 = Convert.ToInt32(Not2[araindeks]);
                        ad4 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d2 == "Geometri")
                {
                    if (Convert.ToInt32(Not2[araindeks]) > yuksek5)
                    {
                        yuksek5 = Convert.ToInt32(Not2[araindeks]);
                        ad5 = OgrenciAd[araindeks].ToString();
                    }
                }
            }
            araindeks = -1;
            foreach (string d3 in Ders3)
            {
                araindeks++;
                if (d3 == "Matematik")
                {
                    if (Convert.ToInt32(Not3[araindeks]) > yuksek1)
                    {
                        yuksek1 = Convert.ToInt32(Not3[araindeks]);
                        ad1 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d3 == "Fizik")
                {
                    if (Convert.ToInt32(Not3[araindeks]) > yuksek2)
                    {
                        yuksek2 = Convert.ToInt32(Not3[araindeks]);
                        ad2 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d3 == "Kimya")
                {
                    if (Convert.ToInt32(Not3[araindeks]) > yuksek3)
                    {
                        yuksek3 = Convert.ToInt32(Not3[araindeks]);
                        ad3 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d3 == "Biyoloji")
                {
                    if (Convert.ToInt32(Not3[araindeks]) > yuksek4)
                    {
                        yuksek4 = Convert.ToInt32(Not3[araindeks]);
                        ad4 = OgrenciAd[araindeks].ToString();
                    }
                }
                else if (d3 == "Geometri")
                {
                    if (Convert.ToInt32(Not3[araindeks]) > yuksek5)
                    {
                        yuksek5 = Convert.ToInt32(Not3[araindeks]);
                        ad5 = OgrenciAd[araindeks].ToString();
                    }
                }
            }
            araindeks = -1;
            MessageBox.Show("Matematik En yüksek :" + yuksek1 + "    Not Sahibi :" + ad1.ToString() + Environment.NewLine + Environment.NewLine +
                            "Fizik En yüksek :" + yuksek2 + "   Not Sahibi :" + ad2.ToString() + Environment.NewLine + Environment.NewLine +
                            "Kimya En yüksek :" + yuksek3 + "   Not Sahibi :" + ad3.ToString() + Environment.NewLine + Environment.NewLine +
                            "Biyoloji En yüksek :" + yuksek4 + "     Not Sahibi :" + ad4.ToString() + Environment.NewLine + Environment.NewLine +
                            "Geometri En yuksek :" + yuksek5+"   Not Sahibi :"+ad5.ToString());

        }

        public void ortsirala()
        {
            int toplam=0;
            ArrayList Ortalama = new ArrayList();
            ArrayList gncliste = new ArrayList();

            foreach(String d1 in OgrenciAd){
                araindeks++;
                toplam += Convert.ToInt32(Not1[araindeks]) + Convert.ToInt32(Not2[araindeks]) + Convert.ToInt32(Not3[araindeks]);
                toplam /= 3;
                Ortalama.Add(toplam);
                toplam = 0;
            }
            araindeks = -1;
            int say = Ortalama.Count;
            int sira = 0, temp;
            String temps;

            int[] ortdiz = new int[say];
            String[] ograd = new String[say];
            String[] ogrno = new String[say];
            int[] not1 = new int[say];
            int[] not2 = new int[say];
            int[] not3= new int[say];
            

            foreach (var nott in Ortalama)
            {
                araindeks++;
                ortdiz[sira] = Convert.ToInt32(nott);
                ograd[sira] = OgrenciAd[araindeks].ToString();
                ogrno[sira] = OgrenciNo[araindeks].ToString();
                not1[sira] = Convert.ToInt32(Not1[araindeks]);
                not2[sira] = Convert.ToInt32(Not2[araindeks]);
                not3[sira] = Convert.ToInt32(Not3[araindeks]);
                sira++;
            }



            for (int i = 1; i < say; i++)
            {
                for (int j = 0; j < say - i; j++)
                {
                    if (ortdiz[j] > ortdiz[j + 1])
                    {
                        temp = ortdiz[j];
                        ortdiz[j] = ortdiz[j + 1];
                        ortdiz[j + 1] = temp;

                        temps = ograd[j];
                        ograd[j] = ograd[j + 1];
                        ograd[j + 1] = temps;

                        temps = ogrno[j];
                        ogrno[j] = ogrno[j + 1];
                        ogrno[j + 1] = temps;

                        temp = not1[j];
                        not1[j] = not1[j + 1];
                        not1[j + 1] = temp;

                        temp = not2[j];
                        not2[j] = not2[j + 1];
                        not2[j + 1] = temp;

                        temp = not3[j];
                        not3[j] = not3[j + 1];
                        not3[j + 1] = temp;

                    }
                }
            }

            for (int i = 0; i < say; i++)
            {
                MessageBox.Show("Öğrenci Numarası : "+ogrno[i]+"    Öğrenci Adı :"+ograd[i]+Environment.NewLine+
                                "Not 1: "+not1[i].ToString()+" Not 2 : "+not2[i]+" Not 3 :"+not3[i]+Environment.NewLine+
                                "Ortalama : "+ortdiz[i]
                                );
            }

                araindeks = -1;
        }

        public void kucuknot()
        {
            foreach (string d1 in Ders1)
            {
                araindeks++;
                if (comboBox5.SelectedItem == d1)
                {
                    if (Convert.ToInt32(Not1[araindeks]) < 60)
                    {
                        MessageBox.Show("Öğrenci Numarası : "+ OgrenciNo[araindeks].ToString()+Environment.NewLine+
                            " Öğreci Adı :" + OgrenciAd[araindeks]+Environment.NewLine+
                            "Öğrenci notu : " +Not1[araindeks]
                            );
                    }
                }
            }
            araindeks = -1;
            foreach (string d2 in Ders2)
            {
                araindeks++;
                if (comboBox5.SelectedItem == d2)
                {
                    if (Convert.ToInt32(Not2[araindeks]) < 60)
                    {
                        MessageBox.Show("Öğrenci Numarası : " + OgrenciNo[araindeks].ToString() + Environment.NewLine +
                            " Öğreci Adı :" + OgrenciAd[araindeks] + Environment.NewLine +
                            "Öğrenci notu : " + Not2[araindeks]
                            );
                    }
                }
            }
            araindeks = -1;
            foreach (string d3 in Ders3)
            {
                araindeks++;
                if (comboBox5.SelectedItem == d3)
                {
                    if (Convert.ToInt32(Not3[araindeks]) < 60)
                    {
                        MessageBox.Show("Öğrenci Numarası : " + OgrenciNo[araindeks].ToString() + Environment.NewLine +
                            " Öğreci Adı :" + OgrenciAd[araindeks] + Environment.NewLine +
                            "Öğrenci notu : " + Not3[araindeks]
                            );
                    }
                }
            }
            araindeks = -1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ogrencikaydet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 0)
            {
                enyukseknotlar();
            }
            else if (comboBox6.SelectedIndex == 1)
            {
                ortsirala();
            }
            else if (comboBox6.SelectedIndex == 2)
            {
                noyagoreara();
            }
            else if (comboBox6.SelectedIndex == 3)
            {
                bolumara();
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                arama();
            }
            else if (radioButton2.Checked)
            {
                kucuknot();
            }
            else
            {
                MessageBox.Show("Lütfen Yukarıdan Seçim Yapınız");
            }
                        
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Not girilecek 3 adet Textbox kutusunun keypress eventlerinin hepsi burraya bağlandı..
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = true;
            comboBox5.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox4.Enabled = false;
            comboBox5.Enabled = true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 2)
            {
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = false;
            }
            else if (comboBox6.SelectedIndex == 3)
            {
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = true;
            }
            else
            {
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;//eğer rakamsa  yazdırma.
            }
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = false;//stringse yazdır
            }
        }

    }
}

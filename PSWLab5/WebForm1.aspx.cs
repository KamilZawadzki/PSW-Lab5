using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace PSWLab5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Regex reg;
        private static TimeSpan czasPodrozy;
        bool i = true;
        private Dictionary<string, int> dniMiesiaca;
        protected void Page_Load(object sender, EventArgs e)
        {
            reg = new Regex(@"^(([1-9]\d*)||(0))$");
            raport.Visible = false;
            dniMiesiaca = new Dictionary<string, int>() { { "1", 31 }, { "2", 28 }, { "3", 31 }, { "4", 30 }, { "5", 31 }, { "6", 30 }, { "7", 31 }, { "8", 31 }, { "9", 30 }, { "10", 31 }, { "11", 30 }, { "12", 31 }, };
            wypelnij_godziny();
            wypelnij_minuty();
        }



        private void wypelnij_minuty()
        {
            for (int i = 0; i <= 59; i++) { wyjazd_minuty.Items.Add(new ListItem(i.ToString("00"), (i - 1).ToString())); }
            for (int i = 0; i <= 59; i++) { powrot_minuty.Items.Add(new ListItem(i.ToString("00"), (i - 1).ToString())); }

        }

        private void wypelnij_godziny()
        {

            for (int i = 0; i <= 23; i++) { wyjazd_godzina.Items.Add(new ListItem(i.ToString("00"), (i - 1).ToString())); }
            for (int i = 0; i <= 23; i++) { powrot_godzina.Items.Add(new ListItem(i.ToString("00"), (i - 1).ToString())); }

        }



        protected void diety_showHide_link_Click(object sender, EventArgs e)
        {
            if (diety_showHide_link.Text.Equals("zwiń"))
            {
                diety.Visible = false;
                diety_showHide_link.Text = "rozwiń";
            }
            else
            {
                diety.Visible = true;
                diety_showHide_link.Text = "zwiń";
            }
        }



        protected void linkButton_zwrot_showHide_Click(object sender, EventArgs e)
        {
            if (linkButton_zwrot_showHide.Text.Equals("zwiń"))
            {
                zwrot.Visible = false;
                linkButton_zwrot_showHide.Text = "rozwiń";
            }
            else
            {
                zwrot.Visible = true;
                linkButton_zwrot_showHide.Text = "zwiń";
            }
        }

        protected void Button_oblicz_Click(object sender, EventArgs e)
        {
            //if (checkInsertedData())
            //{
            if (checkInsertedData() && obliczCzasPodrozy())
            {
                insert.Visible = false;
                raport.Visible = true;
                //dla uniknięcia NullPointerExc \/
                Label_kwotaZaZapewnioneWyzywienie.Text = "0";
                Label_kosztyPrzejazdow.Text = "0";
                zwrotKosztowPrzejazdu();
                kosztZapewnionegoWyzywienia();
                obliczPodsumowanie();

            }


            // }
            //Server.Transfer("WebForm2.aspx", true);

        }

        private void exportToTxt()
        {
            StreamWriter streamWriter = new StreamWriter(Server.MapPath("test.txt"));
            streamWriter.WriteLine("Czas podróży: " + Label_czasPodrozy.Text);
            streamWriter.WriteLine("Wysokość diet: " + Label_wysokoscDiet.Text + "zł");
            streamWriter.WriteLine("Kwota pomniejszająca diety z tytułu zapewnionego wyżywienia: " + Label_kwotaZaZapewnioneWyzywienie.Text + "zł");
            streamWriter.WriteLine("Zwrot za koszty transportu: " + Label_kosztyPrzejazdow.Text + "zł");
            streamWriter.WriteLine("Do wypłaty: " + Label_doWyplaty.Text);
            streamWriter.Close();
            raport.Visible = true;
        }

        private void obliczPodsumowanie()
        {
            double doWyplaty = Convert.ToDouble(Label_wysokoscDiet.Text) + Convert.ToDouble(Label_kosztyPrzejazdow.Text) - Convert.ToDouble(Label_kwotaZaZapewnioneWyzywienie.Text) + Convert.ToDouble(Label_innyPojazd_cenaBiletu.Text);
            Label_doWyplaty.Text = doWyplaty.ToString() + "zł";
            if (czasPodrozy.TotalMinutes == 0)
            {
                Label_doWyplaty.Text = "Nie byłeś na żadnym wyjeździe oszuście! Do wypłaty: 0zł";
            }
        }

        private void kosztZapewnionegoWyzywienia()
        {
            HashSet<System.Web.UI.WebControls.TextBox> textBoxes = new HashSet<TextBox>()
            {
                TB_liczbaKolacji,
                TB_liczbaObiadow,
                TB_liczbaSniadan,
            };
            int counter = 0;
            foreach (TextBox tB in textBoxes)
            {
                if (String.IsNullOrEmpty(tB.Text))
                {
                    tB.Text = "0";
                }
                else
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                zmienWidocznoscJedzeniaWRaporcie();
            }
            else
            {
                Label_iloscSniadan.Text = TB_liczbaSniadan.Text;
                Label_iloscKolacji.Text = TB_liczbaKolacji.Text;
                Label_iloscObiadow.Text = TB_liczbaObiadow.Text;
                double dwadziesciaPiecProcentDietyZaDzien = Convert.ToDouble(wysokoscDietyZaDobe_TB.Text) / 4;
                double piecdziesiatProcentDietyZaDzien = Convert.ToDouble(wysokoscDietyZaDobe_TB.Text) / 2;
                Double kosztyObiadow = (Convert.ToDouble(TB_liczbaSniadan.Text) * dwadziesciaPiecProcentDietyZaDzien) + (Convert.ToDouble(TB_liczbaKolacji.Text) * dwadziesciaPiecProcentDietyZaDzien) + (Convert.ToDouble(TB_liczbaObiadow.Text) * piecdziesiatProcentDietyZaDzien);
                Label_kwotaZaZapewnioneWyzywienie.Text = kosztyObiadow.ToString();
            }
        }

        private void zwrotKosztowPrzejazdu()
        {
            HashSet<System.Web.UI.WebControls.TextBox> textBoxes = new HashSet<TextBox>()
            {
                TB_oPojemnosciSilnikaDo900,
                TB_RodzajSrodkaTransportu,
                TB_oPojemnosciSIlnikaPowyzej900,
                TB_motocyklem,
                TB_motorowerem,
                TB_cenaBiletuZaPrzejazd
            };
            int counter = 0;
            foreach (TextBox tB in textBoxes)
            {
                if (String.IsNullOrEmpty(tB.Text))
                {
                    tB.Text = "0";
                }
                else
                {
                    counter++;
                }
            }
            Label_innyPojazd_cenaBiletu.Text = TB_cenaBiletuZaPrzejazd.Text;
            if (counter == 0)
            {
                zmienWidocznoscKosztowTransportuWRaporcie();
            }
            else
            {
                Label_innySrodekTransportu.Text = TB_RodzajSrodkaTransportu.Text;
                Label_pojDo900.Text = TB_oPojemnosciSilnikaDo900.Text + "km";
                Label_pojPow900.Text = TB_oPojemnosciSIlnikaPowyzej900.Text + "km";
                Label_motocykl.Text = TB_motocyklem.Text + "km";
                Label_motorower.Text = TB_motorowerem.Text + "km";
                Double kosztyPrzejazdow = (Convert.ToDouble(TB_oPojemnosciSilnikaDo900.Text) * 0.5214) + (Convert.ToDouble(TB_oPojemnosciSIlnikaPowyzej900.Text) * 0.8358) + (Convert.ToDouble(TB_motocyklem.Text) * 0.2302) + (Convert.ToDouble(TB_motorowerem.Text) * 0.1382);
                Label_kosztyPrzejazdow.Text = Math.Round(kosztyPrzejazdow, 2).ToString();
            }

        }

        private void zmienWidocznoscKosztowTransportuWRaporcie()
        {
            if (transport.Visible)
            {
                transport.Visible = false;
                transport2.Visible = false;
                transport3.Visible = false;
                transport4.Visible = false;
                transport5.Visible = false;
                transport6.Visible = false;
                transport7.Visible = false;
            }
            else
            {
                transport.Visible = true;
                transport2.Visible = true;
                transport3.Visible = true;
                transport4.Visible = true;
                transport5.Visible = true;
                transport6.Visible = true;
                transport7.Visible = true;
            }
        }

        private void zmienWidocznoscJedzeniaWRaporcie()
        {
            if (jedzenie.Visible)
            {
                jedzenie.Visible = false;
                jedzenie2.Visible = false;
                jedzenie3.Visible = false;
                jedzenie4.Visible = false;
                jedzenie5.Visible = false;
            }
            else
            {
                jedzenie.Visible = true;
                jedzenie2.Visible = true;
                jedzenie3.Visible = true;
                jedzenie4.Visible = true;
                jedzenie5.Visible = true;
            }
        }

        private bool checkInsertedData()
        {
            String error = "";
            if (sprawdzWysokoscDiety(ref error) && sprawdzWyzywienie(ref error) && sprawdzCeneBiletuZaPrzejazd(ref error) && sprawdzKilometry(ref error))
            {
                return true;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", $"<script language = 'javascript'>alert('{error}')</script>");
                return false;
                error = "";
            }

        }

        private bool sprawdzKilometry(ref string error)
        {
            if ((reg.IsMatch(TB_oPojemnosciSilnikaDo900.Text) || String.IsNullOrEmpty(TB_oPojemnosciSilnikaDo900.Text)) && (reg.IsMatch(TB_oPojemnosciSIlnikaPowyzej900.Text) || String.IsNullOrEmpty(TB_oPojemnosciSIlnikaPowyzej900.Text)) && (reg.IsMatch(TB_motocyklem.Text) || String.IsNullOrEmpty(TB_motocyklem.Text)) && (reg.IsMatch(TB_motorowerem.Text) || String.IsNullOrEmpty(TB_motorowerem.Text)))
            {
                return true;
            }
            else
            {
                error = "Nieprawidłowo uzupełnione kilometry.";
                return false;
            }
        }

        private bool sprawdzCeneBiletuZaPrzejazd(ref string error)
        {

            if ((reg.IsMatch(TB_cenaBiletuZaPrzejazd.Text) || String.IsNullOrEmpty(TB_cenaBiletuZaPrzejazd.Text)))
            {
                return true;
            }
            else
            {
                error = "Błędna cena biletu za przejazd.";
                return false;
            }
        }

        private bool sprawdzWyzywienie(ref string error)
        {
            if ((reg.IsMatch(TB_liczbaKolacji.Text) || String.IsNullOrEmpty(TB_liczbaKolacji.Text)) && (reg.IsMatch(TB_liczbaObiadow.Text) || String.IsNullOrEmpty(TB_liczbaObiadow.Text)) && (reg.IsMatch(TB_liczbaSniadan.Text) || String.IsNullOrEmpty(TB_liczbaSniadan.Text)))
            {
                return true;
            }
            else
            {
                error = "Błędna wartość w ustaleniach wyżywienia.";
                return false;
            }
        }

        private bool sprawdzWysokoscDiety(ref String error)
        {
            Regex reg = new Regex(@"^[1-9]\d*$");
            if ((reg.IsMatch(wysokoscDietyZaDobe_TB.Text)))
            {
                if (int.Parse(wysokoscDietyZaDobe_TB.Text)<30)
                {
                    wysokoscDietyZaDobe_TB.Text = "30";
                }
                return true;
            }
            else
            {
                error = "Błędna wartość w polu Wysokość diety lub wartość nie została wprowadzona.";
                return false;
            }
        }

        private bool obliczCzasPodrozy()
        {
            try
            {
                System.DateTime dataWyjazdu = new DateTime(Convert.ToInt32(wyjazd_rok.SelectedItem.Text), Convert.ToInt32(wyjazd_miesiac.SelectedItem.Text), Convert.ToInt32(wyjazd_dzien.SelectedItem.Text), Convert.ToInt32(wyjazd_godzina.SelectedItem.Text), Convert.ToInt32(wyjazd_minuty.SelectedItem.Text), 0);
                System.DateTime dataPowrotu = new DateTime(Convert.ToInt32(powrot_rok.SelectedItem.Text), Convert.ToInt32(powrot_miesiac.SelectedItem.Text), Convert.ToInt32(powrot_dzien.SelectedItem.Text), Convert.ToInt32(powrot_godzina.SelectedItem.Text), Convert.ToInt32(powrot_minuty.SelectedItem.Text), 0);
                Label_dataiGodzinaPowrotu.Text = dataPowrotu.ToString();
                Label_dataiGodzinaWyjazdu.Text = dataWyjazdu.ToString();

                czasPodrozy = dataPowrotu.Subtract(dataWyjazdu);
                Label_czasPodrozy.Text = string.Format("{0:D2}d, {1:D2}g, {2:D2}m", czasPodrozy.Days, czasPodrozy.Hours, czasPodrozy.Minutes);
                if (!String.IsNullOrEmpty(wysokoscDietyZaDobe_TB.Text))
                {
                    if ((Convert.ToInt32(czasPodrozy.Hours) > 0) || (Convert.ToInt32(czasPodrozy.Minutes) > 0))
                    {
                        Label_wysokoscDiet.Text = (Convert.ToInt32(wysokoscDietyZaDobe_TB.Text) * Convert.ToInt32(czasPodrozy.TotalDays + 1)).ToString();
                    }
                    else
                    {
                        Label_wysokoscDiet.Text = (Convert.ToInt32(wysokoscDietyZaDobe_TB.Text) * czasPodrozy.TotalDays).ToString();
                    }
                }
                if (czasPodrozy.TotalDays < 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language = 'javascript'>alert('Sprawdź wprowadzone daty wyjazdu i powrotu i spróbuj ponownie.')</script>");
                return false;
            }
            return true;
        }
        private bool checkDataPowrotu()
        {
            return true;
        }

        private bool checkDataWyjazdu()
        {
            throw new NotImplementedException();
        }


        protected void wyjazd_SelectedIndexChanged1(object sender, EventArgs e)
        {
            wyjazd_dzien.BackColor = System.Drawing.Color.White;
            if (wyjazd_rok.Text.Equals("2016") && wyjazd_miesiac.Text.Equals("2") && (Convert.ToInt32(wyjazd_dzien.Text) > 29))
            {
                wyjazd_dzien.BackColor = System.Drawing.Color.Red;
            }
            else if (dniMiesiaca[wyjazd_miesiac.Text] < (Convert.ToInt32(wyjazd_dzien.Text)))
            {
                wyjazd_dzien.BackColor = System.Drawing.Color.Red;
            }
        }

        protected void powrot_SelectedIndexChanged1(object sender, EventArgs e)
        {
            powrot_dzien.BackColor = System.Drawing.Color.White;
            if (powrot_rok.Text.Equals("2016") && powrot_miesiac.Text.Equals("2") && (Convert.ToInt32(powrot_dzien.Text) > 29))
            {
                powrot_dzien.BackColor = System.Drawing.Color.Red;
            }
            else if (dniMiesiaca[powrot_miesiac.Text] < (Convert.ToInt32(powrot_dzien.Text)))
            {
                powrot_dzien.BackColor = System.Drawing.Color.Red;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            exportToTxt();
        }
    }
}
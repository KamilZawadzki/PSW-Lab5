using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace PSWLab5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Regex reg;
        bool i = true;
        private Dictionary<string, int> dniMiesiaca;
        protected void Page_Load(object sender, EventArgs e)
        {
            reg = new Regex(@"^[1-9]\d*$");
            raport.Visible = false;
            dniMiesiaca = new Dictionary<string, int>() { { "1", 31 },{"2",28},{"3",31},{"4",30},{"5",31},{"6",30}, { "7", 31 }, { "8", 31 }, { "9", 30 }, { "10", 31 }, { "11", 30 }, { "12", 31 }, } ;
            wypelnij_godziny();
            wypelnij_minuty();            
        }



        private void wypelnij_minuty()
        {
            for (int i = 0; i <= 59; i++) { wyjazd_minuty.Items.Add(new ListItem(i.ToString("00"), (i - 1).ToString()));}
            for (int i = 0; i <= 59; i++) { powrot_minuty.Items.Add(new ListItem(i.ToString("00"), (i - 1).ToString())); }

        }

        private void wypelnij_godziny()
        {
          
            for (int i = 0; i <= 23 ; i++) { wyjazd_godzina.Items.Add(new ListItem(i.ToString("00"), (i - 1).ToString()));}
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
            if (checkInsertedData() && czasPodrozy())
            {
                insert.Visible = false;
                raport.Visible = true;
                
            }
            
            
           // }
            //Server.Transfer("WebForm2.aspx", true);

        }

        private bool checkInsertedData()
        {
            String error = "";
            if (sprawdzWysokoscDiety(ref error)&&sprawdzWyzywienie(ref error)&&sprawdzCeneBiletuZaPrzejazd(ref error)&&sprawdzKilometry(ref error))
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
           if ((reg.IsMatch(TB_oPojemnosciSilnikaDo900.Text)|| String.IsNullOrEmpty(TB_oPojemnosciSilnikaDo900.Text)) && (reg.IsMatch(TB_oPojemnosciSIlnikaPowyzej900.Text) || String.IsNullOrEmpty(TB_oPojemnosciSIlnikaPowyzej900.Text)) && (reg.IsMatch(TB_motocyklem.Text) || String.IsNullOrEmpty(TB_motocyklem.Text)) && (reg.IsMatch(TB_motorowerem.Text) || String.IsNullOrEmpty(TB_motorowerem.Text)))
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

            
            if ((reg.IsMatch(wysokoscDietyZaDobe_TB.Text) || String.IsNullOrEmpty(wysokoscDietyZaDobe_TB.Text)))
            {
                return true;
            }
            else
            {
                error = "Błędna wartość w polu Wysokość diety";
                return false;
            }
        }

        private bool czasPodrozy()
        {
            try { System.DateTime dataWyjazdu = new DateTime(Convert.ToInt32(wyjazd_rok.SelectedItem.Text), Convert.ToInt32(wyjazd_miesiac.SelectedItem.Text), Convert.ToInt32(wyjazd_dzien.SelectedItem.Text), Convert.ToInt32(wyjazd_godzina.SelectedItem.Text), Convert.ToInt32(wyjazd_minuty.SelectedItem.Text), 0);
                System.DateTime dataPowrotu = new DateTime(Convert.ToInt32(powrot_rok.SelectedItem.Text), Convert.ToInt32(powrot_miesiac.SelectedItem.Text), Convert.ToInt32(powrot_dzien.SelectedItem.Text), Convert.ToInt32(powrot_godzina.SelectedItem.Text), Convert.ToInt32(powrot_minuty.SelectedItem.Text), 0);
                Label_dataiGodzinaPowrotu.Text = dataPowrotu.ToString();
                Label_dataiGodzinaWyjazdu.Text = dataWyjazdu.ToString();

                TimeSpan czasPodrozy = dataPowrotu.Subtract(dataWyjazdu);
                Label_czasPodrozy.Text = string.Format("{0:D2}d, {1:D2}g, {2:D2}m", czasPodrozy.Days, czasPodrozy.Hours, czasPodrozy.Minutes);
                if (!String.IsNullOrEmpty(wysokoscDietyZaDobe_TB.Text))
                {
                    Label_wysokoscDiet.Text = (int.Parse(wysokoscDietyZaDobe_TB.Text) * czasPodrozy.TotalDays).ToString() + "zł";
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
            if (wyjazd_rok.Text.Equals("2016") && wyjazd_miesiac.Text.Equals("2")&&(Convert.ToInt32(wyjazd_dzien.Text)>29))
            {
                wyjazd_dzien.BackColor = System.Drawing.Color.Red;
            }
            else if (dniMiesiaca[wyjazd_miesiac.Text]<(Convert.ToInt32(wyjazd_dzien.Text)))
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
    }
}
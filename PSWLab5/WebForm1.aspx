<%@ Page Title="" Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PSWLab5.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }

        .right {
            text-align: right;
        }

        .auto-style4 {
            text-align: right;
            width: 426px;
            height: 40px;
            border-bottom: solid thin #808080;
        }

        .auto-style6 {
            height: 481px;
        }

        .auto-style7 {
            height: 346px;
        }

        .auto-style8 {
            margin-left: 235px;
        }

        .auto-style9 {
            height: -42px;
        }

        .auto-style10 {
            margin-left: 252px;
        }

        .auto-style11 {
            width: 446px;
        }

        .auto-style14 {
            width: 658px;
        }

        .auto-style15 {
            margin-left: 351px;
        }

        .auto-style16 {
            margin-left: 362px;
        }

        .auto-style17 {
            margin-left: 199px;
        }

        .auto-style18 {
            margin-left: 217px;
        }

        .auto-style19 {
            width: 663px;
        }

        .auto-style20 {
            width: 662px;
        }

        .auto-style21 {
            width: 675px;
        }

        .auto-style22 {
            height: 58px;
        }
        .auto-style25 {
            border-bottom: solid thin #808080;
            border-top: solid thin #808080;
            width: 238px;
            height: 33px;
        }
        .auto-style26 {
            margin-left: 49px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" id="insert">
        <b><big>Diety</big></b>
        (
    <asp:LinkButton ID="diety_showHide_link" runat="server" OnClick="diety_showHide_link_Click">zwiń</asp:LinkButton>
        )
    <div runat="server" id="diety" class="auto-style6">
        <br />
        Data i godzina wyjazdu:<asp:DropDownList ID="wyjazd_rok" runat="server" OnSelectedIndexChanged="wyjazd_SelectedIndexChanged1" Style="margin-left: 279px; margin-bottom: 0px" AutoPostBack="True">
            <asp:ListItem Value="2018"></asp:ListItem>
            <asp:ListItem Value="2017">2017</asp:ListItem>
            <asp:ListItem Value="2016"></asp:ListItem>
            <asp:ListItem Value="2015"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="wyjazd_miesiac" runat="server" OnSelectedIndexChanged="wyjazd_SelectedIndexChanged1" AutoPostBack="True">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="11"></asp:ListItem>
            <asp:ListItem Value="12"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="wyjazd_dzien" runat="server" AutoPostBack="True" OnSelectedIndexChanged="wyjazd_SelectedIndexChanged1">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="11"></asp:ListItem>
            <asp:ListItem Value="12"></asp:ListItem>
            <asp:ListItem Value="13"></asp:ListItem>
            <asp:ListItem Value="14"></asp:ListItem>
            <asp:ListItem Value="15"></asp:ListItem>
            <asp:ListItem Value="16"></asp:ListItem>
            <asp:ListItem Value="17"></asp:ListItem>
            <asp:ListItem Value="18"></asp:ListItem>
            <asp:ListItem Value="19"></asp:ListItem>
            <asp:ListItem Value="20"></asp:ListItem>
            <asp:ListItem Value="21"></asp:ListItem>
            <asp:ListItem Value="22"></asp:ListItem>
            <asp:ListItem Value="23"></asp:ListItem>
            <asp:ListItem Value="24"></asp:ListItem>
            <asp:ListItem Value="25"></asp:ListItem>
            <asp:ListItem Value="26"></asp:ListItem>
            <asp:ListItem Value="27"></asp:ListItem>
            <asp:ListItem Value="28"></asp:ListItem>
            <asp:ListItem Value="29"></asp:ListItem>
            <asp:ListItem Value="30"></asp:ListItem>
            <asp:ListItem Value="31"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="wyjazd_godzina" runat="server" Style="margin-left: 435px">
        </asp:DropDownList>
        <asp:DropDownList ID="wyjazd_minuty" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <hr />
        <br />
        Data i godzina powrotu:<asp:DropDownList ID="powrot_rok" runat="server" OnSelectedIndexChanged="powrot_SelectedIndexChanged1" Style="margin-left: 279px; margin-bottom: 0px" AutoPostBack="True">
            <asp:ListItem Value="2018"></asp:ListItem>
            <asp:ListItem Value="2017">2017</asp:ListItem>
            <asp:ListItem Value="2016"></asp:ListItem>
            <asp:ListItem Value="2015"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="powrot_miesiac" runat="server" OnSelectedIndexChanged="powrot_SelectedIndexChanged1" AutoPostBack="True">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="11"></asp:ListItem>
            <asp:ListItem Value="12"></asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="powrot_dzien" runat="server" AutoPostBack="True" OnSelectedIndexChanged="powrot_SelectedIndexChanged1">
            <asp:ListItem Value="1"></asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5"></asp:ListItem>
            <asp:ListItem Value="6"></asp:ListItem>
            <asp:ListItem Value="7"></asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9"></asp:ListItem>
            <asp:ListItem Value="10"></asp:ListItem>
            <asp:ListItem Value="11"></asp:ListItem>
            <asp:ListItem Value="12"></asp:ListItem>
            <asp:ListItem Value="13"></asp:ListItem>
            <asp:ListItem Value="14"></asp:ListItem>
            <asp:ListItem Value="15"></asp:ListItem>
            <asp:ListItem Value="16"></asp:ListItem>
            <asp:ListItem Value="17"></asp:ListItem>
            <asp:ListItem Value="18"></asp:ListItem>
            <asp:ListItem Value="19"></asp:ListItem>
            <asp:ListItem Value="20"></asp:ListItem>
            <asp:ListItem Value="21"></asp:ListItem>
            <asp:ListItem Value="22"></asp:ListItem>
            <asp:ListItem Value="23"></asp:ListItem>
            <asp:ListItem Value="24"></asp:ListItem>
            <asp:ListItem Value="25"></asp:ListItem>
            <asp:ListItem Value="26"></asp:ListItem>
            <asp:ListItem Value="27"></asp:ListItem>
            <asp:ListItem Value="28"></asp:ListItem>
            <asp:ListItem Value="29"></asp:ListItem>
            <asp:ListItem Value="30"></asp:ListItem>
            <asp:ListItem Value="31"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="powrot_godzina" runat="server" Style="margin-left: 435px">
        </asp:DropDownList>
        <asp:DropDownList ID="powrot_minuty" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <hr />
        <br />
        Wysokość diety za dobę podróży:<asp:TextBox ID="wysokoscDietyZaDobe_TB" runat="server" Style="margin-left: 181px" Width="190px"></asp:TextBox>
        &nbsp;zł<br />
        <br />
        <hr />
        <br />
        Koszt zapewnionego bezpłatnego wyżywienia zmiejszający diety:<br />
        <br />
        <table style="width: 72%;">
            <tr>

                <td class="right">liczba śniadań</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TB_liczbaSniadan" runat="server" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>

                <td class="right">liczba obiadów</td>
                <td class="auto-style1">
                    <asp:TextBox ID="TB_liczbaObiadow" runat="server" Width="190px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="right">liczba kolacji</td>
                <td>
                    <asp:TextBox ID="TB_liczbaKolacji" runat="server" Width="190px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <hr class="auto-style9" />
    </div>
        <br />

        <big><b>Zwrot kosztów przejazdów </b></big>(
        <asp:LinkButton ID="linkButton_zwrot_showHide" runat="server" OnClick="linkButton_zwrot_showHide_Click">zwiń</asp:LinkButton>
        )<br />

        <div id="zwrot" runat="server" class="auto-style7">
            <br />
            Rodzaj środku transportu
            <asp:TextBox ID="TB_RodzajSrodkaTransportu" runat="server" CssClass="auto-style8" Width="190px"></asp:TextBox>
            <br />
            <hr />
            Cena biletu za przejazd<asp:TextBox ID="TB_cenaBiletuZaPrzejazd" runat="server" CssClass="auto-style10" Width="190px"></asp:TextBox>
            &nbsp;zł<hr />
            <span style="color: rgb(0, 0, 0); font-family: Verdana, arial, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial; line-height: 18px;">Przejazd niebędącym własnością pracodawcy<br />
                (liczba faktycznie przejechanych kilometrów):</span><ul style="margin: 0px 0px 0px 20px; padding: 0px; width: 446px; border: 0px; color: rgb(0, 0, 0); font-family: Verdana, arial, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;" class="auto-style11">
                    <li style="padding: 5px; margin: 0px; border: none; font-size: 12px; text-align: left;">samochodem osobowym:<ul class="auto-style11" style="border-style: none; border-color: inherit; border-width: 0px; margin: 0px 0px 0px 20px; padding: 0px; color: rgb(0, 0, 0); font-family: Verdana, arial, sans-serif; font-size: 12px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(238, 238, 238); text-decoration-style: initial; text-decoration-color: initial;">
                        <li class="auto-style19" style="border-style: none; border-width: medium; padding: 5px; margin: 0px; text-align: left; background-color: #FFFFFF;">o pojemności silnika do 900cm3<asp:TextBox ID="TB_oPojemnosciSilnikaDo900" runat="server" CssClass="auto-style18" Width="190px"></asp:TextBox>
                            &nbsp;km</li>
                        <li class="auto-style14" style="border-style: none; border-color: inherit; border-width: medium; padding: 5px; margin: 0px; text-align: left; background-color: #FFFFFF;">o pojemności silnika pow. 900 cm3<asp:TextBox ID="TB_oPojemnosciSIlnikaPowyzej900" runat="server" CssClass="auto-style17" Width="190px"></asp:TextBox>
                            &nbsp;km</li>
                    </ul>
                    </li>
                    <li class="auto-style20" style="border-style: none; border-color: inherit; border-width: medium; padding: 5px; margin: 0px; text-align: left;">motocyklem<asp:TextBox ID="TB_motocyklem" runat="server" CssClass="auto-style16" Width="190px"></asp:TextBox>
                        &nbsp;km</li>
                    <li class="auto-style21" style="border-style: none; border-color: inherit; border-width: medium; padding: 5px; margin: 0px; text-align: left;">motorowerem<asp:TextBox ID="TB_motorowerem" runat="server" CssClass="auto-style15" Width="190px"></asp:TextBox>
                        &nbsp;km</li>
                </ul>
            <hr />
        </div>
        <br />
        <asp:Button ID="Button_oblicz" runat="server" BackColor="White" BorderColor="#009933" BorderStyle="Ridge" BorderWidth="5px" CssClass="auto-style17" Font-Bold="True" Font-Italic="True" Font-Names="Bradley Hand ITC" Font-Size="Large" ForeColor="#003300" Text="Oblicz" OnClick="Button_oblicz_Click" />
        <br />
        <br />
    </div>
    <div runat="server" id="raport">
        <table class="auto-style1" border="0" style="border: thin solid #808080; border-radius: 10px">
            <tr>
                <td colspan="2" style="background-color: #808080; border-top-left-radius: 10px; border-top-right-radius: 10px; font-family: 'Lucida Handwriting';" class="auto-style22">
                    <center><b>WYNIKI</b></center>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style25">
                    <h3>Diety</h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Data i godzina wyjazdu:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_dataiGodzinaWyjazdu" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Data i godzina powrotu:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_dataiGodzinaPowrotu" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Czas podróży:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_czasPodrozy" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Wysokość diet:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_wysokoscDiet" runat="server" Text=" "></asp:Label> zł
                </td>
            </tr>
            <tr id="transport" runat="server" class="auto-style25">
                <td class="auto-style25" colspan="2">
                    <h3>Zwrot kosztów przejazdu</h3>
                </td>
            </tr>
            <tr id="transport2" runat="server">
                <td class="auto-style4" style="font-size: 13px">Przejazd samochodem osobowym o pojemności do 900cm3:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_pojDo900" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr id="transport3" runat="server">
                <td class="auto-style4" style="font-size: 13px">Przejazd samochodem osobowym o pojemności do 900cm3:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_pojPow900" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr id="transport4" runat="server">
                <td class="auto-style4">Przejazd motocyklem:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_motocykl" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr id="transport5" runat="server">
                <td class="auto-style4">Przejazd motorowerem:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_motorower" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr id="transport6" runat="server">
                <td class="auto-style4" id="innySrodekTransportu" runat="server">
                    <asp:Label ID="Label_innySrodekTransportu" runat="server" Text=" "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:Label ID="Label_innyPojazd_cenaBiletu" runat="server" Text=" "></asp:Label>zł
                </td>             
            </tr>
            <tr id="transport7" runat="server">
                <td class="auto-style4" style="font-size: 18px">Koszty przejazdów rozliczane kilometrówką:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_kosztyPrzejazdow" runat="server" Text=" "></asp:Label>zł
                </td>
            </tr>
            <tr id="jedzenie" runat="server" class="auto-style25">
                <td class="auto-style25" colspan="2">
                    <h3>Pomniejszenie diety - zapewnione wyżywienie</h3>
                </td>
            </tr>
            <tr id="jedzenie2" runat="server">
                <td class="auto-style4">Ilość śniadań:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_iloscSniadan" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr id="jedzenie3" runat="server">
                <td class="auto-style4">Ilość obiadów:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_iloscObiadow" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr id="jedzenie4" runat="server">
                <td class="auto-style4">Ilość kolacji:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_iloscKolacji" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr id="jedzenie5" runat="server">
                <td class="auto-style4">Łączna kwota zmniejszająca diety z tytułu zapewnionego bezpłatnego wyżywienia:</td>
                <td class="auto-style4">
                    <asp:Label ID="Label_kwotaZaZapewnioneWyzywienie" runat="server" Text=" "></asp:Label>zł
                </td>
            </tr>
            <tr>
                <td class="auto-style25" colspan="2">
                    <h3>Wynik</h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4"><b>Do wypłaty:</b></td>
                <td class="auto-style4">
                    <asp:Label ID="Label_doWyplaty" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
        </table>
    <br />
            <asp:Button ID="saveDataToTxt" runat="server" CssClass="auto-style26" OnClick="Button1_Click" Text="Zapisz dane" />
    </div>










</asp:Content>

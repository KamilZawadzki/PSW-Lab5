<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="PSWLab5.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        td {
            border-bottom: solid thin #808080;
        }

        .right {
            text-align: right;
        }

        .auto-style1 {
            width: 60%;
            height: 455px;
        }

        .auto-style4 {
            text-align: right;
            width: 426px;
            height: 40px;
        }

        .auto-style5 {
            height: 38px;
        }

        .auto-style6 {
            height: 52px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1" border="0" style="border: thin solid #808080; border-radius: 10px">
            <tr>
                <td colspan="2" style="background-color: #808080; border-top-left-radius: 10px; border-top-right-radius: 10px; font-family: 'Lucida Handwriting';" class="auto-style6">
                    <center><b>WYNIKI</b></center>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="border-bottom: solid thin #808080; border-top: solid thin #808080;" class="auto-style5">
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
                    <asp:Label ID="Label_wysokoscDiet" runat="server" Text=" "></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2">
                    <h3>Zwrot kosztów przejazdu</h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" style="font-size: 13px">Przejazd samochodem osobowym o pojemności do 900cm3:</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" style="font-size: 13px">Przejazd samochodem osobowym o pojemności do 900cm3:</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Przejazd motocyklem:</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Przejazd motorowerem:</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr >
                <td class="auto-style4" id="innySrodekTransportu" runat="server">
                    <asp:Label ID="Label_innySrodekTransportu" runat="server" Text=" "></asp:Label>
                </td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" style="font-size: 18px">Koszty przejazdów rozliczane kilometrówką:</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2"><h3>Wynik</h3></td>
            </tr>
            <tr>
                <td class="auto-style4"><b>Suma kosztów:</b></td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4"><b>Do wypłaty:</b></td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>

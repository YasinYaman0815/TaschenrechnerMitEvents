using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaschenrechnerMitEvents
{
    public partial class Form1 : Form
    {
        string letzteeingabe; //speichert den zuletzt gedrückten Operator
        public Form1()
        {
            InitializeComponent();
        }
        private void Anzeige(object sender, EventArgs e) //kümmert sich um die Anzeige
        {
            int erg;
            if (letzteeingabe == "=") //löscht Text nach Berechnung
            { 
                txtb_ergebnis.Text = "";
                letzteeingabe = "";
            }
            if(Int32.TryParse((sender as Button).Text, out erg)) //wenn es eine Zahl ist..
            {
                txtb_ergebnis.Text += (sender as Button).Text; //soll die Zahl angehängt werden
            }

            else if (!txtb_ergebnis.Text.Contains(",") && (sender as Button).Text == ",")//Komma
            {
                if(txtb_ergebnis.Text == "")
                {
                    txtb_ergebnis.Text += "0" +(sender as Button).Text;
                }
                else
                {
                    txtb_ergebnis.Text += (sender as Button).Text;
                }
            }
            else if ((sender as Button).Text == "<=" && txtb_ergebnis.Text != "") //Zurück
            {
                txtb_ergebnis.Text = txtb_ergebnis.Text.Remove(txtb_ergebnis.Text.Length-1); 
            }
            else if ((sender as Button).Text == "Clear") //Clear...
            {
                txtb_ergebnis.Text = "";
                txt_klein.Text = "";
            }
            else if ((sender as Button).Text == "+-" && txtb_ergebnis.Text != "")//Vorzeichen
            {
                if(txtb_ergebnis.Text.Contains("-"))
                {
                    txtb_ergebnis.Text = txtb_ergebnis.Text.Remove(0,1);
                }
                else
                {
                    txtb_ergebnis.Text = "-" + txtb_ergebnis.Text;
                }
            }
        }
        private void Operator(object Sender, EventArgs e) //Triggert bei Operatoren
        {
            double.TryParse(txtb_ergebnis.Text.Replace(',', '.'), out double zahl2);
            double.TryParse(txt_klein.Text.Replace(',', '.'), out double zahl1);

            if ((Sender as Button).Text != "=")  //wenn nicht =
            {
                if (txt_klein.Text == "") //packt Zahl in die kleine Textbox
                {
                    txt_klein.Text = txtb_ergebnis.Text;
                }
                else //berechnet
                {
                    if (letzteeingabe == "*")
                    {
                        txt_klein.Text = (zahl1 * zahl2).ToString().Replace('.', ',');
                    }
                    if (letzteeingabe == "+")
                    {
                        txt_klein.Text = (zahl1 + zahl2).ToString().Replace('.', ',');
                    }
                    if (letzteeingabe == "-")
                    {
                        txt_klein.Text = (zahl1 - zahl2).ToString().Replace('.', ',');
                    }
                    if (letzteeingabe == "/")
                    {                        
                        if (zahl1 == 0 || zahl2 == 0)
                        {                          
                            txt_klein.Text = "0";
                        }
                        else
                        {                           
                            txt_klein.Text = (zahl1 / zahl2).ToString().Replace('.', ',');                         
                        }
                    }
                }
                    txtb_ergebnis.Text = "";
            }

            else //wenn =
            {
                if (letzteeingabe == "*")
                {
                    txtb_ergebnis.Text = (zahl1 * zahl2).ToString().Replace('.', ',');
                }
                if (letzteeingabe == "+")
                {
                    txtb_ergebnis.Text = (zahl1 + zahl2).ToString().Replace('.', ',');
                }
                if (letzteeingabe == "-")
                {
                    txtb_ergebnis.Text = (zahl1 - zahl2).ToString().Replace('.', ',');
                }
                if (letzteeingabe == "/")
                {                 
                    if (zahl1 == 0 || zahl2 == 0)
                    {
                        txtb_ergebnis.Text = "0";
                    }
                    else
                    {                      
                        txtb_ergebnis.Text = (zahl1 / zahl2).ToString().Replace('.', ',');
                    }
                }
            txt_klein.Text = "";
            }
            letzteeingabe = (Sender as Button).Text;
        }


    }
}

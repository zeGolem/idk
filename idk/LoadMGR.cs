using Microsoft.Xna.Framework.Graphics;
using static Microsoft.Xna.Framework.Color;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static idk.Data;

namespace idk
{
    public partial class LoadMGR : Form
    {
        string data = "";
        int id = 0;
        string[] arrData;
        string[][] arrDataS;

        public LoadMGR()
        {
            InitializeComponent();
        }

        private void LoadBTN_Click(object sender, EventArgs e)
        {
            //decodes the data
            arrData = data.Split('/');
            arrDataS = new string[arrData.Length][];
            foreach (string s in arrData)
            {

                arrDataS[id] = s.Split(';');
                id++;

            }

            for (int i = 0; i < id - 1; i++)
            {
                //load the data in the listbox
                dataDisplay.Items.Add(i + ": " + "X=" + arrDataS[i][0] + "; Y=" + arrDataS[i][1] + "; Color : R= " + arrDataS[i][2] + " G= " + arrDataS[i][3] + " B= " + arrDataS[i][4]);
            }
        }

        private void Import_BTN_Click(object sender, EventArgs e)
        {

            foreach (string[] s in arrDataS)
            {

                if (s[0] != "")
                {
                    //imports the data in the game
                    rects[rectID] = new Rect(int.Parse(s[0]), int.Parse(s[1]), new Microsoft.Xna.Framework.Color(byte.Parse(s[2]), byte.Parse(s[3]), byte.Parse(s[4]), (byte)255), scale);
                    rectID++;

                }
            }

            this.Close();
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            //opens the file choosen in the ofd
            OFD.ShowDialog();
            string fpath = OFD.FileName;
            data = System.IO.File.ReadAllText(fpath);
            file_pathTXT.Text = fpath;
        }

        private void LoadMGR_Load(object sender, EventArgs e)
        {

        }
    }
}

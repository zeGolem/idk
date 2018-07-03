using Microsoft.Xna.Framework.Graphics;
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

            arrData = data.Split('/');
            arrDataS = new string[arrData.Length][];
            foreach (string s in arrData)
            {

                arrDataS[id] = s.Split(';');
                id++;

            }
            
            for (int i = 0; i < id - 1; i++)
            {
                dataDisplay.Items.Add(i + ": " + "X=" + arrDataS[i][0] + "; Y=" + arrDataS[i][1] + "; Color : R= " + arrDataS[i][2] + " G= " + arrDataS[i][3] + " B= " + arrDataS[i][4]);
            }
        }

        private void Import_BTN_Click(object sender, EventArgs e)
        {

            foreach (string[] s in arrDataS)
            {

                if (s[0] != "")
                {
                    //Console.WriteLine("X:" + s[0]);
                    //Console.WriteLine("Y:" + s[1]);
                    rectsPos[rectID].X = int.Parse(s[0]);
                    rectsPos[rectID].Y = int.Parse(s[1]);
                    rectColor[rectID].R = byte.Parse(s[2]);
                    rectColor[rectID].G = byte.Parse(s[3]);
                    rectColor[rectID].B = byte.Parse(s[4]);
                    rectColor[rectID].A = 255;
                    rectID++;

                }
            }

            this.Close();
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            OFD.ShowDialog();
            string fpath = OFD.FileName;
            data = System.IO.File.ReadAllText(fpath);
            file_pathTXT.Text = fpath;
        }
    }
}

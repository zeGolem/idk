using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using static idk.Data;

namespace idk
{
    public partial class SaveMGR : Form
    {
        Vector2[] rectPos = new Vector2[4096];
        int count;
        string fpath = "";
        Microsoft.Xna.Framework.Color[] rectColor;
        public SaveMGR(Vector2[] pos, int cnt, Microsoft.Xna.Framework.Color[] c)
        {
            InitializeComponent();
            rectPos = pos;
            count = cnt;
            rectColor = c;
        }

        private void SaveMGR_Load(object sender, EventArgs e)
        {
            //loading the data in the listbox
            dataDisplay.Items.Remove(1);
            for (int id = 0; id < count; id++)
                dataDisplay.Items.Add(id + ": " + "X=" + rects[id].X + "; Y=" + rects[id].Y + "; Color : R= " + rects[id].c.R + " G= " + rects[id].c.G+" B= " + rects[id].c.B);

        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            //encodes the data
            string saveData = "";
            for (int i = 0; i < count; i++)
            {

                saveData += rects[i].X + ";" + rects[i].Y + ";" + rects[i].c.R + ";" + rects[i].c.G + ";" + rects[i].c.B + "/";

            }
            System.IO.File.WriteAllText(@fpath, saveData);
            this.Close();

        }

        private void file_pathTXT_TextChanged(object sender, EventArgs e)
        {
            fpath = file_pathTXT.Text;


        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            sfiledlg.ShowDialog();
        }

        private void sfiledlg_ok(object sender, CancelEventArgs e)
        {
            fpath = sfiledlg.FileName;
            file_pathTXT.Text = fpath;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinCloclkConnect4Skel_netFramework
{
    public partial class FrmBinClock : Form
    {
        public FrmBinClock()
        {
            InitializeComponent();
        }

        private void FrmBinClock_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int binh1, binh2, binm1, binm2, bins1, bins2;
            int h1 = DateTime.Now.Hour / 10;
            int h2 = DateTime.Now.Hour % 10;
            int m1 = DateTime.Now.Minute / 10;
            int m2 = DateTime.Now.Minute % 10;
            int s1 = DateTime.Now.Second / 10;
            int s2 = DateTime.Now.Second % 10;
            lblhour1.Text = Convert.ToString(h1);
            lblhour2.Text = Convert.ToString(h2);
            lblmin1.Text = Convert.ToString(m1);
            lblmin2.Text = Convert.ToString(m2);
            lblsec1.Text = Convert.ToString(s1);
            lblsec2.Text = Convert.ToString(s2);

            binh1 = Convert.ToInt32(denToBin(h1));
            binh2 = Convert.ToInt32(denToBin(h2));
            binm1 = Convert.ToInt32(denToBin(m1));
            binm2 = Convert.ToInt32(denToBin(m2));
            bins1 = Convert.ToInt32(denToBin(s1));
            bins2 = Convert.ToInt32(denToBin(s2));

            lblBinh1.Text = Convert.ToString(binh1);
            lblBinh2.Text = Convert.ToString(binh2);
            lblBinm1.Text = Convert.ToString(binm1);
            lblBinm2.Text = Convert.ToString(binm2);
            lblBins1.Text = Convert.ToString(bins1);
            lblBins2.Text = Convert.ToString(bins2);

            

            BlockDisplay("lblsec1b", denToBin(bins1));
            BlockDisplay("lblsec2b", denToBin(bins2));
            BlockDisplay("lblmin1b", denToBin(binm1));
            BlockDisplay("lblmin2b", denToBin(bins2));
            BlockDisplay("lblhr1b", denToBin(binh1));
            BlockDisplay("lblhr2b", denToBin(bins2));

            Console.WriteLine("Hello world");
            //lblBinh1.Text = binStr;
            //lblBinh2.Text = binStr;
            //lblBinm1.Text = binStr;
            //lblBinm2.Text = binStr;
            //lblBins1.Text = binStr;
            //lblBins2.Text = binStr;

        }
        static string denToBin(int denNo)
        {
            string binStr = "";
            do
            {
                binStr = (denNo % 2).ToString() + binStr;
                denNo = denNo / 2;
            } while (denNo != 0);
            // make it 4 bits
            if (binStr.Length == 1)
            {
                binStr = "000" + binStr;
            }
            else if (binStr.Length == 2)
            {
                binStr = "00" + binStr;
            }
            else if (binStr.Length == 3)
            {
                binStr = "0" + binStr;
            }
            return binStr;
        }
        
        
        
        
        
        void BlockDisplay(string ctrlName, string binstr)
        {


            binstr = new string(binstr.ToCharArray().Reverse().ToArray());
            for (int i = 0; i <= 3; i++)
            {
                
                if (binstr[i] == '1')
                {
                    this.Controls[ctrlName + i].BackColor = Color.Red;
                }
                else
                {
                    this.Controls[ctrlName + i].BackColor = Color.PowderBlue;
                }
            }



        }
    }
}


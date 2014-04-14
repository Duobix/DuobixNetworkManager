using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace DuobixNetworkManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Duobix Network Manager";
            shelldoings("netsh", "wlan show interface", null, 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shelldoings("netsh", "wlan show profiles", null, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shelldoings("netsh", "wlan delete profile name=", null, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            shelldoings("netsh", "wlan show network", null, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            shelldoings("netsh", "wlan connect name=", null, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openNetworkConnectionsWindow();
        }
        
        private void openNetworkConnectionsWindow(){
            ProcessStartInfo startInfo = new ProcessStartInfo("NCPA.cpl");
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }
        private void shelldoings(string command, string arguments, string networkname, int output)
        {
            Process networkshow = new Process();
            networkshow.StartInfo.FileName = command;
            networkshow.StartInfo.UseShellExecute = false;
            networkshow.StartInfo.CreateNoWindow = true;
            string IDONTWANTTHIS = arguments;
            if (textBox2.Text != null)
            {
                IDONTWANTTHIS += "\"";
                IDONTWANTTHIS += textBox2.Text;
                IDONTWANTTHIS += "\"";
            }
            networkshow.StartInfo.Arguments = IDONTWANTTHIS;
            networkshow.StartInfo.RedirectStandardOutput = true;
            networkshow.Start();
            textBox2.Text = null;
            textboxset(output, networkshow.StandardOutput.ReadToEnd());
            //textBox1.Text = networkshow.StandardOutput.ReadToEnd();

        }
        private void textboxset(int box, string textStuff)
        {
            if (box == 1)
            {
                textBox1.Text = textStuff;
                //textBox1.ScrollBars = ScrollBars.Vertical;

            }else if(box == 2){
                textBox2.Text = textStuff;

            }else if(box == 3){
                CurrentNetworkTextBox.Text = textStuff;
            }


        }

        private void refreshCurrentNetworkButton_Click(object sender, EventArgs e)
        {
            shelldoings("netsh", "wlan show interface", null, 3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shelldoings("ping", "", null, 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            shelldoings("ipconfig", @"/flushdns", null, 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        

    }
}

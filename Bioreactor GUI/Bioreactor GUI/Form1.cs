using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bioreactor_GUI
{
  public partial class BioreactorGUI : Form
  {
    public delegate void d1(string inputData);
    private static int bioreactorTemprature;
    private static int motorRPM;
    public BioreactorGUI()
    {
      InitializeComponent();
      serialPort1.Open();
    }




        private void onButton_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("B");
        }

        private void offButton_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("C");
        }

        private void kpUpdate_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("G" + kpTextbox.Text.ToString());
        }
        private void kiUpdate_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("H" + kiTextbox.Text.ToString());
        }
        private void kdUpdate_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("I" + kdTextbox.Text.ToString());
        }

        private void updateTemprature_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("A" + tempTextbox.Text.ToString());
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string inputData = serialPort1.ReadLine();
            d1 readTemp = new d1(decodeAndDisplayData);
        }
        private void decodeAndDisplayData(string inputData)
        {
            float bioreactorTemprature;
            float motorRPM;
            string[] tempAndRPMStrings = Regex.Split(inputData, ",");
            bioreactorTemprature = float.Parse(tempAndRPMStrings[0]);
            motorRPM = float.Parse(tempAndRPMStrings[1]);
            rpmLabel.Text = tempAndRPMStrings[1];
            tempLabel.Text = tempAndRPMStrings[0];
            // TODO: Add Graphing.
        }

        private void rpmUpdate_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("F" + rpmTextbox.Text.ToString());
        }

        private void RpmUpdateKp_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("J" + rpmKpTextbox.Text.ToString());
        }

        private void rpmUpdateKi_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("K" + rpmKiTextbox.Text.ToString());
        }

        private void rpmKdUpdate_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("L" + rpmKdTextbox.Text.ToString());
        }
    }
  }
}

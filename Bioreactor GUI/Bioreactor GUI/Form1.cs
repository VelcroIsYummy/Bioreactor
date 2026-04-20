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
      serialPort1.WriteLine("2");
    }

    private void offButton_Click(object sender, EventArgs e)
    {
      serialPort1.WriteLine("3");
    }

    private void kpUpdate_Click(object sender, EventArgs e)
    {
      serialPort1.WriteLine("7" + kpTextbox.Text.ToString());
    }
    private void kiUpdate_Click(object sender, EventArgs e)
    {
      serialPort1.WriteLine("8" + kiTextbox.Text.ToString());
    }
    private void kdUpdate_Click(object sender, EventArgs e)
    {
      serialPort1.WriteLine("9" + kdTextbox.Text.ToString());
    }

    private void updateTemprature_Click(object sender, EventArgs e)
    {
      serialPort1.WriteLine("1" + tempTextbox.Text.ToString());
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
      string[] extractedData = Regex.Split(inputData, ",");
      bioreactorTemprature = float.Parse(extractedData[0]);
      motorRPM = float.Parse(extractedData[1]);
      rpmLabel.Text = extractedData[1];
      tempLabel.Text = extractedData[0];

    }

    private void rpmUpdate_Click(object sender, EventArgs e)
    {
      serialPort1.WriteLine("4" + rpmTextbox.Text.ToString());
      // TODO: Fix edge case where rpm is set below 100, and thus the code thinks it's 499 not 4099 like it should be
    }
  }
}

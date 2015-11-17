using System;
using System.Globalization;
using System.Windows.Forms;

namespace CocosJuceTestClientCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStartTestTone_Click(object sender, EventArgs e)
        {
            try
            {
                double frequency = double.Parse(textBoxFrequency.Text, CultureInfo.InvariantCulture.NumberFormat);
                float amplitude = float.Parse(textBoxAmplitude.Text, CultureInfo.InvariantCulture.NumberFormat);

                bool result = CocosJuce.Api.StartTestTone(frequency, amplitude);

                labelResult.Text = String.Format("Result = {0}   ({1:T})", result, DateTime.Now);

            }
            catch (Exception ex)
            {
                labelResult.Text = String.Format("Exception = {0}   ({1:T})", ex.Message, DateTime.Now);
            }
        }

         
        private void buttonStopTestTone_Click(object sender, EventArgs e)
        {
            try
            { 
                bool result = CocosJuce.Api.StopTestTone();

                labelResult.Text = String.Format("Result = {0}   ({1:T})", result, DateTime.Now);

            }
            catch (Exception ex)
            {
                labelResult.Text = String.Format("Exception = {0}   ({1:T})", ex.Message, DateTime.Now);
            }
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Closing += (o, args) =>
            {
                try
                {
                    CocosJuce.Api.Release();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Exception = {0})", ex.Message));
                }
                
            };
        }

        private void buttonSuspend_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = CocosJuce.Api.Suspend();

                labelResult.Text = String.Format("Result = {0}   ({1:T})", result, DateTime.Now);

            }
            catch (Exception ex)
            {
                labelResult.Text = String.Format("Exception = {0}   ({1:T})", ex.Message, DateTime.Now);
            }
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = CocosJuce.Api.Resume();

                labelResult.Text = String.Format("Result = {0}   ({1:T})", result, DateTime.Now);

            }
            catch (Exception ex)
            {
                labelResult.Text = String.Format("Exception = {0}   ({1:T})", ex.Message, DateTime.Now);
            }

        }


    }
}

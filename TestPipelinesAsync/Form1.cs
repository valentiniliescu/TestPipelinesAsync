using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Refactoring.Pipelines.Async;

namespace TestPipelinesAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int input = int.Parse(inputTextBox.Text);

            Thread.Sleep(5000);
            int output = input + 1;


            outputTextBox.Text = output.ToString();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int input = int.Parse(inputTextBox.Text);

            await Task.Delay(5000);
            int output = input + 1;


            outputTextBox.Text = output.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int input = int.Parse(inputTextBox.Text);

            var inputPipe = new InputPipe<int>("input");
            var parsePipe = inputPipe.ProcessFunction(IncrementWithDelay);
            var collector = parsePipe.Collect();

            inputPipe.Send(input);
            var output = collector.SingleResult;


            outputTextBox.Text = output.ToString();
        }

        private static int IncrementWithDelay(int input)
        {
            Thread.Sleep(5000);
            return input + 1;
        }
    }
}

namespace Challenge6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static int Loop_De_Loop(uint inputNumber)
        {
            int iterations = 0;
            while (inputNumber>1)
            {
                inputNumber = (inputNumber%2==0) ? inputNumber/2 : inputNumber * 3 + 1;
                iterations++;
            }
            return iterations;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            uint num1, num2;
            try 
            {
                num1 = Convert.ToUInt32(textBox1.Text);
                num2 = Convert.ToUInt32(textBox2.Text);
                var task1 = Task<int>.Run(() => Loop_De_Loop(num1));
                var task2 = Task<int>.Run(() => Loop_De_Loop(num2));
                label5.Text = "Number: " + Convert.ToString(num1);
                label6.Text = "Number: " + Convert.ToString(num2);
                int loops = task1.Result;
                int loops2 = task2.Result;
                label3.Text = "Iterations: " + Convert.ToString(loops);
                label4.Text = "Iterations: " + Convert.ToString(loops2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            
        }
    }
}
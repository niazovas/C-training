using System;
using System.Windows.Forms;

namespace ThirdProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            server = new Server();
        }
        Server server;


        private void btnrecieve_Click(object sender, EventArgs e)
        {
            int quantityegg = int.Parse(txtegg.Text);
            int quantitychicken = int.Parse(txtchicken.Text);
            string drinks = comboBox1.Text;
            try
            {
                if (quantitychicken == 0 && quantityegg == 0 && drinks == "NoDrink")
                    throw new Exception("First order please");

                if (quantitychicken >= 0 && quantityegg >= 0)
                    server.Request(quantityegg, quantitychicken, drinks);

                else
                    throw new Exception("Menu is not ordered");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                server.Send();
                listBox1.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var orders = server.Serve();
                for (int i = 0; i < orders.Length; i++)
                {
                    listBox1.Items.Add(orders[i]);
                }
                listBox1.Items.Add("Please enjoy your food!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourthProject
{
    public partial class Form1 : Form
    {
        Server server;
        Cook cook1;
        Cook cook2;


        public Form1()
        {
            InitializeComponent();
            server = new Server();
            cook1 = new Cook() { Name = "Cook1" };
            cook2 = new Cook() { Name = "Cook2" };
        }

        private void btnrecieve_Click(object sender, EventArgs e)
        {
            int quantityegg = int.Parse(txtegg.Text);
            int quantitychicken = int.Parse(txtchicken.Text);
            string name = textBox1.Text;
            string drinks = comboBox1.Text;
            try
            {
                if (quantitychicken == 0 && quantityegg == 0 && drinks == "NoDrink")
                    throw new Exception("First order please");

                if (quantitychicken >= 0 && quantityegg >= 0)
                    server.Request(name, quantityegg, quantitychicken, drinks);

                else
                    throw new Exception("Menu is not ordered");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

            textBox1.Clear();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            Cook cook = null;

            if (!cook1.busy)
                cook = cook1;

            else
                cook = cook2;

            TableRequest table = server.GetTable();
            Task.Run(() => cook.Process(table)).ContinueWith(task =>
            {
                Invoke(new Action(() =>
                {
                    listBox1.Items.AddRange(server.Serve(table).ToArray());
                    listBox1.Items.Add(cook.Name);
                }));
            });

        }





        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

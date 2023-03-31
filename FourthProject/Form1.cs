using System;
using System.Windows.Forms;

namespace FourthProject
{
    //TODO: Кабул кардани факат Drinks-хоро амали кунед
    //TODO: Кабул кардани якчанд намуди Drinks-хоро аз тарафи як Customer амали кунед
    //TODO: Аввал Drinks-хои Customer ба Result бароварда шавад (слайд сах.19)
    public partial class Form1 : Form
    {
        Server server;
        Cook cook;
        public Form1()
        {
            InitializeComponent();
            server = new Server();
            cook = new Cook();
            server.ReadyEvent += ServerReadyEvent;
            cook.Processed += (() => { listBox1.Items.AddRange(server.Serve().ToArray()); });
        }

        private void ServerReadyEvent(TableRequest tableRequest)
        { cook.Process(tableRequest); }

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

            
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                server.Send();
                label3.Text = cook.GetQuality().ToString();
                textBox1.Clear();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

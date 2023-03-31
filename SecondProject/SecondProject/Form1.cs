using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecondProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            server = new Server();

        }
        Server server;

        bool order = false;


        private void btnrecieve_Click(object sender, EventArgs e)
        {
            int quatityegg = int.Parse(txtegg.Text);
            int quantitychicken = int.Parse(txtchicken.Text);
            string drinks = comboBox1.Text;
            try
            {
                if (quantitychicken >= 0 && quatityegg >= 0)
                {
                    server.Request(quatityegg, quantitychicken, drinks);
                    //MessageBox.Show("Menu is ordered");

                }
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
                label5.Text=server.Inspect();
                //MessageBox.Show("Order is send");
                //order = true;
                txtchicken.Clear();
                txtegg.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = (server.Serve());

                //if (order == true)
                //{
                    
                //    order = false;
                //}
                //else
                //    throw new Exception("Food is't send");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

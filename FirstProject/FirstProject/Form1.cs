using System;
using System.Windows.Forms;

namespace FirstProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            employee = new Employee();
        }

        Employee employee;
        bool newRequestIsClicked = false;
        object order;
        string inspect;
        private void button1_Click(object sender, EventArgs e)
        {
            string menuItem = "";
            int quantity = Convert.ToInt32(txtquantity.Text);

            try
            {
                if (rbnEgg.Checked && quantity > 0 || rbnChicken.Checked && quantity > 0)
                {
                    if (rbnEgg.Checked)
                        menuItem = "egg";

                    else if (rbnChicken.Checked)
                        menuItem = "chicken";

                    employee = new Employee();
                    order = employee.NewRequest(quantity, menuItem);

                    inspect = employee.Inspect(order);
                    txtquality.Text = inspect;
                    newRequestIsClicked = true;
                }
                else
                    throw new Exception("Please first get the order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                order = employee.CopyOrder();
                txtquality.Text = inspect;
                MessageBox.Show("Order was copied");
                newRequestIsClicked = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
             try
            {
                if (newRequestIsClicked)
                {
                    listBOrder.Items.Add(employee.PrepareFood(order));
                    newRequestIsClicked = false;
                }
                else
                    throw new Exception("First get order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

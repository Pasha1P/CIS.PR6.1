using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ПР6._1
{
    public partial class Form1 : Form
    {
        public LaundryService LaundryService { get; set; }
        public Random random = new Random();
        bool n, a;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            Height = 284;
            CenterToScreen();
        }

        private void buttonINF_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void textBoxName_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void textBoxAdress_TextChanged(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void textBoxThings_TextChanged_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void buttonChallenge_Click_1(object sender, EventArgs e)
        {
            n = true; a = true;
            if (String.IsNullOrEmpty(textBoxAdress.Text))
            {
                errorProvider2.SetError(textBoxAdress, "нельзя оставлять поле пустым");
                a=false;
            }
            else errorProvider2.Clear();
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                errorProvider3.SetError(textBoxName, "нельзя оставлять поле пустым");
                n=false;
            }
            else errorProvider3.Clear();
            if (a&&n)
            {
                a = n = true;
                if (random.Next(1, 4) <= 2)
                {
                    LaundryService = LaundryService.GetInstance(textBoxName.Text, textBoxAdress.Text);
                    buttonChallenge.Visible = false;
                    labelInf.Visible = true;
                    textBoxThings.Visible = true;
                    labelSumm.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    textBoxAdress.Visible = false;
                    textBoxName.Visible = false;
                    labelAdress.Visible = false;
                    labelName.Visible = false;
                    Height = 367;
                    CenterToScreen();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Прачечная закрыта, приходите в другой раз.", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Retry)
                        buttonChallenge_Click_1(sender, e);
                }
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {            
            if (!String.IsNullOrEmpty(textBoxThings.Text))
            {
                errorProvider1.Clear();
                string str = LaundryService.PlaceOrder();
                if (str != "Заказ успешно размещен.")
                {
                    DialogResult result = MessageBox.Show(str, "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Retry)
                        button1_Click(sender, e);
                }
                else
                {
                    LaundryService.ItemsToClean = Convert.ToInt32(textBoxThings.Text);
                    Form3 form3 = new Form3(LaundryService);
                    form3.ShowDialog();
                    buttonChallenge.Visible = true;
                    labelInf.Visible = false;
                    textBoxThings.Visible = false;
                    labelSumm.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    textBoxAdress.Visible = true;
                    textBoxName.Visible = true;
                    labelAdress.Visible = true;
                    labelName.Visible = true;
                    textBoxAdress.Text = "";
                    textBoxName.Text = "";
                    Height = 367;
                    CenterToScreen();
                }
            }
            else errorProvider1.SetError(textBoxThings, "нельзя оставлять поле пустым"); 
        }
    }
}

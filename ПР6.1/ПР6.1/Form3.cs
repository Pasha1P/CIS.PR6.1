using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПР6._1
{
    public partial class Form3 : Form
    {
        public Random random = new Random();
        public Form3(LaundryService l)
        {
            InitializeComponent();
            labelNumber.Text=string.Format("{0:d8}",random.Next(0,99999999));
            labelDate.Text = string.Format("{0:d2}.{1:d2}.{2:d2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            dataGridView1.Rows.Add(2);
            Names.Text = l.CustomerName;
            Adress.Text = l.CustomerAddress;
            dataGridView1[0, 0].Value = "Стирка";
            dataGridView1[0, 1].Value = "Доставка";
            dataGridView1[1, 0].Value = "10";
            dataGridView1[1, 1].Value = "0";
            dataGridView1[2, 0].Value = l.CalculateTotalCost();
            dataGridView1[2, 1].Value = "0";
            dataGridView1[1, 2].Value = "Итог";
            dataGridView1[2, 2].Value = l.CalculateTotalCost();
        }
    }
}

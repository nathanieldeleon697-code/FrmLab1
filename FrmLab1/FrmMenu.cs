using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLab1
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 lab1 = new Form1();
            lab1.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                FrmRegistration reg = new FrmRegistration();
                reg.Show();
            }
        }
    }
}

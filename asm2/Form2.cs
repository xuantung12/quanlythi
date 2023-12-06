using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asm2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            // câu lệnh chuyển từ form 2 sang form 3
            Form3 F3 = new Form3();
            F3.ShowDialog();
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            // câu lệnh chuyển từ form2 sang form 4
           Form4 F4 = new Form4(); 
            F4.ShowDialog();
        }

        private void btnExamsj_Click(object sender, EventArgs e)
        {
            // câu lệnh chuyển từ form 2 sang form 5 
            Form5 f5 = new Form5();
            f5.ShowDialog();
        }
    }
}

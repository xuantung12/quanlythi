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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // câu lệnh kiểm tra mật khẩu 
            if (cbShow.Checked)
            {
                txtPass.PasswordChar = (char)0;
            }
            else
                txtPass.PasswordChar = '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // tạo hộp thông báo 
            string message = "Do you want to escape?";
            string title = "Notification";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Information;
            DialogResult result = MessageBox.Show(message, title, buttons, icon);
            // nếu bạn chọn có thì sẽ thoát khỏi chương trình
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Điều kiện nếu mật khẩu đúng thì... ngược lại thì... 
            if (txtName.Text == "abcd" && txtPass.Text == "1234")
            {
                // hộp thông báo sẽ hiển thị bãn đẵng đăng nhập thành công
                MessageBox.Show("Successful login");
                Form2 F = new Form2();
                F.Show();
                this.Hide();
            }
            else
            {
                // Hộp thông báo hiển thị bạn đăng nhập thất bại 
                MessageBox.Show("You have failed to login ");
            }
        }
    }
}

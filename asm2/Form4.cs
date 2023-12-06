using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace asm2
{
    public partial class Form4 : Form
    {
        // tạo kết nối và chuỗi kết nối 
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-TMLLU22S\MSSQLSERVER01;Initial Catalog=CDSV;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        // dùng để hiển thị dữ liệu 
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Teacher";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
        public Form4()
        {
            InitializeComponent();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // tạo và trả về một đối tượng Sqlcommand dược liên kết với Sqlconnection
            command = connection.CreateCommand();
            command.CommandText = "delete from Teacher where TeacherID='"+txtTeacherID.Text+"'";
            // sử dụng để thực thi Lệnh SQL hoặc thủ tục được lưu trữ thực hiện các hoạt động CHÈN, CẬP NHẬT hoặc Xóa
            command.ExecuteNonQuery();
            loaddata();
            // xóa các đuối tượng trên textbõ sau khi thêm sửa hoặc xóa 
            txtDoB.Clear();
            txtGender.Clear();
            txtTeacherID.Clear();
            txtTeacherNAME.Clear();
            txtTeacherPhone.Clear(); 
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            connection= new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int i;
            i= dataGridView1.CurrentRow.Index;
            txtTeacherID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTeacherNAME.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDoB.Text= dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtGender.Text= dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtTeacherPhone.Text= dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTeacherID.Text == "")
            {
                MessageBox.Show("hãy nhập đầy đủ thông tin", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeacherID.Focus();
                return;
            }
            string checkIfExistsQuery = "SELECT COUNT(*) FROM Teacher WHERE TeacherID =@teacherid ";
            SqlCommand checkIfExistsCmd = new SqlCommand(checkIfExistsQuery, connection);
            checkIfExistsCmd.Parameters.Add("@teacherid", SqlDbType.Int).Value = int.Parse(txtTeacherID.Text);
            int count = (int)checkIfExistsCmd.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show(this, "id đã tồn tại,vui lòng nhập id khác", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTeacherID.Focus();
                return;
            }

            if (kiemtra())
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into Teacher values ('" + txtTeacherID.Text + "',N'" + txtTeacherNAME.Text + "','" + txtDoB.Text + "',N'" + txtGender.Text + "','" + txtTeacherPhone.Text + "')";
                command.ExecuteNonQuery();
                loaddata();
                txtDoB.Clear();
                txtGender.Clear();
                txtTeacherPhone.Clear();
                txtTeacherID.Clear();
                txtTeacherNAME.Clear();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {
                command = connection.CreateCommand();
                command.CommandText = "update Teacher set TeacherNAME= N'" + txtTeacherNAME.Text + "',DoB='" + txtDoB.Text + "',Gender= N'" + txtGender.Text + "',TeacherPhone='" + txtTeacherPhone.Text + "' where TeacherID='" + txtTeacherID.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                txtDoB.Clear();
                txtGender.Clear();
                txtTeacherPhone.Clear();
                txtTeacherID.Clear();
                txtTeacherNAME.Clear();
            }
        }
        bool kiemtra()
        {
            if (txtTeacherID.Text == "")
            {
                MessageBox.Show("hãy nhập đầy đủ thông tin", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeacherID.Focus();
                return false;
            }
            string Phone= txtTeacherPhone.Text;
            long ketqua;
            char[] chars = Phone.ToCharArray();

            if (txtTeacherNAME.Text == "")
            {
                MessageBox.Show("bạn chưa nhập tên giáo viên ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeacherNAME.Focus();
                return false;
            }
            if (txtGender.Text == "")
            {
                MessageBox.Show("bạn chưa nhập giới tính giáo viên ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGender.Focus();
                return false;
            }
            if (txtTeacherPhone.Text == "")
            {
                MessageBox.Show("bạn chưa nhập số điện thoại của giáo viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeacherPhone.Focus();
                return false;
            }
            if (txtDoB.Text == "")
            {
                MessageBox.Show("bạn chưa nhập ngày tháng năm sinh giáo viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDoB.Focus();
                return false;
            }
            if(!(long.TryParse(Phone,out ketqua)))
            {
                MessageBox.Show("hãy nhập đúng định dạng của số điện thoại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeacherPhone.Focus();
                return false;
            }
            if (ketqua<0)
            {
                MessageBox.Show("số điện thoại không được âm ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeacherPhone.Focus();
                return false;
            }
            if (chars.Length !=10)
            {
                MessageBox.Show("số điện thoại phải đúng đủ 10 số ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTeacherPhone.Focus();
                return false;
            }

            return true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

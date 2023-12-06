using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asm2
{
    public partial class Form3 : Form
    {
        //tạo kết nối và chuỗi kết nối 
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-TMLLU22S\MSSQLSERVER01;Initial Catalog=CDSV;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        // hiển thị dữ liệu 
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from Student";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        public Form3()
        {
            InitializeComponent();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //truy vấn chuỗi kết nối 
            connection = new SqlConnection(str);
            //Mở kết nối 
            connection.Open();
            loaddata();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                MessageBox.Show("hãy nhập đầy đủ thông tin", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentID.Focus();
                return;
            }
            string checkIfExistsQuery = "SELECT COUNT(*) FROM Student WHERE StudentID =@studentid";
            SqlCommand checkIfExistsCmd = new SqlCommand(checkIfExistsQuery, connection);
            checkIfExistsCmd.Parameters.Add("@studentid", SqlDbType.Int).Value = int.Parse(txtStudentID.Text);
            int count = (int)checkIfExistsCmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show(this, "id đã tồn tại,vui lòng nhập id khác", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentID.Focus();
                return;
            }
            if (kiemtra())
            {
                // tạo và trả về một đối tượng Sqlcommand dược liên kết với Sqlconnection 
                command = connection.CreateCommand();
                command.CommandText = "insert into Student values ('" + txtStudentID.Text + "',N'" + txtStudentName.Text + "','" + txtDoB.Text + "',N'" + txtGender.Text + "','" + txtStudentPhone.Text + "')";
                // sử dụng để thực thi Lệnh SQL hoặc thủ tục được lưu trữ thực hiện các hoạt động CHÈN, CẬP NHẬT hoặc Xóa
                command.ExecuteNonQuery();
                loaddata();
                // xóa các đối tượng trên textbox sau khi thêm sửa hoặc xóa
                txtDoB.Clear();
                txtGender.Clear();
                txtStudentPhone.Clear();
                txtStudentName.Clear();
                txtStudentID.Clear();
            }
        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            // thêm dữ liệu từ Sql sever vào bảng datagridview 
            i = dataGridView1.CurrentRow.Index;
            txtStudentID.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtStudentName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDoB.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtGender.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtStudentPhone.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //  tạo và trả về một đối tượng Sqlcommand dược liên kết với Sqlconnection
            command = connection.CreateCommand();
            command.CommandText= "delete from Student where StudentID='" + txtStudentID.Text + "'";
            //sử dụng để thực thi Lệnh SQL hoặc thủ tục được lưu trữ thực hiện các hoạt động CHÈN, CẬP NHẬT hoặc Xóa
            command.ExecuteNonQuery();
            loaddata();
            txtDoB.Clear();
            txtGender.Clear();
            txtStudentPhone.Clear();
            txtStudentName.Clear();
            txtStudentID.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {
                command = connection.CreateCommand();
                command.CommandText = "update Student set StudentNAME=N'" + txtStudentName.Text + "',DoB='" + txtDoB.Text + "',Gender=N '" + txtGender.Text + "',StudentPhone='" + txtStudentPhone.Text + "' where StudentID='" + txtStudentID.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                txtDoB.Clear();
                txtGender.Clear();
                txtStudentPhone.Clear();
                txtStudentName.Clear();
                txtStudentID.Clear();
            }
        }
        bool kiemtra()
        {
            if (txtStudentID.Text == "")
            {
                MessageBox.Show("hãy nhập đầy đủ thông tin", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentID.Focus();
                return false;
            }
            string Phone = txtStudentPhone.Text;
            long ketqua;
            char[] chars = Phone.ToCharArray();
          
            if (txtStudentName.Text == "")
            {
                MessageBox.Show("bạn chưa nhập tên sinh viên ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentName.Focus();
                return false;
            }
            if (txtGender.Text == "")
            {
                MessageBox.Show("bạn chưa nhập giới tính sinh viên ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGender.Focus();
                return false;
            }
            if (txtStudentPhone.Text == "")
            {
                MessageBox.Show("bạn chưa nhập số điện thoại của sinh viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentPhone.Focus();
                return false;
            }
            if (txtDoB.Text == "")
            {
                MessageBox.Show("bạn chưa nhập ngày tháng năm sinh của sinh viên", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDoB.Focus();
                return false;
            }
            if (!(long.TryParse(Phone, out ketqua)))
            {
                MessageBox.Show("hãy nhập đúng định dạng của số điện thoại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentPhone.Focus();
                return false;
            }
            if (ketqua < 0)
            {
                MessageBox.Show("số điện thoại không được âm ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentPhone.Focus();
                return false;
            }
            if (chars.Length != 10)
            {
                MessageBox.Show("số điện thoại phải đúng đủ 10 số ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentPhone.Focus();
                return false;
            }
            return true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            // đóng chương trình 
            this.Close();
        }
    }
   
}

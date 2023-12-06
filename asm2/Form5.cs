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
using System.Data.SqlTypes;
using Microsoft.Win32;

namespace asm2
{
    public partial class Form5 : Form
    {
        // tạo kết nối và chuỗi kết nối
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-TMLLU22S\MSSQLSERVER01;Initial Catalog=CDSV;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        // hiển thị dữ liệu
        void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ExamSJ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  tạo và trả về một đối tượng Sqlcommand dược liên kết với Sqlconnection
            command = command.Connection.CreateCommand();
            command.CommandText = " delete from ExamSJ where ExamSJID ='" + txtExamSJID.Text + "'";
            // sử dụng để thực thi Lệnh SQL hoặc thủ tục được lưu trữ thực hiện các hoạt động CHÈN, CẬP NHẬT hoặc Xóa
            command.ExecuteNonQuery();
            loaddata();
            //  xóa các đối tượng trên textbox sau khi thêm sửa hoặc xóa
            txtExamSJDATE.Clear();
            txtExamSJID.Clear();
            txtExamSJNAME.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {
                command = command.Connection.CreateCommand();
                command.CommandText = "update ExamSJ set ExamSJNAME='" + txtExamSJNAME.Text + "',ExamSJDATE='" + txtExamSJDATE.Text + "' where ExamSJID='" + txtExamSJID.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                txtExamSJID.Clear();
                txtExamSJDATE.Clear();
                txtExamSJNAME.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i= dataGridView1.CurrentCell.RowIndex;
            txtExamSJID.Text=dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtExamSJNAME.Text= dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtExamSJDATE.Text= dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtExamSJID.Text == "")
            {
                MessageBox.Show("hay nhap day du thong tin", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExamSJID.Focus();
                return;
            }
            string checkIfExistsQuery = "SELECT COUNT(*) FROM ExamSJ WHERE ExamSJID =@examsjid ";
            SqlCommand checkIfExistsCmd = new SqlCommand(checkIfExistsQuery, connection);
            checkIfExistsCmd.Parameters.Add("@examsjid", SqlDbType.Int).Value = int.Parse(txtExamSJID.Text);

            int count = (int)checkIfExistsCmd.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show(this, "id đã tồn tại,vui lòng nhập id khác", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (kiemtra())
            {
                command = command.Connection.CreateCommand();
                command.CommandText = "insert into ExamSJ values ('" + txtExamSJID.Text + "','" + txtExamSJNAME.Text + "','" + txtExamSJDATE.Text + "')";
                command.ExecuteNonQuery();
                loaddata();
                txtExamSJDATE.Clear();
                txtExamSJNAME.Clear();
                txtExamSJID.Clear();
            }
        }
        bool kiemtra()
        {
            if (txtExamSJID.Text == "")
            {
                MessageBox.Show("hay nhap day du thong tin", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExamSJID.Focus();
                return false;
            }
            string date = txtExamSJID.Text;
            long ketqua;
            char[] chars = date.ToCharArray();

            if (txtExamSJNAME.Text == "")
            {
                MessageBox.Show("hay nhap thong tin ExamSJNAME", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExamSJNAME.Focus();
                return false;
            }
            if (txtExamSJDATE.Text == "")
            {
                MessageBox.Show("hay nhap thong tin ExamSJDATE","thong bao",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExamSJDATE.Focus();
                return false;
            }
            if (!(long.TryParse(date, out ketqua)))
            {
                MessageBox.Show("hãy nhập đúng định dạng của ID ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExamSJID.Focus();
                return false;
            }
                return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

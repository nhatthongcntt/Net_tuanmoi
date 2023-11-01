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

namespace ketnoi_sql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        HangHoa hanghoa;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = modify.Table("Select * from HangHoa");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.Message);
            }
            Reset_table();
        }
        private void comboBox_Ten_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Ten.Text == "LIFEBOY")
                {
                    textBox_NuocSX.Text = "Việt Nam";
                    textBox_GiaTien.Text = "20000";
                }
            if (comboBox_Ten.Text == "HAMBURGER")
                {
                    textBox_NuocSX.Text = "Anh";
                    textBox_GiaTien.Text = "30000";
                }
            if (comboBox_Ten.Text == "PEN XANH")
                {
                    textBox_NuocSX.Text = "Việt Nam";
                    textBox_GiaTien.Text = "5000";
                }
        }


        private void textBox_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void Reset_table()
        {
            comboBox_Ten.SelectedIndex = -1;
            textBox_GiaTien.Text = "";
            textBox_NuocSX.Text = "";
            textBox_SoLuong.Text = "";
        }
        private bool KiemTra_truockhithem(){
            if(comboBox_Ten.SelectedIndex==-1){
                MessageBox.Show("hãy chọn hàng hóa");
                return false;
            }
            if(textBox_SoLuong.Text == ""){
                MessageBox.Show("hãy nhập số lượng");
                return false;
            }
            return true;
        }
        private void getValues()
        {
            string _tenHH= comboBox_Ten.Text;
            string _nuocSX = textBox_NuocSX.Text;
            double _giatien = double.Parse(textBox_GiaTien.Text);
            int  _soluong = int.Parse(textBox_SoLuong.Text);
            hanghoa = new HangHoa(_tenHH,_nuocSX,_giatien,_soluong);
        }
        private void button_Them_Click(object sender, EventArgs e)
        {
            getValues();
            string query = "INSERT INTO HangHoa VALUES (N'" + hanghoa.TenHH + "',N'" + hanghoa.NuocSX + "','" + hanghoa.GiaTien + "','" + hanghoa.SoLuong + "','" + hanghoa.ThanhToan() + "') ";
            try
            {
                if (KiemTra_truockhithem())
                {
                    
                    modify.Command(query);
                    MessageBox.Show("thêm thành công");
                    Form1_Load(sender,e);
                }
            }
            catch(Exception ex){
                MessageBox.Show("Lỗi thêm: "+ex.Message);
            }
        }

        


    }
}

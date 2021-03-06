using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;

namespace TangGiaoDien
{
    public partial class FrThayDoiQuyDinh : Form
    {
        public FrThayDoiQuyDinh()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void FrThayDoiQuyDinh_Load(object sender, EventArgs e)
        { 
            txttiengoitoithieu.Text = ThamSo_BUS.SoTienGoiToiThieu().ToString();
            txttiengoithemtoithieu.Text = ThamSo_BUS.SoTienGoiThemToiThieu().ToString();
            txtthoihanduocrut.Text = ThamSo_BUS.SoNgayDaGoi().ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tiencu = ThamSo_BUS.SoTienGoiToiThieu().ToString();
            string tienmoi = txttiengoitoithieu.Text.ToString();
            if (tiencu != tienmoi)
            {

                long mathamso = ThamSo_BUS.LayMaThamSo("sotiengoitoithieu");
                float giatri = float.Parse(tienmoi);
                ThamSo_BUS.ThayDoiQuyDinh(mathamso, giatri);

            }

            string tienthemcu = ThamSo_BUS.SoTienGoiThemToiThieu().ToString();
            string tienthemmoi = txttiengoithemtoithieu.Text.ToString();
            if (tienthemcu != tienthemmoi)
            {
                long mathamsomoi = ThamSo_BUS.LayMaThamSo("sotiengoithemtoithieu");
                float giatrithem = float.Parse(tienthemmoi);
                ThamSo_BUS.ThayDoiQuyDinh(mathamsomoi, giatrithem);
            }

           
            string thoihancu = ThamSo_BUS.SoNgayDaGoi().ToString();
            string thoihanmoi = txtthoihanduocrut.Text.ToString();
            if (thoihancu != thoihanmoi)
            {
                long mathoihan = ThamSo_BUS.LayMaThamSo("thoihanduocrut");
                float giatrithoihan = float.Parse(thoihanmoi);
                ThamSo_BUS.ThayDoiQuyDinh(mathoihan, giatrithoihan); 
            } 
            MessageBox.Show("Thay Đổi Thành Công");
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Enabled = true; 
            }
            if (checkBox1.Checked == false)
            {
                groupBox1.Enabled = false;
            }
        }
        void thaydoiquidinh()
        {
            int loi = 0;
            string strloi = "";
            long sotiengoi;
            if (long.TryParse(txttiengoitoithieu.Text, out sotiengoi) == false)
            {
                loi++;
                strloi += loi + ". Tiền Gởi Chỉ Được Nhập Số \n";

            }
            if (long.TryParse(txttiengoithemtoithieu.Text, out sotiengoi) == false)
            {
                loi++;
                strloi += loi + ". Tiền gửi thêm tối thiểu chỉ được nhập số \n";
            }
            if (long.TryParse(txtthoihanduocrut.Text, out sotiengoi) == false)
            {
                loi++;
                strloi += loi + ". Thời hạn rút tối thiểu chỉ được nhập số \n";
            }
            if (loi > 0)
            {

                MessageBox.Show(strloi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tiencu = ThamSo_BUS.SoTienGoiToiThieu().ToString();
            string tienmoi = txttiengoitoithieu.Text.ToString();
            if (tiencu != tienmoi)
            {

                long mathamso = ThamSo_BUS.LayMaThamSo("sotiengoitoithieu");
                float giatri = float.Parse(tienmoi);
                ThamSo_BUS.ThayDoiQuyDinh(mathamso, giatri);

            }

            string tienthemcu = ThamSo_BUS.SoTienGoiThemToiThieu().ToString();
            string tienthemmoi = txttiengoithemtoithieu.Text.ToString();
            if (tienthemcu != tienthemmoi)
            {
                long mathamsomoi = ThamSo_BUS.LayMaThamSo("sotiengoithemtoithieu");
                float giatrithem = float.Parse(tienthemmoi);
                ThamSo_BUS.ThayDoiQuyDinh(mathamsomoi, giatrithem);
            }


            string thoihancu = ThamSo_BUS.SoNgayDaGoi().ToString();
            string thoihanmoi = txtthoihanduocrut.Text.ToString();
            if (thoihancu != thoihanmoi)
            {
                long mathoihan = ThamSo_BUS.LayMaThamSo("thoihanduocrut");
                float giatrithoihan = float.Parse(thoihanmoi);
                ThamSo_BUS.ThayDoiQuyDinh(mathoihan, giatrithoihan);

            }


            MessageBox.Show("Thay Đổi Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btthaydoiquydinh_Click(object sender, EventArgs e)
        {
            thaydoiquidinh();

        } 
        private void btthaydoi_Click(object sender, EventArgs e)
        {
            Form ThayDoi = new FrThayDoiLoaiTietKiem();
            ThayDoi.Show();
        } 
        private void btthoat_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == t)
            {
                this.Close();
            }
        }
        private void validateTextInteger(object sender, EventArgs e)
        {

        }

        private void btthaydoiquydinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thaydoiquidinh();
            }
        }

        private void FrThayDoiQuyDinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                thaydoiquidinh();
            }
            else
            {
                if (e.KeyCode == Keys.Escape)
                {
                    DialogResult t;
                    t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == t)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void btthoat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult t;
                t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == t)
                {
                    this.Close();
                }
            }
        } 
    }
}
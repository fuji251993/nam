using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using BUS;
using DTO;

namespace TangGiaoDien
{
    public partial class FrSoTietKiem : Form
    {
        public FrSoTietKiem()
        {
            InitializeComponent();
        }

        private void FrSoTietKiem_Load(object sender, EventArgs e)
        { 
            
            cbtenloaitietkiem.DataSource = LoaiTietKiem_BUS.DSLoaiTietKiem();
            cbtenloaitietkiem.DisplayMember = "tenloaitietkiem";
            cbtenloaitietkiem.ValueMember = "maloaitietkiem";
            txtsotiengoi.Text = ThamSo_BUS.SoTienGoiToiThieu().ToString();
            txtMaSo.Text = SoTietKiem_BUS.MaTiepTheo().ToString();
            loaddulieu();
        }
       
        private void loaddulieu()
        {
            List<SoTietKiem_DTO> tam = SoTietKiem_BUS.ListSo();
            dataGrid.DataSource = tam; 
        }
       
        public void Reset()
        {
            txtdiachi.Text = "";
            txtcmnd.Text = "";
            txtsotiengoi.Text = "";
            txttenkhach.Text = "";
            txtsotiengoi.Text = ThamSo_BUS.SoTienGoiToiThieu().ToString(); 
        } 
        private void btlapsomoi_Click(object sender, EventArgs e)
        {
            Reset();
        } 
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == t)
            {
                this.Close();
            }
        }
        void lapso()
        {
            // Vung validation and verification
            int loi = 0;
            string strloi = "";
            SoTietKiem_DTO LapSo = new SoTietKiem_DTO();
            if (txttenkhach.Text == "")
            {
                loi++;
                strloi += loi + ". Chưa nhập tên khách hàng\n";
            }
            LapSo.tenkhachhang = txttenkhach.Text.Replace("'", "");
            if (txtdiachi.Text == "")
            {
                loi++;
                strloi += loi + ". Chưa nhập Địa Chỉ\n";
            }
            LapSo.diachi = txtdiachi.Text;
            if (txtcmnd.Text == "")
            {
                loi++;
                strloi += loi + ". Chưa nhập CMND\n";
            }
            LapSo.cmnd = txtcmnd.Text;
            LapSo.maloaitietkiem = long.Parse(cbtenloaitietkiem.SelectedValue.ToString());
            LapSo.ngaymo = dtngaymo.Value.Date;
            if (txtsotiengoi.Text == "")
            {
                loi++;
                strloi += loi + ". Chưa nhập Số Tiền Gởi\n";
            }
            long sotiengoi;

            if (long.TryParse(txtsotiengoi.Text, out sotiengoi) == false)
            {
                loi++;
                strloi += loi + ". Tiền Gởi Chỉ Được Nhập Số\n";

            }
            if (loi > 0)
            {
                MessageBox.Show(strloi);
                return;
            }
            // Tinh toan du lieu
            LapSo.sotiengoi = long.Parse(txtsotiengoi.Text.ToString());
            float tiengoi = ThamSo_BUS.SoTienGoiToiThieu();
            if (LapSo.sotiengoi < tiengoi)
            {
                MessageBox.Show("Số Tiền Gởi Không Đúng Quy Định,Tiền Gởi Phải Lớn Hơn " + tiengoi);
                return;
            }
            SoTietKiem_BUS.LapSoTK(LapSo);
            MessageBox.Show("Đã Lập Sổ Mới Thành Công");

            txtMaSo.Text = SoTietKiem_BUS.MaTiepTheo().ToString();
            loaddulieu(); 
        }
        private void btlapso_Click(object sender, EventArgs e)
        {
            lapso();
            loaddulieu();
        } 
        private void btcapnhat_Click(object sender, EventArgs e)
        {
            SoTietKiem_DTO sotietkiem = new SoTietKiem_DTO();
            string ten = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
               sotietkiem.maso  = long.Parse(gridView1.GetRowCellValue(i, "maso").ToString());
               sotietkiem.maloaitietkiem = long.Parse(gridView1.GetRowCellValue(i, "maloaitietkiem").ToString());
               ten = gridView1.GetRowCellValue(i, "tenkhachhang").ToString();
               sotietkiem.tenkhachhang= ten.Replace("'","");
               sotietkiem.cmnd = gridView1.GetRowCellValue(i, "cmnd").ToString();
               sotietkiem.diachi = gridView1.GetRowCellValue(i, "diachi").ToString();
               sotietkiem.ngaymo =  DateTime.Parse(gridView1.GetRowCellValue(i, "ngaymo").ToString());
               sotietkiem.sotiengoi = long.Parse(gridView1.GetRowCellValue(i, "sotiengoi").ToString());
               sotietkiem.tongtien  = long.Parse(gridView1.GetRowCellValue(i, "tongtien").ToString());
               sotietkiem.tinhtrang = bool.Parse(gridView1.GetRowCellValue(i, "tinhtrang").ToString());
               SoTietKiem_BUS.CapNhatSoTietKiem(sotietkiem);
            }
            MessageBox.Show("Cập nhật thành công"); 
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maso").ToString();
                if (a != "")
                {
                    DialogResult t;
                    t = MessageBox.Show("Bạn có chắc chắn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == t)
                    {
                        SoTietKiem_BUS.DeleteLoai(a);
                        loaddulieu();
                    }
                }
                else
                {
                    MessageBox.Show("Không có mã để xóa ?");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có dữ liệu");

            }
        }

        private void repositoryItemCheckEdit2_Click(object sender, EventArgs e)
        {
            try
            {
                string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maso").ToString();
                if (a != "")
                {
                    DialogResult t;
                    t = MessageBox.Show("Bạn có chắc chắn xóa không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == t)
                    {
                        SoTietKiem_BUS.DeleteLoai(a);
                        loaddulieu();
                    }
                }
                else
                {
                    MessageBox.Show("Không có mã để xóa ?");
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không có dữ liệu");
            }
        } 
        private void repositoryItemCheckEdit1_Click(object sender, EventArgs e)
        {
            SoTietKiem_DTO sotietkiem = new SoTietKiem_DTO();
            string ten = "";
            sotietkiem.maso = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maso").ToString());
            sotietkiem.maloaitietkiem = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maloaitietkiem").ToString());
            ten = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "tenkhachhang").ToString();
            sotietkiem.tenkhachhang = ten.Replace("'", "");
            sotietkiem.cmnd = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cmnd").ToString();
            sotietkiem.diachi = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "diachi").ToString();
            sotietkiem.ngaymo = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ngaymo").ToString());
            sotietkiem.sotiengoi = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "sotiengoi").ToString());
            sotietkiem.tongtien = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "tongtien").ToString());
            sotietkiem.tinhtrang = bool.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "tinhtrang").ToString());
            SoTietKiem_BUS.CapNhatSoTietKiem(sotietkiem);
            MessageBox.Show("Cập nhật thành công");
        } 
    }
}
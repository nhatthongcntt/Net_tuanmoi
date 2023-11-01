using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ketnoi_sql
{
    class HangHoa
    {
        private string _tenHH;

        public string TenHH
        {
            get { return _tenHH; }
            set { _tenHH = value; }
        }
        private string _nuocSX;

        public string NuocSX
        {
            get { return _nuocSX; }
            set { _nuocSX = value; }
        }
        private int _soLuong;

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }
        private double _giaTien;

        public double GiaTien
        {
            get { return _giaTien; }
            set { _giaTien = value; }
        }
        public HangHoa()
        {

        }
        public HangHoa(string tenHH, string nuocSX, double giatien,int soluong)
        {
            this._tenHH = TenHH;
            this._nuocSX = nuocSX;
            this._giaTien = giatien;
            this._soLuong = soluong;
        }
        public double ThanhToan()
        {
            return _soLuong * _giaTien;
        }
    }
}
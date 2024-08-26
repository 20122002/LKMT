using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace BUS
{
    public class NhomSanPhamBLL
    {
        private static NhomSanPhamBLL instance;

        public static NhomSanPhamBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new NhomSanPhamBLL();
                return instance;
            }
        }
        public void showNhomSP(DataGridView data)
        {
            var result = from a in DAO.NhomSanPhamDAL.Instance.getNhomSP() select new { id_nhom = a.id_nhom, tennhom = a.tennhom, ngaytao = a.ngaytao, ngaycapnhat = a.ngaycapnhat};
            data.DataSource = result.ToList();
        }
        public bool suaNhomSP(string id, string name, DateTime ngaytao)
        {
            nhomsanpham a = new nhomsanpham();
            a.id_nhom = id;
            a.tennhom = name;
            a.ngaytao = ngaytao;
            a.ngaycapnhat = DateTime.Now;
            return NhomSanPhamDAL.Instance.suaNhomSP(a);
        }
        public bool themNhomSp(string id, string name)
        {
            nhomsanpham a = new nhomsanpham();
            a.id_nhom = id;
            a.tennhom = name;
            a.ngaytao = DateTime.Now;
            a.ngaycapnhat = DateTime.Now;
            return NhomSanPhamDAL.Instance.themNhomSP(a);
        }
        public bool xoaNhomSP(string id)
        {
            return NhomSanPhamDAL.Instance.xoaNhomSP(id);        
        }
        public void showTenNhomToCBO(string id,ComboBox cbo)
        {
            nhomsanpham a = NhomSanPhamDAL.Instance.findNhomSP(id);
            if (a!= null)
            {
                cbo.Text = a.tennhom;
            }
        }
        public void showListNhomSP(ComboBox cbo)
        {
            cbo.DataSource = DAO.NhomSanPhamDAL.Instance.getNhomSP();
            cbo.DisplayMember = "tennhom";
        }      
    }
}

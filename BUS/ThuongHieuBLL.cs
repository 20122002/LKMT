using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
namespace BUS
{
    public class ThuongHieuBLL
    {
        private static ThuongHieuBLL instance;

        public static ThuongHieuBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThuongHieuBLL();
                return instance;
            }
        }
        public void showListThuongHieu(DataGridView data)
        {
            var result = from a in DAO.ThuongHieuDAL.Instance.getListThuongHieu()
                         select new { id_thuonghieu = a.id_thuonghieu, tenthuonghieu = a.tenthuonghieu, id_nhom = a.nhomsanpham.id_nhom, ngaytao = a.ngaytao, ngaycapnhat = a.ngaycapnhat};
            data.DataSource = result.ToList();
        }
        public bool suaThuongHieu(int id, string tenth, ComboBox cboNhomSP, DateTime ngaytao)
        {
            thuonghieu a = new thuonghieu();
            nhomsanpham nsp = cboNhomSP.SelectedItem as nhomsanpham;
            if (nsp != null)
            {
                a.id_thuonghieu = id;
                a.nhomsanpham = nsp;
                a.id_nhom = nsp.id_nhom;
                a.ngaytao = ngaytao;
                a.tenthuonghieu = tenth;
            }
            a.ngaycapnhat = DateTime.Now;
            return ThuongHieuDAL.Instance.suaThuongHieu(a);
        }
        public bool themThuongHieu(string id, string tenth, ComboBox cboNhomSP)
        {
            thuonghieu a = new thuonghieu();
            nhomsanpham nsp = cboNhomSP.SelectedItem as nhomsanpham;
            if (nsp != null)
            {
                a.nhomsanpham = nsp;
                a.id_nhom = nsp.id_nhom;
                a.tenthuonghieu = tenth;
                a.ngaytao = DateTime.Now;
                a.ngaycapnhat = DateTime.Now;
            }
            return ThuongHieuDAL.Instance.themThuongHieu(a);
        }
        public bool xoaThuongHieu(int id)
        {
            return ThuongHieuDAL.Instance.xoaThuongHieu(id);
        }
        public void showListThuongHieu(DataGridView data, ComboBox cboNhomSP)
        {
            List<thuonghieu> list = new List<thuonghieu>();
            nhomsanpham nsp = cboNhomSP.SelectedItem as nhomsanpham;
            if (nsp != null)
            {
                foreach (thuonghieu a in ThuongHieuDAL.Instance.getListThuongHieu().Where(x => x.id_nhom == nsp.id_nhom))
                {
                    list.Add(a);
                }
                data.DataSource = list;
            }
        }


    }
}

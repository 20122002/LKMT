using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class ThanhToanBLL
    {
        private static ThanhToanBLL instance;

        public static ThanhToanBLL Instance
        {
            get
            {
                if (instance == null)
                    instance = new ThanhToanBLL();
                return instance;
            }
        }
        public void showThanhToan(DataGridView data)
        {
            var result = from a in DAO.ThanhToanDAL.Instance.getListThanhToan() select new { id = a.id_thanhtoan, tenthanhtoan = a.tenthanhtoan};
            data.DataSource = result.ToList();
        }
        public bool suaThanhToan(int id, string ten)
        {
            DAO.phuongthucthanhtoan a = new DAO.phuongthucthanhtoan();
            a.id_thanhtoan = id;
            a.tenthanhtoan = ten;          
            return DAO.ThanhToanDAL.Instance.suaThanhToan(a);
        }
        public bool themThanhToan(string ten)
        {
            DAO.phuongthucthanhtoan a = new DAO.phuongthucthanhtoan();
            a.tenthanhtoan = ten;         
            return DAO.ThanhToanDAL.Instance.themThanhToan(a);
        }
        public bool xoaThanhToan(int id)
        {
            return DAO.ThanhToanDAL.Instance.xoaThanhToan(id);
        }

    }
}

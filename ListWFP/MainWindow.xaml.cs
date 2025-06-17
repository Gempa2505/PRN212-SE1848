using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListWFP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> dsDuLieu = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtGiaTriChen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtGiaTri_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(txtGiaTri.Text);
            //thêm x vào danh sách:
            dsDuLieu.Add(x);
            HienThiDanhDanh();
            txtGiaTri.Text = "";
        }
        void HienThiDanhDanh()
        {
            lstDuLieu.Items.Clear();
            for (int i = 0; i < dsDuLieu.Count; i++)
            {
                int x = dsDuLieu[i];
                lstDuLieu.Items.Add(x);
            }
        }
        private void BtnChen_Click(object sender, RoutedEventArgs e)
        {
            //x là giá trị muốn chèn
            int x = int.Parse(txtGiaTriChen.Text);
            //vt mà ta chèn x vào
            int vt = int.Parse(txtViTriChen.Text);
            //chèn x vào vị trí vt
            dsDuLieu.Insert(vt, x);
            //hiện thị lại danh sách
            HienThiDanhDanh();
            txtViTriChen.Text = "";
            txtGiaTriChen.Text = "";
        }
        private void btnSapXepTang_Click(object sender, RoutedEventArgs e)
        {
            //gọi lệnh sắp xếp danh sách:
            dsDuLieu.Sort();
            //hiển thị lại danh sách
            HienThiDanhDanh();
        }
        private void btnSapXepGiam_Click(object sender, RoutedEventArgs e)
        {
            //sắp xếp tăng dần
            dsDuLieu.Sort();
            //đảo ngược danh sách
            dsDuLieu.Reverse();
            //hiển thị lại danh sách
            HienThiDanhDanh();
        }
        private void btnXoa1PhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn phần tử mới xóa được", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }
            //xóa phần tử tại vị trí đang chọn:
            dsDuLieu.RemoveAt(lstDuLieu.SelectedIndex);
            HienThiDanhDanh();
        }
        private void BtnXoaNhieuPhanTu_Click(object sender, RoutedEventArgs e)
        {
            if (lstDuLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn phần tử mới xóa được", "Thông báo lỗi", MessageBoxButton.OK);
                return;
            }
            //vòng lặp lấy các phần tử được chọn trên giao diện
            while (lstDuLieu.SelectedItems.Count > 0)
            {
                //lấy phần tử đầu tiên ra
                int data = (int)lstDuLieu.SelectedItems[0];
                //xóa khỏi danh sách
                dsDuLieu.Remove(data);
                //xóa trên giao diện
                lstDuLieu.Items.Remove(data);
            }
        }
        private void BtnXoaToanBoPhanTu_Click(object sender, RoutedEventArgs e)
        {
            dsDuLieu.Clear(); //xóa toàn bộ dữ liệu
            HienThiDanhDanh();
        }
    }
}
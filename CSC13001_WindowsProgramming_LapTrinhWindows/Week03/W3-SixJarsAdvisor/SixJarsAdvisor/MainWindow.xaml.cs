using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SixJarsAdvisor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void ThuNhapTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

       
            //string ThuNhap = 
            

            //Phan chia thanh 6 lo


           

            
            //TietKiemDaiHanTextBox.Text = TietKiemDaiHan.ToString();

            
            //QuyGiaoDucTextBox.Text = QuyGiaoDuc.ToString();

          
            //HuongThuTextBox.Text = HuongThu.ToString();

            
            //QuyTuDoTaiChinhTextBox.Text = QuyTuDoTaiChinh.ToString();

            
            //QuyTuThienTextBox.Text = QuyTuThien.ToString();

            //ChiTieuCanThietTextBox.Text = ChiTieuCanThiet.ToString();

        
        ThuNhap tn = null;
        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {

            string ThuNhapBangChu = ThuNhapTextBox.Text;
            

            double ThuNhapBangSo = double.Parse(ThuNhapBangChu);
            

            tn = new ThuNhap()
            {

                ThuNhapHangThang = ThuNhapBangSo,
                ChiTieuCanThiet = ThuNhapBangSo * 0.55,
                TietKiemDaiHan = ThuNhapBangSo * 0.1,
                QuyGiaoDuc = ThuNhapBangSo * 0.1,
                HuongThu = ThuNhapBangSo * 0.1,
                QuyTuDoTaiChinh = ThuNhapBangSo * 0.1,
                QuyTuThien = ThuNhapBangSo * 0.05

            };
            
            DataContext = tn;
        }

        private void ThuNhapTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}

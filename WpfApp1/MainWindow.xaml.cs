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

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

    }

    private void BtnLogin(object sender, RoutedEventArgs e)
    {
        if (UserName.Text == "Zeynab" && Password.Password == "12345")
        {

            MessageBox.Show("ورود موفقیت‌آمیز بود!");
            string username = UserName.Text;
            SecondWindow1 sw = new SecondWindow1();
            sw.Show();
            this.Close();
        }
        else
        {
            MessageBox.Show("نام کاربری یا رمز عبور اشتباه است.");
        }

    }
}
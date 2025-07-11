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
using System.Windows.Shapes;
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for TaskForm.xaml
    /// </summary>
    public partial class TaskForm : UserControl
    {
        private string imagePath;
        public event Action<TaskModel> TaskSubmitted;
        public TaskForm()
        {
            InitializeComponent();
        }
        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            // کد انتخاب تصویر و ذخیره مسیر آن (مثلاً OpenFileDialog)
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
            }
        }
        private void DoneBtnClick(object sender, RoutedEventArgs e)
        {
            var task = new TaskModel
            {
                Title = TitleTextBox.Text,
                Date = TaskDatePicker.SelectedDate,
                Description = DescriptionTextBox.Text,
                ImagePath = imagePath
            };

            TaskSubmitted?.Invoke(task); // ارسال اطلاعات

            MessageBox.Show("وظیفه با موفقیت ثبت شد.");
        }

    }
}

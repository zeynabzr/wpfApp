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
    /// Interaction logic for SecondWindow1.xaml
    /// </summary>
    public partial class SecondWindow1 : Window
    {
        public SecondWindow1()
        {
            InitializeComponent();
            SidebarMenu.SelectedIndex = 0;

        }
        private List<TaskModel> tasks = new List<TaskModel>();
        private void OnTaskSubmitted(TaskModel task)
        {
            tasks.Add(task);

            MessageBox.Show("وظیفه با موفقیت ثبت شد.");
        }
        private void SidebarMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SidebarMenu.SelectedItem is ListBoxItem selectedItem)
            {
                string selectedText = selectedItem.Content.ToString();

                switch (selectedText)
                {

                    case "اضافه کردن وظیفه جدید":
                        var taskForm = new TaskForm();
                        taskForm.TaskSubmitted += OnTaskSubmitted;
                        MainContent.Content = taskForm;
                 
                        break;

                    case "وظایف من":
                        if (tasks.Count > 0)
                        {
                            var taskDisplay = new TaskDisplay(tasks); // مطمئن شو کانستراکتورش لیست می‌گیره
                            MainContent.Content = taskDisplay;
                        }
                        else
                        {
                            MainContent.Content = null;
                            MessageBox.Show("هیچ وظیفه‌ای ثبت نشده است.");
                        }
                        break;
                }
            }
        }
        }
}

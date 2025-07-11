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
using System.IO;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for TaskDisplay.xaml
    /// </summary>
    public partial class TaskDisplay : UserControl
    {
        private List<TaskModel> tasks;

        // کانستراکتور جدید که لیست تسک رو میگیره
        public TaskDisplay(List<TaskModel> tasks)
        {
            InitializeComponent();

            this.tasks = tasks;

            foreach (var task in tasks)
            {
                var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };

          

                var textBlock = new TextBlock
                {
                    Text = $"عنوان: {task.Title}\nتاریخ: {task.Date?.ToShortDateString()}\nتوضیح: {task.Description}",
                    TextWrapping = TextWrapping.Wrap,          
                };


                if (!string.IsNullOrEmpty(task.ImagePath) && File.Exists(task.ImagePath))
                {
                    var image = new Image
                    {
                        Width = 50,
                        Height = 50,
                        Margin = new Thickness(0, 0, 10, 0),
                        Source = new BitmapImage(new Uri(task.ImagePath, UriKind.Absolute))
                    };

                    stackPanel.Children.Add(image);
                }
                stackPanel.Children.Add(textBlock);

                var border = new Border
                {
                    BorderBrush = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(0, 0, 0, 10),
                    Padding = new Thickness(10),
                    Child = stackPanel
                };

                TasksPanel.Children.Add(border);
            }
        }

    }
}

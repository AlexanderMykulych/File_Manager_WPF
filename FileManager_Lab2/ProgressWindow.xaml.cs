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

namespace FileManager_Lab2
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        public ProgressWindow(String Title, String Label, int value, bool isIndeterminate)
        {
            InitializeComponent();

            this.Title = Title;
            TextBlock1.Text = Label;
            ProgressBar1.Value = value;
            ProgressBar1.IsIndeterminate = isIndeterminate;
        }

        public void SetValue(int value)
        {
            ProgressBar1.Value = value;
        }
        public void SetText(String Label)
        {
            TextBlock1.Text = Label;
        }

        public void SetTitle(String Title)
        {
            this.Title = Title;
        }
    }
}

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
    /// Interaction logic for InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        private static String edit = "";
        public String Edit { get { return edit; } }
        public InputBox(String Title)
        {
            InitializeComponent();

            CommandBinding ok = new CommandBinding(ApplicationCommands.New, Click_OK, CanClick);
            CommandBindings.Add(ok);
            this.Title = Title;
            
        }

        private void Click_OK(object sender, ExecutedRoutedEventArgs e)
        {
            edit = TextBox1.Text;
            Close();
        }
        private void CanClick(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TextBox1.Text.Length > 0;
        }
    }
}

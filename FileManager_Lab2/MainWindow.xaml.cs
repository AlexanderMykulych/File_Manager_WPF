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
using System.Drawing;



namespace FileManager_Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIElement elemWithPopup;
        Controller controller;


        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller();
           

            controller.AddNewUIElement(new ViewElement(ListView1, backBtn1, forwardBtn1, CheckBox1));
            controller.AddNewUIElement(new ViewElement(ListView2, backBtn2, forwardBtn2, CheckBox2));

        }

        private void Copy_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;

            ListView lv = (ListView)elemWithPopup;

            controller.Request(RequestType.Copy, controller.getElementIndex(lv), lv.SelectedIndex);

        }

        private void Cut_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;

            ListView lv = (ListView)elemWithPopup;

            controller.Request(RequestType.Cut, controller.getElementIndex(lv), lv.SelectedIndex);

        }

        private void Past_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;

            ListView lv = (ListView)elemWithPopup;

            controller.Request(RequestType.Past, controller.getElementIndex(lv));

        }
        private void AddToMerge_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;

            ListView lv = (ListView)elemWithPopup;

            controller.Request(RequestType.AddToMerge, controller.getElementIndex(lv), lv.SelectedIndex);
        }
        private void SaveMerge_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;

            ListView lv = (ListView)elemWithPopup;

            controller.Request(RequestType.SaveMerge, controller.getElementIndex(lv), lv.SelectedIndex);
        }
        private void NewMerge_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;

            ListView lv = (ListView)elemWithPopup;

            controller.Request(RequestType.NewMerge, controller.getElementIndex(lv), lv.SelectedIndex);
        }
        private void Open_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;
            ListBox_MouseDoubleClick((ListView)elemWithPopup, e);
        }
        private void Rename_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;
            ListView lv = (ListView)elemWithPopup;
            

            controller.Request(RequestType.Rename, controller.getElementIndex(lv), lv.SelectedIndex);

        }
        private void Delete_Click(object sender, MouseButtonEventArgs e)
        {
            Popup1.IsOpen = false;
            ListView lv = (ListView)elemWithPopup;


            controller.Request(RequestType.Delete, controller.getElementIndex(lv), lv.SelectedIndex);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            //MessageBox.Show(controller.getElementIndex(cb).ToString());
            controller.Request(RequestType.ChangeOpenType, controller.getElementIndex(cb), cb.IsChecked);
        }

        private void ListBox_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ListView lv = (ListView)sender;

            

            controller.Request(RequestType.Open, controller.getElementIndex(lv), lv.SelectedIndex);
        }


        private void ListBox1_MouseRightUp(object sender, MouseButtonEventArgs e)
        {
            elemWithPopup = ListView1;
            // MessageBox.Show("asdasd");
            Popup1.IsOpen = true;
        }
        private void ListBox2_MouseRightUp(object sender, MouseButtonEventArgs e)
        {
            elemWithPopup = ListView2;
            // MessageBox.Show("asdasd");
            Popup1.IsOpen = true;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("asd");
            Button btn = (Button)sender;
            controller.Request(RequestType.Back, controller.getElementIndex(btn));
        }

        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            controller.Request(RequestType.Forward, controller.getElementIndex(btn));
        }

        public UIElement ListBox1 { get; set; }
    }
}

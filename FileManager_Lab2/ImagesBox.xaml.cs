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
    /// Interaction logic for ImagesBox.xaml
    /// </summary>
    /// 
    

    public partial class ImagesBox : Window
    {
        private List<string> imageList;
        private List<BitmapImage> bitmapList;

        private int ImageWidth;
        private const int ImageWidthProcentStep = 25;
        public ImagesBox(List<string> imageList)
        {
            InitializeComponent();

            this.imageList = imageList;
            ImageWidth = 100;

            LoadBitmap(this.imageList);
            UpdateList();

        }

        private void OnDoubleClick(object sender, RoutedEventArgs e)
        {
            ListBox lst = (ListBox)sender;

            int id = lst.SelectedIndex;
            string path = imageList[id];
            if(System.IO.File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
        }
        private void LoadBitmap(List<string> imageList)
        {
            bitmapList = new List<BitmapImage>();
            foreach(string image in imageList)
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = new Uri(image);
                bmp.EndInit();

                bitmapList.Add(bmp);
            }
        }
        private void Add_BtnClick(object sender, RoutedEventArgs e)
        {
            ImageWidth += ImageWidthProcentStep;
            UpdateList();
        }

        private void Dec_BtnClick(object sender, RoutedEventArgs e)
        {
            ImageWidth -= ImageWidthProcentStep;
            UpdateList();
        }
        private void UpdateList()
        {
            ListBox1.BeginInit();
            ListBox1.Items.Clear();
            foreach (BitmapImage bmp in bitmapList)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal; 
                Image img = new Image();

                

                double wh = bmp.Width/bmp.Height;
                int height = (int)(ImageWidth / wh);

                img.Source = bmp;

                img.Width = (double)ImageWidth;
                img.Height = (double)height;

                
                
                TextBlock tb = new TextBlock();
                tb.Text = bmp.UriSource.ToString().Substring(8);
                tb.FontSize = 25;

                sp.Children.Add(img);
                sp.Children.Add(tb);

                ListBox1.Items.Add(sp);

            }
            ListBox1.EndInit();
        }

        
    }

    
}

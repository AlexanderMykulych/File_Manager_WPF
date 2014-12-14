using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FileManager_Lab2
{
    class View : IModelListener
    {
        UIElement viewElement;

        List<BitmapImage> images;
        String[] imagesName = { "File2.png", "Folder.png", "Disk.png" };
        public View(UIElement viewElement)
        {
            this.viewElement = viewElement;

            LoadResource();
        }

        private void LoadResource()
        {
            images = new List<BitmapImage>();

            for (int i = 0; i < 3; i++)
            {
                BitmapImage img = new BitmapImage();

                img.BeginInit();
                img.UriSource = new Uri("pack://application:,,/Resource/" + imagesName[i]);
                img.EndInit();

                images.Add(img);
            }
        }

        public void Update(List<ViewItem> viewItem)
        {
            OutPut(viewItem);
        }

        private void OutPut(List<ViewItem> viewItem)
        {
            if (viewElement is ListView)
                ListViewOutPut(viewItem);
        }

        private void ListViewOutPut(List<ViewItem> viewItem)
        {
            if (viewItem != null)
            {
                ListView lv = (ListView)viewElement;

                lv.Items.Clear();
                
                foreach (ViewItem vi in viewItem)
                {

                    StackPanel sp1 = new StackPanel();
                    sp1.Orientation = Orientation.Horizontal;

                    TextBlock tb = new TextBlock();

                    Image img = new Image(); ;


                    if (vi.Type == FileObjectType.fot_File)
                    {
                        try
                        {
                            System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(vi.Name);
                            img.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(icon.ToBitmap().GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromWidthAndHeight(25, 25));
                            tb.Text = System.IO.Path.GetFileName(vi.Name);
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(vi.Name + "\n" + e.Message);
                        }

                        

                    }
                    else
                    {
                        img.Width = 25;
                        img.Height = 25;
                        if (vi.Type == FileObjectType.fot_Folder)
                        {
                            img.Source = images[1];
                            tb.Text = System.IO.Path.GetFileName(vi.Name);
                        }
                        else
                            if (vi.Type == FileObjectType.fot_Disk)
                            {
                                img.Source = images[2];
                                tb.Text = vi.Name;
                            }
                    }
                    sp1.Children.Add(img);

                    sp1.Children.Add(tb);

                    lv.Items.Add(sp1);
                }
            }
        }

    }
}

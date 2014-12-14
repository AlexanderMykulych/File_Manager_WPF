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
    static class ModelHelper
    {
        public static List<FileObject> GetFileObject(FileObjectType fileObjectType, FileObject from = null)
        {
            switch(fileObjectType)
            {
                case FileObjectType.fot_Disk:
                    {
                        List<FileObject> disk = new List<FileObject>();

                        string[] allDrives = Environment.GetLogicalDrives();

                        foreach (String s in allDrives)
                        {
                            FileObject d = new Disk(s);

                            disk.Add(d);
                        }

                        return disk; 
                    }
                case FileObjectType.fot_Folder:
                    {
                        if (from != null)
                        {
                            return from.GetChiled();
                        }
                        else
                            return null;

                    }
            }
            return null;
        }

       /* public static void Open(UIElement elementOpen, FileObject fileObject, List<BitmapImage> image)
        {
            Open(elementOpen, fileObject.GetChiled(), image);
        }*/

       /* public static void Open(UIElement elementOpen, List<FileObject> fileObject, List<BitmapImage> image)
        {
            if (elementOpen is ListView)
            {
                ListView lv = (ListView)elementOpen;
                lv.Items.Clear();

                foreach (FileObject fo in fileObject)
                {
                    


                    StackPanel sp1 = new StackPanel();
                    sp1.Orientation = Orientation.Horizontal;

                    TextBlock tb = new TextBlock();

                    Image img = new Image(); ;
                    img.Width = 25;
                    img.Height = 25;
                    if (fo is ObjFolder)
                    {
                        img.Source = image[0];

                    }
                    else
                        if (fo is ObjFile)
                        {
                            img.Source = image[1];
                        }

                    sp1.Children.Add(img);
                    tb.Text = System.IO.Path.GetFileName(fo.Name);
                    sp1.Children.Add(tb);

                    lv.Items.Add(sp1);
                }
            }
        }*/
    }

    
}

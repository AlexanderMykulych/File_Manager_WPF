using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileManager_Lab2
{


    class ImageLinkCommand
    {
        private static RoutedUICommand imageLink;

        static ImageLinkCommand()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.I, ModifierKeys.Control, "Ctrl + I"));
            imageLink = new RoutedUICommand("imageLink", "imageLink", typeof(ImageLinkCommand), inputs);
        }

        public static RoutedUICommand ImageLink
        {
            get {return imageLink;}
        }
    }
}

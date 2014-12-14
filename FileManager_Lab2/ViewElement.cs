using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FileManager_Lab2
{
    class ViewElement
    {
        public ViewElement(UIElement dirView, Button backBtn, Button forwardBtn, CheckBox openWith)
        {
            this.dirView = dirView;
            this.backBtn = backBtn;
            this.forwardBtn = forwardBtn;
            this.openWith = openWith;
        }
        public UIElement dirView;
        public Button backBtn;
        public Button forwardBtn;
        public CheckBox openWith;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileManager_Lab2
{
    class CompositDelegate
    {
        public CompositDelegate(RoutedEvent newEvent, Delegate newDelegate)
        {
            this.newEvent = newEvent;
            this.newDelegate = newDelegate;
        }
        public RoutedEvent newEvent;
        public Delegate newDelegate;
    }
}

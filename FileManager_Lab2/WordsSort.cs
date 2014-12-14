using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileManager_Lab2
{
    class WordsSort
    {
        private static RoutedUICommand wordsSort;
        
        static WordsSort()
        {
            InputGestureCollection input = new InputGestureCollection();
            input.Add(new KeyGesture(Key.W, ModifierKeys.Control, "Ctrl + W"));
            wordsSort = new RoutedUICommand("wordsSort", " wordsSort", typeof(WordsSort), input);
        }

        public static RoutedUICommand WordSort
        {
            get { return wordsSort; }
        }
    }
}

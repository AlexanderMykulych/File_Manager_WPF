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
using System.Text.RegularExpressions;

namespace FileManager_Lab2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private String FilePath;

        private FileModel File;

        private bool isTextChanged = false;
        private bool isFileSaved = true;
        private Brush SelectBrush = Brushes.Yellow;

        //Просто відкриває файл
        public Window1(String filePath)
        {
            InitializeComponent();
            
           

            CommandBinding openCommand = new CommandBinding(ApplicationCommands.Open, Execute_OpenBtn);
            CommandBindings.Add(openCommand);

            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, Execute_SaveBtn, CanExecute_SaveBtn);
            CommandBindings.Add(saveCommand);

            CommandBinding newCommand = new CommandBinding(ApplicationCommands.New, Execute_NewBtn);
            CommandBindings.Add(newCommand);

            CommandBinding saveAsCommand = new CommandBinding(ApplicationCommands.SaveAs, Execute_SaveAsBtn);
            CommandBindings.Add(saveAsCommand);


            CommandBinding findCommand = new CommandBinding(ApplicationCommands.Find, Execute_FindBtn, CanExecute_FindBtn);
            CommandBindings.Add(findCommand);

            CommandBinding imageCommand = new CommandBinding(ImageLinkCommand.ImageLink, Execute_ImageBtn, CanExecute_ImageBtn);
            CommandBindings.Add(imageCommand);

            CommandBinding sortCommand = new CommandBinding(WordsSort.WordSort, Execute_SortBtn, CanExecute_SortBtn);
            CommandBindings.Add(sortCommand);
            //Перевіряємо чи відкривається файл
            if (!OpenFile(filePath))
            {
                ApplicationCommands.New.Execute(null, this); 
            }

            
           
        }

        private String GetTextRB(RichTextBox r)
        {
            return new TextRange(r.Document.ContentStart, r.Document.ContentEnd).Text;
        }

        private void SetTextRB(RichTextBox r, String t)
        {
            FlowDocument fb = new FlowDocument();
            fb.Blocks.Add(new Paragraph(new Run(t)));
            r.Document = fb;
        }
        //image btn

        private void Execute_ImageBtn(object sender, ExecutedRoutedEventArgs e)
        {
            List<string> images = TextAnalysis.GetImageFromText(GetTextRB(TextBox1));

            if(images.Count > 0)
            {
                ImagesBox imgBox = new ImagesBox(images);
                imgBox.Show();
            }
        }

        private void CanExecute_ImageBtn(object sender, CanExecuteRoutedEventArgs e)
        {
            /*if (TextBox1.Text.Length < 1)
                e.CanExecute = false;
            else*/
                e.CanExecute = true;
        }

        //sort words
        private void Execute_SortBtn(object sender, ExecutedRoutedEventArgs e)
        {
            SortedDictionary<String, int> dictionary = TextAnalysis.WordStatistic(GetTextRB(TextBox1));
            String path = System.IO.Path.GetDirectoryName(FilePath);
            String Name = System.IO.Path.GetFileNameWithoutExtension(FilePath) + "Sort";
            String Ext = System.IO.Path.GetFileName(FilePath);
            path += Name + Ext;

            if(!System.IO.File.Exists(path))
            {
                System.IO.FileStream fs = System.IO.File.Create(path);

                String st = "";
                foreach(String key in dictionary.Keys)
                {
                    st += key + " " + dictionary[key].ToString() + "\n";
                }
                Byte[] text = new UTF8Encoding().GetBytes(st);
                fs.Write(text, 0, text.Length);
            }
            else
            {
                System.IO.FileStream fs = System.IO.File.Open(path, System.IO.FileMode.Open);

                String st = "";
                foreach (String key in dictionary.Keys)
                {
                    st += key + " " + dictionary[key].ToString() + "\n";
                }
                Byte[] text = new UTF8Encoding().GetBytes(st);
                fs.Write(text, 0, text.Length);
            }

            MessageBox.Show("Sorted text in " + path);

        }

        private void CanExecute_SortBtn(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //find word
        private void Execute_FindBtn(object sender, ExecutedRoutedEventArgs e)
        {


            List<int> wordsPos = TextAnalysis.FindWordInText(GetTextRB(TextBox1), TextBoxFind.Text);
            if (wordsPos.Count != 0)
            {
                SelectWord(TextBox1, wordsPos, TextBoxFind.Text.Length);
                MessageBox.Show("У файлі є це слово!");
            }
            else
                MessageBox.Show("У файлі " + FilePath + " немає даного слова!");
        }

        private void CanExecute_FindBtn(object sendder, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TextBoxFind.Text != "";
        }
             
        //select word
        private void SelectWord(RichTextBox textBox, List<int> Ip, int length)
        {
            foreach (int pos in Ip)
            {
               // MessageBox.Show(pos + " " + length);

                
                ChangeBackgroud(textBox, pos, length, SelectBrush);
            }           
            
        }

        private Span sp;
        private void ChangeBackgroud(RichTextBox rTB, int pos1, int len, Brush br)
        {
           // pos1 = 1;
           // len = 6;
           
            TextPointer tp1 = rTB.Document.ContentStart;
            
 
            MessageBox.Show("Позиція входження:\n" + pos1.ToString());
            //rTB.Selection.Select(tp1.GetPositionAtOffset(pos1), tp1.GetPositionAtOffset(pos1 + len));
            //TextRange tr = new TextRange(tp1.GetPositionAtOffset(pos1+2), tp1.GetPositionAtOffset(pos1 + 2 + len));
           // Span sp = new Span(tp1.GetPositionAtOffset(150), tp1.GetPositionAtOffset(154));
           // sp.Inlines.Add(rTB);
            
           // tr.Load()
        }
        //відриваємо файл
        private bool OpenFile(String path)
        {
           
            if(isTextChanged)
            {
                MessageBoxResult result = MessageBox.Show("Файл: " + File.GetFileName() + " не збережено.\nБажаєте зберегти перед відкриттям нового файла?", 
                                                            "Попередження", 
                                                            MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if(isFileSaved)
                        {
                            ApplicationCommands.Save.Execute(null, this);
                        }
                        else
                        {
                            ApplicationCommands.SaveAs.Execute(null, this);
                        }
                        
                        break;
                    case MessageBoxResult.No:

                        break;
                    case MessageBoxResult.Cancel:
                        return false;
                }                
            }

            File = new FileModel(path);
            if (!File.IsFileExist())
            {
                MessageBox.Show("File: " + path + "\n is not Exist!!!");
                return false;
            }

            SetTextRB(TextBox1, File.GetFileText());

            isTextChanged = false;
            this.FilePath = path;
            this.Title = "Opened: " + path;

            return true;

            
        }

        //Open Button
        private void Execute_OpenBtn(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = "*.*";
            dlg.Filter = "All documents (.*)|*.*";

            Nullable<bool> result = dlg.ShowDialog();

            if(result == true)
            {
                String fileToOpen = dlg.FileName;

                OpenFile(fileToOpen);
            }
        }
        
        //Save Button
        private void Execute_SaveBtn(object sender, ExecutedRoutedEventArgs e)
        {
            if(File.SetFileText(GetTextRB(TextBox1)))
            {
                MessageBox.Show("File was save successfully =)");
                isTextChanged = false;
            }
            else
            {
                ApplicationCommands.SaveAs.Execute(null, this);
            }
        }
        private void CanExecute_SaveBtn(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isTextChanged;
        }

        //SaveAs Button
        private void Execute_SaveAsBtn(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog(this);
            if(result == true)
            {
                String path = dlg.FileName;
                File.CreateFile(path);
                File.SetFileText(GetTextRB(TextBox1));
                isTextChanged = false;
                MessageBox.Show("Файл " + path + " успішно збережено.");
            }
        }


        //New Btn
        private void Execute_NewBtn(object sender, ExecutedRoutedEventArgs e)
        {
            if (isTextChanged)
            {
                MessageBoxResult result = MessageBox.Show("Файл: " + File.GetFileName() + " не збережено.\nБажаєте зберегти перед відкриттям нового файла?",
                                                            "Попередження",
                                                            MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (isFileSaved)
                        {
                            ApplicationCommands.Save.Execute(null, this);
                        }
                        else
                        {
                            ApplicationCommands.SaveAs.Execute(null, this);
                        }

                        break;
                    case MessageBoxResult.No:

                        break;
                    case MessageBoxResult.Cancel:
                        return;
                }
            }

            File = new FileModel();
            SetTextRB(TextBox1, "");
            isTextChanged = false;
            this.FilePath = "";
            this.Title = "Open new file";

        }

        //textbox1
        private void TextBox1_Changed(object sender, RoutedEventArgs e)
        {
            isTextChanged = true;
        }

        
    }
    
}

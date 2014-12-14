using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;

namespace FileManager_Lab2
{
    
    class ManagerModel
    {
        List<IModelListener> listeners;

        Merge merge;

        LinkedList<FileObject> History;
        LinkedListNode<FileObject> currentDirInHistory;

        private bool? openFileWithTextReader;
        

        FileObject currentDirectory;

        private ManagerModel() { }
        public ManagerModel(IModelListener firstListener)
        {
            openFileWithTextReader = false;

            merge = new Merge();

            listeners = new List<IModelListener>();
            listeners.Add(firstListener);

            History = new LinkedList<FileObject>();
            currentDirInHistory = null;

            currentDirectory = new TotalSystem();

            OpenCurrentDir(true);

        }

        private void DeleteFromLinkedLinkStartFrom(LinkedList<FileObject> ll, LinkedListNode<FileObject> lln)
        {
            if(lln != null)
            {
                DeleteFromLinkedLinkStartFrom(ll, lln.Next);
                ll.Remove(lln);
            }
        }

        
        public void AddListener(IModelListener newListener)
        {
            listeners.Add(newListener);
        }

        private void UpdateAllListeners(List<ViewItem> items)
        {
            foreach(IModelListener listener in listeners)
            {
                listener.Update(items);
            }
        }
        

        private void OpenCurrentDir(bool doNotesInHistory)
        {
            
            if (doNotesInHistory)
            {
                //MessageBox.Show("Open");
                if (currentDirInHistory != null)
                {
                    History.AddAfter(currentDirInHistory, currentDirectory);
                    currentDirInHistory = currentDirInHistory.Next;
                }
                else
                {
                    History.AddLast(currentDirectory);
                    currentDirInHistory = History.Last;
                }

                

                DeleteFromLinkedLinkStartFrom(History, currentDirInHistory.Next);
                
            }

            //ShowMeHistory();
            List<ViewItem> items = new List<ViewItem>();


            if(currentDirectory is TotalSystem)
            {
                List<FileObject> disks = ModelHelper.GetFileObject(FileObjectType.fot_Disk);

                
                foreach(FileObject fo in disks)
                {

                    ViewItem vi = new ViewItem(FileObjectType.fot_Disk, fo.Name);
                    //MessageBox.Show(fo.Name);
                    items.Add(vi);
                }
            }
            else
                if(currentDirectory is ObjFolder || currentDirectory is Disk)
                {
                    List<FileObject> files = ModelHelper.GetFileObject(FileObjectType.fot_Folder, currentDirectory);
                    if (files != null)
                    {

                        foreach (FileObject fo in files)
                        {
                            FileObjectType fileType;
                            if (fo is ObjFile)
                            {
                                fileType = FileObjectType.fot_File;
                            }
                            else
                            {
                                fileType = FileObjectType.fot_Folder;
                            }
                            ViewItem vi = new ViewItem(fileType, fo.Name);
                            items.Add(vi);
                        }
                    }
                    else
                    {
                        items = null;
                    }

                }
                else
                {
                   
                    Window1 wnd = new Window1(currentDirectory.Name);
                    wnd.Show();

                    items = null;
                }

            UpdateAllListeners(items);
        }

        public void ChangeCurrentDir(int chiledIndex)
        {
           // MessageBox.Show("old Current dir is " + currentDirectory.ToString());
            if (currentDirectory is ObjFolder || currentDirectory is Disk)
            {
                
                List<FileObject> fo = ModelHelper.GetFileObject(FileObjectType.fot_Folder, currentDirectory);
                if (fo == null)
                    return;
                if (fo[chiledIndex] is ObjFile)
                {
                    if ((bool)(openFileWithTextReader ?? true))
                    {
                        Window1 wnd = new Window1(fo[chiledIndex].Name);
                        wnd.Show();
                    }
                    else
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(fo[chiledIndex].Name);
                        }
                        catch(SystemException e)
                        {
                            MessageBox.Show("Сталась помилка: \"" + e.Message + "\"");
                        }
                    }
                }
                else
                {
                    currentDirectory = fo[chiledIndex];
                }

            }
            else

                if(currentDirectory is TotalSystem)
                {
                    List<FileObject> disks = ModelHelper.GetFileObject(FileObjectType.fot_Disk);
                    if (disks == null)
                        return;
                    currentDirectory = disks[chiledIndex];
                }
               

           // MessageBox.Show("new Current dir is " + currentDirectory.ToString());

            OpenCurrentDir(true);
        }
        public void ReturnBack()
        {
            if (currentDirInHistory == null)
            {
                currentDirInHistory = History.Last;
            }
            if (currentDirInHistory.Previous != null)
            {
                currentDirInHistory = currentDirInHistory.Previous;

                currentDirectory = currentDirInHistory.Value;

                
            }
            OpenCurrentDir(false);
        }

        private void ShowMeHistory()
        {
            foreach(FileObject fo in History)
            {
                MessageBox.Show(fo.Name);
            }
            if(currentDirInHistory != null)
             MessageBox.Show(currentDirInHistory.Value.Name);
        }
        public void ReturnForvard()
        {
            if (currentDirInHistory.Next != null)
            {
                currentDirInHistory = currentDirInHistory.Next;

                currentDirectory = currentDirInHistory.Value;

                OpenCurrentDir(false);
            }
        }

        public void setOpenFileWithTextReader(bool? newOpenFileWithTextReader)
        {
            openFileWithTextReader = newOpenFileWithTextReader;
        }

        public void Rename(int index)
        {
            if(currentDirectory is TotalSystem)
            {
                MessageBox.Show("Неможливо перейменувати!");
                return;
            }

            List<FileObject> fo = currentDirectory.GetChiled();
            try
            {
                fo[index].Rename();
                OpenCurrentDir(false);
            }
            catch(System.IO.IOException e)
            {
                MessageBox.Show("Сталась помилка: " + e.Message);
            }
            
        }

        public void Delete(int index)
        {
            if(currentDirectory is TotalSystem)
            {
                MessageBox.Show("Неможливо Видалити!");
                return;
            }

            List<FileObject> fo = currentDirectory.GetChiled();
            try
            {
                fo[index].Delete();
                System.Windows.MessageBox.Show("Папку видалено успішно=)");
                OpenCurrentDir(false);
            }
            catch(System.IO.IOException e)
            {
                MessageBox.Show("Сталась помилка: " + e.Message);
            }
        }

        public void AddToMerge(int index)
        {
            if (currentDirectory is TotalSystem)
            {
                MessageBox.Show("Неможливо додати диск!");
                return;
            }

            List<FileObject> fo = currentDirectory.GetChiled();
            
            if(!(fo[index] is ObjFile))
            {
                MessageBox.Show("Неможливо додати, оскільки це не файл!");
                return;
            }

            merge.AddFile((ObjFile)fo[index]);
            
        }

        public void SaveMerge()
        {
            merge.SaveMerge();
            OpenCurrentDir(false);
        }

        public void NewMerge()
        {
            merge.Clear();
        }


        public void CopyFileObject(int index)
        {
            if (currentDirectory is TotalSystem)
            {
                MessageBox.Show("Неможливо!");
                return;
            }
            List<FileObject> fo = currentDirectory.GetChiled();

            FileObject targetFile = fo[index];

            System.Collections.Specialized.StringCollection strFile = new System.Collections.Specialized.StringCollection();
            strFile.Add(targetFile.Name);

            Clipboard.SetFileDropList(strFile);

        }
        public void CutFileObject(int index)
        {
            if (currentDirectory is TotalSystem)
            {
                MessageBox.Show("Неможливо!");
                return;
            }
            List<FileObject> fo = currentDirectory.GetChiled();

            FileObject targetFile = fo[index];

            System.Collections.Specialized.StringCollection strFile = new System.Collections.Specialized.StringCollection();
            strFile.Add(targetFile.Name);

            Clipboard.SetFileDropList(strFile);
        }
        private void ShowProgress()
        {
            var progr = new ProgressWindow("", "", 0, true);
            progr.Show();
            System.Windows.Threading.Dispatcher.Run();
        }
        public void PastFileObject()
        {
            if (currentDirectory is TotalSystem)
            {
                MessageBox.Show("Неможливо!");
                return;
            }
          
            if (Clipboard.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection strFile = Clipboard.GetFileDropList();

             //   int value = 0;

              //  var threade = new System.Threading.Thread(ShowProgress);
              //  threade.SetApartmentState(System.Threading.ApartmentState.STA);

              //  threade.IsBackground = true;
              //  threade.Start();

                

                foreach(string s in strFile)
                {
                    Past(currentDirectory.Name, s);
               //     value++;
                   
                }

               /// threade.Abort();
            }

        }

        private void Past(String targetPath, String sourcePath)
        {
            try
            {
                System.IO.FileAttributes fileAtr = System.IO.File.GetAttributes(sourcePath);

                if ((fileAtr & System.IO.FileAttributes.Directory) == System.IO.FileAttributes.Directory)
                {
                    if(targetPath.IndexOf(sourcePath) > -1 )
                    {
                        MessageBox.Show("Неможливо скопіювати в дочірню папку!");
                        return;
                    }

                    //                MessageBox.Show("source = " + sourcePath.ToString() + " \ntarget=" + targetPath.ToString() + " \nfileName=" + System.IO.Path.GetFileName(sourcePath));
                    //              MessageBox.Show(targetPath + "\\" + System.IO.Path.GetFileName(sourcePath));
                    System.IO.Directory.CreateDirectory(targetPath + "\\" + System.IO.Path.GetFileName(sourcePath));

                    String[] dir = System.IO.Directory.GetDirectories(sourcePath);
                    foreach (String s in dir)
                    {
                        Past(targetPath + "\\" + System.IO.Path.GetFileName(sourcePath), s);
                    }

                    String[] file = System.IO.Directory.GetFiles(sourcePath);
                    foreach (String s in file)
                    {
                        //MessageBox.Show("file:" + s);
                        Past(targetPath + "\\" + System.IO.Path.GetFileName(sourcePath), s);
                    }

                }
                else
                {
                    try
                    {
                        System.IO.File.Copy(sourcePath, targetPath + "\\" + System.IO.Path.GetFileName(sourcePath));
                    }
                    catch (System.IO.IOException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }

            catch(System.IO.IOException e)
            {
                MessageBox.Show(e.Message);
            }
                OpenCurrentDir(false);
            
        }

    }
}

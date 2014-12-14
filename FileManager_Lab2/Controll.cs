using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FileManager_Lab2
{
    class Controll
    {
        private ViewElement elements;
        private View view;
        private ManagerModel model;
        public Controll(ViewElement elements)
        {
            this.elements = elements;

            view = new View(this.elements.dirView);
            model = new ManagerModel(view);

            
            model.setOpenFileWithTextReader(this.elements.openWith.IsChecked);
        }

        public void Open(int index)
        {
            model.ChangeCurrentDir(index);
        }

        public void Delete(int index)
        {
            model.Delete(index);
        }
        public void Rename(int index)
        {
           
            model.Rename(index);
        }

        public void GoBack()
        {
            model.ReturnBack();
        }
        
        public void GoForward()
        {
            model.ReturnForvard();
        }

        public UIElement getElement()
        {
            return elements.dirView;
        }

        public Button getBackButton()
        {
            return elements.backBtn;
        }

        public Button getForwardButton()
        {
            return elements.forwardBtn;
        }
        public CheckBox getOpenWith()
        {
            return elements.openWith;
        }

        public void setOpenType(bool? newOpenType)
        {
            model.setOpenFileWithTextReader(newOpenType);
        }

        public void NewMerge()
        {
            model.NewMerge();
        }

        public void SaveMerge()
        {
            model.SaveMerge();
        }

        public void AddToMerge(int index)
        {
            model.AddToMerge(index);
        }

        public void Copy(int index)
        {
            model.CopyFileObject(index);

        }
        public void Cut(int index)
        {
            model.CutFileObject(index);
        }

        public void Past()
        {
            model.PastFileObject();
        }
    }

}

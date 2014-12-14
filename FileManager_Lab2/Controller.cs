using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FileManager_Lab2
{
    enum RequestType {Open, Back, Forward, ChangeOpenType, Rename, Delete, AddToMerge, NewMerge, SaveMerge, Copy, Cut, Past};
    class Controller
    {
        List<Controll> elements;
        public Controller()
        {
            elements = new List<Controll>();
        }

        public void AddNewUIElement(ViewElement elements)
        {
            this.elements.Add(new Controll(elements));
        }

        public void Request(RequestType type, int senderId, object info = null)
        {
            if (elements[senderId] != null)
            {
                switch (type)
                {
                    case RequestType.Open:
                        {

                            int index = (int)info;
                            elements[senderId].Open(index);

                            break;
                        }

                    case RequestType.Back:
                        {
                            elements[senderId].GoBack();
                            break;
                        }

                    case RequestType.Forward:
                        {
                            elements[senderId].GoForward();
                            break;
                        }

                    case RequestType.ChangeOpenType:
                        {
                            bool? cb = (bool?)info;

                            elements[senderId].setOpenType(cb);

                            break;
                        }

                    case RequestType.Rename:
                        {

                            int index = (int)info;

                            elements[senderId].Rename(index);
                            break;
                        }

                    case RequestType.Delete:
                        {
                            int index = (int)info;

                            elements[senderId].Delete(index);

                            break;
                        }
                    case RequestType.SaveMerge:
                        {

                            elements[senderId].SaveMerge();

                            break;
                        }
                    case RequestType.NewMerge:
                        {
                            elements[senderId].NewMerge();

                            break;
                        }
                    case RequestType.AddToMerge:
                        {
                            int index = (int)info;

                            elements[senderId].AddToMerge(index);

                            break;
                        }
                    case RequestType.Copy:
                        {
                            int index = (int)info;

                            elements[senderId].Copy(index);

                            break;
                        }
                    case RequestType.Cut:
                        {
                            int index = (int)info;

                            elements[senderId].Cut(index);

                            break;
                        }
                    case RequestType.Past:
                        {
                            elements[senderId].Past();

                            break;
                        }
                }
            }
        }

        public int getElementIndex(UIElement element)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (element == elements[i].getElement())
                {
                    //MessageBox.Show(i.ToString());
                    return i;
                }
            }
            return -1;
        }

        public int getElementIndex(Button element)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (element == elements[i].getBackButton() || element == elements[i].getForwardButton())
                {
                    //MessageBox.Show(i.ToString());
                    return i;
                }
            }
            return -1;
        }
        
        public int getElementIndex(CheckBox element)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (element == elements[i].getOpenWith())
                {
                    //MessageBox.Show(i.ToString());
                    return i;
                }
            }
            return -1;
        }
    }
}

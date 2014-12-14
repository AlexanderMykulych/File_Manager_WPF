using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_Lab2
{
    class ViewItem
    {
        public ViewItem(FileObjectType type, String name)
        {
            Type = type;
            Name = name;
        }
        public FileObjectType Type
        {
            get;
            set;
        }
        public String Name
        {
            get{return name;}
            set { name = value; }
        }
        public String name;
    }
}

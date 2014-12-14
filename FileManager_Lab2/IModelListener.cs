using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager_Lab2
{
    interface IModelListener
    {
        
        void Update(List<ViewItem> viewItem);
    }
}

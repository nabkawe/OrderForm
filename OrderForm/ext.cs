using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public static class BindingListExtensions
    {
        public static void Move<T>(this BindingList<T> list, int oldIndex, int newIndex)
        {

            if (oldIndex == newIndex)
            {
                return;
            }

            if (newIndex >= list.Count)
            {
                newIndex = list.Count - 1;
            }

            T item = list[oldIndex];
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, item);
        }
    }

 
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
        }
    }

  
    }


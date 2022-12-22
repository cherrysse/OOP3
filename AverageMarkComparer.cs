using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloiseLab3
{
    internal class AverageMarkComparer : IComparer<Student>
    {
        public int Compare(Student one, Student two)
        {
            if (one.AverageMark.CompareTo(two.AverageMark) != 0)
            { 
                return one.AverageMark.CompareTo(two.AverageMark); 
            }
            else
            { 
                return 0; 
            }
        }
    }
}

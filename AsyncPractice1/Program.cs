using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncPractice1
{
    class Program
    {
        static void Main(string[] args)
        {
//            var mzObj = new TwoPointOne();
//            mzObj.DoSomethingAsync();
            var TwoPointFour = new TwoPointFour();
            TwoPointFour.ProcessTasksAsync();
        }
    }
}

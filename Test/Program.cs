using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementations;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CRMContex();

            var group = (from g in context.GroupDbSet select  g).ToList();

            foreach (var g in group)
            {
                var a = g.User;
            }
        }
    }
}

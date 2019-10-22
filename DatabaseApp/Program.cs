using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseForFred;

namespace DatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var myProduct = DB.getProduct(1);
            System.Console.WriteLine(myProduct.ProductDescription);
        }
    }
}

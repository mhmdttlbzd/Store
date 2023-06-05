using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Interface.Exeption
{
    public class ProductNameExeption : ApplicationException
    {
        public override string Message => "product name is not corect";
    }
}

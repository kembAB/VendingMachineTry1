using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    public class Cola : Softdrink
    {
        public Cola()
        {
            this.Name = "Cola";
            this.Price = 20;
            this.IsUsed = false;
        }
        public override Sharedinfo GetNewItem()
        {
            return new Cola();
        }
    }
}

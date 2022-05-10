using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    public class Marabou : Choklad
    {
        public Marabou()
        {
            this.Name = "Marabou";
            this.Price = 8;
            this.IsUsed = false;
        }
        public override Sharedinfo GetNewItem()
        {
            return new Marabou();
        }
    }
}

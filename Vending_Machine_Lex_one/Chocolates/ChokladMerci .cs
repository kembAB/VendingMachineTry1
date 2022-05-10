using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    public class ChokladMerci : Choklad
    {

        public ChokladMerci()
        {
            this.Name = "ChokladMerci";
            this.Price = 15;
            this.IsUsed = false;
        }
        public override Sharedinfo GetNewItem()
        {
            return new ChokladMerci();
        }
    }
}

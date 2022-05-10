using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
   public class Fanta:Softdrink
    {
        public Fanta()
        {
            this.Name = "Fanta";
            this.Price = 20;
            this.IsUsed = false;
        }
        public override Sharedinfo GetNewItem()
        {
            return new Fanta();
        }
    }
}

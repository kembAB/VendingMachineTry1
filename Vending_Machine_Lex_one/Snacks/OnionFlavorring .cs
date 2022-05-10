using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    public class OnionFlavorring : Snacks
    {
        public OnionFlavorring()
        {
            this.Name = "OnionFlavorring";
            this.Price = 18;
            this.IsUsed = false;
        }
        public override Sharedinfo GetNewItem()
        {
            return new OnionFlavorring();
        }
    }
}

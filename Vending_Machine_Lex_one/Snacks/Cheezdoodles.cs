using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    public class Cheezdoodles : Snacks
    {

        public Cheezdoodles()
        {
            this.Name = "Cheezdoodles";
            this.Price = 19;
            this.IsUsed = false;
        }

        public override Sharedinfo GetNewItem()
        {
            return new Cheezdoodles();
        }

    }
}

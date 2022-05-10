using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    public class Twix : Choklad
    {

        public Twix()
        {
            this.Name = "Twix";
            this.Price = 12;
            this.IsUsed = false;
        }

        public override Sharedinfo GetNewItem()
        {
            return new Twix();
        }

    }
}

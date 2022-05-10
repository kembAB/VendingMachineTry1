using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    public class EsterellaChips:Snacks
    {
        public EsterellaChips()
        {
            this.Name = "EsterellaChips";
            this.Price = 18;
            this.IsUsed = false;
        }
        public override Sharedinfo GetNewItem()
        {
            return new EsterellaChips();
        }
    }
}


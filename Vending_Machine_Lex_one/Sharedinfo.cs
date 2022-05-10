using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
   public  abstract class  Sharedinfo
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsUsed { get; set; }
        public abstract void Use();
        public abstract Sharedinfo GetNewItem();
        public abstract void Examine();
   }
}


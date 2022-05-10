using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    public class Choklad : Sharedinfo
    {
        public new string Name { get; set; }
        public new int Price { get; set; }
        public new bool IsUsed { get; set; }
        public override void Use()
        {

            if (!IsUsed)
            {
                Console.WriteLine($"Chocolate {Name}");
                IsUsed = true;
            }
            else if (IsUsed)
            {
                Console.WriteLine("Chocolate  is empty");
            }
        }

        public override void Examine()
        {
            Console.WriteLine($"{Name} : {Price} Sek.");
        }
        public override Sharedinfo GetNewItem()
        {
            return new Choklad();
        }
    }
}

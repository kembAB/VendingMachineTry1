using System;
using System.Collections.Generic;
using System.Text;

namespace Vending_Machine_Lex_one
{
    interface Ivending
    {
        //showall --display products
        void ShowAll();
        //purchase -select producto
        void Purchase();


        //InsertMoney --entercoin
        void InsertMoney();
        //show the change . and last words
        void EndTransaction();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    class Drink : Food, IDispensingMessage
    {
        public Drink(string name, decimal price) : base(name, price)
        {

        }

        public void DispenseMessage()
        {
            //TODO add in functionality to display money remaining
            Console.WriteLine($"Glug Glug, Yum! {Name}, {Price}");
        }

    }
}

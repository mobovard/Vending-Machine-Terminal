using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    class Chip : Food, IDispensingMessage
    {
        public Chip(string name, decimal price) : base(name, price)
        {

        }

        public void DispenseMessage()
        {
            //TODO add in functionality to display money remaining
            Console.WriteLine($"Crunch Crunch, Yum! {Name}, {Price}");
        }


    }
}

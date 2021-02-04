﻿using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    class Gum : Food, IDispensingMessage
    {
        public Gum(string name, decimal price) : base(name, price)
        {

        }

        public void DispenseMessage()
        {
            //TODO add in functionality to display money remaining
            Console.WriteLine($"Chew Chew, Yum! {Name}, {Price}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    class Chip : Food
    {
        public Chip(string name, decimal price) : base(name, price)
        {

        }

        public override string DispenseMessage()
        {
            return $"Crunch Crunch, Yum! {this.Name}, {this.Price}.";
        }

        public override void TimesPurchased()
        {
            NumberOfTimesPurchased++;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    class Drink : Food
    {
        public Drink(string name, decimal price) : base(name, price)
        {

        }

        public override string DispenseMessage()
        {
            return $"Glug Glug, Yum! {this.Name}, {this.Price}.";
        }

        public override void TimesPurchased()
        {
            this.NumberOfTimesPurchased++;
        }
    }
}

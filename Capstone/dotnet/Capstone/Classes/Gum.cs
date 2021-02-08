using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    class Gum : Food
    {
        public Gum(string name, decimal price) : base(name, price)
        {

        }

        public override string DispenseMessage()
        {            
            return $"Chew Chew, Yum! {this.Name}, {this.Price}.";
        }

        public override void TimesPurchased()
        {
            NumberOfTimesPurchased++;
        }
    }
}

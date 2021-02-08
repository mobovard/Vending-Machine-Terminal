using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Interfaces;

namespace Capstone.Classes
{
    class Candy : Food
    {
        public Candy(string name, decimal price) : base(name, price)
        {

        }

        public override string DispenseMessage()
        {
            return $"Munch Munch, Yum! {this.Name}, {this.Price}.";
        }

        public override void TimesPurchased()
        {
            NumberOfTimesPurchased++;
        }
    }
}

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
            //TODO add in functionality to display money remaining
            return $"Crunch Crunch, Yum! {this.Name}, {this.Price}.";
        }


    }
}

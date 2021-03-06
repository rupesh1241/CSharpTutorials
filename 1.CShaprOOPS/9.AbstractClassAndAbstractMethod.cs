﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShaprOOPS
{
    public abstract class AbstractClassAndAbstractMethod
    {
        protected double rate;
        public abstract void getRate();
        public void calculation(int units)
        {
            Console.Write("BILL AMOUNT FOR " + units + " UNITS is: Rs.");
            Console.WriteLine(rate * units);
        }
    }
    class CommercialPlan : AbstractClassAndAbstractMethod
    {
        public override void getRate()
        {
            rate = 5.00;
        }
    }
    class AbstractClass : AbstractClassAndAbstractMethod
    {
        public override void getRate()
        {
            rate = 2.50;
        }
        static void Main(string[] args)
        {
            AbstractClassAndAbstractMethod p;
            Console.WriteLine("COMMERCIAL CONNECTION");
            p = new CommercialPlan();
            p.getRate();
            p.calculation(250);
            Console.WriteLine("DOMESTIC CONNECTION");
            p = new AbstractClass();
            p.getRate();
            p.calculation(150);
            Console.ReadKey();
        }
    }
}

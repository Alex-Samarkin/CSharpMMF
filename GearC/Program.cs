using System;

namespace GearC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gear calc");
            Gear gear = new Gear();
            Console.WriteLine(gear.BaseInfo());
        }
    }
}

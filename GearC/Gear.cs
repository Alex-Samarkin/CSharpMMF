using System;
using System.Collections.Generic;
using System.Text;

namespace GearC
{
    public class Gear
    {
        /// <summary>
        /// 
        /// </summary>
        public int z { get; set; } = 16;
        public int ZMin { get; set; } = 12;
        public double alpha { get; set; } = 0;
        public double m { get; set; } = 2;
        public double s => 0.5 * Math.PI * m;
        public double alphaW { get; set; } = 20;
        public double x { get; set; } = 0;
        public double dy { get; set; } = 0;
        public double kf => ka + kc;
        public double kc { get; set; } = 0.25;
        public double ka { get; set; } = 1;

        private double rad(double a) { return a * Math.PI / 180; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double d () { return m * z; }
        public double d0() { return d()*Math.Cos(rad(alphaW)); }
        public double ha() => ka * m;
        public double hf() => kf * m;
        public double h() => ha() + hf();
        public double c() => kc * m;
        public double df() => d() - 2.0 * hf();
        public double da() => d() + 2.0 * ha();

        public double A(Gear gear) => m * (z + gear.z) / 2.0;

        public string BaseInfo ()
        {
            return $"Z= {z}, модуль={m}\nУгол зацепления {alphaW}, угол зуба {alpha}\n" +
                $"ka = {ka}, kc = {kc}, kf = {kf}\n"+
                $"x = {x}, угол наклона зуба {alpha}";
        }

        public double y() => x * m;
        public double dax() => 2.0 * m * (z / 2 + ka + x - dy);
        public double hx() => m * (kc + 2.0 * ka - dy);
        public double sx() => m * (Math.PI / 2 + 2 * x * Math.Tan(rad(alphaW)));


    }
}

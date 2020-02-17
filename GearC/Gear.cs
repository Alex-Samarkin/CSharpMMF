using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GearC
{
    public class Gear
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        #region Константы

        [Description("Количество зубьев колеса")]
        public int z { get; set; } = 16;
        [Description("Минимальное количество зубьев колеса")]
        public int ZMin { get; set; } = 12;
        [Description("Угол наклона зубьев колеса для колес с винтовым зубом")]
        public double alpha { get; set; } = 0;
        [Description("Модуль")]
        public double m { get; set; } = 2;
        [Description("Толщина зуба по делительной окружности")]
        public double s => 0.5 * Math.PI * m;
        [Description("Угол зацепления")]
        public double alphaW { get; set; } = 20;
        [Description("Коэффициент смещения")]
        public double x { get; set; } = 0;
        [Description("Коэффициент уравнительного смещения (см. станочное зацепление)")]
        public double dy { get; set; } = 0;
        [Description("Коэффициент ножки зуба")]
        public double kf => ka + kc;
        [Description("Коэффициент зазора")]
        public double kc { get; set; } = 0.25;
        [Description("Коэффициент головки зуба")]
        public double ka { get; set; } = 1;

        #endregion
        /// <summary>
        /// пересчет градусов в радианы
        /// </summary>
        /// <param name="a">угол в градусах</param>
        /// <returns>угол в радианах</returns>
        private double rad(double a) { return a * Math.PI / 180; }

        #region Размеры без учета смещения
        /// <summary>
        /// делительный диаметр
        /// </summary>
        /// <returns></returns>
        public double d () { return m * z; }
        /// <summary>
        /// диаметр основной окружности
        /// </summary>
        /// <returns></returns>
        public double d0() { return d()*Math.Cos(rad(alphaW)); }
        /// <summary>
        /// высота головки зуба
        /// </summary>
        /// <returns></returns>
        public double ha() => ka * m;
        /// <summary>
        /// величина ножки зуба
        /// </summary>
        /// <returns></returns>
        public double hf() => kf * m;
        /// <summary>
        /// высота зуба
        /// </summary>
        /// <returns></returns>
        public double h() => ha() + hf();
        /// <summary>
        /// величина зазора
        /// </summary>
        /// <returns></returns>
        public double c() => kc * m;
        /// <summary>
        /// диаметр впадин
        /// </summary>
        /// <returns></returns>
        public double df() => d() - 2.0 * hf();
        /// <summary>
        /// диаметр вершин
        /// </summary>
        /// <returns></returns>
        public double da() => d() + 2.0 * ha();

        /// <summary>
        /// межосевое расстояние
        /// </summary>
        /// <param name="gear">сопряженное колесо</param>
        /// <returns>межосевое расстояние</returns>
        public double A(Gear gear) => m * (z + gear.z) / 2.0;

        public string BaseInfo ()
        {
            return $"Z= {z}, модуль={m}\nУгол зацепления {alphaW}, угол зуба {alpha}\n" +
                $"ka = {ka}, kc = {kc}, kf = {kf}\n"+
                $"x = {x}, угол наклона зуба {alpha}";
        }
        #endregion

        /// <summary>
        /// уранительное мещение
        /// </summary>
        /// <returns></returns>
        public double y() => x * m;
        /// <summary>
        /// диаметр вершин со смещением
        /// </summary>
        /// <returns></returns>
        public double dax() => 2.0 * m * (z / 2 + ka + x - dy);
        /// <summary>
        /// высота зуба с учетом смещения
        /// </summary>
        /// <returns></returns>
        public double hx() => m * (kc + 2.0 * ka - dy);
        /// <summary>
        /// толщина зуба с учетом смещения
        /// </summary>
        /// <returns></returns>
        public double sx() => m * (Math.PI / 2 + 2 * x * Math.Tan(rad(alphaW)));


    }
}

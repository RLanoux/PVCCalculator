using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVCCalculator
{
    class Circle
    {
        public Circle()//Default radius
        {
            dRadius = 1.0;
        }

        public Circle(Double initRadius)//Initialize the radius
        {
            dRadius = initRadius;
        }

        public Double ShowRadius()//Show the value of the radius
        {
            return dRadius;
        }

        public Double ShowCircumference()//Calculate and show the radius when this is used
        {
            return 2 * Math.PI * dRadius;
        }

        public Double ShowArea()//Calculate the and show the area
        {
            return dRadius * dRadius * Math.PI;
        }

        public Double ShowDiameter()//Calculate and show the diameter
        {
            return dRadius * 2;
        }

        protected Double dRadius;
    }
}

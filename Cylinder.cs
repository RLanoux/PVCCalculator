using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PVCCalculator
{
    class Cylinder : Circle
    {
        public Cylinder()//Default radius and length
        {
            dRadius = 1.0;
            dLength = 1.0;
        }

        public Cylinder(Double initRadius, Double initLength)//Initialize the default radius and length
        {
            dRadius = initRadius;
            dLength = initLength;
        }

        public Double ShowVolume()//Calculate and show the Volume when this is used
        {
            return dRadius * dRadius * Math.PI * dLength;
        }

        public Double ShowSurfaceArea()
        {
            return (2 * dRadius * Math.PI * dLength) 
                + ((2) * (dRadius * dRadius * Math.PI));
        }

        protected Double dLength;
    }
}

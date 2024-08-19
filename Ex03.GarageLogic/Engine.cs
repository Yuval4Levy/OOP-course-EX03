using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        readonly eEnergyType r_EnergyType;
        readonly float r_MaximumCapacity;

        public Engine(eEnergyType i_EnergyType, float i_MaximumCapacity)
        {
            r_EnergyType = i_EnergyType;
            r_MaximumCapacity = i_MaximumCapacity;
        }
        public float MaximumCapacity
        {
            get { return r_MaximumCapacity; }
        }
        public eEnergyType EnergyType
        {
            get { return r_EnergyType; }
        }
        public static void isValidEnergyType(int i_EnergyType)
        {
            if (!Enum.IsDefined(typeof(eEnergyType), i_EnergyType))
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return string.Format("The maximum capacity of the engine is: {0}\nThe engine's energy type is: {1}\n", r_MaximumCapacity, r_EnergyType);
        }
    }
}

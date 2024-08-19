using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly bool r_IsHazardous;
        private readonly float r_CargoVolume;

        public Truck(string i_LicenseNumber, string i_Model, int i_NumOfWheels, string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure, eEnergyType i_eEnergyType, float i_MaximumEngineCapacity, float i_CargoVolume, bool i_IsHazardous, float i_EnergyLeftPercentage)
            : base(i_LicenseNumber, i_Model, i_NumOfWheels, i_Manufacturer, i_CurrentAirPressure, i_MaxAirPressure, i_eEnergyType, i_MaximumEngineCapacity, i_EnergyLeftPercentage)
        {
            r_IsHazardous = i_IsHazardous;
            r_CargoVolume = i_CargoVolume;
        }
        public bool IsHazardous
        {
            get { return r_IsHazardous; }
        }
        public float CargoVolume
        {
            get { return r_CargoVolume; }
        }
        public static void isValidCargoVolume(float i_CargoVolume)
        {
            if (i_CargoVolume < 0)
            {
                throw new ArgumentException();
            }
        }
        public override string ToString()
        {
            return string.Format("The truck that was asked for is the following{0}\nIs Hazardous?: {1}\nCargo volume: {2}", base.ToString(), r_CargoVolume, r_IsHazardous);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private readonly eLicenseType r_eLicenseType;
        private readonly int r_EngineVolume;

        public MotorCycle(string i_LicenseNumber, string i_Model, int i_NumOfWheels, string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure, eEnergyType i_eEnergyType, float i_MaximumEngineCapacity, eLicenseType i_eLicenseType, int i_EngineVolume, float i_EnergyLeftPercentage)
            : base(i_LicenseNumber, i_Model, i_NumOfWheels, i_Manufacturer, i_CurrentAirPressure, i_MaxAirPressure, i_eEnergyType, i_MaximumEngineCapacity, i_EnergyLeftPercentage)
        {
            r_eLicenseType = i_eLicenseType;
            r_EngineVolume = i_EngineVolume;
        }
        public eLicenseType eLicenseType
        {
            get { return r_eLicenseType; }
        }
        public int EngineVolume
        {
            get { return r_EngineVolume; }
        }
        public static void IsValidLicenseType(int i_LicenseTypeInput)
        {
            if (!Enum.IsDefined(typeof(eLicenseType), i_LicenseTypeInput))
            {
                throw new ArgumentException();
            }
        }
        public override string ToString()
        {
            return string.Format("The motorcycle that was asked for is the following{0}\nLicense type: {1}\nEngine volume: {2}", base.ToString(), r_eLicenseType, r_EngineVolume);
        }
    }
}

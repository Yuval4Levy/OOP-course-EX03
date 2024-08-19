using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private readonly eCarColor r_eCarColor;
        private readonly int r_AmountOfDoors;

        public Car(string i_LicenseNumber, string i_Model, int i_NumOfWheels, float i_CurrentAirPressure, float i_MaxAirPressure, eEnergyType i_eEnergyType, string i_Manufacturer, float i_MaximumEngineCapacity, eCarColor i_eCarColor, int i_AmountOfDoors, float i_EnergyLeftPercentage)
            : base(i_LicenseNumber, i_Model, i_NumOfWheels, i_Manufacturer, i_CurrentAirPressure, i_MaxAirPressure, i_eEnergyType, i_MaximumEngineCapacity, i_EnergyLeftPercentage)

        {
            r_eCarColor = i_eCarColor;
            r_AmountOfDoors = i_AmountOfDoors;
        }
        public eCarColor eCarColor
        {
            get { return r_eCarColor; }
        }
        public int AmountOfDoors
        {
            get { return r_AmountOfDoors; }
        }

        public static void IsValidCarColor(int i_CarColorInput)
        {
            if (!Enum.IsDefined(typeof(eCarColor), i_CarColorInput))
            {
                throw new ArgumentException();
            }
        }
        public static void IsValidDoorAmount(int i_DoorAmountInput)
        {
            if (!(i_DoorAmountInput >= 2 && i_DoorAmountInput <= 5))
            {
                throw new ArgumentException();
            }
        }
        public override string ToString()
        {
            return string.Format("The car that was asked for is the following{0}\nColor: {1}\nNumber of doors: {2}", base.ToString(), r_eCarColor, r_AmountOfDoors);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        const eEnergyType k_RegularCarFuel = eEnergyType.Octan95;
        const eEnergyType k_RegularMotorcycleFuel = eEnergyType.Octan98;
        const eEnergyType k_TruckFuel = eEnergyType.Soler;
        const eEnergyType k_ElectricVehicleEnergy = eEnergyType.Electric;
        const int k_MotorcycleNumOfWheels = 2;
        const int k_CarNumOfWheels = 5;
        const int k_TruckNumOfWheels = 12;
        const float k_ElectricCarEngineCapacity = 3.5f;
        const float k_ElectricMotorcycleEngineCapacity = 2.5f;
        const float k_RegularCarTankVolume = 45;
        const float k_RegularMotorcycleTankVolume = 5.5f;
        const float k_TruckTankVolume = 120;
        const int k_CarMaxWheelAirPressure = 31;
        const int k_MotorcylceMaxWheelAirPressure = 33;
        const int k_TruckMaxWheelAirPressure = 28;

        public enum eVehicleType
        {
            RegularCar = 1,
            ElectricCar = 2,
            Truck = 3,
            RegularMotorcycle = 4,
            ElectricMotorcycle = 5
        }
        public static Vehicle CreateVehicle(eVehicleType i_eVehicleType, string i_LicenseNumber, string i_Model, string i_WheelManufacturer, float i_CurrentAirPressure, List<string> i_UniqueParamsPerType, float i_EnergyLeftPercentage)
        {
            Vehicle vehicle = null;

            switch (i_eVehicleType)
            {
                case eVehicleType.RegularCar:
                    eCarColor regularCarColor = new eCarColor();
                    int RegularCarAmountOfDoors = int.Parse(i_UniqueParamsPerType[1]);

                    Car.IsValidDoorAmount(RegularCarAmountOfDoors);
                    Car.IsValidCarColor(int.Parse(i_UniqueParamsPerType[0]));
                    Enum.TryParse(i_UniqueParamsPerType[0], true, out regularCarColor);
                    vehicle = new Car(i_LicenseNumber, i_Model, k_CarNumOfWheels, i_CurrentAirPressure, k_CarMaxWheelAirPressure, k_RegularCarFuel, i_WheelManufacturer,
                            k_RegularCarTankVolume, regularCarColor, RegularCarAmountOfDoors, i_EnergyLeftPercentage);
                    break;
                case eVehicleType.ElectricCar:
                    eCarColor electricCarColor = new eCarColor();
                    Enum.TryParse(i_UniqueParamsPerType[0], true, out electricCarColor);
                    int electricCarAmountOfDoors = int.Parse(i_UniqueParamsPerType[1]);

                    Car.IsValidDoorAmount(electricCarAmountOfDoors);
                    Car.IsValidCarColor(int.Parse(i_UniqueParamsPerType[0]));
                    vehicle = new Car(i_LicenseNumber, i_Model, k_CarNumOfWheels, i_CurrentAirPressure, k_CarMaxWheelAirPressure, k_ElectricVehicleEnergy, i_WheelManufacturer,
                        k_ElectricCarEngineCapacity, electricCarColor, electricCarAmountOfDoors, i_EnergyLeftPercentage);
                    break;
                case eVehicleType.Truck:
                    float cargoVolume = float.Parse(i_UniqueParamsPerType[0]);
                    Truck.isValidCargoVolume(cargoVolume);
                    bool isHazardous = bool.Parse(i_UniqueParamsPerType[1]);

                    vehicle = new Truck(i_LicenseNumber, i_Model, k_TruckNumOfWheels, i_WheelManufacturer, i_CurrentAirPressure, k_TruckMaxWheelAirPressure, k_TruckFuel,
                        k_TruckTankVolume, cargoVolume, isHazardous, i_EnergyLeftPercentage);
                    break;
                case eVehicleType.RegularMotorcycle:
                    eLicenseType regularMotorcycleLicenseType = new eLicenseType();
                    MotorCycle.IsValidLicenseType(int.Parse(i_UniqueParamsPerType[1]));
                    Enum.TryParse(i_UniqueParamsPerType[1], true, out regularMotorcycleLicenseType);
                    int regularMotorcycleEngineVolume = int.Parse(i_UniqueParamsPerType[0]);

                    vehicle = new MotorCycle(i_LicenseNumber, i_Model, k_MotorcycleNumOfWheels, i_WheelManufacturer, i_CurrentAirPressure, k_MotorcylceMaxWheelAirPressure, k_RegularMotorcycleFuel,
                        k_RegularMotorcycleTankVolume, regularMotorcycleLicenseType, regularMotorcycleEngineVolume, i_EnergyLeftPercentage);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    eLicenseType electricMotorcycleLicenseType = new eLicenseType();
                    MotorCycle.IsValidLicenseType(int.Parse(i_UniqueParamsPerType[1]));

                    Enum.TryParse(i_UniqueParamsPerType[1], true, out electricMotorcycleLicenseType);
                    int electricMotorcycleEngineVolume = int.Parse(i_UniqueParamsPerType[0]);

                    vehicle = new MotorCycle(i_LicenseNumber, i_Model, k_MotorcycleNumOfWheels, i_WheelManufacturer, i_CurrentAirPressure, k_MotorcylceMaxWheelAirPressure, k_ElectricVehicleEnergy,
                        k_ElectricMotorcycleEngineCapacity, electricMotorcycleLicenseType, electricMotorcycleEngineVolume, i_EnergyLeftPercentage);
                    break;
                default:
                    throw new ArgumentException("Invalid value!");
            }

            return vehicle;
        }

        public static string[] GetParamsForType(int input)
        {
            switch ((eVehicleType)input)
            {
         
                case (eVehicleType.RegularCar):
                    return new string[] {"The Car's color:\n1 - Yellow\n2 - White\n3 - Red\n4 - Black", "The doors amount (2 - 5)"};
                case (eVehicleType.ElectricCar):
                    return new string[] {"The Car's color:\n1 - Yellow\n2 - White\n3 - Red\n4 - Black", "The doors amount (2 - 5)"};
                case eVehicleType.ElectricMotorcycle:
                    return new string[] { "The engine volume:", "The license type:\n1 - A\n2 - A1\n3 - AA\n4 - B1" };
                case eVehicleType.RegularMotorcycle:
                    return new string[] { "The engine volume:", "The license type:\n1 - A\n2 - A1\n3 - AA\n4 - B1" };
                case eVehicleType.Truck:
                    return new string[] { "The cargo volume:", "Is it hazardous (True / False):"};
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }

        public static void isValidVehicleType(int i_VehicleType)
        {
            if (!Enum.IsDefined(typeof(eVehicleType), i_VehicleType))
            {
                throw new ArgumentException();
            }
        }
    }
}

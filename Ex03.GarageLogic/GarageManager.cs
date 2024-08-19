using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Ex03.GarageLogic.VehicleCreator;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, OrderDetails> m_LicenseOrderDict;
        private List<Vehicle> m_VehicleList;

        public GarageManager()
        {
            m_LicenseOrderDict = new Dictionary<string, OrderDetails>();
            m_VehicleList = new List<Vehicle>();
        }
        public bool IsVehicleExists(string i_LicenseNum)
        {
            bool isFound = m_LicenseOrderDict.ContainsKey(i_LicenseNum);

            return isFound;
        }
        public Vehicle CreateNewVehicle(int i_VehicleType, string i_LicenseNumber, string i_Model, string i_WheelManufacturer, float i_CurrentAirPressure, List<string> i_UniqueParamsPerType, float i_EnergyLeftPercentage)
        {
            eVehicleType eVehicleTypeToAdd = new eVehicleType();
            VehicleCreator.isValidVehicleType(i_VehicleType);
            eVehicleTypeToAdd = (eVehicleType)i_VehicleType;
            Vehicle newVehicle = VehicleCreator.CreateVehicle(eVehicleTypeToAdd, i_LicenseNumber, i_Model, i_WheelManufacturer, i_CurrentAirPressure, i_UniqueParamsPerType, i_EnergyLeftPercentage);

            return newVehicle;
        }
        public OrderDetails CreateNewOrder(string i_LicenseNumber, string i_OwnerName, string i_OwnerPhone)
        {
            OrderDetails newOrder = new OrderDetails(i_OwnerName, i_OwnerPhone);

            return newOrder;
        }

        public void AddOrderToDictionary(string i_LicenseNumber, OrderDetails i_newOrder)
        {
            m_LicenseOrderDict.Add(i_LicenseNumber, i_newOrder);
        }

        public void AddNewVehicleToList(Vehicle i_newVehicle)
        {
            m_VehicleList.Add(i_newVehicle);
        }
        public List<string> GetVehiclesLicenseNumberByState(int i_State)
        {
            List<string> vehicleLicensesByType = new List<string>();
            eVehicleState eVehicleStateForFiltering = new eVehicleState();

            OrderDetails.isValidVehicleState(i_State);
            eVehicleStateForFiltering = (eVehicleState)i_State;
            foreach (KeyValuePair<string, OrderDetails> kvp in m_LicenseOrderDict)
            {
                if (kvp.Value.eVehicleState == eVehicleStateForFiltering || eVehicleStateForFiltering == eVehicleState.All)
                {
                    vehicleLicensesByType.Add(kvp.Key);
                }
            }

            return vehicleLicensesByType;
        }
        public void SetVehicleState(string i_LicenseNumber, int i_NewState)
        {
            eVehicleState eNewState = new eVehicleState();

            ThrowExceptionIfLicenseNotFound(i_LicenseNumber);
            OrderDetails.isValidVehicleState(i_NewState);
            eNewState = (eVehicleState)i_NewState;
            m_LicenseOrderDict[i_LicenseNumber].eVehicleState = eNewState;
        }
        public void InflateAirInWheelsToMaximum(string i_LicenseNumber)
        {
            ThrowExceptionIfLicenseNotFound(i_LicenseNumber);
            foreach (Vehicle vehicle in m_VehicleList)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    foreach (Wheel wheel in vehicle.VehicleWheels)
                    {
                        wheel.AddAir(wheel.MaximumAirPressure - wheel.CurrentAirPressure);
                    }
                    break;
                }
            }
        }
        public void FuelOrChargeVehicle(string i_LicenseNumber, int i_FuelType, float i_EnergyAmountToAdd)
        {
            float percentageToAdd;
            eEnergyType eFuelType = new eEnergyType();

            ThrowExceptionIfLicenseNotFound(i_LicenseNumber);
            Engine.isValidEnergyType(i_FuelType);
            eFuelType = (eEnergyType)i_FuelType;
            foreach (Vehicle vehicle in m_VehicleList)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    if (eFuelType == vehicle.Engine.EnergyType)
                    {
                        if (eFuelType != eEnergyType.Electric)
                        {
                            percentageToAdd = i_EnergyAmountToAdd / vehicle.Engine.MaximumCapacity * 100;
                        }
                        else
                        {
                            percentageToAdd = (i_EnergyAmountToAdd / 60) / vehicle.Engine.MaximumCapacity * 100;
                        }

                        vehicle.AddEnergyToVehicle(percentageToAdd);
                        break;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }
        public void GetVehicleAndClientDetails(string i_LicenseNumber, out OrderDetails o_OrderDetails, out Vehicle o_Vehicle)
        {
            o_Vehicle = null;
            o_OrderDetails = m_LicenseOrderDict[i_LicenseNumber];

            ThrowExceptionIfLicenseNotFound(i_LicenseNumber);
            foreach (Vehicle vehicle in m_VehicleList)
            {
                if (vehicle.LicenseNumber == i_LicenseNumber)
                {
                    o_Vehicle = vehicle;
                    break;
                }
            }
        }

        public string[] GetUniqueParamsForType(int i_Type)
        {
            return VehicleCreator.GetParamsForType(i_Type);
        }
        public void ThrowExceptionIfLicenseNotFound(string i_LicenseNumber)
        {
            bool isLicenseFound = IsVehicleExists(i_LicenseNumber);

            if (!isLicenseFound)
            {
                throw new ArgumentException();
            }
        }
    }
}

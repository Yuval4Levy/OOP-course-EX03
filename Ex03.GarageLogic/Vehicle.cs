using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        const int k_MaxEnergyLeftPercentage = 100;
        private readonly string r_LicenseNumber;
        private readonly string r_Model;
        private float m_EnergeyLeftPercentage;
        private List<Wheel> m_VehicleWheels;
        private Engine m_Engine;

        public Vehicle(string i_LicenseNumber, string i_Model, int i_NumOfWheels, string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressure, eEnergyType i_eEnergyType, float i_MaximumEngineCapacity, float i_EnergyLeftPercentage)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_Model = i_Model;
            m_VehicleWheels = new List<Wheel>(i_NumOfWheels);
            Wheel.IsValidAirPressure(i_CurrentAirPressure, i_MaxAirPressure);
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(i_Manufacturer, i_CurrentAirPressure, i_MaxAirPressure));
            }
            m_Engine = new Engine(i_eEnergyType, i_MaximumEngineCapacity);
            IsEnergyLeftValid(i_EnergyLeftPercentage);
            m_EnergeyLeftPercentage = i_EnergyLeftPercentage;
        }
        public string LicenseNumber
        {
            get { return r_LicenseNumber; }
        }
        public string Model
        {
            get { return r_Model; }
        }
        public float EnergeyLeftPercentage
        {
            get { return m_EnergeyLeftPercentage; }
            set { m_EnergeyLeftPercentage = value; }
        }
        public List<Wheel> VehicleWheels
        {
            get { return m_VehicleWheels; }
        }
        public Engine Engine
        { get { return m_Engine; } }
        public void AddEnergyToVehicle(float i_PercentageToAdd)
        {
            if (m_EnergeyLeftPercentage + i_PercentageToAdd > k_MaxEnergyLeftPercentage)
            {
                throw new ValueOutOfRangeException(0, k_MaxEnergyLeftPercentage - m_EnergeyLeftPercentage);
            }
            else
            {
                m_EnergeyLeftPercentage += i_PercentageToAdd;
            }
        }
        public static void IsEnergyLeftValid(float i_EnergyLeft)
        {
            if (i_EnergyLeft < 0 || i_EnergyLeft > k_MaxEnergyLeftPercentage)
            {
                throw new ArgumentException();
            }
        }

        // $G$ NTT-999 (-0) You should have used Environment.NewLine instead of "\n".
        public override string ToString()
        {
            return string.Format("Model: {0}\nLicense Number: {1}\nEnergy Level: {2}\n{3}\n{4}\n", r_Model, r_LicenseNumber, m_EnergeyLeftPercentage, m_Engine.ToString(), m_VehicleWheels[0].ToString());
        }
    }
}

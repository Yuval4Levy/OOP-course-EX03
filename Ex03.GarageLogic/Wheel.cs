using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_Manufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaximumAirPressure;

        public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            r_Manufacturer = i_Manufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaximumAirPressure = i_MaximumAirPressure;
        }
        public void AddAir(float i_AirToAdd)
        {
            if (i_AirToAdd + m_CurrentAirPressure > r_MaximumAirPressure || i_AirToAdd < 0)
            {
                float maxAvilableAirToAdd = r_MaximumAirPressure - m_CurrentAirPressure;
                throw new ValueOutOfRangeException(0, maxAvilableAirToAdd);
            }
            else
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }
        public string Manufacturer
        {
            get { return r_Manufacturer; }
        }
        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }
        public float MaximumAirPressure
        {
            get { return r_MaximumAirPressure; }
        }
        public static void IsValidAirPressure(float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            if (i_CurrentAirPressure < 0 || i_CurrentAirPressure > i_MaxAirPressure)
            {
                throw new ArgumentException();
            }
        }

        // $G$ NTT-999 (-0) You should have used Environment.NewLine instead of "\n".
        public override string ToString()
        {
            return string.Format("The manufacturer of the wheels is: {0}\nThe current air pressure is: {1}\nThe maximum air pressure of the wheels is: {2}", r_Manufacturer, m_CurrentAirPressure, r_MaximumAirPressure);
        }
    }
}

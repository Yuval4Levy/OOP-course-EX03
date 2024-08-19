using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class OrderDetails
    {
        private readonly string r_OwnerName;
        private readonly string r_OwnerPhone;
        private eVehicleState m_eVehicleState;

        public OrderDetails(string i_OwnerName, string i_OwnerPhone)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;
            m_eVehicleState = eVehicleState.InWork;
        }
        public OrderDetails(string i_OwnerName, string i_OwnerPhone, eVehicleState i_VehicleFixingState)
        {
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;
            m_eVehicleState = i_VehicleFixingState;
        }
        public string OwnerName
        {
            get { return r_OwnerName; }
        }
        public string OwnerPhone
        {
            get { return r_OwnerPhone; }
        }
        public eVehicleState eVehicleState
        {
            get { return m_eVehicleState; }
            set { m_eVehicleState = value; }
        }
        public static void isValidVehicleState(int i_VehicleFixingState)
        {
            if (!Enum.IsDefined(typeof(eVehicleState), i_VehicleFixingState))
            {
                throw new ArgumentException();
            }
        }

        // $G$ NTT-999 (-0) You should have used Environment.NewLine instead of "\n".
        public override string ToString()
        {
            return string.Format("The owner's name is: {0}\nThe owner's phone number is: {1}\nThe vehicle state is: {2}", r_OwnerName, r_OwnerPhone, m_eVehicleState);
        }
    }
}

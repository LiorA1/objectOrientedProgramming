using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        OnRepair = 1,
        Repaired,
        Paid
    }

    // $G$ CSS-999 (-3) Each enum/class/struct which is not nested should be in a separate file.
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseNumber;
        private List<Wheel> m_VehicleWheels;
        private eVehicleStatus m_Status;
        private PowerSource m_PowerSource;

        protected Vehicle(string i_ModelName, string i_LicenseNumber, Wheel i_Wheel, int i_NumOfWheels, eVehicleStatus i_eStatus, PowerSource m_PowerSource)
        {
            this.r_ModelName = i_ModelName ?? throw new ArgumentNullException(nameof(r_ModelName));
            this.r_LicenseNumber = i_LicenseNumber ?? throw new ArgumentNullException(nameof(r_LicenseNumber));
            this.m_Status = i_eStatus;
            this.m_PowerSource = m_PowerSource ?? throw new ArgumentNullException(nameof(m_PowerSource));
            m_VehicleWheels = new List<Wheel>();

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_VehicleWheels.Add(i_Wheel);
            }
        }

        public PowerSource PowerSource
        {
            get { return this.m_PowerSource; }
            set { this.m_PowerSource = value; }
        }

        public void InflateWheelsToMax()
        {
            foreach(Wheel wheel in this.m_VehicleWheels)
            {
                wheel.InflateToMax();
            }
        }   

        public eVehicleStatus VehicleStatus
        {
            get { return this.m_Status; }
            set { this.m_Status = value; }
        }

        public string ModelName
        {
            get { return this.r_ModelName; }
        }

        public string LicenseNumber
        {
            get { return this.r_LicenseNumber; }
        }

        public override string ToString()
        {
            string details = string.Format(
                @"License Number: {0}
Model: {1}
Power type: {2}. Current power state: {3}
Vehicle status: {4}
Wheel info: {5}
",
r_LicenseNumber,
r_ModelName,
PowerSource.ToString(),
PowerSource.CurrAmount,
VehicleStatus.ToString(),
m_VehicleWheels[0].ToString());

            return details;
        }
    }
}

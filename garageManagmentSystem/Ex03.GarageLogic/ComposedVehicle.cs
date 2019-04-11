using System;

namespace Ex03.GarageLogic
{
    public class ComposedVehicle
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;

        public ComposedVehicle(Vehicle m_Vehicle, string m_OwnerName, string m_OwnerPhoneNumber)
        {
            this.m_Vehicle = m_Vehicle ?? throw new ArgumentNullException(nameof(m_Vehicle));
            this.m_OwnerName = m_OwnerName ?? throw new ArgumentNullException(nameof(m_OwnerName));
            this.m_OwnerPhoneNumber = m_OwnerPhoneNumber ?? throw new ArgumentNullException(nameof(m_OwnerPhoneNumber));
        }

        public string LicenseNumber
        {
            get
            {
                return m_Vehicle.LicenseNumber;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_Vehicle.VehicleStatus; }
            set { m_Vehicle.VehicleStatus = value; }
        }

        public PowerSource PowerSource
        {
            get { return m_Vehicle.PowerSource; }
        }

        public void InflateWheelsToMax()
        {
            m_Vehicle.InflateWheelsToMax();
        }

        public override string ToString()
        {
            return $@"Owner Name: {m_OwnerName}
Owner number: {m_OwnerPhoneNumber}
{m_Vehicle}";
        }
    }
}

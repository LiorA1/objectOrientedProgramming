namespace Ex03.GarageLogic
{
    public enum eLicencseType
    {
        A1,
        A2,
        AB,
        B
    }

    public class Motorcycle : Vehicle
    {
        private readonly int r_EngineCapacity;
        private eLicencseType m_LicenseType;

        public Motorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            Wheel i_Wheel,
            int i_NumOfWheels, 
            eVehicleStatus i_eStatus,
            PowerSource i_PowerSource,
            eLicencseType i_LicenseType,
            int i_EngineCapacity) : base(i_ModelName, i_LicenseNumber, i_Wheel, i_NumOfWheels, i_eStatus, i_PowerSource)
        {
            this.m_LicenseType = i_LicenseType;
            this.r_EngineCapacity = i_EngineCapacity; 
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
License type: {m_LicenseType}
Engine capacity: {r_EngineCapacity}";
        }
    }
}

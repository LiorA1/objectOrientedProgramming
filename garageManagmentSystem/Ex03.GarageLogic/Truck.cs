namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly float r_TrunkCapticity;
        private bool m_CooledTrunk;

        public Truck(string i_ModelName, string i_LicenseNumber, Wheel i_Wheel, int i_NumOfWheels, eVehicleStatus i_eStatus, PowerSource m_PowerSource, float i_RTrunkCapticity, bool i_MCooledTrunk) : base(i_ModelName, i_LicenseNumber, i_Wheel, i_NumOfWheels, i_eStatus, m_PowerSource)
        {
            r_TrunkCapticity = i_RTrunkCapticity;
            m_CooledTrunk = i_MCooledTrunk;
        }

        public float TrunkCapticity
        {
            get { return this.r_TrunkCapticity; }
        }

        public bool CooledTrunk
        {
            get { return this.m_CooledTrunk; }
            set { this.m_CooledTrunk = value; }
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Trunk capacity: {r_TrunkCapticity}
Is trunk cooled: {m_CooledTrunk}";
        }
    }
}

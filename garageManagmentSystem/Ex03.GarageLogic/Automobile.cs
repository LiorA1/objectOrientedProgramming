namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Gray,
        White,
        Green,
        Purple
    }

    public enum eNumOfDoors
    {
        Two = 2,
        Three,
        Four,
        Five
    }

    public class Automobile : Vehicle
    {
        private readonly eNumOfDoors m_NumOfDoors;
        private eColor m_Color;

        public Automobile(string i_ModelName, string i_LicenseNumber, Wheel i_Wheel, int i_NumOfWheels, eVehicleStatus i_eStatus, PowerSource m_PowerSource, eColor i_MColor, eNumOfDoors i_MNumOfDoors) : base(i_ModelName, i_LicenseNumber, i_Wheel, i_NumOfWheels, i_eStatus, m_PowerSource)
        {
            m_Color = i_MColor;
            m_NumOfDoors = i_MNumOfDoors;
        }

        public eColor Color
        {
            get { return this.m_Color; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return this.m_NumOfDoors; }
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Color: {m_Color.ToString()}
Number of doors {m_NumOfDoors}";
        }
    }
}

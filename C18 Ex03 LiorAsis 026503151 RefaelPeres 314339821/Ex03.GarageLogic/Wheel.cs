namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private readonly float r_MaxPressure;
        private float m_CurrPressure;

        public Wheel(string i_NameOfManufacture, float i_MaxPressure, float i_CurrentPressure)
        {
            r_ManufacturerName = i_NameOfManufacture;
            r_MaxPressure = i_MaxPressure;
            CurrPressure = i_CurrentPressure;
        }

        public override string ToString()
        {
            return $"Manufacturer: {ManufacturerName}. Current air pressure: {CurrPressure}";
        }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }
    
        public float MaxPressure
        {
            get { return r_MaxPressure; }
        }

        public float CurrPressure
        {
            get => m_CurrPressure;
            set
            {
                if (value + m_CurrPressure <= MaxPressure)
                {
                    m_CurrPressure += value;
                }
                else
                {
                    var voore = new ValueOutOfRangeException(0, this.MaxPressure);
                    voore.Source = this.GetType().Name + " Pressure";
                    throw voore;
                }
            }
        }
    
        public void InflateToMax()
        {
            m_CurrPressure = r_MaxPressure;
        }

        public void InflatingWheel(float i_InflationUnitsToAdd)
        {
            if(i_InflationUnitsToAdd + m_CurrPressure <= r_MaxPressure)
            {
                m_CurrPressure += i_InflationUnitsToAdd;
            }
            else
            {
                // Pressure asked is too big.
                var voore = new ValueOutOfRangeException(0, this.MaxPressure);
                voore.Source = this.GetType().Name;
                throw voore;
            }
        }
    }
}

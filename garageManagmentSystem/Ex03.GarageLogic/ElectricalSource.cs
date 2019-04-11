namespace Ex03.GarageLogic
{
    public class ElectricalSource : PowerSource
    {
        public ElectricalSource(float i_MaxHours, float i_CurrentAmount) : base(i_MaxHours, i_CurrentAmount)
        {
        }

        // This method charge the engine battery, only if it is less than MaxCap.
        public void Charge(float i_NumHoursCharged)
        {
            if (this.MaxCapacity >= this.CurrAmount + i_NumHoursCharged)
            {
                this.CurrAmount += i_NumHoursCharged;
            }
            else
            {
                // Charged Amount is too big. 
                var voore = new ValueOutOfRangeException(0, this.MaxCapacity);
                voore.Source = this.GetType().Name;
                throw voore;
            }
        }

        public override string ToString()
        {
            return "Electric";
        }
    }
}
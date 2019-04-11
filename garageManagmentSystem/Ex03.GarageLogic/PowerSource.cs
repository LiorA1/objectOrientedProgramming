namespace Ex03.GarageLogic
{
    public abstract class PowerSource
    {
        private float m_CurrentAmount;

        public PowerSource(float i_MaxCapacity, float i_CurrentAmount)
        {
            MaxCapacity = i_MaxCapacity;
            CurrAmount = i_CurrentAmount;
        }

        public float MaxCapacity { get; }

        public float CurrAmount
        {
            get { return m_CurrentAmount; }
            set
            {
                if(value + m_CurrentAmount <= MaxCapacity)
                {
                    m_CurrentAmount += value;
                }
                else
                {
                    var voore = new ValueOutOfRangeException(0, this.MaxCapacity);
                    voore.Source = this.GetType().Name;
                    throw voore;
                }
            }
        }

        // Return true, if the quantity can be added.
        // Else, False.
        public bool ValidateAmountToBeAdded(float i_QuantityToBeAdded)
        {
            bool isAmountValid = false;

            if (CurrAmount + i_QuantityToBeAdded <= MaxCapacity)
            {
                isAmountValid = true;
            }

            return isAmountValid;
        }
    }
}

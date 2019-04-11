using System;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Octan95 = 1,
        Octan96,
        Octan98,
        Soler
    }

    public class FuelSource : PowerSource
    {
        private readonly eFuelType r_FuelType;

        public FuelSource(float i_MaxLiters, float i_CurrentAmount, eFuelType i_FuelType) : base(i_MaxLiters, i_CurrentAmount)
        {
            this.r_FuelType = i_FuelType;
        }

        public override string ToString()
        {
            return "Fuel";
        }

        // This method, is refueling the fuelSource, only if same fuel type and amount is legal.
        public void Refuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            if(this.r_FuelType != i_FuelType)
            {
                throw new ArgumentException();
            }

            if (this.MaxCapacity >= i_AmountToAdd + this.CurrAmount )
            {
                // Everything is fine.
                this.CurrAmount += i_AmountToAdd;
            }
            else
            {
                // Too big Amount.
                var voore = new ValueOutOfRangeException(0, this.MaxCapacity);
                voore.Source = this.GetType().Name;
                throw voore;
            }
        }
    }
}

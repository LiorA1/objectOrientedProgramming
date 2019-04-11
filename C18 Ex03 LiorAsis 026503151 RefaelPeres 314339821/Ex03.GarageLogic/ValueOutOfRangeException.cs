using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_MinVal, float i_MaxVal) : base()
        {
            this.m_MinValue = i_MinVal;
            this.m_MaxValue = i_MaxVal;
        }

        public float MinValue
        {
            get { return this.m_MinValue; }
        }

        public float MaxValue
        {
            get { return this.m_MaxValue; }
        }

        public override string Message
        {
            get { return $"Out of range value in {Source}. Expected value from {m_MinValue} to {m_MaxValue}."; }
        }
    }
}

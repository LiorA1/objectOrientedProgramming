namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public static Vehicle CreateMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturer, 
            float i_CurrentAirPressure,
            float i_CurrentPower,
            eLicencseType i_eLicenseType,
            int i_EngineCapacity)
        {
            Vehicle fueledMotorcycle = new Motorcycle(
                i_ModelName,
                i_LicenseNumber,
                new Wheel(i_WheelManufacturer, 28, i_CurrentAirPressure),
                2,
                eVehicleStatus.OnRepair,
                new FuelSource(5, i_CurrentPower, eFuelType.Octan95),
                i_eLicenseType,
                i_EngineCapacity);

            return fueledMotorcycle;
        }

        public static Vehicle CreateElectricMotorcycle(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_CurrentAirPressure,
            float i_CurrentPower,
            eLicencseType i_eLicenseType,
            int i_EngineCapacity)
        {
            Vehicle electricMotorcycle = new Motorcycle(
                i_ModelName,
                i_LicenseNumber,
                new Wheel(i_WheelManufacturer, 28, i_CurrentAirPressure),
                2,
                eVehicleStatus.OnRepair,
                new ElectricalSource(3.2f, i_CurrentPower),
                i_eLicenseType,
                i_EngineCapacity);

            return electricMotorcycle;
        }

        public static Vehicle CreateAutomobile(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturer, 
            float i_CurrentAirPressure,
            float i_CurrentPower,
            eColor i_eColor,
            eNumOfDoors i_eNumOfDoors)
        {
            Vehicle fueledAutomobile = new Automobile(
                i_ModelName,
                i_LicenseNumber,
                new Wheel(i_WheelManufacturer, 30, i_CurrentAirPressure),
                4,
                eVehicleStatus.OnRepair,
                new FuelSource(48, i_CurrentPower, eFuelType.Octan96),
                i_eColor,
                i_eNumOfDoors);

            return fueledAutomobile;
        }

        public static Vehicle CreateElectricAutomobile(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturer, 
            float i_CurrentAirPressure,
            float i_CurrentPower,
            eColor i_eColor,
            eNumOfDoors i_eNumOfDoors)
        {
            Vehicle electricAutomobile = new Automobile(
                i_ModelName,
                i_LicenseNumber,
                new Wheel(i_WheelManufacturer, 30, i_CurrentAirPressure),
                4,
                eVehicleStatus.OnRepair,
                new ElectricalSource(4.8f, i_CurrentPower),
                i_eColor,
                i_eNumOfDoors);

            return electricAutomobile;
        }

        public static Vehicle CreateTruck(
            string i_ModelName,
            string i_LicenseNumber,
            string i_WheelManufacturer,
            float i_CurrentAirPressure,
            float i_CurrentPower,
            float i_TruckCapacity,
            bool i_IsTrunkCooled)
        {
            Vehicle truck = new Truck(
                i_ModelName,
                i_LicenseNumber,
                new Wheel(i_WheelManufacturer, 32, i_CurrentAirPressure),
                16,
                eVehicleStatus.OnRepair,
                new FuelSource(105, i_CurrentPower, eFuelType.Soler),
                i_TruckCapacity,
                i_IsTrunkCooled);

            return truck;
        }
    }
}

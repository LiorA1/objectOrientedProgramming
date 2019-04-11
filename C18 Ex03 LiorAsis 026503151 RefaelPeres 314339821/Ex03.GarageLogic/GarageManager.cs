using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public enum eValidVehicle
    {
        RegMotorCycle = 1,
        ElectricalCycle,
        RegCar,
        ElectricalCar,
        Truck
    }

    public class GarageManager
    {
        private Dictionary<string, ComposedVehicle> m_VehiclesInGarage;

        public GarageManager()
        {
            this.m_VehiclesInGarage = new Dictionary<string, ComposedVehicle>(); 
        }

        public Dictionary<string, ComposedVehicle> VehiclesInGarage
        {
            get { return this.m_VehiclesInGarage; }
        }

        public ComposedVehicle CreateAutomobile(
            eValidVehicle i_eValidVehicle,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_LicenseNumber,
            string i_ModelName,
            string i_WheelManufacturer, 
            float i_WheelPressure,
            float i_CurrentPower,
            eColor i_eColor,
            eNumOfDoors i_eNumOfDoors)
        {
            Vehicle vehicle;
            ComposedVehicle composedVehicle;

            if (i_eValidVehicle == eValidVehicle.RegCar)
            {
                vehicle = VehicleFactory.CreateAutomobile(
                    i_ModelName,
                    i_LicenseNumber,
                    i_WheelManufacturer,
                    i_WheelPressure,
                    i_CurrentPower,
                    i_eColor,
                    i_eNumOfDoors);
            }
            else
            {
                vehicle = VehicleFactory.CreateElectricAutomobile(
                    i_ModelName,
                    i_LicenseNumber,
                    i_WheelManufacturer,
                    i_WheelPressure,
                    i_CurrentPower,
                    i_eColor,
                    i_eNumOfDoors);
            }
            
            composedVehicle = new ComposedVehicle(vehicle, i_OwnerName, i_OwnerPhoneNumber);

            return composedVehicle;
        }

        public ComposedVehicle CreateMotorcycle(
            eValidVehicle i_eValidVehicle,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_LicenseNumber,
            string i_ModelName,
            string i_WheelManufacturer, 
            float i_WheelPressure,
            float i_CurrentPower,
            eLicencseType i_eLicenseType,
            int i_EngineCapacity)
        {
            Vehicle vehicle;
            ComposedVehicle composedVehicle;

            if (i_eValidVehicle == eValidVehicle.RegMotorCycle)
            {
                vehicle = VehicleFactory.CreateMotorcycle(
                    i_ModelName,
                    i_LicenseNumber,
                    i_WheelManufacturer,
                    i_WheelPressure,
                    i_CurrentPower,
                    i_eLicenseType,
                    i_EngineCapacity);
            }
            else
            {
                vehicle = VehicleFactory.CreateElectricMotorcycle(
                    i_ModelName,
                    i_LicenseNumber,
                    i_WheelManufacturer,
                    i_WheelPressure,
                    i_CurrentPower,
                    i_eLicenseType,
                    i_EngineCapacity);
            }

            composedVehicle = new ComposedVehicle(vehicle, i_OwnerName, i_OwnerPhoneNumber);

            return composedVehicle;
        }

        public ComposedVehicle CreateTruck(
            eValidVehicle i_eValidVehicle,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string i_LicenseNumber,
            string i_ModelName,
            string i_WheelManufacturer, 
            float i_WheelPressure,
            float i_CurrentPower,
            float i_TruckCapacity,
            bool i_IsCooled)
        {
            Vehicle vehicle = VehicleFactory.CreateTruck(i_ModelName, i_LicenseNumber, i_WheelManufacturer, i_WheelPressure, i_CurrentPower, i_TruckCapacity, i_IsCooled);
            ComposedVehicle composedVehicle = new ComposedVehicle(vehicle, i_OwnerName, i_OwnerPhoneNumber);

            return composedVehicle;
        }
        
        // Insert a some approved Vehicle to the garage.
        public bool InsertVehicle(ComposedVehicle i_Vehicle)
        {
            bool successfulInsert = false;
            if(i_Vehicle != null)
            {
                this.m_VehiclesInGarage.Add(i_Vehicle.LicenseNumber, i_Vehicle);
                successfulInsert = true;
            }
            else
            {
                // throw nullReferenceException.
                throw new ArgumentException();
            }

            return successfulInsert;
        }

        // Show Licenses numbers (All or by CurrStatus(eVehicleStatus))
        public List<string> GetAllVehiclesLicensesNumbers()
        {
            List<string> allVehicles = new List<string>();

            foreach(KeyValuePair<string, ComposedVehicle> vehicleIter in this.VehiclesInGarage)
            {
                allVehicles.Add(vehicleIter.Key);
            }

            return allVehicles;
        }

        public List<string> GetVehiclesLicenseFilterdByStatus(eVehicleStatus i_VehicleStatus)
        {
            List<string> filterdVehicles = new List<string>();

            foreach(ComposedVehicle vehicle in this.m_VehiclesInGarage.Values)
            {
                if(vehicle.VehicleStatus == i_VehicleStatus)
                {
                    // Insert.(status is valid)
                    filterdVehicles.Add(vehicle.LicenseNumber);
                }
            }
            
            return filterdVehicles;
        }

        // Change The Vehicle Status.(parameters : licence, newStatus).
        public bool ChangeVehicleStatus(string i_License, eVehicleStatus i_NewStatus)
        {
            // Return true, if exists.
            bool changedVehicleStatusExists = this.VehiclesInGarage.TryGetValue(i_License, out var vehicleThatIsInTheGarage);
            
            if(changedVehicleStatusExists)
            {
                vehicleThatIsInTheGarage.VehicleStatus = i_NewStatus;
            }
            else
            {
                // !changedVehicleStatusExists
                throw new ArgumentException();
            }

            return changedVehicleStatusExists;
        }

        // Inflate Wheels to max. (By License number).
        public void InflateWheelsToMax(string i_License)
        {
            ComposedVehicle VehicleThatIsInTheGarage;

            bool VehicleToInflateWheelsExists = this.VehiclesInGarage.TryGetValue(i_License, out VehicleThatIsInTheGarage);

            if(VehicleToInflateWheelsExists)
            {
                VehicleThatIsInTheGarage.InflateWheelsToMax();
            }
            else
            {
                // !VehicleToInflateWheelsExists
                throw new ArgumentException();
            }
        }

        // Refuel by License Number, parameters : License number, FuelType, Amount.
        public void RefuelVehicle(string i_License, eFuelType i_FuelType, float i_AmountToFuel)
        {
            ComposedVehicle VehicleThatIsInTheGarage;

            bool VehicleToRefuelExists = this.VehiclesInGarage.TryGetValue(i_License, out VehicleThatIsInTheGarage);
            
            if(VehicleToRefuelExists)
            {
                FuelSource fS = VehicleThatIsInTheGarage.PowerSource as FuelSource;

                if (fS != null)
                {
                    fS.Refuel(i_AmountToFuel, i_FuelType);
                }
                else
                {
                    // PowerSource is not Fuel.
                    // PowerSource of the asked vehicle is not fuel.(
                    throw new ArgumentException();
                }
            }
            else
            {
                // !VehicleToRefuelExists
                throw new ArgumentException();
            }
        }

        // Recharge by License, Amount(Minutes).
        public void RechargeVehicle(string i_License, float i_MinutesToCharge)
        {
            const float minutesInAHour = 60;
            float hoursToCharge = i_MinutesToCharge / minutesInAHour;
            ComposedVehicle vehicleThatIsInTheGarage;

            bool vehicleToRechargeExists = this.VehiclesInGarage.TryGetValue(i_License, out vehicleThatIsInTheGarage);

            if (vehicleToRechargeExists)
            {
                ElectricalSource eS = vehicleThatIsInTheGarage.PowerSource as ElectricalSource;

                if (eS != null)
                {
                    eS.Charge(hoursToCharge);
                }
                else
                {
                    // PowerSource is not Electrical.
                    // PowerSource of the asked vehicle is not Electrical.
                    throw new ArgumentException();
                }
            }
            else
            {
                // !VehicleToRechargeExists
                throw new ArgumentException();
            }
        }
        
        // Return Vehicle Data : License, ModelName, OwnerName, CurrStatus, Wheels Data, Energy Level, FuelType OR BatteryStatus,
        public ComposedVehicle GetVehicle(string i_License)
        {
            ComposedVehicle vehicleToBeReturned = null;
            bool VehicleExists = this.VehiclesInGarage.TryGetValue(i_License, out vehicleToBeReturned);
            
            if(!VehicleExists)
            {
                throw new ArgumentException();
            }
            
            return vehicleToBeReturned;
        }

        public bool IsVehicleInGarage(string i_License)
        {
            return m_VehiclesInGarage.ContainsKey(i_License);
        }

        public string GetVehicleDetails(string i_License)
        {
            ComposedVehicle cmpVehicle = null;
            string details;
            bool isVehicleInGarage = IsVehicleInGarage(i_License);
            if (IsVehicleInGarage(i_License))
            {
                cmpVehicle = GetVehicle(i_License);
                details = cmpVehicle.ToString();
            }
            else
            {
                details = $"There's no vehicle with license {i_License}" +
                    $" in the garage.";
            }

            return details;
        }
    }
}

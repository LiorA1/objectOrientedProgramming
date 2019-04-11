using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class DataExtractor
    {
        public DataExtractor(eValidVehicle vehicleType, string licenseNumber)
        {
            VehicleType = vehicleType;
            LicenseNumber = licenseNumber ?? throw new ArgumentNullException(nameof(licenseNumber));

            Console.WriteLine("Please enter your name:");
            OwnerName = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");
            OwnerNumber = Console.ReadLine();
            Console.WriteLine("Enter model name:");
            Model = Console.ReadLine();
            Console.WriteLine("Enter wheel manufacturer:");
            WheelManufacturer = Console.ReadLine();
            getExtraDetails();
            getVechicleSpecificDetails();
        }

        public eValidVehicle VehicleType { get; }

        public string LicenseNumber { get; }

        public string OwnerName { get; }

        public string OwnerNumber { get; }

        public string Model { get; private set; }

        public float PowerLeft { get; private set; }

        public string WheelManufacturer { get; private set; }

        public float CurrentWheelPressure { get; set; }
        
        // Motorcycle
        public int EngineSize { get; private set; }

        public eLicencseType ELicenseType { get; private set; }

        // Automobile
        public eColor EColor { get; private set; }

        public eNumOfDoors ENumOfDoors { get; private set; }

        // Truck
        public float TruckCapacity { get; private set; }

        public bool IsCooled { get; private set; }

        private void getExtraDetails()
        {
            float wheelPressure = 0, currentPowerState = 0;
            bool isValidPressure = false;
            while (!isValidPressure)
            {
                Console.WriteLine("Enter valid wheel pressure:");
                isValidPressure = float.TryParse(Console.ReadLine(), out wheelPressure);
            }

            CurrentWheelPressure = wheelPressure;

            bool isValidPowerState = false;
            while (!isValidPowerState)
            {
                Console.WriteLine("Enter state of power source:");
                isValidPowerState = float.TryParse(Console.ReadLine(), out currentPowerState);
            }

            PowerLeft = currentPowerState;
        }

        private void getVechicleSpecificDetails()
        {  
            if (VehicleType == eValidVehicle.ElectricalCar || VehicleType == eValidVehicle.RegCar)
            {
                getCarDetails();
            }
            else if (VehicleType == eValidVehicle.RegMotorCycle || VehicleType == eValidVehicle.ElectricalCycle)
            {
                ELicenseType = (eLicencseType)getLicenseTypeFromString();
                getEngineSize();
            }
            else
            {
                getTruckDetails();
            }
        }

        private eLicencseType? getLicenseTypeFromString()
        {
            eLicencseType? eLicenseType = null;
            bool isValidLicense = false;

            Console.WriteLine("Please enter your license type (A1/A2/AB/B):");
            string licenseTypeStr = Console.ReadLine();

            while (!isValidLicense)
            {
                if (licenseTypeStr != null && (licenseTypeStr.Equals("A1") || licenseTypeStr.Equals("A2") || licenseTypeStr.Equals("AB") ||
                                               licenseTypeStr.Equals("B")))
                {
                    isValidLicense = true;
                    switch (licenseTypeStr)
                    {
                        case "A1":
                            eLicenseType = eLicencseType.A1;
                            break;
                        case "A2":
                            eLicenseType = eLicencseType.A2;
                            break;
                        case "AB":
                            eLicenseType = eLicencseType.AB;
                            break;
                        case "B":
                            eLicenseType = eLicencseType.B;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("License type invalid.\nPlease enter your license type (A1/A2/AB/B):");
                    licenseTypeStr = Console.ReadLine();
                }
            }

            return eLicenseType;
        }

        private void getEngineSize()
        {
            int engineSize = 0;
            bool isValidSize = false;
            
            while (!isValidSize)
            {
                Console.WriteLine("Please enter valid motorcycle engine size:");
                isValidSize = int.TryParse(Console.ReadLine(), out engineSize);
            }

            EngineSize = engineSize;
        }

        private void getTruckDetails()
        {
            bool isValidCapacity = false;
            float truckCapacity = 0;

            while (!isValidCapacity)
            {
                Console.WriteLine("Please enter truck trunk capacity:");
                isValidCapacity = float.TryParse(Console.ReadLine(), out truckCapacity);
            }

            TruckCapacity = truckCapacity;

            Console.WriteLine("Is truck truck cooled? (Yes/No)");
            IsCooled = UserInterface.GetAnswerYesOrNot("Is truck truck cooled? (Yes/No)");
        }

        private void getCarDetails()
        {
            getValidColor();
 
            Console.WriteLine("Please enter the number of doors:");
            bool isValidNumOfDoors = false;
            int numOfDoors = 0;
            while (!isValidNumOfDoors)
            {
                isValidNumOfDoors = int.TryParse(Console.ReadLine(), out numOfDoors);
                if (!isValidNumOfDoors || (numOfDoors >= (int) eNumOfDoors.Five && numOfDoors <= (int) eNumOfDoors.Two))
                {
                    isValidNumOfDoors = false;
                }
                else
                {
                    ENumOfDoors = (eNumOfDoors) numOfDoors;
                }
            }
        }

        private void getValidColor()
        {
            string colorStr = string.Empty;
            string[] colors = new[] { "Gray", "White", "Green", "Purple" };
            bool isValidColor = false;

            while (!isValidColor)
            {
                Console.WriteLine("Please enter the color of your car (Supported colors: Gray, White, Green, Purple)");
                colorStr = Console.ReadLine();
                foreach (var color in colors)
                {
                    if (colorStr.Equals(color))
                    {
                        isValidColor = true;    
                    }
                } 
            }

            switch (colorStr)
            {
                case "Gray":
                    EColor = eColor.Gray;
                    break;
                case "White":
                    EColor = eColor.White;
                    break;
                case "Purple":
                    EColor = eColor.Purple;
                    break;
                case "Green":
                    EColor = eColor.Green;
                    break;
            }
        }
    }
}

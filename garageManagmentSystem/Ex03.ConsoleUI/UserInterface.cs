using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        public enum eEntryMenuOptions
        {
            SingleVehicleOption = 1,
            GarageOption,
            Exit = 9
        }

        public enum ePerLicenseMenuOption
        {
            Insert = 1,
            ChangeStatus,
            InflateAllWheels,
            Refuel,
            Recharge,
            ShowFullVehicleDetails,
            Exit = 9
        }

        private const string k_EntryMenu =
            @"Please select an option:
1. Single vehicle option by license number (Available options).
2. Operations On all vehicles (Only show vehicles details. Optional: filterd by status).
9. Exit.";

        private const string k_PerLicenseMenu =
            @"1. Insert the vehicle to the garage.
2. Change the status of the vehicle.
3. Inflate all wheels to the maximum.
4. Refuel.
5. Recharge.
6. Show full vehicle details.
9. Exit.";

        private const string k_AllVehiclesMenu =
            @"1. Show all licenses.
2. Show licenses filtered by their status.";

        private const string k_InsertVehicleTypeSelect =
            @"Select vehicle type:
1. Motorcycle.
2. Electric Motorcycle.
3. Private Car.
4. Electric Car.
5. Truck.";

        private const string k_InsertVehicleLicense =
            @"Please Insert Vehicle license: ";

        private const string k_SetNewStatus =
            @"Please select the status:
1. OnRepair.
2. Repaired,
3. Paid.";

        private const string k_GetFuelType = @"Please select fuel type: 
1. Octan95
2. Octan96
3. Octan98
4. Soler";

        private bool wasExitPressed;

        private GarageManager GM;

        /*true - Yes
        /*false - No
         *
         * */


        // $G$ CSS-999 (-3) If you use strings as conditions, You should use constants.
        // $G$ CSS-013 (-3) Input parameters names should start with i_Pascalcase.
        public static bool GetAnswerYesOrNot(string ques)
        {
            bool res = false;
            bool validateAnswer = false;
            string answer = Console.ReadLine();

            while (!validateAnswer)
            {
                if (answer.CompareTo("No") == 0)
                {
                    res = false;
                    validateAnswer = true;
                }
                else if (answer.CompareTo("Yes") == 0)
                {
                    res = true;
                    validateAnswer = true;
                }
                else
                {
                    Console.WriteLine(ques);
                    answer = Console.ReadLine();
                }
            }

            return res;
        }
        
        public UserInterface()
        {
            GM = new GarageManager();
        }

        public void Run()
        {
            while (!wasExitPressed)
            {
                EntryMenu();
                Console.Clear();
            }
        }

        public void EntryMenu()
        {
            int choice = getSelection(k_EntryMenu, validEntryMenuOption);
            
            switch (choice)
            {
                case (int)eEntryMenuOptions.SingleVehicleOption:
                    OneVehicleOptionsMenu();
                    break;
                case (int)eEntryMenuOptions.GarageOption:
                    GarageOptionsMenu();
                    break;
                case (int)eEntryMenuOptions.Exit:
                    wasExitPressed = true;
                    break;
            }
        }

        public void OneVehicleOptionsMenu()
        {
            // Here we have a little bug : after choose to exit, user is asked to enter a license number - no reason.
            int selection = getSelection(k_PerLicenseMenu, validPerLicenseMenuOption);

            Console.WriteLine(k_InsertVehicleLicense);
            string license = Console.ReadLine();

            switch (selection)
            {
                case (int)ePerLicenseMenuOption.Insert:
                    insertVehicleFlow(license);
                    break;
                case (int)ePerLicenseMenuOption.ChangeStatus:
                    changeStatus(license);
                    break;
                case (int)ePerLicenseMenuOption.InflateAllWheels:
                    InflateWheelsToMax(license);
                    break;
                case (int)ePerLicenseMenuOption.Refuel:
                    refuelVehicle(license);
                    break;
                case (int)ePerLicenseMenuOption.Recharge:
                    rechargeVehicle(license);
                    break;
                case (int)ePerLicenseMenuOption.ShowFullVehicleDetails:
                    Console.WriteLine(GM.GetVehicleDetails(license));
                    break;
                case (int)ePerLicenseMenuOption.Exit:
                    wasExitPressed = true;
                    break;
            }
            
            Console.WriteLine("Press any key to return to entry menu.");
            Console.ReadKey();
        }

        private delegate bool MyValidator(int i_Choice);

        private int getSelection(string i_MenuToPrint, MyValidator i_ValidationMethod)
        {
            int selection;

            Console.WriteLine(i_MenuToPrint);
            string choiceStr = Console.ReadLine();

            while (!int.TryParse(choiceStr, out selection))
            {
                if (i_ValidationMethod(selection))
                {
                    break;
                }

                Console.WriteLine("Illegal value, please type a valid value.");
                choiceStr = Console.ReadLine();
            }

            return selection;
        }

        private bool validEntryMenuOption(int i_Choice)
        {
            bool isValid = i_Choice == (int)eEntryMenuOptions.SingleVehicleOption || i_Choice == (int)eEntryMenuOptions.GarageOption || i_Choice == (int)eEntryMenuOptions.Exit;

            return isValid;
        }

        private bool validPerLicenseMenuOption(int i_Choice)
        {
            bool isValid = i_Choice == (int)ePerLicenseMenuOption.Exit || (i_Choice >= (int)ePerLicenseMenuOption.Insert && i_Choice <= (int)ePerLicenseMenuOption.ShowFullVehicleDetails);

            return isValid;
        }

        private bool validChangeStatusMenu(int i_Choice)
        {
            bool isValid = i_Choice >= (int)eVehicleStatus.OnRepair && i_Choice <= (int)eVehicleStatus.Paid;

            return isValid;
        }

        private bool validFuelTypeMenu(int i_Choice)
        {
            bool isValid = i_Choice >= (int)eFuelType.Octan95 && i_Choice <= (int)eFuelType.Soler;

            return isValid;
        }

        private bool validCarTypeMenu(int i_Choice)
        {
            bool isValid = i_Choice >= (int)eValidVehicle.RegMotorCycle && i_Choice <= (int)eValidVehicle.Truck;

            return isValid;
        }

        private void rechargeVehicle(string i_License)
        {
            float chargeAmount = 0f;
            Console.WriteLine("Enter time to recharge:(by minutes)");
            try
            {
                chargeAmount = float.Parse(Console.ReadLine());
                RechargeVehicle(i_License, chargeAmount);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid fuel amount entered.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid license number or vehicle is not in the garage.");
            }
        }

        // $G$ DSN-007 (-5) This method is too long, it should have been split into several methods.
        // $G$ DSN-011 (-7) The component responsible for creating vehicles should be implemented in the Logic project...
        private void insertVehicleFlow(string i_License)
        {
            bool isVehicleInserted = false;
            int selection = getSelection(k_InsertVehicleTypeSelect, validCarTypeMenu);
            eValidVehicle validVehicle = (eValidVehicle)selection;
            ComposedVehicle vehicleToInsert = null;

            if (GM.IsVehicleInGarage(i_License))
            {
                // print active car menu
                Console.WriteLine("The status of vehicle with the license {0} was changed to repair.", i_License);
                GM.ChangeVehicleStatus(i_License, eVehicleStatus.OnRepair);
            }
            else
            {
                // car not in garage - print "enter full details".
                DataExtractor dataExtractor = new DataExtractor(validVehicle, i_License);
                try
                {
                    if (validVehicle == eValidVehicle.ElectricalCar || validVehicle == eValidVehicle.RegCar)
                    {
                        vehicleToInsert = GM.CreateAutomobile(
                            dataExtractor.VehicleType,
                            dataExtractor.OwnerName,
                            dataExtractor.OwnerNumber,
                            dataExtractor.LicenseNumber,
                            dataExtractor.Model,
                            dataExtractor.WheelManufacturer,
                            dataExtractor.CurrentWheelPressure,
                            dataExtractor.PowerLeft,
                            dataExtractor.EColor,
                            dataExtractor.ENumOfDoors);
                    }
                    else if (validVehicle == eValidVehicle.RegMotorCycle ||
                             validVehicle == eValidVehicle.ElectricalCycle)
                    {
                        vehicleToInsert = GM.CreateMotorcycle(
                            dataExtractor.VehicleType,
                            dataExtractor.OwnerName,
                            dataExtractor.OwnerNumber,
                            dataExtractor.LicenseNumber,
                            dataExtractor.Model,
                            dataExtractor.WheelManufacturer,
                            dataExtractor.CurrentWheelPressure,
                            dataExtractor.PowerLeft,
                            dataExtractor.ELicenseType,
                            dataExtractor.EngineSize);
                    }
                    else
                    {
                        vehicleToInsert = GM.CreateTruck(
                            dataExtractor.VehicleType,
                            dataExtractor.OwnerName,
                            dataExtractor.OwnerNumber,
                            dataExtractor.LicenseNumber,
                            dataExtractor.Model,
                            dataExtractor.WheelManufacturer,
                            dataExtractor.CurrentWheelPressure,
                            dataExtractor.PowerLeft,
                            dataExtractor.TruckCapacity,
                            dataExtractor.IsCooled);
                    }

                    isVehicleInserted = GM.InsertVehicle(vehicleToInsert);

                    if (isVehicleInserted)
                    {
                        Console.WriteLine("Vehicle with license {0} has entered the garage.", i_License);
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                catch (ValueOutOfRangeException voore)
                {
                    Console.WriteLine(voore.Message);
                    Console.WriteLine("Vehicle was not added");
                }
            }
        }

        private void changeStatus(string i_License)
        {
            eVehicleStatus eVehicleStatus;
            int selection = getSelection(k_SetNewStatus, validChangeStatusMenu);

            if (selection == (int)eVehicleStatus.OnRepair)
            {
                eVehicleStatus = eVehicleStatus.OnRepair;
            }
            else if (selection == (int)eVehicleStatus.Repaired)
            {
                eVehicleStatus = eVehicleStatus.Repaired;
            }
            else
            {
                eVehicleStatus = eVehicleStatus.Paid;
            }

            try
            {
                GM.ChangeVehicleStatus(i_License, eVehicleStatus);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("No valid license provided or vehicle is not in the garage.");
            }
        }

        private void refuelVehicle(string i_License)
        {
            eFuelType? fuelType = null;
            var selection = getSelection(k_GetFuelType, validFuelTypeMenu);

            switch (selection)
            {
                case (int)eFuelType.Octan95:
                    fuelType = eFuelType.Octan95;
                    break;
                case (int)eFuelType.Octan96:
                    fuelType = eFuelType.Octan96;
                    break;
                case (int)eFuelType.Octan98:
                    fuelType = eFuelType.Octan98;
                    break;
                case (int)eFuelType.Soler:
                    fuelType = eFuelType.Soler;
                    break;
            }

            float fuelAmount = 0f;
            Console.WriteLine("Enter amount to fuel:");
            try
            {
                fuelAmount = float.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid fuel amount entered.");
            }

            if (fuelType != null)
            {
                try
                {
                    RefuelVehicle(i_License, (eFuelType)fuelType, fuelAmount);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid license number or vehicle is not in the garage.");
                }
            }
        }

        public void GarageOptionsMenu()
        {
            // TODO
            int selection = getSelection(k_AllVehiclesMenu, x => x == 1 || x == 2);
            switch (selection)
            {
                case 1:
                    List<string> allLicenses = GM.GetAllVehiclesLicensesNumbers();
                    allLicenses.ForEach(Console.WriteLine);
                    break;
                case 2:
                    int statusSelection = getSelection(k_SetNewStatus, validChangeStatusMenu);
                    List<string> allLicensesByFilter =
                        GM.GetVehiclesLicenseFilterdByStatus((eVehicleStatus) statusSelection);
                    allLicensesByFilter.ForEach(Console.WriteLine);
                    break;
            }

            Console.WriteLine("Press any key to return to entry menu.");
            Console.ReadKey();
        }
        
        public void InflateWheelsToMax(string i_License)
        {
            this.GM.InflateWheelsToMax(i_License);
        }

        private void RefuelVehicle(string i_License, eFuelType i_FuelType, float i_AmountToFuel)
        {
            this.GM.RefuelVehicle(i_License, i_FuelType, i_AmountToFuel);
        }

        public void RechargeVehicle(string i_License, float i_MinutesToCharge)
        {
            this.GM.RechargeVehicle(i_License, i_MinutesToCharge);
        }
    }
}

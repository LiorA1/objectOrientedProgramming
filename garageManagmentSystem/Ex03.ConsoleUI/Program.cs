namespace Ex03.ConsoleUI
{
    // $G$ SFN-999 (-5) not showing all the details when showing vehicle details by license number

    // $G$ DSN-999 (-10) this project can be more maitanable - if we add new type of vehicke in the futue we will have a lot of work to do...

    // $G$ RUL-006 (-80) Late submission - 2 day.

    public class Program
    {
        public static void Main()
        {
            var UI = new UserInterface();
            UI.Run();
        }
    }
}

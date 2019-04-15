using System;
using System.Collections.Generic;
using System.Text;

// $G$ SFN-012 (+16) Bonus: Events in the Logic layer are handled by the UI.
// $G$ SFN-013 (+9) Bonus: Animation

namespace C18_Ex05.UI
{
    public class Program
    {
        public static void Main()
        {     
            var settings = new GameSettingsPane();
            settings.ShowDialog();
        }
    }
}

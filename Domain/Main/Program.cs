using InventoryManagementSystem;
using InventoryManagementSystem.Domain.Models;
using InventoryManagementSystem.Domain.Main;
using InventoryManagementSystem.Domain.General;

PrintWelcome();

Utilities.InitializeStock();

Utilities.ShowMainMenu();

Console.WriteLine("Application shutting down...");

Console.ReadLine();

#region Layout
void PrintWelcome()
{

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(@"     
()()()()()()  _____                    ___                       ________                                                 ___    ()()()()()()
|\         |  |_ _|_ ____   _____ _ __ | |_ ___  _ __ _   _      |  \/  | __ _ _ __   __ _  __ _  ___ _ __ ___   ___ _ __ | |_   |\         |
|.\. . . . |   | || '_ \ \ / / _ \ '_ \| __/ _ \| '__| | | |_____| |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '_ ` _ \ / _ \ '_ \| __|  |.\. . . . |
\'.\       |   | || | | \ V /  __/ | | | || (_) | |  | |_| |_____| |  | | (_| | | | | (_| | (_| |  __/ | | | | |  __/ | | | |_   \'.\       |
 \.:\ . . .|  |___|_|_|_|\_/ \___|_|_|_|\__\___/|_|   \__, |     |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_| |_| |_|\___|_| |_|\__|   \.:\ . . .|
  \'o\     |       / ___| _   _ ___| |_ ___ _ __ ___  |___/                                |___/                                   \'o\     |
   \.'\. . |   ____\___ \| | | / __| __/ _ \ '_ ` _ \                                                                               \.'\. . |
    \'.\   |  |_____|__) | |_| \__ \ ||  __/ | | | | |                                                                               \'.\   |
     \'`\ .|       |____/ \__, |___/\__\___|_| |_| |_|                                                                                \'`\ .|
      \.'\ |              |___/                                                                                                        \.'\ |                                                           
       \__\|                                                                                                                            \__\|      
");

    Console.ResetColor();

    Console.WriteLine("Press enter key to start logging in!");

    //accepting enter here
    Console.ReadLine();

    Console.Clear();
}
#endregion
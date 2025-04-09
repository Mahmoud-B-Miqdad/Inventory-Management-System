using InventoryManagementSystem;
using InventoryManagementSystem.Domain.Models;
using InventoryManagementSystem.Domain.Main;
using InventoryManagementSystem.Domain.General;

PrintWelcome();

// اطلب من المستخدم اختيار نوع قاعدة البيانات
string databaseType = ChooseDatabaseType();

// مرر نوع القاعدة إلى Utilities
Utilities.InitializeStock(databaseType);

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
    Console.ReadLine();
    Console.Clear();
}
#endregion

string ChooseDatabaseType()
{
    while (true)
    {
        Console.WriteLine("Please choose your database:");
        Console.WriteLine("1 - MongoDB");
        Console.WriteLine("2 - MSSQL");
        Console.Write("Enter your choice (1 or 2): ");
        string choice = Console.ReadLine()?.Trim();

        switch (choice)
        {
            case "1":
                return "MongoDB";
            case "2":
                return "MSSQL";
            default:
                Console.WriteLine("Invalid input. Please choose 1 or 2.\n");
                break;
        }
    }
}

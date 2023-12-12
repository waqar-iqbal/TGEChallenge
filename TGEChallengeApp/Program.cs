using System.Text.RegularExpressions;
using TGEChallengeApp.DataAccess;

Console.WriteLine(@"
 _______ _____            _   _  _____  _____ _      ____  ____          _      
 |__   __|  __ \     /\   | \ | |/ ____|/ ____| |    / __ \|  _ \   /\   | |     
    | |  | |__) |   /  \  |  \| | (___ | |  __| |   | |  | | |_) | /  \  | |     
    | |  |  _  /   / /\ \ | . ` |\___ \| | |_ | |   | |  | |  _ < / /\ \ | |     
    | |  | | \ \  / ____ \| |\  |____) | |__| | |___| |__| | |_) / ____ \| |____ 
    |_|  |_|  \_\/_/____\_\_|_\_|_____/_\_____|______\____/|____/_/    \_\______|
               |  ____\ \ / /  __ \|  __ \|  ____|/ ____/ ____|                  
  ______ ______| |__   \ V /| |__) | |__) | |__  | (___| (___ ______ ______      
 |______|______|  __|   > < |  ___/|  _  /|  __|  \___ \\___ \______|______|     
               | |____ / . \| |    | | \ \| |____ ____) |___) |                  
   _____ _    _|______/_/_\_\_| _  |_| _\_\______|_____/_____/___ ___  ____      
  / ____| |  | |   /\   | |    | |    |  ____| \ | |/ ____|  ____|__ \|___ \     
 | |    | |__| |  /  \  | |    | |    | |__  |  \| | |  __| |__     ) | __) |    
 | |    |  __  | / /\ \ | |    | |    |  __| | . ` | | |_ |  __|   / / |__ <     
 | |____| |  | |/ ____ \| |____| |____| |____| |\  | |__| | |____ / /_ ___) |    
  \_____|_|  |_/_/    \_\______|______|______|_| \_|\_____|______|____|____/ 
                                                                                 
                                                                                 
");

PostcodeManager postcodeManager = new PostcodeManager(new TGEChallengeApp.DataAccess.API.DummyTGEChallengeAPI());

Console.WriteLine("Welcome to postcode manager select on of the following commands:");

while (true)
{
    Console.WriteLine("1: Get the postcode district summary");
    Console.WriteLine("2: Remove invalid postcodes");
    
    ConsoleKeyInfo key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.D1)
    {
        Console.WriteLine(postcodeManager.GetDistrictSummary()
            ? "District Summary has been saved to file a new." 
            : "Error! District Summary has not been saved to file.");
    }
    else if (key.Key == ConsoleKey.D2)
    {
        Console.WriteLine(postcodeManager.ValidatePostcodes() 
            ? "Removed invalid postcodes and saved the valid postcodes to a new file." 
            : "Error postcodes could not be validated.");
    }
    else
    {
        Console.WriteLine("Invalid input");
    }

    Console.WriteLine("Press x to exit or select another command");

    if (key.Key == ConsoleKey.X)
    {
        Environment.Exit(0);
    }
}


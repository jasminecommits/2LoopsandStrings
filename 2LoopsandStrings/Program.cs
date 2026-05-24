using System.ComponentModel.Design;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    //Här lägger jag in en metod med syfte att ta emot en ålder, och returnera ett "prispaket".
    //Prispaketet består av en sträng som beskriver vilken typ av pris det är (pensionär, ungdom, standard), och en int som beskriver priset i kronor.
    static (string, int) GetPricePackageForAge(int age)
    {
        if (age < 20)
        {
            return ("Ungdomspris", 80);
        }
        else if (age >= 65)
        {
            return ("Pensionärspris", 90);
        }
        else
        {
            return ("Standardpris", 120);
        }
    }
    //Lägger in en metod som skriver ut rubriken centrerat i konsolen, för att göra det lite mer tjusigt.
    static void printConsoleTextCenter(string text)
    {
        Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.CursorTop);
        Console.WriteLine(text);
    }

    static void Main(string[] args)
    {
        //Här lägger jag in två bools. Den första tillåter användaren att fortsätta med programmet så länge den vill.
        //Den andra boolen ser till att välkomstmeddelandet bara skrivs ut en gång.

        bool running = true;
        bool firstTime = true;

        while (running)
        {
            if (firstTime)
            {
                printConsoleTextCenter("Välkommen till testmiljön!");
                Console.WriteLine("\n\n"); //Lägger in några radbrytningar för att göra det lite mer luftigt.
                Console.WriteLine("Du kommer nu att få testa ett antal funktioner.");
                firstTime = false;
            }
            
            Console.WriteLine();
            Console.WriteLine("Du kan göra följande val:");
            Console.WriteLine("\t1: Ungdom eller pensionär");
            Console.WriteLine("\t2: Upprepa tio gånger");
            Console.WriteLine("\t3: Det tredje ordet");

            //Nedan konverterar jag användarens input till en int, så att jag kan använda den i switch-satsen.
            // nullable int, variabeln är tom hittills.
            int choice;
            //Jag har lagt in en try-catch för att fånga upp eventuella fel i input, så att programmet kör vidare.
            try
            {
                choice = (int)Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            //Om användaren inte skriver in en int, får användaren att försöka igen.
            {
                Console.WriteLine("Felaktig input, vänligen ange en siffra:");
                continue;
            }

            //Switch-satsen gör det möjligt för användaren att välja mellan de olika funktionerna i programmet via cases,
            //och kör sedan den kod som är kopplad till det valda caset.
            switch (choice)
            {
                case 0:
                    //Om använder väljer 0, sätts running till false, och programmet avslutas.
                    running = false;
                    break;

                case 1:
                    //En while-loop finns för att programmet inte ska sluta köra när ett val är gjort.
                    //Dessutom finns det en while-loop i varje case för att användaren ska kunna fortsätta testa funktionerna i befintligt val, utan att behöva starta om programmet.
                    while (true)
                    {

                        Console.WriteLine("Ungdom eller pensionär");
                        Console.WriteLine();
                        Console.WriteLine("Välj ett av följande alternativ:");
                        Console.WriteLine();
                        Console.WriteLine("\t1: Se om personen ska betala ungdoms-, pensionärs- eller standardpris");
                        Console.WriteLine("\t2: Räkna ut priset för ett helt sällskap");
                        Console.WriteLine("\t0: Gå tillbaka till huvudmenyn");
                        //Nedan konverterar jag användarens input till en int, så att jag kan använda den i if-satsen.
                        int ageChoice = (int)Convert.ToInt32(Console.ReadLine());
                        //Här har jag lagt in en if-sats med tre olika alternativ. Om användaren väljer 0, bryts den inre while-loopen, och användaren kommer tillbaka till huvudmenyn.
                        //Denna if-sats upprepas för varje case.
                        if (ageChoice == 0) break;
                        else if (ageChoice == 1)
                        {
                            while (true)
                            {
                                Console.WriteLine("Skriv in personens ålder:");

                                string age = Console.ReadLine();

                                int ageInt = 0;

                                //Jag har lagt in en try-catch för att fånga upp eventuella felaktiga inputs, så att programmet inte kraschar.
                                try
                                {
                                    ageInt = int.Parse(age);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Felaktig input, vänligen ange en giltig ålder:");
                                    continue;
                                }

                                //Här kallar jag på metoden GetPricePackageForAge, och sparar resultatet i en variabel.
                                (string, int) packageMatch = GetPricePackageForAge(ageInt);
                                //Jag skriver ut resultatet med ett $ för att texten ska formatera sträng och variabler till en gemensam sträng.
                                //jag använder sedan Item1 (string - typ av pris) och Item2 (value - pris) för att komma åt värdena.
                                Console.WriteLine($"{packageMatch.Item1}: {packageMatch.Item2}kr");

                                break;
                            }
                        }

                        else if (ageChoice == 2)
                        {
                            while (true)
                            {
                                Console.WriteLine("Ange hur många personer ska gå på bio:");

                            string people = Console.ReadLine();
                            //Nedan konverterar jag en sträng till ett heltal
                            int peopleInt = int.Parse(people);

                            int totalPrice = 0;
                                //Här använder jag en for-loop för att gå igenom varje person i sällskapet.
                                for (int i = 0; i < peopleInt; i++)
                            {
                              //För varje person i sällskapet, frågar jag efter deras ålder.
                                Console.WriteLine($"Skriv in åldern på person {i + 1}:");
                                string personAge = Console.ReadLine();
                                int personAgeInt = int.Parse(personAge);

                              // Här kallar jag på metoden GetPricePackageForAge för att få fram priset för varje person, och adderar det sedan till totalpriset.
                                int personPrice = GetPricePackageForAge(personAgeInt).Item2;

                                totalPrice = totalPrice + personPrice;
                            }
                            Console.WriteLine($"Ni är {peopleInt} stycken personer i sällskapet. Ert totala pris är: {totalPrice}kr.");

                                break;
                            }
                        }

                        else
                        {
                            Console.WriteLine("Felaktig input, försök igen.");
                        }
                    }
                    break;


                case 2:

                        Console.WriteLine("Upprepa tio gånger");
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("(Skriv 0 för att gå tillbaka till huvudmenyn)");
                        Console.WriteLine();
                        Console.WriteLine("Vänligen skriv in en text som du vill ska upprepas tio gånger:");

                        
                        string text = Console.ReadLine();

                        Console.WriteLine();
                        if (text == "0") break;
                        //Här använder jag en for-loop för att upprepa texten tio gånger, och skriver ut numret på varje upprepning.
                        //För varje upprepning läggs ett kommatecken till, förutom efter den sista upprepningen.
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write($"{i + 1}:{text}");
                            if (i < 9)
                            {
                                Console.Write(",");
                            } 
                        }
                    }
                    break;


                case 3:

                    Console.WriteLine("Det tredje ordet");
                    Console.WriteLine();
                    Console.WriteLine("(Skriv 0 för att gå tillbaka till huvudmenyn)");
                    Console.WriteLine();
                    Console.WriteLine("Ange en mening med minst tre ord. Programmet kommer då att skriva ut det tredje ordet från din text.");

                    while (true)
                    {
                        string str = Console.ReadLine();

                        if (str == "0") break;

                        //Här delar jag upp användarens mening i ord med hjälp av metoden Split.
                        //Strängen delas upp vid varje mellanslag, och sparas sedan i en ny array som heter words.
                        //Jag tar samtidigt bort eventuella tomma strängar som kan uppstå om användaren skriver in flera mellanslag mellan orden.
                        string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        //Här har lagt till en if-sats för att se om användaren har skrivit in minst tre ord, för att undvika att programmet kraschar.
                        if (words.Length >= 3)
                    {
                        Console.WriteLine($"Det tredje ordet är: {words[2]}");
                        Console.WriteLine();
                        Console.WriteLine("(Skriv 0 för att gå tillbaka till huvudmenyn)");
                        Console.WriteLine();

                        }

                    else
                    {
                        Console.WriteLine("Felaktig input, vänligen ange minst tre ord:");
                    }

            }

                    break;


                default:
                    Console.WriteLine("Felaktig input, försök igen.");
                    break;

            }
        }
    }
}

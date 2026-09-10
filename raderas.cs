/*Skriv ett konsolprogram som håller reda på en inköpslista med namn och pris för varje vara.
Eftersom vi inte använder objekt i den här delen håller du ihop datan med två parallella listor — en
List<string> för namnen och en List<int> för priserna — där samma index hör ihop (names[i] kostar
prices[i]).
Programmet ska hela tiden visa listan som en numrerad lista med totalsumma, t.ex.:
1. Mjölk - 15 kr
2. Bröd - 32 kr
3. Ost - 89 kr
Totalt: 136 kr
Input från användaren:
En vara: skriv ett varunamn (text). Programmet frågar då efter priset (ett heltal) och lägger till varan
sist i listan. Skriver användaren något som inte är ett heltal som pris ska varan inte läggas till.
Ett nummer: varan på den positionen tas bort ur listan (både namn och pris).
Om användaren anger ett nummer som inte finns i listan ska programmet säga till i stället för att
krascha.
Extra (frivilligt, påverkar inte betyget):
● Ordet dyrast skriver ut vilken vara som är dyrast.
● Sortera listan efter pris.*/

List<string> names = new List<string>(); //En lista som håller reda på namnen på varorna.
List<int> prices = new List<int>(); // En lista som håller reda på priserna på varorna.

{
    if (names.Count == 0) //Om listan är tom, skriv ut ett meddelande om det.
    {
        Console.WriteLine("Inköpslistan är tom."); //Meddelandet
    }
    else //Annars, om listan inte är tom, skriv ut alla varor och deras priser samt totalsumman.
    {
        int total = 0;
        for (int i = 0; i < names.Count; i++)//Loopar igenom alla varor i listan.
        {
            Console.WriteLine($"{i + 1}. {names[i]} - {prices[i]} kr");//Skriver ut varje vara med dess namn och pris.
            total += prices[i];
        }
        Console.WriteLine($"Totalt: {total} kr"); // Skriver ut totalsumman av varorna
    }
}
Console.WriteLine("Skriv ett varunamn för att lägga till en vara, eller ett nummer för att ta bort en vara:");
string input = (Console.ReadLine() ?? ""). Trim(); 
//Läser in användarens input och tar bort eventuella mellanslag i början och slutet.
if (int.TryParse(input, out int index)) //Försöker konvertera input till ett heltal.
{
    if (index >= 1 && index <= names.Count) //Om index är giltigt, ta bort varan på den positionen.
    {
        names.RemoveAt(index - 1);
        prices.RemoveAt(index - 1);
        Console.WriteLine($"Varan på position {index} har tagits bort.");
    }
    else //Om index inte är giltigt, skriv ut ett felmeddelande.
    {
        Console.WriteLine("Ogiltigt nummer. Ingen vara togs bort.");
    }
}
else //Om input inte är ett nummer, behandla det som ett varunamn.
{
    Console.WriteLine("Ange priset för varan (ett heltal):");
    string priceInput = (Console.ReadLine() ?? "").Trim();
    if (int.TryParse(priceInput, out int price)) //Försöker konvertera priset till ett heltal.
    {
        names.Add(input); //Lägg till varunamnet i listan.
        prices.Add(price); //Lägg till priset i listan.
        Console.WriteLine($"Varan '{input}' med pris {price} kr har lagts till.");
    }
    else //Om priset inte är ett heltal, skriv ut ett felmeddelande.
    {
        Console.WriteLine("Ogiltigt pris. Varan lades inte till.");
    }
}

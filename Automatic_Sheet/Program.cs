using Automatic_Sheet_BL;

Console.WriteLine("***** Генератор разъездной ведомости *****");

string? answer;
int rowCount;
int ticketCount;
int ticketPrice;
int month;
bool isDone = false;
List<int>? vacation = new List<int>();

do
{
    Console.WriteLine("\nВведите необходимое количество строк для ведомости: ");

    answer = Console.ReadLine();
} while (!int.TryParse(answer, out rowCount));


do
{
    Console.WriteLine("\nВведите количество биллетов: ");

    answer = Console.ReadLine();
} while (!int.TryParse(answer, out ticketCount));


do
{
    Console.WriteLine("\nВведите стоимость биллетов: ");

    answer = Console.ReadLine();
} while (!int.TryParse(answer, out ticketPrice));


do
{
    Console.WriteLine("\nВведите номер месяца если нынешний не подходит.");
    Console.WriteLine("\nЕсли необходим нынешний введите н/Н: ");

    answer = Console.ReadLine();

    if (answer.Contains("n", StringComparison.OrdinalIgnoreCase) ||
        answer.Contains("н", StringComparison.OrdinalIgnoreCase))
    {
        month = DateTime.Today.Month;
        break;
    }
} while (!int.TryParse(answer, out month));


do
{
    Console.WriteLine("\nВведите числа отпуска через запятую если они есть.");
    Console.WriteLine("\nЕсли их нет введите н/Н: ");

    answer = Console.ReadLine();

    if (answer.Contains("n", StringComparison.OrdinalIgnoreCase) ||
        answer.Contains("н", StringComparison.OrdinalIgnoreCase))
    {
        vacation = null;
        break;
    }

    string[] strings = answer.Split(",", StringSplitOptions.TrimEntries);
    int day;

    foreach (string str in strings)
    {
        if (!int.TryParse(str, out day))
        {
            vacation = new List<int>();
            continue;
        }

        vacation.Add(day);
    }

    isDone=true;
} while (!isDone);

try
{
    IDateGenerator dateGenerator = new DateGenerator(month, vacation);
    List<string> dateListStrings = dateGenerator.CreateTravelList(rowCount);

    ITripListGenerator tripListGenerator = new TripListGenerator();
    var repository = tripListGenerator.GetRepository();
    var tripList = tripListGenerator.GetTripList(rowCount, ticketCount, repository);
    List<string> tripStringList = tripListGenerator.GetTripStringList(tripList);

    IPriceListGenerator priceListGenerator = new PriceListGenerator();
    List<string> priiceList = priceListGenerator.GetPriceList(tripList, ticketPrice);

    IListStringGenerator listStringGenerator = new ListStringGenerator();
    string table = listStringGenerator.CreateTable(dateListStrings, tripStringList, priiceList);

    ISerializerToFile serializer = new SerializerToFile();
    serializer.SerializeToFile(table);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nДанные записаны в файл: \"Данные ведомости.csv\" в каталоге программы");
    Console.ResetColor();
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n" + ex.Message);
    Console.ResetColor();
    Console.ReadLine();
    return;
}
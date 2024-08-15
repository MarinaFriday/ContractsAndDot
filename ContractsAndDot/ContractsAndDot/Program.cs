using ContractsAndDot.Services;

var contructService = new ContractService();
bool menu = true;

do
{
    Console.WriteLine("------Меню------");
    Console.WriteLine("МАЛО ТЕСТОВЫХ ДАННЫХ, Я ПОДГРУЖАЛА ПЯТЬ РАЗ ОДНО И ТОЖЕ, ЧТОБЫ ПРОТЕСТИРОВАТЬ ЗАПРОСЫ");
    Console.WriteLine("0.Загрузить тестовые данные.");
    Console.WriteLine("1.Вывести сумму всех заключенных договоров за текущий год.");
    Console.WriteLine("2.Вывести сумму заключенных договоров по каждому контрагенту из России.");
    Console.WriteLine("3.Вывести список e-mail уполномоченных лиц, заключивших договора за последние 30 дней, на сумму больше 40000");
    Console.WriteLine("4.Изменить статус договора на Расторгнут для физических лиц, у которых есть действующий договор, и возраст которых старше 60 лет включительно");
    Console.WriteLine("5.Создать отчет (текстовый файл, например, в формате xml, xlsx, json) содержащий ФИО, e-mail, моб. телефон, дату рождения физ. лиц, у которых есть действующие договора по компаниям, расположенных в городе Москва");
    Console.WriteLine("6. Выход");
    Console.WriteLine();

    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        default:
            Console.WriteLine("Неверный ввод");
            break;
        case 0:
            var testData = new TestData();
            break;
        case 1:
            Console.Clear();
            contructService.QuerySumAmount();
            break;
        case 2:
            Console.Clear();
            contructService.QuerySumAmountForCounterparty();
            break;
        case 3:
            Console.Clear();
            contructService.QueryEmails();
            break;
        case 4:
            Console.Clear();
            contructService.UpdateStatus();
            break;
        case 5:
            var query_for_ser = contructService.QueryForReport();
            Console.WriteLine("Введите путь, по которому сохранится файл: ");
            string path = Console.ReadLine();
            //C:\Users\marin\OneDrive\Desktop\json.json;
            var transformService = new TransformService();
            string jsonFormat = transformService.TransformToJson(query_for_ser);
            transformService.WriteToFile(path, jsonFormat);
            break;
        case 6:
            menu=false;
            break;
    }
} while (menu);
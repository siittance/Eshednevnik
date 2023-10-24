using System.Globalization;
using System.Text;
using static System.Console;
namespace Eshednevnik
//РУССКИЕ БУКВЫ ПРИ ВВОДЕ ВСЕ ЕЩЕ НЕ ОТОБРАЖАЮТСЯ
{
    internal class Program
    {
        static DateTime currentDate = DateTime.Today;
        static int maxPosition = 7;
        static int minPosition = 5;
        static int currentPosition = 5;
        static bool isWorking = true;
        static List<Diary> diaries = new List<Diary>();
        static void Main(string[] args)
        {
        diaries.Add(new Diary("Выпить пива", "просто хочу пива", new DateTime(2023, 10, 23)));
        diaries.Add(new Diary("Закадрить мальчика", "просто хочу мальчика", new DateTime(2023, 10, 24)));
        diaries.Add(new Diary("Выпить пива", "мальчика закадрить не удалось", new DateTime(2023, 10, 25)));
        diaries.Add(new Diary("Тяжело", "план не существует", new DateTime(2023, 10, 25)));
        diaries.Add(new Diary("Сидеть дома", "ушла в депрессию", new DateTime(2023, 10, 26)));
        diaries.Add(new Diary("Все решено!", "нашла другого", new DateTime(2023, 10, 27)));
            CursorVisible = false;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
        InputEncoding = Encoding.UTF8;
        OutputEncoding = Encoding.UTF8;
        Menu();
        }


        static void Menu()
        {
            ConsoleKey key;
            while (isWorking)
            {
                Clear();
                WriteLine("----------------------------------|");
                WriteLine("Добро пожаловать в ежендевник!!!  |");
                WriteLine("----------------------------------|");
                WriteLine("                                  | ");
                WriteLine($"  Текущая дата {currentDate:dd-MM-yyyy}         |");
                WriteLine("  1. Добавить заметки             |");
                WriteLine("  2. Посмотреть заметки           |");
                WriteLine("  3. Выйти из программы           |");
                WriteLine("                                  |");
                WriteLine("----------------------------------|");
                CursorWrite();
                key = ReadKey().Key;
                if (key == ConsoleKey.RightArrow) Move(1);
                if (key == ConsoleKey.LeftArrow) Move(2);
                if (key == ConsoleKey.DownArrow) Move(3);
                if (key == ConsoleKey.UpArrow) Move(4);
                if (key == ConsoleKey.Enter) Move(5);
            }
        }


        static void Move(int move)
        {
            switch (move)
            {
                case 1:
                    currentDate =  currentDate.AddDays(1);
                    break;
                case 2:
                    currentDate =  currentDate.AddDays(-1);
                    break;
                case 3:
                    PrintArrow(true);
                    break;
                case 4:
                    PrintArrow(false);
                    break;
                case 5:
                    if (currentPosition == 5)
                    {
                        AddDiary();
                    }
                    if (currentPosition == 6)
                    {
                        LookOnDiaries();
                    }
                    if (currentPosition == 7)
                    {
                        isWorking = false;
                    }
                    break;
            }
        }

        private static void LookOnDiaries()
        {
            Clear();
            foreach (var diary in diaries)
            {
                if(diary.Date == currentDate)
                {




                WriteLine($"Название: {diary.Name}\r\n" +
                    $"Описание: {diary.Description}");
                }
            }
            ReadKey();
        }

        private static void AddDiary()
        {
            Clear();
            var name = ReadLine();
            var desk = ReadLine();
            diaries.Add(new Diary(name, desk, currentDate));
        }

        private static void PrintArrow(bool mama)
        {
            if (mama)
            {
                currentPosition++;
                if (currentPosition > maxPosition)
                {
                    currentPosition--;
                }
            }
            else
            {
                currentPosition--;
                if (currentPosition < minPosition)
                {
                    currentPosition++;
                }
            }
        }

        private static void CursorWrite()
        {
            SetCursorPosition(0, currentPosition - 1);
            WriteLine("  ");
            SetCursorPosition(0, currentPosition);
            WriteLine("->");
            SetCursorPosition(0, currentPosition + 1);
            WriteLine("  ");
        }
    }
}

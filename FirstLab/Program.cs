using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FirstLab
{
    class Program
    {
        
        public static Dictionary<int, Record> notebook = new Dictionary<int, Record>();
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует пре-альфа-альфа версия системы хранения данных людей v0.0.0,5\nДля взаимодействия с системой доступны следующие команды");
            Console.WriteLine("Добавить - создание новой записи\nИзменить - изменение существующей записи\nУдалить - удаление записи\nПросмотр - просмотр информации в записи\nВсе - просмотр всей базы\nПомощь - напоминание о существущих командах\nЗакончить - для завершения работы");
            Console.WriteLine("Введите команду для начала работы");
            while (ChooseAction(Console.ReadLine())) { Console.WriteLine("Введите новую команду"); };
        }

        public static bool ChooseAction(string action)
        {
            Program prog = new Program();
            switch (action.ToLower())
            {
                case "добавить":
                    prog.Add();
                    break;
                case "изменить":
                    Console.WriteLine("Введите Id записи для изменеия");
                    prog.Change(int.Parse(Console.ReadLine()));
                    break;
                case "удалить":
                    Console.WriteLine("Введите Id записи для удаления");
                    prog.Delete(int.Parse(Console.ReadLine()));
                    break;
                case "просмотр":  
                    Console.WriteLine("Введите Id записи для просмотра");
                    prog.Show(int.Parse(Console.ReadLine()));
                    break;
                case "все":
                    prog.ShowAll();
                    break;
                case "закончить":
                    Console.WriteLine("С вами было приятно работать, коллега");
                    return false;
                    break;
                case "помощь":
                    Console.WriteLine("Добавить - создание новой записи\nИзменить - изменение существующей записи\nУдалить - удаление записи\nПросмотр - просмотр информации в записи\nВсе - просмотр всей базы\nПомощь - напоминание о существущих командах\nЗакончить - для завершения работы");
                    break;
                default:
                    Console.WriteLine("Несуществующая команда");
                    break;
            }
            Console.WriteLine();
            return true;
        }

        public void Add()
        {
            Console.WriteLine("Введите обязательные поля в указанном порядке, каждое с новой строчки - Имя, Фамилия, Номер, Страна");
            string tempName = Console.ReadLine();
            string tempSurame = Console.ReadLine();
            int tempNumb;
            while (!int.TryParse(Console.ReadLine(), out tempNumb))
            {
                Console.WriteLine("Введите корректное число");
            }
            string tempCountry = Console.ReadLine();
            Record record = new Record(tempName, tempSurame, tempNumb, tempCountry);
            notebook.Add(record.Id, record);
        }
        public void Change(int id)
        {   
            if (notebook.ContainsKey(id))
            {
                Console.WriteLine("Для редактирования записи, укажите поле для изменения (Имя/фамилия/отчество/телефон/страна/дата рождения/организация/должность/заметки\nДля отмены редактирования введите слово \"Отмена\"");
                notebook[id].Redact(Console.ReadLine()); ;
            }
            else Console.WriteLine("Элемента с таким Id не существует");
        }
        public void Delete(int id)
        {
            if (notebook.ContainsKey(id))
            {
                notebook.Remove(id);
                Console.WriteLine("Элемент с id = " +id+ " удалён");
            }
            else Console.WriteLine("Элемента с таким Id не существует");
        }
        public void Show(int id)
        {
            if (notebook.ContainsKey(id))
            {
                Console.WriteLine( notebook[id].ShowAllInfo());
            }
            else Console.WriteLine("Элемента с таким Id не существует");
        }
        public void ShowAll()
        {
            Dictionary<int, Record>.Enumerator it = notebook.GetEnumerator();
            Console.WriteLine("Id  Фамилия  Имя   Номер");
            while(it.MoveNext())
            {
                Console.WriteLine(it.Current.Value.ToString()); 
                Console.WriteLine("--------------------------");
            }
        }

    }
}

using System;

namespace FirstLab
{
    public class Record
    {
        public static int counter = 1;
        public int Id { set; get; }

        private string secondName;
        public string SecondName { set { secondName = value; } get {return secondName; } }

        private string firstName;
        public string FirstName{ set { firstName = value; } get { return firstName; } }

        private string lastName;
        public string LastName{ set { lastName = value; } get { return lastName; } }

        private int number;
        public int Number  { set { number = value; } get { return number; } }

        private string country;
        public string Country { set { country = value; } get { return country; } }
        private DateTime birthday;
        public DateTime Birthday { set { birthday = value; } get { return birthday; } }
        private string organisation;
        public string Organisation { set { organisation = value; } get { return organisation; } }
        private string job;
        public string Job { set { job = value; } get { return job; } }
        private string others;
        public string Others { set { others = value; } get { return others; } }

        public Record( string firstName, string secondName, int number, string country)
        {
            this.Id = counter;
            counter++;
            this.SecondName = secondName;
            this.FirstName = firstName;
            this.Number = number;
            this.Country = country;
            FillAdditional();
        }
        public void FillAdditional()
        {
            Console.WriteLine("Желаете ли заполнить необязательную информацию? (Да/Нет)");
            if (Console.ReadLine().ToLower() == "да")
            {
                Console.WriteLine("Введите отчество");
                this.LastName = Console.ReadLine();
                Console.WriteLine("Введите дату рождения");
                {
                    DateTime tempDate;
                    if (DateTime.TryParse(Console.ReadLine(), out tempDate))
                        this.Birthday = tempDate;
                }
                Console.WriteLine("Введите название организации");
                this.Organisation = Console.ReadLine();
                Console.WriteLine("Введите должность");
                this.Job = Console.ReadLine();
                Console.WriteLine("Введите заметки");
                this.Others = Console.ReadLine();
            }
        }
        //~Record()
        //{
        //    counter--;
        //}

        public override string ToString()
        {
            return this.Id + " "+ this.SecondName +" "+ this.FirstName +" "+ this.Number;
        }

        public void Redact(string field)
        {
            bool flag = true;
                switch (field.ToLower())
                {
                    case "имя":
                        this.FirstName = Console.ReadLine();
                        break;
                    case "фамилия":
                        this.SecondName = Console.ReadLine();
                        break;
                    case "отчество":
                        this.LastName = Console.ReadLine();
                        break;
                    case "телефон":
                        int temp = 0;
                        if (int.TryParse(Console.ReadLine(), out temp))
                            this.Number = temp;
                        else
                        {
                            Console.WriteLine("Введите корректный номер"); Redact("телефон");
                        }
                        break;
                    case "страна":
                        this.Country = Console.ReadLine();
                        break;
                    case "дата рождения":
                        DateTime tempDate;
                        if (DateTime.TryParse(Console.ReadLine(), out tempDate))
                            this.Birthday = tempDate;
                        else { Console.WriteLine("Введите корректную дату"); Redact("дата рождения"); }
                        break;
                    case "организация":
                        this.Organisation = Console.ReadLine();
                        break;
                    case "должность":
                        this.Job = Console.ReadLine();
                        break;
                    case "заметки":
                        this.Others = Console.ReadLine();
                        break;
                    case "отмена":
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели несуществующую команду\nВведите иную команду");
                        break;
            }

            if (flag) { Console.WriteLine("Изменение проведено. Укажите следующее поле"); Redact(Console.ReadLine()); }
        }

        public string ShowAllInfo()
        {
            string s = "Id - ";
            s += Id + " ";
            if (this.FirstName != null || this.FirstName != "") { s +="Имя: "; s += this.FirstName; s += " "; }
            if (this.SecondName != null || this.SecondName != "") { s += "Фамилия: "; s += this.SecondName; s += " "; }
            if (this.LastName != null || this.LastName != "") { s += "Отчество: "; s += this.LastName; }
            s += "\n";
            if (this.Number != 0) { s += "Номер телефона: "; s += this.Number; s += " "; }
            if (this.Country != null || this.Country != "") { s += "Страна: "; s += this.Country; s += " "; }
            if (this.Birthday != DateTime.MinValue) { s += "День рождения: "; s += this.Birthday; }
            s += "\n";
            if (this.Organisation != null || this.Organisation != "") { s += "Организация: "; s += this.Organisation; s += " "; }
            if (this.Job != null || this.Job != "") { s += "Должность: "; s += this.Job; s += " "; }
            if (this.Others != null || this.Others != "") { s += "Заметки: "; s += this.Others; }

            return s;
        }
    }
}

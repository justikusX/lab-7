
struct Worker
{
    public string LastName;       // Фамилия
    public string FirstName;      // Имя
    public string MiddleName;     // Отчество
    public string Position;       // Должность
    public string Gender;         // пол сотрудника (муж)\|/(жен)
    public DateTime HireDate;     // Дата приёма на работу

    public Worker(string lastName, string firstName, string middleName, string position, string gender, DateTime hireDate)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Position = position;
        Gender = gender;
        HireDate = hireDate;
    }

    
    public int Stage()
    {
        return DateTime.Now.Year - HireDate.Year;
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Worker[] Workers =
        {
            new Worker("Иванов", "Ваня", "Иванович", "Менеджер", "Муж", new DateTime(2015, 5, 10)),
            new Worker("Петров", "Андрюха", "Петрович", "Программист", "Муж", new DateTime(2018, 7, 15)),
            new Worker("Сидорова", "Аня", "Александровна", "Аналитик", "Жен", new DateTime(2010, 3, 20))
        };

        
        double averageExperience = Workers.Average(e => e.Stage());

        
        Console.WriteLine($"Средний стаж сотрудников: {averageExperience:F1} лет");

        
        Console.WriteLine("\nСотрудники со стажем выше среднего:");
        foreach (var Worker in Workers.Where(e => e.Stage() > averageExperience))
        {
            Console.WriteLine($"{Worker.LastName} {Worker.FirstName} {Worker.MiddleName} " +
                              $"\nДолжность: {Worker.Position}" +
                              $"\nПол: {Worker.Gender} " +
                              $"\nДата приёма: {Worker.HireDate.ToShortDateString()}" +
                              $"\nСтаж: {Worker.Stage()} лет");
        }
    }
}
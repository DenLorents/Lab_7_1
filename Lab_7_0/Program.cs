using System;
using System.Collections.Generic;
using System.Linq;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class HospitalQueue
{
    private LinkedList<Patient> patients = new LinkedList<Patient>();

    public void AddPatient(Patient patient)
    {
        patients.AddLast(patient);
        Console.WriteLine($"Пацієнт {patient.Name} додан у чергу. ID пацієнта: {patient.Id}");
    }

    public void RemovePatient(Guid id)
    {
        var patientToRemove = patients.FirstOrDefault(p => p.Id == id);

        if (patientToRemove == null)
        {
            Console.WriteLine($"Пацієнт з ID {id} не доданий у чергу.");
            return;
        }

        patients.Remove(patientToRemove);
        Console.WriteLine($"Пацієнт {patientToRemove.Name} видалений з черги.");
    }

    public void DisplayQueue()
    {
        Console.WriteLine("Черга пацієнтів:");
        foreach (var patient in patients)
        {
            Console.WriteLine($"ID: {patient.Id}, Ім'я: {patient.Name}, Вік: {patient.Age}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        HospitalQueue hospitalQueue = new HospitalQueue();

        while (true)
        {
            Console.WriteLine("1. Дадати пацієнта");
            Console.WriteLine("2. Видалити пацієнта");
            Console.WriteLine("3. Показати чергу");
            Console.WriteLine("4. Вихід");
            Console.Write("Обрати дію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ввести ім'я пацієнта: ");
                    string name = Console.ReadLine();
                    Console.Write("Ввести вік пацієнта: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    hospitalQueue.AddPatient(new Patient { Id = Guid.NewGuid(), Name = name, Age = age });
                    break;
                case "2":
                    Console.Write("Ввести ID пацієнта для видалення: ");
                    Guid idToRemove;
                    if (Guid.TryParse(Console.ReadLine(), out idToRemove))
                    {
                        hospitalQueue.RemovePatient(idToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Невірний формат ID. Будь ласка, спробуйте знову.");
                    }
                    break;
                case "3":
                    hospitalQueue.DisplayQueue();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Будь ласка, спробуйте знову.");
                    break;
            }
        }
    }
}

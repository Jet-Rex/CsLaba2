/*************************
* Автор: Базанов В.В.    *
* Название: ООП на С#    *
*************************/


using System;
using System.Collections.Generic;

namespace AnimalOOP {

  // Base abstract class
  public abstract class Animal {

    public string Nickname { get; private set; }
    public int Age { get; private set; }
    public string Habitat { get; private set; }
    public string DietType { get; private set; }
    public double Weight { get; private set; }

    protected Animal(string nickname, int age, string habitat, string dietType, double weight) {
      Nickname = nickname;
      Age = age;
      Habitat = habitat;
      DietType = dietType;
      Weight = weight;
    }

    public virtual string GetInfo() {
      return $"Nickname: {Nickname}, Age: {Age}, Habitat: {Habitat}, Diet: {DietType}, Weight: {Weight} kg";
    }
  }

  // Derived classes
  public class Mammal : Animal {

    public bool HasFur { get; private set; }

    public Mammal(string nickname, int age, string habitat, string dietType, double weight, bool hasFur)
      : base(nickname, age, habitat, dietType, weight) {
      HasFur = hasFur;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Mammal, Has Fur: {(HasFur ? "Yes" : "No")}";
    }
  }

  public class Bird : Animal {

    public double WingSpan { get; private set; }

    public Bird(string nickname, int age, string habitat, string dietType, double weight, double wingSpan)
      : base(nickname, age, habitat, dietType, weight) {
      WingSpan = wingSpan;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Bird, Wing Span: {WingSpan} m";
    }
  }

  public class Fish : Animal {

    public string WaterType { get; private set; }

    public Fish(string nickname, int age, string habitat, string dietType, double weight, string waterType)
      : base(nickname, age, habitat, dietType, weight) {
      WaterType = waterType;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Fish, Water Type: {WaterType}";
    }
  }

  public class Reptile : Animal {

    public bool IsVenomous { get; private set; }

    public Reptile(string nickname, int age, string habitat, string dietType, double weight, bool isVenomous)
      : base(nickname, age, habitat, dietType, weight) {
      IsVenomous = isVenomous;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Reptile, Venomous: {(IsVenomous ? "Yes" : "No")}";
    }
  }

  public class Amphibian : Animal {

    public string SkinMoisture { get; private set; }

    public Amphibian(string nickname, int age, string habitat, string dietType, double weight, string skinMoisture)
      : base(nickname, age, habitat, dietType, weight)
    {
      SkinMoisture = skinMoisture;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Amphibian, Skin Moisture: {SkinMoisture}";
    }
  }


  // Singleton Manager
  public class AnimalManager {

    private static AnimalManager s_instance;

    public static AnimalManager Instance {
      get {
        if (s_instance == null) {
          s_instance = new AnimalManager();
        }

        return s_instance;
      }
    }

    private List<Animal> animalList;

    private AnimalManager() {
      animalList = new List<Animal>();
    }

    public void AddAnimal(Animal animal) {
      animalList.Add(animal);
    }

    public void ShowAllAnimals() {
      if (animalList.Count == 0) {
        Console.WriteLine("No animals in the system.");
        return;
      }

      for (int animalIndex = 0; animalIndex < animalList.Count; ++animalIndex) {
        Console.WriteLine($"{animalIndex}: {animalList[animalIndex].GetInfo()}");
      }
    }

    public void ShowAnimalByIndex(int index) {
      if (index >= 0 && index < animalList.Count) {
        Console.WriteLine(animalList[index].GetInfo());
      }
      else {
        Console.WriteLine("Invalid index.");
      }
    }
  }

  // Program Entry Point
  class Program {
    static void Main(string[] args) {
      AnimalManager manager = AnimalManager.Instance;

      manager.AddAnimal(new Mammal("Barsik", 5, "Forest", "Predator", 4.5, true));
      manager.AddAnimal(new Bird("Sky", 2, "Mountains", "Omnivore", 1.2, 1.5));
      manager.AddAnimal(new Fish("Nemo", 1, "Ocean", "Omnivore", 0.3, "Saltwater"));

      RunMenu();
    }

    private static void RunMenu() {

      AnimalManager manager = AnimalManager.Instance;
      bool isRunning = true;

      while (isRunning) {

        Console.WriteLine("\n--- Animal Manager ---");
        Console.WriteLine("1 - Show all animals");
        Console.WriteLine("2 - Show animal by index");
        Console.WriteLine("3 - Add new animal");
        Console.WriteLine("0 - Exit");
        Console.Write("Choose option: ");

        string input = Console.ReadLine();

        switch (input) {

          case "1":
            manager.ShowAllAnimals();
            break;

          case "2":
            Console.Write("Enter index: ");
            if (int.TryParse(Console.ReadLine(), out int index)) {
              manager.ShowAnimalByIndex(index);
            }
            else {
              Console.WriteLine("Invalid input.");
            }
            break;

          case "3":
            CreateAnimalFromUserInput();
            break;

          case "0":
            isRunning = false;
            break;

          default:
            Console.WriteLine("Unknown option.");
            break;
        }
      }
    }

    private static void CreateAnimalFromUserInput() {

      AnimalManager manager = AnimalManager.Instance;

      Console.WriteLine("Choose type:");
      Console.WriteLine("1 - Mammal");
      Console.WriteLine("2 - Bird");
      Console.WriteLine("3 - Fish");
      Console.WriteLine("4 - Reptile");
      Console.WriteLine("5 - Amphibian");

      string typeChoice = Console.ReadLine();

      Console.Write("Nickname: ");
      string nickname = Console.ReadLine();

      Console.Write("Age: ");
      int age = int.Parse(Console.ReadLine());

      Console.Write("Habitat: ");
      string habitat = Console.ReadLine();

      Console.Write("Diet type: ");
      string dietType = Console.ReadLine();

      Console.Write("Weight: ");
      double weight = double.Parse(Console.ReadLine());

      switch (typeChoice) {
        case "1":
          Console.Write("Has fur (true/false): ");
          bool hasFur = bool.Parse(Console.ReadLine());
          manager.AddAnimal(new Mammal(nickname, age, habitat, dietType, weight, hasFur));
          break;

        case "2":
          Console.Write("Wing span: ");
          double wingSpan = double.Parse(Console.ReadLine());
          manager.AddAnimal(new Bird(nickname, age, habitat, dietType, weight, wingSpan));
          break;

        case "3":
          Console.Write("Water type: ");
          string waterType = Console.ReadLine();
          manager.AddAnimal(new Fish(nickname, age, habitat, dietType, weight, waterType));
          break;

        case "4":
          Console.Write("Is venomous (true/false): ");
          bool isVenomous = bool.Parse(Console.ReadLine());
          manager.AddAnimal(new Reptile(nickname, age, habitat, dietType, weight, isVenomous));
          break;

        case "5":
          Console.Write("Skin moisture: ");
          string skinMoisture = Console.ReadLine();
          manager.AddAnimal(new Amphibian(nickname, age, habitat, dietType, weight, skinMoisture));
          break;

        default:
          Console.WriteLine("Invalid type selected.");
          break;
      }
    }
  }
}
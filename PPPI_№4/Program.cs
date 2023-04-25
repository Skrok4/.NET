using System;
using System.Reflection;

namespace ReflectionDemo
{
    public class Car
    {
        private string _make;
        public string Model
        {
            get; set;
        }
        public int Year
        {
            get; set;
        }
        public float Price
        {
            get; set;
        }
        private bool _isAvailable;

        public Car(string make, string model, int year, float price, bool isAvailable)
        {
            _make = make;
            Model = model;
            Year = year;
            Price = price;
            _isAvailable = isAvailable;
        }

        public string GetMake()
        {
            return _make;
        }

        public bool SetAvailability(bool isAvailable)
        {
            _isAvailable = isAvailable;
            return _isAvailable;
        }

        public void PrintCarInfo()
        {
            Console.WriteLine($"Make: {_make}\tModel: {Model}\tYear: {Year}\tPrice: ${Price:c}\tAvailable: {(_isAvailable ? "Yes" : "No")}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Get the type and type info of the Car class
            Type carType = typeof(Car);
            TypeInfo carTypeInfo = carType.GetTypeInfo();
            // Print information about the type
            Console.WriteLine($"Type name: {carType.Name}");
            Console.WriteLine($"Type namespace: {carType.Namespace}");
            Console.WriteLine($"Type full name: {carType.FullName}");
            Console.WriteLine($"Type assembly qualified name: {carType.AssemblyQualifiedName}");

            Console.WriteLine($"Is class: {carTypeInfo.IsClass}");
            Console.WriteLine($"Is abstract: {carTypeInfo.IsAbstract}");
            Console.WriteLine($"Is sealed: {carTypeInfo.IsSealed}");
            Console.WriteLine($"Is public: {carTypeInfo.IsPublic}");

            // Get all public and instance members of the Car class
            MemberInfo[] carMembers = carType.GetMembers(BindingFlags.Public | BindingFlags.Instance);

            // Print information about each member
            foreach (MemberInfo member in carMembers)
            {
                Console.WriteLine($"Member name: {member.Name}, Member type: {member.MemberType}");
            }

            // Get the value of the private _make field of the Car instance
            Car car = new("Honda", "Civic", 2020, 20000, true);
            car.PrintCarInfo();

            FieldInfo makeField = carType.GetField("_make", BindingFlags.NonPublic | BindingFlags.Instance);
            string makeValue = (string)makeField.GetValue(car);
            Console.WriteLine($"Make value: {makeValue}");

            // Set the value of the _make field to another one value and get the new one
            makeField.SetValue(car, "Toyota");
            makeValue = (string)makeField.GetValue(car);
            Console.WriteLine($"Make value after update: {makeValue}");

            // Invoke the PrintCarInfo method of the Car instance
            MethodInfo printCarInfoMethod = carType.GetMethod("PrintCarInfo", BindingFlags.Public | BindingFlags.Instance);
            printCarInfoMethod.Invoke(car, null);
        }
    }
}
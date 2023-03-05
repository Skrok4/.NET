using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Net.Http;

namespace DotNetStandardApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\tUsing System.Collections.Generic library");
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\tUsing System.IO library");
            string fileName = "example.txt";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            if (File.Exists(filePath))
            {
                string contents = File.ReadAllText(filePath);
                Console.WriteLine(contents);
            }
            else
            {
                Console.WriteLine($"File '{fileName}' does not exist in directory '{Directory.GetCurrentDirectory()}'.");
            }

            Console.WriteLine("\tUsing System.Linq library");
            int[] array = { 2, 4, 6, 8, 10 };
            int sum = array.Sum();
            Console.WriteLine("Sum of array elements: " + sum);

            Console.WriteLine("\tUsing System.Text library");
            string text = "hello world";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            Console.WriteLine("Encoded string: " + Encoding.UTF8.GetString(bytes));

            Console.WriteLine("\tUsing System.Xml library");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<root><child>Hello world!</child></root>");
            XmlNode node = xmlDocument.SelectSingleNode("/root/child");
            Console.WriteLine("Node value: " + node.InnerText);

            Console.WriteLine("\tUsing System.Diagnostics library");
            Process process = new Process();
            process.StartInfo.FileName = "notepad.exe";
            process.Start();

            Console.WriteLine("\tUsing System.Security.Cryptography library");
            byte[] inputBytes = Encoding.UTF8.GetBytes("password");
            byte[] hashBytes = SHA256.Create().ComputeHash(inputBytes);
            string hash = Convert.ToBase64String(hashBytes);
            Console.WriteLine("Hashed password: " + hash);

            Console.WriteLine("\tUsing System.Net.Http library");
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://www.google.com");
                Console.WriteLine("Status code: " + response.StatusCode);
            }
            Console.WriteLine("\tUsing System.Threading.Tasks library");
            await Task.Run(() =>
            {
                Console.WriteLine("Task running...");
                Task.Delay(5000).Wait();
                Console.WriteLine("Task finished.");
            });

            Console.ReadKey();
        }
    }
}
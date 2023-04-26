using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using Newtonsoft.Json;

namespace APIClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var apiClient = new ApiClient(httpClient);
            var textApi = new TextApi(apiClient);

            // GET request
            var getResult = await textApi.Get<List<User>>("https://reqres.in/api/users?page=2");
            Console.WriteLine($"Message: {getResult.Message}\nStatus code: {getResult.StatusCode}");

            if (getResult.Data != null && getResult.Data is List<User> list)
            {
                foreach (var user in list)
                {
                    Console.WriteLine($"ID: {user.id}\nEmail: {user.email}\nFull Name: {user.first_name} {user.last_name}\nAvatar: {user.avatar}\n");
                }
            }

            // POST request
            var postResult = await textApi.Post<User>("https://reqres.in/api/users", new
            {
                id = 13,
                first_name = "John",
                last_name = "Doe",
                email = "JohnDoe22@yahoo.com",
                avatar = "https://upload.wikimedia.org/wikipedia/ru/thumb/4/4d/Wojak.png/200px-Wojak.png"
            });;

            Console.WriteLine($"Message: {postResult.Message}\nStatus code: {postResult.StatusCode}");

            if (postResult.Data != null && postResult.Data is User newUser)
            {
                Console.WriteLine($"New user data:\nID: {newUser.id}\nEmail: {newUser.email}\nFull Name: {newUser.first_name} {newUser.last_name}\nAvatar: {newUser.avatar}\n");
            }

            Console.ReadLine();
        }
    }
}
using AndreAirLines.API.Models.Enums;
using AndreAirLines.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AndreAirLines.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
            RunAsync().Wait();
        }

        public static async Task RunAsync()
        {
            Console.WriteLine("Digite o caminho do arquivo");
            string caminho = Console.ReadLine();
            await AdicionarVoos(ReadJson.getData<Passagem>(caminho));

            Console.WriteLine("Adicionado com sucesso");
        }

        public async static Task AdicionarVoos(List<Passagem> passagens)
        {
            foreach (var passagem in passagens)
            {
                await AdicionarVoos(passagem);
            }
        }

        public async static Task AdicionarVoos(Passagem passagem)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.PostAsJsonAsync($"api/Passagens", passagem);

            }
        }


    }
}

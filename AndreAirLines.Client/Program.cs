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
            GetBasePrices().Wait();
            RunAsync().Wait();
        }

        public static async Task RunAsync()
        {
            Console.WriteLine("Digite o caminho do arquivo");
            string caminho = Console.ReadLine();
            await AdicionarVoos(ReadJson.getData<Ticket>(caminho));

            Console.WriteLine("Adicionado com sucesso");
        }

        public async static Task AdicionarVoos(List<Ticket> passagens)
        {
            foreach (var passagem in passagens)
            {
                await AdicionarVoos(passagem);
            }
        }

        public async static Task AdicionarVoos(Ticket passagem)
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

        public async static Task GetBasePrices()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = (await client.GetAsync($"api/BasePrices")).Content.ReadAsStringAsync();
                Console.WriteLine(response);
            }
        }


    }
}

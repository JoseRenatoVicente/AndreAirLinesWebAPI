using AndreAirLines.Domain.Entities;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AndreAirLines.Application.Services
{
    public  class ViaCepService
    {
        public async Task<Endereco> ConsultarCEP(string cep)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://viacep.com.br/");
                var response = await client.GetAsync($"ws/{cep}/json/");
                ViaCep endereco = await response.Content.ReadFromJsonAsync<ViaCep>();

                return new Endereco(endereco.bairro, endereco.localidade, endereco.cep, endereco.Logradouro, endereco.uf);
            }
        }
    }
}

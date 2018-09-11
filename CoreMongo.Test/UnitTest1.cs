using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoreMongo.Test
{
    public class UnitTest1
    {
        readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };

        private async Task<List<Nota>> GetNotasAsync()
        {
            var response = await this.client.GetAsync("/Api/Notas");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Nota>>(content);
            }

            return null;
        }

        private async Task<bool> CreateNotaAsync(Nota nota)
        {
            var content = new StringContent(JsonConvert.SerializeObject(nota), Encoding.UTF8, "application/json");

            var response = await this.client.PostAsync("/Api/Notas", content);

            return response.IsSuccessStatusCode;
        }

        private async Task<bool> UpdateNotaAsync(Nota nota)
        {
            var content = new StringContent(JsonConvert.SerializeObject(nota), Encoding.UTF8, "application/json");

            var response = await this.client.PutAsync($"/Api/Notas/{nota.Id}", content);

            return response.IsSuccessStatusCode;
        }

        private async Task<bool> DeleteNotaAsync(Guid id)
        {
            var response = await this.client.DeleteAsync($"/Api/Notas/{id}");

            return response.IsSuccessStatusCode;
        }

        [Fact]
        public async void BuscaProdutos()
        {
            var notas = await GetNotasAsync();

            Assert.True(notas != null && notas.Count > 0);
        }

        [Fact]
        public async void IncluiProduto()
        {
            bool sucesso = await CreateNotaAsync(new Nota() { Titulo = "Titulo", Conteudo = "Titulo ou subtitulo", Acessos = 10 });

            Assert.True(sucesso);
        }

        [Fact]
        public async void IncluiEExcluiProduto()
        {
            bool sucessoInclusao = await CreateNotaAsync(new Nota() { Titulo = "Titulo a ser excluido", Conteudo = "Titulo ou subtitulo", Acessos = 1000 });
            bool sucessoExclusao = false;

            var notas = await GetNotasAsync();

            if (notas.Count > 0)
            {
                Guid idExcluir = notas.LastOrDefault().Id;

                sucessoExclusao = await DeleteNotaAsync(idExcluir);
            }

            Assert.True(sucessoInclusao && sucessoExclusao);
        }
    }
}
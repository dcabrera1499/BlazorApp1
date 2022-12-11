using BlazorApp1.Shared;
using System.Diagnostics;
using System.Net.Http.Json;

namespace BlazorApp1.Client.Pages
{
    public partial class Index 
    {

        private List<Usuario> lista;

        protected override async Task OnInitializedAsync()
        {
            lista = await Http.GetFromJsonAsync<List<Usuario>>("api/Usuario");
        }

         void metodoEditarComida(int Cualquiercosa)
        {
            Debug.WriteLine("Cualquier cosa vale: " +Cualquiercosa);

        }

    }
}

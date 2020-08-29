using Movie_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Movie_UI.Pages
{
    public partial class AddMovie
    {
        private MovieCreateModel _movieCreateModel = new MovieCreateModel();


        public string Address { get; set; }
        private async void Savetodb()
        {
            _movieCreateModel.Actors= new int[] { 5, 6 };
            var content = JsonContent.Create(_movieCreateModel);
            var result = await httpClient.PostAsync("api/movie", content);
            var readasstring = await result.Content.ReadAsStringAsync();
            Console.WriteLine(readasstring);
        }
    }
}

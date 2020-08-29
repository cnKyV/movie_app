using Movie_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Movie_UI.Pages
{
    public partial class AddActor
    {
        private ActorCreateModel _actorCreateModel = new ActorCreateModel();

        
        public string Address { get; set; }
        private async void Savetodb()
        {
            _actorCreateModel.MovieId = new int[] { 5, 6 };
            var content = JsonContent.Create(_actorCreateModel);
            var result = await httpClient.PostAsync("api/actor", content);
            var readasstring = await result.Content.ReadAsStringAsync();
            Console.WriteLine(readasstring);
        }
    }
    
}

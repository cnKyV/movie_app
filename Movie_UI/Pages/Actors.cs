using Microsoft.AspNetCore.Components;
using Movie_API.Models.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Movie_UI.Pages
{
    public partial class Actors
    {
        private IEnumerable<ActorResponseModel> _actors;
        private List<string> _actorNames;
        protected override async Task OnInitializedAsync()
        {
            var result = await httpClient.GetAsync("api/actor");
            var readasstring = await result.Content.ReadAsStringAsync();
           _actors = JsonConvert.DeserializeObject<IEnumerable<ActorResponseModel>>(readasstring);
            Console.WriteLine(Address);
            
            var result2 = await httpClient.PostAsync("api/actor/ReturnNameById", JsonContent.Create(new int[] { 4, 5, 6, 7 }));
            var readasstring2 = await result2.Content.ReadAsStringAsync();
            _actorNames = JsonConvert.DeserializeObject<List<string>>(readasstring2);
            StateHasChanged();
        }
        [Parameter]
        public string Address { get; set; }

    }
}

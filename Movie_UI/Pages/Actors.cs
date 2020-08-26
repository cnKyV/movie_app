using Microsoft.AspNetCore.Components;
using Movie_API.Models.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_UI.Pages
{
    public partial class Actors
    {
        private IEnumerable<ActorResponseModel> _actors;
        protected override async Task OnInitializedAsync()
        {
            var result = await httpClient.GetAsync(Address);
            var readasstring = await result.Content.ReadAsStringAsync();
           _actors = JsonConvert.DeserializeObject<IEnumerable<ActorResponseModel>>(readasstring);
            StateHasChanged();
        }
        [Parameter]
        public string Address { get; set; }
        private void BtnClick()
        {
            _actors = null;
        }
    }
}

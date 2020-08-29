using Movie_API.Contracts.Models.ResponseModels;
using Movie_API.Models.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_UI.Pages
{
    public partial class Movies
    {
        private IEnumerable<MovieResponseModel> _movies;

        
        
        protected override async Task OnInitializedAsync()
        {
            var result = await httpClient.GetAsync("api/movie");
            var readasstring = await result.Content.ReadAsStringAsync();
            _movies = JsonConvert.DeserializeObject<IEnumerable<MovieResponseModel>>(readasstring);
      
            
            StateHasChanged();
        }
    }
}

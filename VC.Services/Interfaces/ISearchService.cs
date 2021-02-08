using System.Collections.Generic;
using VC.Services.Models;

namespace VC.Services.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<VideoViewModel> Procurar(SearchParametersViewModel parameters);
        VideoViewModel ObterVideo(string id);
    }
}
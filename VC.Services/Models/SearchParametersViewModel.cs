using System.ComponentModel.DataAnnotations;
using VC.Commom.Enumerables;

namespace VC.Services.Models
{
    public class SearchParametersViewModel
    {
        [Required]
        [Display(Name = "Valor para pesquisa")]
        public string SearchText { get; set; }
        
        [EnumDataType(typeof(SearchTypes))]
        public SearchTypes SearchType { get; set; }
    }
}
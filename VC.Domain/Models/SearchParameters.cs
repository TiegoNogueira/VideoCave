using System.ComponentModel.DataAnnotations;
using VC.Commom.Enumerables;

namespace VC.Domain.Models
{
    public class SearchParameters
    {
        [Required]
        public string SearchText { get; set; }
        
        [EnumDataType(typeof(SearchTypes))]
        public SearchTypes SearchType { get; set; }
    }
}
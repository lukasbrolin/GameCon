using System.ComponentModel.DataAnnotations;

namespace DatingSite.Models
{
    public class GenreViewModel
    {
        [Display(Name = "Genre")]
        public string Name { get; set; }

        public GenreViewModel(string name)
        {
            this.Name = name;
        }
    }


}
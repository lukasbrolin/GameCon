using System.ComponentModel.DataAnnotations;

namespace DatingSite.Models
{
    public class PlatformViewModel
    {
        [Display(Name = "Platform")]
        public string Name { get; set; }

        public PlatformViewModel(string name)
        {
            this.Name = name;
        }
    }


}
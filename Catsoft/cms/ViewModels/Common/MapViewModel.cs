namespace App.cms.ViewModels.Common
{
    public class MapViewModel
    {
        public string Location { get; set; }

        public static MapViewModel GetDefaultLocation()
        {
            return new MapViewModel()
            {
               Location = "<iframe class='h-100 w-100' style=\"border:0;filter: invert(90%)\"; src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1400.9547568430396!2d-7.420237106767184!3d37.19450966157094!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd10239f35bdc05f%3A0x91e6e5c9f447ab24!2sVIRTUALITY%2C%20UNIPESSOAL%20LDA!5e0!3m2!1sen!2spt!4v1714339139266!5m2!1sen!2spt\" allowfullscreen=\"\" loading=\"lazy\" referrerpolicy=\"no-referrer-when-downgrade\"></iframe>"
            };
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.cms.Repositories.TextResource;
using App.Models.Booking;

namespace App.ViewModels.Views
{
    public class SelectorViewModel(string label, string value, List<KeyValueViewModel> options, bool multipleSelection)
    {
        public string Label { get; set; } = label;

        public string SelectedValue { get; set; } = value;

        public List<KeyValueViewModel> Options { get; set; } = options;

        public bool MultipleSelection { get; set; } = multipleSelection;

        public bool DefaultSelection { get; set; } = true;

        public string OnChangeScript { get; set; }

        public bool WithDefaultValue { get; set; } = true;

        public bool Enabled { get; set; } = true;

        public static async Task<SelectorViewModel> GetGuestsSelector(
            PersonBookingModel personBooking,
            TextResourceRepository textRepository)
        {
            var options = cms.Options.Options.Booking.GetOptions();

            var guest = await textRepository.GetByTagAsync("guest");
            var guests = await textRepository.GetByTagAsync("guests");

            var optionsLabels = new List<string>();
            foreach (var label in options.Select(w => w == 1 ? w + " " + guest : w + " " + guests))
            {
                optionsLabels.Add(await textRepository.GetByTagAsync(label));
            }

            var personCount = personBooking.PeopleCount;

            var selectorDto = new SelectorViewModel(await textRepository.GetByTagAsync("Number of guests"),
                personCount.ToString(),
                options.Select(w => new KeyValueViewModel(optionsLabels[w - 1], w.ToString())).ToList(),
                false)
            {
                DefaultSelection = false,
                WithDefaultValue = false
            };
            return selectorDto;
        }
    }
}
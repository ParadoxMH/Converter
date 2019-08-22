
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CurencyConverter.Models
{
    public class CurrencyDropDownModel
    {
        private readonly List<Currency> _currencies;

        [Display(Name = "Favorite Flavor")]
        public int SelectedFlavorId { get; set; }

        public IEnumerable<SelectListItem> FlavorItems
        {
            get { return new SelectList(_currencies, "Id", "Name"); }
        }
        //public int Id { get; set; }
        //public string Name { get; set; }

        public CurrencyDropDownModel(List<Currency> currencies)
        {
            _currencies = currencies;
        }
    }
}

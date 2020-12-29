using Microsoft.AspNetCore.Mvc.Rendering;
using Model;

using System.Collections.Generic;


namespace Models.ViewModel
{
    public class MenuItemViewModel
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }
    }
}
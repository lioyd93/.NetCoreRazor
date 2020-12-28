using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data.Repository.IRepository
{
    public interface IFoodTypeRepository :IRepository<FoodType> 
    {
        IEnumerable<SelectListItem> GetSelectListItemsFoodType();

        void Update(FoodType foodtype);
        
    }
}

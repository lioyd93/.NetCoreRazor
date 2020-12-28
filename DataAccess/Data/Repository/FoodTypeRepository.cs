using DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Data.Repository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {

        private readonly ApplicationDbContext _db;
        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetSelectListItemsFoodType()
        {
           return _db.FoodType.Select(i => new SelectListItem()
           {
               Text = i.Name,
               Value = i.Id.ToString()
           });

        }

        public void Update(FoodType foodtype)
        {
            var FoodObj = _db.FoodType.FirstOrDefault(i => i.Id == foodtype.Id);
            FoodObj.Name = foodtype.Name;
            _db.SaveChanges();
        }
    }
}

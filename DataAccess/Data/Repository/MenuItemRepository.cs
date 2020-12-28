﻿using DataAccess.Data.Repository.IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Data.Repository
{
    public class MenuItemRepository : Repository<MenuItem>,IMenuItemRepository
    {

        private readonly ApplicationDbContext _db;
        public MenuItemRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(MenuItem menuItem)
        {
            var menuItemFromDb = _db.MenuItem.FirstOrDefault(s=>s.Id==menuItem.Id);

            menuItemFromDb.Name = menuItem.Name;
            menuItemFromDb.CategoryId = menuItem.CategoryId;
            menuItemFromDb.Description = menuItem.Description;
            menuItemFromDb.FoodTypeId = menuItem.FoodTypeId;
            menuItemFromDb.Price = menuItem.Price;
            if(menuItemFromDb.Image !=null)
            {
                menuItemFromDb.Image = menuItem.Image;
            }
            _db.SaveChanges();
        }
    }
}

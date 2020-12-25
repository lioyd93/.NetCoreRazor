﻿using DataAccess.Data.Repository.IRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data.Repository
{
    class UnitOfWork : IUnitOfWork

    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }
        public ICategoryRepository Category { get; private set;  }

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

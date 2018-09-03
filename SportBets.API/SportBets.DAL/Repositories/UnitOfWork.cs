﻿using SportBets.BLL.Interfaces;
using SportBets.DAL.EntitiesContext;

namespace SportBets.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportBetsContext _context;
        
        
        public UnitOfWork(SportBetsContext context)
        {
            this._context = context;
        }

        public UnitOfWork()
        {
            _context = new SportBetsContext();
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }
        
    }
}


using CoreDomain.Interfaces;
using CoreDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        #region Fileds
        protected readonly DbContext db;

        public UnitOfWork()
        {
            db = new TContext();
        }

        #endregion


       


        #region Dispose And Save

        public Task<int> AsyncSave() => db.SaveChangesAsync();
        public void Save() => db.SaveChanges();



        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}

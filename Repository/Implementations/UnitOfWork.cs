using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private BlackMarketDBContext context = new BlackMarketDBContext();
        private GenericRepository<Artifact> artifactRepository;
        private GenericRepository<Dealer> dealerRepository;
        private GenericRepository<Transaction> transactionRepository;
        public GenericRepository<Artifact> ArtifactRepository
        {
            get
            {

                if (this.artifactRepository == null)
                {
                    this.artifactRepository = new GenericRepository<Artifact>(context);
                }
                return artifactRepository;
            }
        }
        public GenericRepository<Dealer> DealerRepository
        {
            get
            {
                if (this.dealerRepository == null)
                {
                    this.dealerRepository = new GenericRepository<Dealer>(context);
                }
                return dealerRepository;
            }
        }
        public GenericRepository<Transaction> TransactionRepository
        {
            get
            {
                if (this.transactionRepository == null)
                {
                    this.transactionRepository = new GenericRepository<Transaction>(context);
                }
                return transactionRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

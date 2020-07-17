using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reader.Application.Common.Interfaces;
using Readerz.Domain.Common;
using Readerz.Domain.Entities;


namespace Readerz.Persistence
{
    public class ReaderzDbContext : DbContext, IReaderzDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public ReaderzDbContext(DbContextOptions options) : base(options)
        {
        }
    
        public ReaderzDbContext(DbContextOptions options,
            ICurrentUserService currentUserService) 
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardSet> CardSets { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<CardCreator> CardCreators { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
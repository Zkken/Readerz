using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Readerz.Domain.Entities;

namespace Reader.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<CardSet> CardSets { get; set; }
        DbSet<Readerz.Domain.Entities.Text> Texts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

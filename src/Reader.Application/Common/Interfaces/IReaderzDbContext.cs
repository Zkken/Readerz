using Microsoft.EntityFrameworkCore;
using Readerz.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Reader.Application.Common.Interfaces
{
    public interface IReaderzDbContext
    {
        DbSet<Readerz.Domain.Entities.CardCreator> CardCreators { get; set; }
        DbSet<Card> Cards { get; set; }
        DbSet<CardSet> CardSets { get; set; }
        DbSet<Readerz.Domain.Entities.Text> Texts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

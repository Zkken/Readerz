using Microsoft.EntityFrameworkCore;
using Readerz.Web.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Reader.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<CardSet> CardSets { get; set; }
        DbSet<Readerz.Web.Domain.Entities.Text> Texts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

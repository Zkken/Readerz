using Microsoft.EntityFrameworkCore;
using Readerz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reader.Application.Common.Interfaces
{
    public interface IReaderzDbContext
    {
        DbSet<Card> Cards { get; set; }
        DbSet<CardSet> CardSets { get; set; }
        DbSet<Text> Texts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

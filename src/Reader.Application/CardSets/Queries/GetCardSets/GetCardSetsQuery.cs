using MediatR;
using Readerz.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Reader.Application.CardSets.Queries.GetCardSets
{
    public class GetCardSetsQuery : IRequest<CardSetVm>
    {
        public int UserId { get; set; }
    }
}
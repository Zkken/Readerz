using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reader.Application.CardSets.Commands.CreateCommand
{
    class CreateCardSetCommand : IRequest
    {
        public int Id { get; set; }


    }
}

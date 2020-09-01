using AutoMapper;

namespace Reader.Application.CardSets.Commands.IncrementCardSetCommand.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}

using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class RankTypeService : BaseService<RankType>, IRankTypeService
    {
        public RankTypeService(IRankTypeRepository repository) : base(repository)
        {
        }
    }
}
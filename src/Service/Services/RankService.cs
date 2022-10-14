using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class RankService : BaseService<Rank>, IRankService
    {
        public RankService(IRankRepository repository) : base(repository)
        {
        }
    }
}
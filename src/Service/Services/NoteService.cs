using FluentValidation;
using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class NoteService : BaseService<Note>, INoteService
    {
        public NoteService(INoteRepository repository) : base(repository)
        {
        }
    }
}
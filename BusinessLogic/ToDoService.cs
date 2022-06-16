using AutoMapper;
using Data.Domain.Models;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ToDoService:BaseService
    {
        private readonly ToDoDbContext _dbContext;
        public ToDoService(ToDoDbContext dbContext, IMapper mapper) : base(mapper)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ToDoViewModel>> FetchAsync()
        {
            return await _dbContext.ToDos.Select(x => new ToDoViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                UserId = x.UserId,
            }).ToListAsync();  
        }
        public async Task<IEnumerable<ToDoViewModel>> FetchAsync(string userId)
        {
            var items = await _dbContext.ToDos.ToListAsync();
            return Mapper.Map<IEnumerable<ToDoViewModel>>(items);
        }
        public async Task<ToDoViewModel> FetchAsync(int id)
        {
            var todo = await _dbContext.ToDos.SingleOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<ToDoViewModel>(todo);
        }
        public Task<List<ToDoViewModel>> AddAsync(ToDoViewModel model)
        {
            return _dbContext.ToDos.Select(x => new ToDoViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                //UserId = x.UserId,
            }).ToListAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var todo = await _dbContext.ToDos.SingleOrDefaultAsync(x => x.Id == id);
            _dbContext.ToDos.Remove(todo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoViewModel todo)
        {
            var item = await _dbContext.ToDos.SingleOrDefaultAsync(x => x.Id == todo.Id);
            item.Name = todo.Name;
            item.Description = todo.Description;
            item.Complete = todo.Complete;

            _dbContext.ToDos.Update(item);
            await _dbContext.SaveChangesAsync();

        }
        public async Task CreateAsync(ToDoViewModel model)
        {
            await _dbContext.ToDos.AddAsync(Mapper.Map<ToDo>(model));

            await _dbContext.SaveChangesAsync();
        }
        public async Task CloseAsync(int id)
        {
            var item = await _dbContext.ToDos.SingleOrDefaultAsync(x => x.Id == id);

            //TODO check for null

            item.Complete = true;

            _dbContext.ToDos.Update(item);

            await _dbContext.SaveChangesAsync();
        }
    }
}

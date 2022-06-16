using Common.Mappings;
using AutoMapper;
using System.Collections.Generic;

namespace Data.Domain.Models
{
    public class ToDoViewModel : IMapFrom<ToDo>, IMapTo<ToDo>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
        public string SelectedItem { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        //public IEnumerable<ToDo> Todos { get; set; }
       
    }
}

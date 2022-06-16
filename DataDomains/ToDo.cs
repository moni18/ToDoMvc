using Data.Domain.Base;


namespace Data.Domain.Models
{
    public class ToDo : NameKeyEntityBase<int>
    {             
        public string Description { get; set; }
        public bool Complete { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }       


    }
}

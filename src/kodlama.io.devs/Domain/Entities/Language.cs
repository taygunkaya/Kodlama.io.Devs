using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Language : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Framework> Frameworks { get; set; }
        public DateTime CreateDate { get; set; }

        public Language()
        {

        }

        public Language(int id, string name, DateTime creteDate) : this()
        {
            Id = id;
            Name = name;
            CreateDate = creteDate;
        }
    }
}

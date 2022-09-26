using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Dtos
{
    public class CreatedLanguageDto
    {
        public int Id { get; set; } 
        public int Name { get; set; }  
        public DateTime CreateDate { get; set; } = DateTime.Now;  



    }
}

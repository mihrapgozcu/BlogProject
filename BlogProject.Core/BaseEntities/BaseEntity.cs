using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.BaseEntities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }  
        public string? DeletedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public  DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace c240tube.entity
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        
        public DateTime CreateAt { get; set; }
        public BaseEntity()
        {
            this.IsDeleted = false;
            CreateAt = DateTime.Now;
        }
    }
}

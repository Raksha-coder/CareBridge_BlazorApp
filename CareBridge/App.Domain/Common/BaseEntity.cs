namespace App.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime DeletedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}

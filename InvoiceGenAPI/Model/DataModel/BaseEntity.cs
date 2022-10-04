namespace InvoiceGenAPI.Model.DataModel
{
    public class BaseEntity
    {
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
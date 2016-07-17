using System;
using Models.Enums;

namespace Models.Models
{
    public class Tree
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDateTime { get; set; }
        public DateTime TransplantDateTime { get; set; }
        public TreeShapeType TreeShapeType { get; set; }
        public TransplantType TransplantType { get; set; }
        public decimal Price { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public ApplicationUser UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string CreatedByUserId { get; set; }
        public string UpdatedByUserId { get; set; }
    }
}

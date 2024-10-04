using IdentityProvider.Domain.Interfaces;

namespace SweetAuth.IdentityProvider.Domain.Entities
{
    public class BaseEntity : IIdentifiable, IActivable, IDeletable, ICreatedAt
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

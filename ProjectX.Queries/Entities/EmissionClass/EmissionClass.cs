using ProjectX.Queries.Entities.Common;

namespace ProjectX.Queries.Entities.EmissionClass
{
    public class EmissionClass : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}

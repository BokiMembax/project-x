using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.EmissionClass
{
    public class EmissionClass : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}

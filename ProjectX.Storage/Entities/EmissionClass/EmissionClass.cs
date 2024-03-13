using ProjectX.Storage.Entities.Common;

namespace ProjectX.Storage.Entities.EmissionClass
{
    public class EmissionClass : BaseEntity
    {
        /// <summary>
        /// Emission class name 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Emission class description
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}

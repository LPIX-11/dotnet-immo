namespace Immovable.Models
{
    public class ImmovableStoreDatabaseSettings : IImmovableStoreDatabaseSettings
    {
        public string ImmovableCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IImmovableStoreDatabaseSettings
    {
        string ImmovableCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
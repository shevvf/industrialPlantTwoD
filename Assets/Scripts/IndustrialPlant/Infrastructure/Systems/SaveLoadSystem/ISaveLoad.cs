namespace IndustrialPlant.Infrastructure.Systems.SaveLoadSystem
{
    public interface ISaveLoad : IEntryPoint
    {
        void Save();

        void Load();

        void Rewrite();
    }
}
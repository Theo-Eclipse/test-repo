namespace Wolfdev.Configs.API
{
    public interface IConfig
    {
        System.Type Type { get; }
        string Name { get; }
    }
}
namespace ViolaTricolor.Configuration
{
    public interface IConfig
    {
        void MergeWith(IConfig config);
    }
}

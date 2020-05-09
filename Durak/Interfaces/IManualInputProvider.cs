namespace Durak
{
    public interface IManualInputProvider
    {
        string message { get; }
        int ReturnLanguageTypeInputValue();
    }
}

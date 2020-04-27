using Durak.Properties;

namespace Durak.Interfaces
{
    public interface IConfigurationSetter
    {
        IMessages Message { get; }
        IAlerts Alert { get; }
        IDefaultConstants Constant { get; }
        ICardAttributesConverter CardAttributes { get; }
    }
}

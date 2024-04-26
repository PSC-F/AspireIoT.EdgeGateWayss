using AspireIoT.EdgeGateWays.ProtcolAdaptService.Protocol.MQTT;

namespace AspireIoT.EdgeGateWays.ProtcolAdaptService.Protocol;

public interface IProtocol
{
    Task ConnectAsync(string serverAddress, int port);
    Task SendMessageAsync(string topic, string message);
    Task DisconnectAsync();
}
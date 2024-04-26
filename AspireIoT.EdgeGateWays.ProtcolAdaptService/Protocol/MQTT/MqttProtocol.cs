using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace AspireIoT.EdgeGateWays.ProtcolAdaptService.Protocol.MQTT;

public class MqttProtocol : IProtocol
{
    private IMqttClient mqttClient;

    public async Task ConnectAsync(string serverAddress,int port)
    {
        try
        {
            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(serverAddress,port)
                .Build();
            Console.WriteLine("connect");
            await mqttClient.ConnectAsync(options);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }


        // 返回当前实例，以支持链式调用
    }

    public async Task SendMessageAsync(string topic, string message)
    {
        if (mqttClient == null || !mqttClient.IsConnected)
        {
            throw new InvalidOperationException("MQTT client is not connected.");
        }

        try
        {
            var mqttMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(message)
                .Build();
            Console.WriteLine("send");
            await mqttClient.PublishAsync(mqttMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public async Task DisconnectAsync()
    {
        try
        {
            if (mqttClient != null && mqttClient.IsConnected)
            {
                Console.WriteLine("DisconnectAsync");
                await mqttClient.DisconnectAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
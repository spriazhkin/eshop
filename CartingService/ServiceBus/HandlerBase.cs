using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceBus;

namespace Usga.Deacon.Tools.MessageBroker;

public abstract class HandlerBase : IHostedService, IAsyncDisposable
{
    private readonly ILogger<HandlerBase> _logger;
    private readonly ServiceBusProcessor _processor;
    private readonly TypeInfoConverter _converter;

    protected abstract string Topic { get; }

    private protected HandlerBase(ServiceBusClient client, ILogger<HandlerBase> logger, TypeInfoConverter converter)
    {
        _processor = client.CreateProcessor(Topic);
        _logger = logger;
        _converter = converter;
    }

    public ValueTask DisposeAsync()
    {
        return _processor.DisposeAsync();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _processor.ProcessMessageAsync += MessageHandler;
        _processor.ProcessErrorAsync += ErrorHandler;

        await _processor.StartProcessingAsync(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _processor.StopProcessingAsync(cancellationToken);

        _processor.ProcessMessageAsync -= MessageHandler;
        _processor.ProcessErrorAsync -= ErrorHandler;
    }


    private async Task MessageHandler(ProcessMessageEventArgs arg)
    {
        var json = arg.Message.Body.ToString();
        var message = JsonConvert.DeserializeObject<object>(json, _converter);

        Handle(message);

        await arg.CompleteMessageAsync(arg.Message);
    }

    private Task ErrorHandler(ProcessErrorEventArgs arg)
    {
        _logger.LogError(arg.Exception, "Message retrieval error");
        return Task.CompletedTask;
    }

    private void Handle(object message)
    {
        var messageType = message.GetType();
        var method = GetType().GetMethod("Handle", new[] { messageType });

        if (method == null)
        {
            throw new NotImplementedException($"Method for handling {messageType} message type is not implemented");
        }

        method.Invoke(this, new object[] { message });
    }
}
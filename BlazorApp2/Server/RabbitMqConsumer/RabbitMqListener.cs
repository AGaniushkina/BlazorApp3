using BlazorApp2.Server.Extensions;
using BlazorApp2.Server.Services;
using BlazorApp2.Shared;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BlazorApp2.Server.RabbitMqConsumer;

public class RabbitMqListener : BackgroundService
{
	private IConnection _connection;
	private IModel _channel;
	private readonly PassengersService _passengersService;

	public RabbitMqListener(PassengersService passengersService)
	{
		var factory = new ConnectionFactory { HostName = "localhost" };
		_connection = factory.CreateConnection();
		_channel = _connection.CreateModel();
		_channel.QueueDeclare(queue: "MyQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
		_passengersService = passengersService;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		stoppingToken.ThrowIfCancellationRequested();

		var consumer = new EventingBasicConsumer(_channel);
		consumer.Received += async (ch, ea) =>
		{
			var content = Encoding.UTF8.GetString(ea.Body.ToArray());
			try
			{
				AddPassenger addPassenger = JsonConvert.DeserializeObject<AddPassenger>(content)!;
				await _passengersService.CreateAsync(addPassenger.ToPassenger());
			}
			catch (Exception ex)
			{
				_channel.BasicAck(ea.DeliveryTag, false);
			}
			_channel.BasicAck(ea.DeliveryTag, false);
		};
		_channel.BasicConsume("MyQueue", false, consumer);

		return Task.CompletedTask;
	}

	public override void Dispose()
	{
		_channel.Close();
		_connection.Close();
		base.Dispose();
	}
}

﻿using BlazorApp2.Shared;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace BlazorApp2.Server.RabbitMqProducer;

public class RabbitMqService : IRabbitMqService
{
	public void SendMessage(object obj)
	{
		var message = JsonSerializer.Serialize(obj);
		SendMessage(message);
	}

	public void SendMessage(string message)
	{
		var factory = new ConnectionFactory() { HostName = "localhost" };
		using (var connection = factory.CreateConnection())
		using (var channel = connection.CreateModel())
		{
			channel.QueueDeclare(queue: "MyQueue",
						   durable: false,
						   exclusive: false,
						   autoDelete: false,
						   arguments: null);

			var body = Encoding.UTF8.GetBytes(message);

			channel.BasicPublish(exchange: "",
						   routingKey: "MyQueue",
						   basicProperties: null,
						   body: body);
		}
	}

	public void SendMessage(BookingModel addPassenger)
	{
		var factory = new ConnectionFactory() { HostName = "localhost" };
		using (var connection = factory.CreateConnection())
		using (var channel = connection.CreateModel())
		{
			var message = JsonSerializer.Serialize(addPassenger);

			channel.QueueDeclare(queue: "MyQueue",
						   durable: false,
						   exclusive: false,
						   autoDelete: false,
						   arguments: null);

			var body = Encoding.UTF8.GetBytes(message);

			channel.BasicPublish(exchange: "",
						   routingKey: "MyQueue",
						   basicProperties: null,
						   body: body);
		}
	}
}

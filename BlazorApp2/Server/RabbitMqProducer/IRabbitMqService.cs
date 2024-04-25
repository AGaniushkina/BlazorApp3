using BlazorApp2.Shared;

namespace BlazorApp2.Server.RabbitMqProducer;

public interface IRabbitMqService
{
	void SendMessage(object obj);
	void SendMessage(string message);
	void SendMessage(BookingModel addPassenger);
}

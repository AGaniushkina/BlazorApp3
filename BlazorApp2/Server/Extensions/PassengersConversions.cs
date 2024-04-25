using BlazorApp2.Shared;

namespace BlazorApp2.Server.Extensions;

public static class PassengersConversions
{
	public static Passenger ToPassenger(this AddPassenger passenger) =>
		new()
		{
			LastName = passenger.LastName,
			FirstName = passenger.FirstName,
			Patronymic = passenger.Patronymic,
			Sex = passenger.Sex,
			DateOfIssue = passenger.DateOfIssue,
			DocumentSeriesAndNumber = passenger.DocumentSeriesAndNumber,
			Email = passenger.Email,
			PhoneNumber = passenger.PhoneNumber
		};
}

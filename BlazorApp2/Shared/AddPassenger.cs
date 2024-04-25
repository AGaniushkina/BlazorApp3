namespace BlazorApp2.Shared;

public class AddPassenger
{
	public string LastName { get; set; } = "";
	public string FirstName { get; set; } = "";
	public string Patronymic { get; set; } = "";
	public GenderEnum Sex { get; set; }
	public DateTime DateOfIssue { get; set; }
	public string? DocumentSeriesAndNumber { get; set; } = "";
	public string Email { get; set; } = "";
	public string PhoneNumber { get; set; } = "";
}

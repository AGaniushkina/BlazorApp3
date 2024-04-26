using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Shared;

public class AddPassenger
{
    [Required(ErrorMessage = "Фамилия обязательна")]
    [RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Некорректно")]
    public string LastName { get; set; } = "";

    [Required]
	[RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Некорректно")]
	public string FirstName { get; set; } = "";

	[Required]
	[RegularExpression(@"^[a-zA-Z\s.\-']{2,}$", ErrorMessage = "Некорректно")]
	public string Patronymic { get; set; } = "";

	[Required]
	public GenderEnum Sex { get; set; }

	[Required]
	public DateTime DateOfIssue { get; set; }

	[Required]
	[RegularExpression(@"[0-9]+", ErrorMessage = "Некорректно")]
	public string? DocumentSeriesAndNumber { get; set; } = "";

	[Required]
	[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Некорректно")]
	public string Email { get; set; } = "";

	[Required]
	[RegularExpression(@"[0-9]+", ErrorMessage = "Некорректно")]
	public string PhoneNumber { get; set; } = "";
}

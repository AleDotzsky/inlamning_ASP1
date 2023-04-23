namespace API_Fixxo.Models.DTO
{
	public class ContactHttpResponse
	{
		public int ContactId { get; set; }
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Comment { get; set; } = null!;

	}
}

using API_Fixxo.Models.Entities;

namespace API_Fixxo.Models.DTO
{
	public class ContactHttpRequest
	{
        public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Comment { get; set; } = null!;

		public static implicit operator ContactEntity(ContactHttpRequest request)
        {
            return new ContactEntity
            {
                Name = request.Name,
                Email = request.Email,
                Comment = request.Comment,
            };
        }
    }


}

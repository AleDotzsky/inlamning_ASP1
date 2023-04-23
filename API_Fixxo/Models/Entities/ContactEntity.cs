using API_Fixxo.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace API_Fixxo.Models.Entities
{
	public class ContactEntity
	{
		[Key]
        public int ContactId { get; set; }
		public string Name { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string Comment { get; set; } = null!;

		public static implicit operator ContactHttpResponse(ContactEntity entity)
		{
			return new ContactHttpResponse
			{
				ContactId = entity.ContactId,
				Name = entity.Name,
				Email = entity.Email,
				Comment = entity.Comment,
			};
		}
	}
}


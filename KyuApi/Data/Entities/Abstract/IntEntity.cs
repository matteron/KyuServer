using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Data.Entities.Abstract
{
	public abstract class IntEntity : IEntity<int>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
	}
}

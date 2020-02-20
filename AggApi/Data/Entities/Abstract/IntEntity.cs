using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AggApi.Data.Entities.Interfaces;

namespace AggApi.Data.Entities.Abstract
{
	public class IntEntity : IEntity<int>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
	}
}

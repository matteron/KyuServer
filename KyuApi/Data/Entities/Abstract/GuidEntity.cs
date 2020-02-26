using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KyuApi.Data.Entities.Interfaces;

namespace KyuApi.Data.Entities.Abstract
{
	public abstract class GuidEntity : IEntity<Guid>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
	}
}

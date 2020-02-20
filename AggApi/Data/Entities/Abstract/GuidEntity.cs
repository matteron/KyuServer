using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities.Interfaces;

namespace AggApi.Data.Entities.Abstract
{
	public abstract class GuidEntity : IEntity<Guid>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
	}
}

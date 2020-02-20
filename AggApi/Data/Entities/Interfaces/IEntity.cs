using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AggApi.Data.Entities.Interfaces
{
	public interface IEntity<out TKey>
	{
		TKey Id { get; }
	}
}

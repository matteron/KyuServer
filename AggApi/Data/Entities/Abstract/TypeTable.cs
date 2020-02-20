using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AggApi.Data.Entities.Interfaces;

namespace AggApi.Data.Entities.Abstract
{
	public class TypeTable : IntEntity, INamed
	{
		public string Name { get; set; }
	}
}

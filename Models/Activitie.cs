using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrowEasy.Models
	{
	public class Activitie
		{
			public int Id { get; set; }
			public string name { get; set; }
			public string description { get; set; }
			[ForeignKey("Vivencia")]
			public int VivenciaId { get; set; }
			


		}
	}

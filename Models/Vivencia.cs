using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrowEasy.Models
{
    public class Vivencia
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string client { get; set; }
        public DateTime beginDate  { get; set; }
        public DateTime endDate { get; set; }
        public MainDesc MainDesc { get; set; }

		[ForeignKey("MainDesc")]
		public int MainDescId {  get; set; }		        

		public List<Activitie> Activities { get; set; }

		}
}
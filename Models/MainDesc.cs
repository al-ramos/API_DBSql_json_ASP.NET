using System;
using System.Collections.Generic;

namespace GrowEasy.Models {

public class MainDesc {

    public int Id { get; set; }
    public string name { get; set; }
    public DateTime birhDate { get; set; }
    public bool senior { get; set; }
    public string email  { get; set; }
    public string linkedin { get; set; }
    public string about { get; set; }

   public List<Vivencia> Vivencias { get; set; }
   

		}

} 
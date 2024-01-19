using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using GrowEasy.Models;
using GrowEasy.Repository.Interfaces;

namespace GrowEasy.Repository
{
    public class ReposACtion: Repository<Activitie>,  IActivitie
    {
       private readonly RContext _rcontext; 

       public ReposACtion(RContext db) : base(db) {} 

    }
}
using GrowEasy.Models;
using GrowEasy.Repository.Interfaces;

namespace GrowEasy.Repository
	{
	public class ReposVivencia : Repository<Vivencia>, IVivencia
		{
		private readonly RContext _db;

		public ReposVivencia(RContext db) : base(db)
			{
			_db = db;
			}

		}
	}

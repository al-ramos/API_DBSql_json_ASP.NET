using GrowEasy.Models;
using GrowEasy.Repository.Interfaces;

namespace GrowEasy.Repository
	{
	public class ReposMainDesc : Repository<MainDesc>, IMainDesc
		{
			private readonly RContext _db;

			public ReposMainDesc(RContext db): base(db)
				{
					_db = db;
				}

		}
	}

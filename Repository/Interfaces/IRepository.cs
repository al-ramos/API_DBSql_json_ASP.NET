using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GrowEasy.Models;
using Microsoft.EntityFrameworkCore;

namespace GrowEasy.Repository.Interfaces
{
	public interface IRepository<T> where T : class
		{
        void NewData(T T);
        void PutData(T T);
        void DelData(T T);
        T GetData(int Id);
        public IEnumerable<T> GetData(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);




		}
}
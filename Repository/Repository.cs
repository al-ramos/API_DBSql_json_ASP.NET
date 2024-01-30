using GrowEasy.Models;
using Microsoft.EntityFrameworkCore;
using GrowEasy.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ServiceStack;

namespace GrowEasy.Repository
	{
	public class Repository<T> : IRepository<T> where T : class
		{

		private readonly RContext rContext;
		internal DbSet<T> dbSet;

		public Repository(RContext context)
			{
			rContext = context;
			this.dbSet = rContext.Set<T>();
			}
			
	public MainDesc GetData(int Id)
			{
			return rContext.MainDescs.Find(Id);
			}


		public void DelData(MainDesc mainDesc)
			{
			rContext.MainDescs.Remove(mainDesc);
			rContext.SaveChanges();
			}
	
		public void NewData(MainDesc mainDesc)
			{
			rContext.MainDescs.Add(mainDesc);
			rContext.SaveChanges();

			}

		public void PutData(MainDesc mainDesc)
			{
			rContext.MainDescs.Update(mainDesc);
			rContext.SaveChanges();
			}		

		public void NewData(T T)
			{
			throw new NotImplementedException();
			}

		public void PutData(T T)
			{
			throw new NotImplementedException();
			}

		public void DelData(T T)
			{
			throw new NotImplementedException();
			}

		public IEnumerable<T> GetData(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
			{

			IQueryable<T> query = dbSet;
			if (!tracked)
				{
				query = query.AsNoTracking();
				}
			if (filter != null)
				{
				query = query.Where(filter);
				}

			if (includeProperties != null)
				{
				foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
					{
					query = query.Include(includeProp);
					//query = query.Where(u=>   u.)
					}
				}								
			
				return query.ToList();		

			}

		T IRepository<T>.GetData(int Id)
			{
			throw new NotImplementedException();
			}
		}
		}
	
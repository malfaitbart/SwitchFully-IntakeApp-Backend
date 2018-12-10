using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories
{
	public interface IRepository<T>
	{
		Task<List<T>> GetAll();
		Task<T> GetById(Guid id);
		Task<T> UpdateAsync(T objectToUpdate);
		Task<T> Create(T objectToCreate);
	}
}

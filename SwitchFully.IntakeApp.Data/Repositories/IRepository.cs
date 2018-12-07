using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.Data.Repositories
{
	public interface IRepository<T>
	{
		List<T> GetAll();
		Task<T> GetById(Guid id);
		T Update(T objectToUpdate);
		T Create(T objectToCreate);
	}
}

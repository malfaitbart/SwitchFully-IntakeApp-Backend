using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchFully.IntakeApp.Data.Repositories
{
	public interface IRepository<T>
	{
		List<T> GetAll();
		T GetById(Guid id);
		T Update(T objectToUpdate);
		T Create(T objectToCreate);
	}
}

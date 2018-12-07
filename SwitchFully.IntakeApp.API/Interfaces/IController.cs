using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Interfaces
{
	public interface IController<T, U>
	{
		ActionResult GetAll();
		ActionResult<U> GetById(int id);
		ActionResult<U> Update(T objectToUpdate);
		ActionResult<U> Create(T objectToCreate);
	}
}

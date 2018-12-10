using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwitchFully.IntakeApp.API.Interfaces
{
	public interface IController<T, U>
	{
		Task<ActionResult<List<U>>> GetAll();
		Task<ActionResult<U>> GetById(int id);
		Task<ActionResult<U>> Update(T objectToUpdate);
		Task<ActionResult<U>> Create(T objectToCreate);
	}
}

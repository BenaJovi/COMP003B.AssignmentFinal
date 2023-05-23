using COMP003B.AssignmentFinal.Services;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.AssignmentFinal.Controllers
{
	public class LifetimeDemoController : Controller
	{
		// private fields
		private readonly MyTransientService _transientService1;
		private readonly MyTransientService _transientService2;
		private readonly MyScopedService _scopedService1;
		private readonly MyScopedService _scopedService2;
		private readonly MySingletonService _singletonService1;
		private readonly MySingletonService _singletonService2;
		// constructor
		public LifetimeDemoController(MyTransientService transientService1,
		MyScopedService scopedService1, MySingletonService singletonService1,
		MyTransientService transientService2, MyScopedService scopedService2,
		MySingletonService singletonService2)
		{
			_transientService1 = transientService1;
			_transientService2 = transientService2;
			_scopedService1 = scopedService1;
			_scopedService2 = scopedService2;
			_singletonService1 = singletonService1;
			_singletonService2 = singletonService2;
		}
		public IActionResult Index()
		{
			ViewData["TransientId1"] = _transientService1.GetUniqueId();
			ViewData["TransientId2"] = _transientService2.GetUniqueId();
			ViewData["ScopedId1"] = _scopedService1.GetUniqueId();
			ViewData["ScopedId2"] = _scopedService2.GetUniqueId();
			ViewData["SingletonId1"] = _singletonService1.GetUniqueId();
			ViewData["SingletonId2"] = _singletonService2.GetUniqueId();
			return View();
		}
	}
}

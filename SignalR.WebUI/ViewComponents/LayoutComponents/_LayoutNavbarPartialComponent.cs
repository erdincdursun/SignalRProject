using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutNavbarPartialComponent :ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

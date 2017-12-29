using events.tac.local.Models;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            Item currentItem = RenderingContext.Current.ContextItem;
            Item section = currentItem.Axes.GetAncestors()
                .FirstOrDefault(i => i.TemplateName == "Events Section");
            var Model = CreateNavigationMenu(section, currentItem);

            return View(Model);
        }

        private NavigationMenu CreateNavigationMenu(Item root,Item current)
        {
            NavigationMenu menu = new NavigationMenu()
            {
                Title = root.DisplayName,
                URL = LinkManager.GetItemUrl(root),
                Children = root.Axes.IsAncestorOf(current) ? root.GetChildren().Select(x => CreateNavigationMenu(x, current)) : null
            };
            return menu;
        }
    }
}
using events.tac.local.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        // GET: RelatedEvents
        public ActionResult Index()
        {
            var item = RenderingContext.Current.ContextItem;
            if (item == null) return new EmptyResult();

            MultilistField relatedEvents = item.Fields["Related Events"];
            if (relatedEvents == null) return new EmptyResult();

            var events = relatedEvents.GetItems()
                .Select(x => new NavigationItem()
                {
                    Title = x.DisplayName,
                    URL = LinkManager.GetItemUrl(x)
                });

            return View(events);
        }
    }
}
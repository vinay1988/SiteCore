using events.tac.local.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;

namespace events.tac.local.Controllers
{
    public class FeaturedEventController : Controller
    {
        private static FeaturedEvent CreateModel()
        {
            var item = RenderingContext.Current.Rendering.Item;
            var featuredEvent = new FeaturedEvent()
            {
                Heading = new HtmlString(FieldRenderer.Render(item, "ContentHeading")),
                EventImage = new HtmlString(FieldRenderer.Render(item, "Event Image", "mw=400")),
                Intro = new HtmlString(FieldRenderer.Render(item, "ContentIntro"))

            };
            var cssClass = RenderingContext.Current.Rendering.Parameters["CssClass"];
            if (!string.IsNullOrEmpty(cssClass))
            {
                var refItem = Sitecore.Context.Database.GetItem(cssClass);
                if (refItem != null)
                {
                    featuredEvent.CssClass = refItem["class"];
                }
                else
                {
                    featuredEvent.CssClass = cssClass;
                }

            }
            featuredEvent.URL = Sitecore.Links.LinkManager.GetItemUrl(item);
            return featuredEvent;
        }
        // GET: FeaturedEvent
        public ActionResult Index()
        {
            return View(CreateModel());
        }
    }
}
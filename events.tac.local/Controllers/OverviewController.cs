﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using events.tac.local.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;

namespace events.tac.local.Controllers
{
    public class OverviewController : Controller
    {
        // GET: Overview
        public ActionResult Index()
        {
            var model = new OverviewList()
            {
                ReadMore = Sitecore.Globalization.Translate.Text("Read More")
            };

            model.AddRange(RenderingContext.Current.ContextItem.GetChildren()
                .Select(i => new OverviewItem()
                {
                    Url=LinkManager.GetItemUrl(i),
                    Title=new HtmlString(FieldRenderer.Render(i,"contentheading")),
                    Image = new HtmlString(FieldRenderer.Render(i, "DecorationBanner","mw=500&mh=333")),
                }
                ));

            return View(model);
        }
    }
}
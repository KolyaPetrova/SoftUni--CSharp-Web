﻿using System.Runtime.CompilerServices;
using SIS.Framework.ActionResults;
using SIS.Framework.ActionResults.Contracts;
using SIS.Framework.Utilities;
using SIS.Framework.Views;
using SIS.HTTP.Requests.Contracts;

namespace SIS.Framework.Controllers
{
    public abstract class Controller
    {
        protected Controller() { }

        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerUtilities.GetControllerName(this);

            string fullyQualifiedName = ControllerUtilities.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }
    }
}

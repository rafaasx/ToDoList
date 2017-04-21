﻿using System.Web.Mvc;

namespace ToDoList.Controllers
{
    public class StaticController: Controller
    {
        protected override void HandleUnknownAction(string actionName)
        {
            this.View(actionName).ExecuteResult(this.ControllerContext);
        }
    }
}
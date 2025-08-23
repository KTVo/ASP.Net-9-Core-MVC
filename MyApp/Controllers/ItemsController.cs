using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

namespace MyApp.Controllers;

public class ItemsController : Controller
{
    // QUESTION: WOULD YOU ALWAYS USE IACTIONRESULT? WHEN WOULDN'T YOU

    // IACTIONRESULT CAN RETURN ANY RESULT THAT AN ACTION CAN RETURN
    // AN ACTION ARE A METHOD TYPE USED TO HANDLE INCOMING REQUESTS
    public IActionResult Overview()
    {
        Item item = new Item()
        {
            Name = "Keyboard",
            Color = "Yellow"
        };
        return View(item);
    }

    // ANOTHER WAY TO REVIEW A VIEW BUT IACTIONRESULT CAN RETURN
    // ANYTHING FOR AN ACTION METHOD: VIEW, VIEWRESULT, ETC
    // public ViewResult Overview()
    // {
    //     return new ViewResult();
    // }

    // URL: http://localhost:5154/items/edit?itemId=4
    public IActionResult Edit(int itemId)
    {
        return Content("id= " + itemId);
    }

}

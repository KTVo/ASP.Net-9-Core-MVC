using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.MVCS.Models;

namespace MyApp.Controllers;

public class ItemsController : Controller
{
    private readonly MyAppContext _context;
    public ItemsController(MyAppContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        //INCLUDES SEARCHES FOR SerialNumber and Category WHEN SEARCHING FOR ITEMS
        List<Item>? items = await _context.Items.Include(s => s.SerialNumber)
                                                .Include(c => c.Category)
                                                .Include(ic => ic.ItemClients)
                                                .ThenInclude(c => c.Client )
                                                .ToListAsync();

        return View(items);
    }

    // RETURNS THE VIEW FOR THE /Items/Create PAGE TO BE ABLE TO SEE IT ON THE BROWSER
    // HTML TAG LINKS TO THIS VIA asp-for="Create"
    public IActionResult Create()
    {
        // USED TO DISPLAY ALL OF THE INFO FROM THE DATABASE FOR Categories
        // SEARCHES Categories by the "Id"
        // AND IT'LL DISPLAY IT BY "Name"
        // THIS WILL CREATE A DICTIONARY THAT WILL BE PASSED TO THE CREATE VIEW PAGE
        // WITHOUT THIS OUR Category DROPDOWN WOULD BE BLANK
        ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");

        return View();
    }

    // BINDS THE LABEL TO
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id, Name, Price, Color, CategoryId")] Item item)
    {
        // VERIFIES IF THE INPUT IN OUR FORM IS AN ACTUAL ITEM
        if (ModelState.IsValid)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            // RETURNS TO THE INDEX PAGE AFTER ADDING AN ITEM
            return Redirect("Index");
        }

        return View(item);
    }

    // RETURNS THE VIEW OF THE EDIT PAGE
    public async Task<IActionResult> Edit(int id)
    {
        Item? foundItem = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

        if (foundItem == null) { return NotFound(); }

        // USED TO DISPLAY ALL OF THE INFO FROM THE DATABASE FOR Categories
        // SEARCHES Categories by the "Id"
        // AND IT'LL DISPLAY IT BY "Name"
        // THIS WILL CREATE A DICTIONARY THAT WILL BE PASSED TO THE CREATE VIEW PAGE
        // WITHOUT THIS OUR Category DROPDOWN WOULD BE BLANK
        ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");


        return View(foundItem);
    }

    // UPDATES THE DATABASE WITH EDIT AND REDIRECTS TO INDEX PAGE
    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Id, Name, Price, Color, CategoryId")] Item item)
    {
        if (ModelState.IsValid)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // IF UNSUCCESSFULL THE USER WILL STILL AND ON THE SAME EDIT PAGE
        return View(item);
    }

    // RETURNS THE VIEW OF THE EDIT PAGE
    public async Task<IActionResult> Delete(int id)
    {
        Item? item = await _context.Items.FirstOrDefaultAsync();

        if (item == null) { NotFound(); }

        return View(item);
    }

    // DELETE ITEM FROM THE DATABASE
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmation(int id)
    {
        Item? item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

        if (item == null) { return RedirectToAction("Index"); }

        _context.Items.Remove(item);

        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
    

}

// public class ItemsController : Controller
// {
//     // QUESTION: WOULD YOU ALWAYS USE IACTIONRESULT? WHEN WOULDN'T YOU

//     // IACTIONRESULT CAN RETURN ANY RESULT THAT AN ACTION CAN RETURN
//     // AN ACTION ARE A METHOD TYPE USED TO HANDLE INCOMING REQUESTS
//     public IActionResult Overview()
//     {
//         Item item = new Item()
//         {
//             Name = "Keyboard",
//             Color = "Yellow"
//         };
//         return View(item);
//     }

//     // ANOTHER WAY TO REVIEW A VIEW BUT IACTIONRESULT CAN RETURN
//     // ANYTHING FOR AN ACTION METHOD: VIEW, VIEWRESULT, ETC
//     // public ViewResult Overview()
//     // {
//     //     return new ViewResult();
//     // }

//     // URL: http://localhost:5154/items/edit?itemId=4
//     public IActionResult Edit(int itemId)
//     {
//         return Content("id= " + itemId);
//     }

// }


// public class ItemsController : Controller
// {
//     // QUESTION: WOULD YOU ALWAYS USE IACTIONRESULT? WHEN WOULDN'T YOU

//     // IACTIONRESULT CAN RETURN ANY RESULT THAT AN ACTION CAN RETURN
//     // AN ACTION ARE A METHOD TYPE USED TO HANDLE INCOMING REQUESTS
//     public IActionResult Overview()
//     {
//         Item item = new Item()
//         {
//             Name = "Keyboard",
//             Color = "Yellow"
//         };
//         return View(item);
//     }

//     // ANOTHER WAY TO REVIEW A VIEW BUT IACTIONRESULT CAN RETURN
//     // ANYTHING FOR AN ACTION METHOD: VIEW, VIEWRESULT, ETC
//     // public ViewResult Overview()
//     // {
//     //     return new ViewResult();
//     // }

//     // URL: http://localhost:5154/items/edit?itemId=4
//     public IActionResult Edit(int itemId)
//     {
//         return Content("id= " + itemId);
//     }

// }

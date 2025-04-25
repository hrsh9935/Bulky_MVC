using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                // Redirect or handle error
                RedirectToPage("Index");
            }

            Category = _db.Categories.Find(id);

            if (Category == null)
            {
                // Redirect or handle error
                RedirectToPage("Index");
            }
        }


        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();

                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
           
        }
    }
}

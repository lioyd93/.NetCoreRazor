using DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreRazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvirnoment;


        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvirnoment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvirnoment = hostingEnvirnoment;
        }


        [HttpGet]
        public IActionResult Get()
        {
            //return Json(new { data = _unitOfWork.SP_Call.ReturnList<Category>("usp_GetAllCategory", null) });
            return Json(new { data = _unitOfWork.MenuItem.GetAll(null ,null,"Category,FoodType") });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var imagePath=Path.Combine(_hostingEnvirnoment.WebRootPath,objFromDb.Image.TrimStart('\\'));
            if(System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            _unitOfWork.MenuItem.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }

    }
}

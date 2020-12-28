using BLL.Service;
using DAL.Repositories;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.MyErrors;
using BLL.DTO;
using CursovaHr.Models;
using System.Collections.Generic;

namespace CursovaHr.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryService CategoryServ;
        UnitOfWork uof;
        IMapper map = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDto, CategoryViewModel>()).CreateMapper();
        public CategoryController()
        {
            uof = new UnitOfWork();
            CategoryServ = new CategoryService();
        }
        public ActionResult Index(int? TablN, string name)
        {
            if (name != null & name != "-1")
            {
                return View((map.Map<IEnumerable<CategoryDto>, List<CategoryViewModel>>(CategoryServ.GetAll().Where(t => t.Catname.ToLower().CompareTo(name.ToLower()) == 0))));
            }
            else if (TablN != 0 && TablN != null)
            {
                return View(CategoryServ.GetAll().Where(t => t.Id == TablN));
            }
            else
            {
                return View(map.Map<IEnumerable<CategoryDto>, List<CategoryViewModel>>(CategoryServ.GetAll()));
            }
        }

        public ActionResult Index2()
        {
            CategoryDto k = new CategoryDto();
            return View(k);

        }
        [HttpPost]
        public ActionResult Index2(CategoryDto item)
        {


            List<CategoryDto> m = CategoryServ.GetByItem(item);
            return RedirectToAction("Index3", "Category", m);

        }
        public ActionResult Index3(List<CategoryDto> item)
        {
            try
            {
                return View(map.Map<List<CategoryDto>, List<CategoryViewModel>>(item));
            }
            catch (CreationError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }

        }
        public ActionResult Create()
        {

            CategoryDto punct = new CategoryDto();
            return View(punct);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryDto item)
        {
            int k = 0;
            int b = 0;
            try
            {
                
                CategoryServ.Create(item);
                return RedirectToAction("Index", "Category");
            }
            catch (CreationError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }

        }


        public ActionResult Edit(int id)
        {
            try
            {

                return View(CategoryServ.GetById(id));
            }
            catch (CantGetByIdError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }
            catch (IncorrectId e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }
        }
        // POST:Category/Edit/1
        [HttpPost]
        public ActionResult Edit(CategoryDto good)
        {
            try{
            CategoryServ.Edit(good);
            return RedirectToAction("Index", "Category", new { Id = good.Id });
            }
            catch (CantGetByIdError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First()
                };
            }
            catch (IncorrectId e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }           
        }
        public ActionResult Delete(int id)
        {

            try
            {

                var Orderid = CategoryServ.Delete(id);
                return RedirectToAction("Index", "Category");
            }
            catch (CantGetByIdError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult
                {
                    Content = e.Errors.First()
                };
            }
            catch (IncorrectId e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }
        }
    }
}

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
    public class UnemController : Controller
    {
        
        UnemService UnemServ;
        IMapper map = new MapperConfiguration(cfg => cfg.CreateMap<UnemDto, UnemViewModel>()).CreateMapper();
        public UnemController()
        {
            
            UnemServ = new UnemService();
        }
        // GET: Unem
        public ActionResult Index(int? TablN,string name)
        {
            if (name != null & name != "")
            {
                return View((map.Map<IEnumerable<UnemDto>, List<UnemViewModel>>(UnemServ.GetAll().Where(t => t.Name.ToLower().CompareTo(name.ToLower()) == 0 | t.Surname.ToLower().CompareTo(name.ToLower()) == 0))));
            }
            if (TablN != 0 && TablN != null)
            {
                if (TablN==1) {
                    return View(map.Map<IEnumerable<UnemDto>, List<UnemViewModel>>(UnemServ.SortByName()));
                }
                else if(TablN == 3){
                    return View(map.Map<IEnumerable<UnemDto>, List<UnemViewModel>>(UnemServ.SortBySurname()));
                }
                else if (TablN == 2)
                {
                    return View(map.Map<IEnumerable<UnemDto>, List<UnemViewModel>>(UnemServ.SortByNameDec()));
                }
                else
                {
                    return View(map.Map<IEnumerable<UnemDto>, List<UnemViewModel>>(UnemServ.SortBySurnameDec()));
                }
            }
            else
            {
                return View(map.Map<IEnumerable<UnemDto>, List<UnemViewModel>>(UnemServ.GetAll()));
            }
        }

        // GET: Unem/Details/1
        public ActionResult Details(int id)
        {

            try
            {

                return View(map.Map<UnemDto, UnemViewModel>(UnemServ.GetUnemById(id)));
            }
            catch (CantGetByIdError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }


        }

        //GET: Unem/Create
        public ActionResult Create()
        {
            

            UnemDto punct = new UnemDto();
            return View(punct);
        }

        // POST: Unem/Create
        [HttpPost]
        public ActionResult Create(UnemDto item)
        {
            
            try
            {
                UnemServ.Create(item);
                return RedirectToAction("Index", "Unem");
            }
            catch (CreationError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }
            
        }

        //GET:Unem/Edit/1
        public ActionResult Edit(int id)
        {
            try
            {

                return View(UnemServ.GetUnemById(id));
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

            
            

            // POST:Unem/Edit/1
            [HttpPost]
        public ActionResult Edit(UnemDto good)
        {
            
                UnemServ.Edit(good);
                return RedirectToAction("Index", "Unem", new { Id = good.Id });
            
        }


        public ActionResult Chose(int id, int Catid)
        {
            return RedirectToAction("Index2", "Vac", new { id = id, cat=Catid });
        }
        public ActionResult Delete(int id )
        {


            try
            {

                var Orderid = UnemServ.Delete(id);
                return RedirectToAction("Index", "Unem");
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

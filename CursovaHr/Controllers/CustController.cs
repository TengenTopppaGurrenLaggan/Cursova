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
    public class CustController : Controller
    {
        
        CustService CustServ;
        UnitOfWork uof;
        IMapper map = new MapperConfiguration(cfg => cfg.CreateMap<CustDto, CustViewModel>()).CreateMapper();
        public CustController()
        {
            uof = new UnitOfWork();
            CustServ = new CustService();
        }
        // GET: Cust
        public ActionResult Index(int? TablN)
        {
            if (TablN != 0 && TablN != null)
            {
                if (TablN == 1)
                {
                    return View(map.Map<IEnumerable<CustDto>, List<CustViewModel>>(CustServ.SortByName()));
                }
                else if (TablN == 3)
                {
                    return View(map.Map<IEnumerable<CustDto>, List<CustViewModel>>(CustServ.SortBySurname()));
                }
                else if (TablN == 2)
                {
                    return View(map.Map<IEnumerable<CustDto>, List<CustViewModel>>(CustServ.SortByNameDec()));
                }
                else
                {
                    return View(map.Map<IEnumerable<CustDto>, List<CustViewModel>>(CustServ.SortBySurnameDec()));
                }
            }
            else
            {
                return View(map.Map<IEnumerable<CustDto>, List<CustViewModel>>(CustServ.GetAll()));
            }
        }

        // GET: Cust/Details/5
        public ActionResult Details(int id)
        {

            try
            {

                return View(map.Map<CustDto, CustViewModel>(CustServ.GetCustById(id)));
            }
            catch (CantGetByIdError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }


        }

        //GET: Cust/Create
        public ActionResult Create()
        {
            

            CustDto punct = new CustDto();
            return View(punct);
        }

        // POST: Cust/Create
        [HttpPost]
        public ActionResult Create(CustDto item)
        {
            try
            {
                CustServ.Create(item);
                return RedirectToAction("Index", "Cust");
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

                return View(CustServ.GetCustById(id));
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


        

        // POST: Cuts/Edit/1
        [HttpPost]
        public ActionResult Edit(CustDto good)
        {

            CustServ.Edit(good);
            return RedirectToAction("Index", "Cust", new { Id = good.Id });

        }



        public ActionResult Delete(int id)
        {
            
            var Orderid = CustServ.Delete(id);
            return RedirectToAction("Index", "Cust");
            

        }
    }
}

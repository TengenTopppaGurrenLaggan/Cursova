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
    public class VacController : Controller
    {
        
        VacService VacServ;
        ResumeService ResumeServ;
        UnitOfWork uof;
        IMapper map = new MapperConfiguration(cfg => cfg.CreateMap<VacDto, VacViewModel>()).CreateMapper();
        public VacController()
        {
            uof = new UnitOfWork();
            VacServ = new VacService();
            ResumeServ = new ResumeService();
        }
        // GET: Vac
        public ActionResult Index(int? TablN,string name)
        {
            if (name != null & name != "-1")
            {
                return View((map.Map<IEnumerable<VacDto>, List<VacViewModel>>(VacServ.GetAll().Where(t => t.Vacname.ToLower().CompareTo(name.ToLower()) == 0))));
            }
            else if(TablN != 0 && TablN != null)
            {
                if (TablN == 1)
                {
                    return View(map.Map<IEnumerable<VacDto>, List<VacViewModel>>(VacServ.SortByName()));
                }
                else if (TablN == 3)
                {
                    return View(map.Map<IEnumerable<VacDto>, List<VacViewModel>>(VacServ.SortBySurname()));
                }
                else if (TablN == 2)
                {
                    return View(map.Map<IEnumerable<VacDto>, List<VacViewModel>>(VacServ.SortByNameDec()));
                }
                else
                {
                    return View(map.Map<IEnumerable<VacDto>, List<VacViewModel>>(VacServ.SortBySurnameDec()));
                }
            }
            else
            {
                return View(map.Map<IEnumerable<VacDto>, List<VacViewModel>>(VacServ.GetAll()));
            }
        }

        // GET: Vac/Details/1
        public ActionResult Details(int id)
        {

            try
            {

                return View(map.Map<VacDto, VacViewModel>(VacServ.GetByID(id)));
            }
            catch (CantGetByIdError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }
        }



        //GET: Vac/Create
        public ActionResult Create()
        {
            var list = VacServ.GetListOfCust();
            var list2 = VacServ.GetListOfCat();
            ViewBag.Cust = new SelectList(list, "Id", "Name");
            
            ViewBag.Category = new SelectList(list2, "Id", "Catname");
            

            VacDto punct = new VacDto();
            return View(punct);



        }
        // POST: Vac/Create
        [HttpPost]
        public ActionResult Create(VacDto punct)
        {


            try
            {
                if (ModelState.IsValid)
                {

                    var list = VacServ.GetListOfCust();
                    var list2 = VacServ.GetListOfCat();
                    ViewBag.Cust=new SelectList(list, "Id", "Name");
                    ViewBag.Category = new SelectList(list2, "Id", "Catname");


                    VacServ.Create(punct, punct.Category_Id, punct.Cust_Id);

                    return RedirectToAction("Index", "Vac");
                }
                return View();
            }
            catch (CreationError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }
            
        }



        public ActionResult Edit(int id)
        {
            var list = VacServ.GetListOfCust();
            var list2 = VacServ.GetListOfCat();
            ViewBag.Cust = new SelectList(list, "Id", "Name");
            ViewBag.Category = new SelectList(list2, "Id", "Catname");
            VacDto k = VacServ.GetByID(id);
            return View(k);


        }

        // POST: Vac/Edit/5
        [HttpPost]
        public ActionResult Edit(VacDto good)
        {

            VacServ.Edit(good);
            return RedirectToAction("Index", "Vac");

        }

        // GET: Vac/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {

                VacServ.Delete(id);
                return RedirectToAction("Index", "Vac");

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
        // GET: Vac/Inex2/id=1&cat1
        public ActionResult Index2(int cat)
        {


            
            return View((map.Map<IEnumerable<VacDto>, List<VacViewModel>>(VacServ.GetAll().Where(t => t.Category_Id==cat))));
            



        }
        public ActionResult Chose(int id)
        {


            
            VacServ.Delete(id);
            return RedirectToAction("Index", "Unem");


        }
    }
    }

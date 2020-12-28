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
    public class ResumeController : Controller
    {
        
        ResumeService ResumeServ;
        UnitOfWork uof;
        IMapper map = new MapperConfiguration(cfg => cfg.CreateMap<ResumeDto, ResumeViewModel>()).CreateMapper();
        public ResumeController()
        {
            uof = new UnitOfWork();
            ResumeServ = new ResumeService();
        }
        // GET: Resume
        public ActionResult Index(int? TablN)
        {
            if (TablN != 0 && TablN != null)
            {
                if (TablN == 1)
                {
                    return View(map.Map<IEnumerable<ResumeDto>, List<ResumeViewModel>>(ResumeServ.SortByName()));
                }
                else if (TablN == 3)
                {
                    return View(map.Map<IEnumerable<ResumeDto>, List<ResumeViewModel>>(ResumeServ.SortBySurname()));
                }
                else if (TablN == 2)
                {
                    return View(map.Map<IEnumerable<ResumeDto>, List<ResumeViewModel>>(ResumeServ.SortByNameDec()));
                }
                else
                {
                    return View(map.Map<IEnumerable<ResumeDto>, List<ResumeViewModel>>(ResumeServ.SortBySurnameDec()));
                }
            }
            else
            {
                return View(map.Map<IEnumerable<ResumeDto>, List<ResumeViewModel>>(ResumeServ.GetAll()));
            }
        }

        // GET: Resume/Details/1
        public ActionResult Details(int id)
        {

            try
            {

                return View(map.Map<ResumeDto, ResumeViewModel>(ResumeServ.GetByID(id)));
            }
            catch (CantGetByIdError e)
            {
                MyLogger.GetInstance().Error($"{e.Errors.First()} Error code: {(int)e.Errorcode}  ", null);
                return new ContentResult { Content = e.Errors.First() };
            }
        }

    

    //GET: Resume/Create
    public ActionResult Create()
    {
        var list = ResumeServ.GetListOfUn();
        var list2 = ResumeServ.GetListOfCat();
        ViewBag.Unem = new SelectList(list, "Id", "Name");
        ViewBag.Category = new SelectList(list2, "Id", "Catname");
        ResumeDto punct = new ResumeDto();
        return View(punct);



    }
    // POST: Resume/Create
    [HttpPost]
    public ActionResult Create(ResumeDto punct)
    {


        try
        {
            if (ModelState.IsValid)
            {

                //var list = ResumeServ.GetListOfUn();
                //var list2 = ResumeServ.GetListOfCat();
                //ViewBag.Unem = new SelectList(list, "Id", "Name");
                //ViewBag.Category = new SelectList(list2, "Id", "Catname");


                ResumeServ.Create(punct, punct.Category_Id, punct.Unem_Id);

                return RedirectToAction("Index", "Resume");
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
        var list = ResumeServ.GetListOfUn();
        var list2 = ResumeServ.GetListOfCat();
        ViewBag.Unem = new SelectList(list, "Id", "Name");
        ViewBag.Category = new SelectList(list2, "Id", "Catname");
        ResumeDto k = ResumeServ.GetByID(id);
        return View(k);


    }

    // POST: Resume/Edit/1
    [HttpPost]
    public ActionResult Edit(ResumeDto good)
    {
            
                ResumeServ.Edit(good);
                return RedirectToAction("Index", "Resume");
            

    }



    public ActionResult Delete(int id)
    {
        try
        {

            ResumeServ.Delete(id);
            return RedirectToAction("Index", "Resume");

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
        //[HttpPost]
        //public ActionResult Details(ResumeDto good)
        //{
        //    ResumeServ.Delete(good.Id);
        //    return RedirectToAction("Index2", "Vac", new {good.Category_Id});
        //}
    }
}

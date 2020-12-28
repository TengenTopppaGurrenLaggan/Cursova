using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.MyErrors;
using DAL;
using DAL.Repositories;

namespace BLL.Service
{
    public class CustService
    {

        public UnitOfWork uofs;
        public IMapper Goodmapper = new MapperConfiguration(cfg => cfg.CreateMap<Cust, CustDto>()).CreateMapper();

        public CustService()
        {
            uofs = new UnitOfWork();
        }




        public IEnumerable<CustDto> GetAll()
        {


           
                return Goodmapper.Map<IEnumerable<Cust>, List<CustDto>>((IEnumerable<Cust>)uofs.Custs.GetAll());
               
            
        }
        public IEnumerable<CustDto> SortBySurname()
        {



            return Goodmapper.Map<IEnumerable<Cust>, List<CustDto>>((IEnumerable<Cust>)uofs.Custs.GetAll().OrderBy(r => r.Surname));


        }
        public IEnumerable<CustDto> SortByName()
        {



            return Goodmapper.Map<IEnumerable<Cust>, List<CustDto>>((IEnumerable<Cust>)uofs.Custs.GetAll().OrderBy(r => r.Name));


        }
        public IEnumerable<CustDto> SortBySurnameDec()
        {



            return Goodmapper.Map<IEnumerable<Cust>, List<CustDto>>((IEnumerable<Cust>)uofs.Custs.GetAll().OrderByDescending(r => r.Surname));

        }
        public IEnumerable<CustDto> SortByNameDec()
        {



            return Goodmapper.Map<IEnumerable<Cust>, List<CustDto>>((IEnumerable<Cust>)uofs.Custs.GetAll().OrderByDescending(r => r.Name));
            

        }


        public CustDto Details(int id)
        {
            if (id <= 0)
            {
                throw new IncorrectId();
            }
            var Good = uofs.Custs.GetAll().Include(r => r.Id).FirstOrDefault(l => l.Id == id);
            return Goodmapper.Map<Cust, CustDto>(Good);
        }

        public CustDto GetCustById(int id)
        {
            if (id <= 0)
            {
                throw new IncorrectId();
            }


            var item = uofs.Custs.GetAll().Where(r => r.Id == id).FirstOrDefault();
            if (item == null)
            {
                throw new CantGetByIdError($"Cant find Customer with Id {id}");
            }
            else
            {
                
                CustDto GoodDto = new CustDto
                {
                    Name = item.Name,
                    Id = item.Id,
                    Age = item.Age,
                    Surname = item.Surname,
                };
                return GoodDto;
            }


            return Goodmapper.Map<Cust, CustDto>(item);
        }

        public int Create(CustDto item)
        {
            if (item == null)
            {
                throw new NullableItemError();
            }
            if (item.Age < 18)
            {
                item.Age = 18;
            }
            if (item.Age > 80)
            {
                item.Age = 80;
            }
            Cust good = new Cust
            {
                Name = item.Name,
                Id = item.Id,
                Age = item.Age,
                Surname = item.Surname
            };
            uofs.Custs.Create(good);
            uofs.Save();
            return uofs.Custs.GetAll().OrderByDescending(r => r.Id).FirstOrDefault().Id;

        }
        public int Delete(int id)
        {

            if (id <= 0)
            {
                throw new IncorrectId();
            }
            var ing = uofs.Custs.GetTbyID(id);
            var T = uofs.Vacs.GetAll().Where(t => t.Cust_Id == id);
            foreach (Vac item in T)
            {
                uofs.Vacs.Delete(item.Id);
            }
            
            if (ing == null)
            {
                throw new CantGetByIdError();
            }
            if (ing == null)
            {
                throw new CantGetByIdError($"Cant find Customer {id}");
            }




            uofs.Custs.Delete(id);
            uofs.Save();
            return id;
        }

        public void Edit(CustDto item)
        {
            if (item == null)
            {
                throw new NullableItemError();
            }
            if (item.Age < 18)
            {
                item.Age = 18;
            }
            if (item.Age > 80)
            {
                item.Age = 80;
            }
            Cust good = uofs.Custs.GetTbyID(item.Id);
            good.Surname = item.Surname;
            good.Name = item.Name;

            good.Age = item.Age;

            uofs.Custs.Update(good);
            uofs.Save();

        }


    }
}

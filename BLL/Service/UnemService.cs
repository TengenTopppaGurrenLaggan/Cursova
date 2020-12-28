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
    public class UnemService
    {

        public UnitOfWork uofs;
        public IMapper Goodmapper = new MapperConfiguration(cfg => cfg.CreateMap<Unem, UnemDto>()).CreateMapper();

        public UnemService()
        {
            uofs = new UnitOfWork();
        }




        public IEnumerable<UnemDto> GetAll()
        {


           
                return Goodmapper.Map<IEnumerable<Unem>, List<UnemDto>>((IEnumerable<Unem>)uofs.Unems.GetAll());
            
        }
        public IEnumerable<UnemDto> SortBySurname()
        {



            return Goodmapper.Map<IEnumerable<Unem>, List<UnemDto>>((IEnumerable<Unem>)uofs.Unems.GetAll().OrderBy(r => r.Surname));
            

        }
        public IEnumerable<UnemDto> SortByName()
        {



            return Goodmapper.Map<IEnumerable<Unem>, List<UnemDto>>((IEnumerable<Unem>)uofs.Unems.GetAll().OrderBy(r => r.Name));


        }
        public IEnumerable<UnemDto> SortBySurnameDec()
        {



            return Goodmapper.Map<IEnumerable<Unem>, List<UnemDto>>((IEnumerable<Unem>)uofs.Unems.GetAll().OrderByDescending(r => r.Surname));
            
        }
        public IEnumerable<UnemDto> SortByNameDec()
        {



            return Goodmapper.Map<IEnumerable<Unem>, List<UnemDto>>((IEnumerable<Unem>)uofs.Unems.GetAll().OrderByDescending(r => r.Name));
            

        }


        public UnemDto Details(int id)
        {
            if (id <= 0)
            {
                throw new IncorrectId();
            }
            var Good = uofs.Unems.GetAll().Include(r => r.Id).FirstOrDefault(l => l.Id == id);
            return Goodmapper.Map<Unem, UnemDto>(Good);
        }
        
        public UnemDto GetUnemById(int id)
        {
            if (id <= 0)
            {
                throw new IncorrectId();
            }


            var item = uofs.Unems.GetAll().Where(r => r.Id == id).FirstOrDefault();
            if (item == null)
            {
                throw new CantGetByIdError($"Cant find Unemployed with Id {id}");
            }
            else
            {
                UnemDto GoodDto = new UnemDto
                {
                    Name = item.Name,
                    Id = item.Id,
                    Age = item.Age,
                    Surname = item.Surname,
                };
                return GoodDto;
            }


            return Goodmapper.Map<Unem, UnemDto>(item);
        }

        public int Create(UnemDto item)
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
            Unem good = new Unem
            {
                Name = item.Name,
                Id = item.Id,
                Age = item.Age,
                Surname = item.Surname
            };
            uofs.Unems.Create(good);
            uofs.Save();
            return uofs.Unems.GetAll().OrderByDescending(r => r.Id).FirstOrDefault().Id;

        }
        public int Delete(int id)
        {
            
            if (id <= 0)
            {
                throw new CantGetByIdError($"Cant find Unemployed with Id {id}");
            }
            var ing = uofs.Unems.GetTbyID(id);
            
            var S = uofs.Resumes.GetAll().Where(t => t.Unem_Id == id);
            foreach (Resume item2 in S)
            {
                uofs.Resumes.Delete(item2.Id);
            }
            if (ing == null)
            {
                throw new CantGetByIdError($"Cant find Unemployed with Id {id}");
            }

            


            uofs.Unems.Delete(id);
            uofs.Save();
            return id;
        }

        public void Edit(UnemDto item)
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
            Unem good = uofs.Unems.GetTbyID(item.Id);
            good.Surname = item.Surname;
            good.Name = item.Name;

            good.Age = item.Age;

            uofs.Unems.Update(good);
            uofs.Save();

        }


    }
}

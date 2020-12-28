using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Data.Entity;
using DAL;
using BLL.MyErrors;
using BLL.DTO;

namespace BLL.Service
{
    public class ResumeService
    {

        public UnitOfWork unit;
        public IMapper Ordermap = new MapperConfiguration(cfg => cfg.CreateMap<Resume, ResumeDto>()).CreateMapper();
        public ResumeService()
        {
            unit = new UnitOfWork();

        }

        public IEnumerable<ResumeDto> GetAll()
        {
            try
            {
            return Ordermap.Map<IEnumerable<Resume>, List<ResumeDto>>(unit.Resumes.GetAll());
        }
            catch
            {
                return null;
            }
        }
        public IEnumerable<ResumeDto> SortBySurname()
        {



            return Ordermap.Map<IEnumerable<Resume>, List<ResumeDto>>((IEnumerable<Resume>)unit.Resumes.GetAll().OrderBy(r => r.Resname));


        }
        public IEnumerable<ResumeDto> SortByName()
        {



            return Ordermap.Map<IEnumerable<Resume>, List<ResumeDto>>((IEnumerable<Resume>)unit.Resumes.GetAll().OrderBy(r => r.Worktime));


        }
        public IEnumerable<ResumeDto> SortBySurnameDec()
        {



            return Ordermap.Map<IEnumerable<Resume>, List<ResumeDto>>((IEnumerable<Resume>)unit.Resumes.GetAll().OrderByDescending(r => r.Resname));

        }
        public IEnumerable<ResumeDto> SortByNameDec()
        {



            return Ordermap.Map<IEnumerable<Resume>, List<ResumeDto>>((IEnumerable<Resume>)unit.Resumes.GetAll().OrderByDescending(r => r.Worktime));
            

        }
        public ResumeDto GetByID(int id)
        {
            if (id <= 0)
            {
                throw new IncorrectId();
            }
            var item = unit.Resumes.GetAll().Where(r => r.Id == id).FirstOrDefault();
            if (item == null)
            {
                throw new CantGetByIdError($"Cant find Resume with  id = {id}");
            }
            else
            {
                ResumeDto orderDto = new ResumeDto
                {
                    Category_Id = item.Category_Id,
                    Unem_Id = item.Unem_Id,
                    Id = item.Id,
                    Worktime = item.Worktime,
                    Resname=item.Resname
                };
                return orderDto;
            }
        }
        public void Edit(ResumeDto item)
        {
            if (item == null)
            {
                throw new NullableItemError();
            }
            Resume order = unit.Resumes.GetTbyID(item.Id);
            if (item.Worktime < 0)
            {
                item.Worktime = 0;
            }
            if (item.Worktime > 100)
            {
                item.Worktime = 100;
            }
            order.Category_Id = item.Category_Id;
            order.Unem_Id = item.Unem_Id;
            order.Worktime = item.Worktime;
            order.Resname = item.Resname;
            unit.Resumes.Update(order);
            unit.Save();

        }

        public void Create(ResumeDto item,int k,int b)
        {
            if (item == null)
            {
                throw new NullableItemError();
            }
            if (item.Worktime < 0)
            {
                item.Worktime = 0;
            }
            if (item.Worktime > 100)
            {
                item.Worktime = 100;
            }
            Resume order2 = new Resume
            {
                Category_Id = k,
               Unem_Id = b,
                Worktime = item.Worktime,
                Resname=item.Resname
            };

            unit.Resumes.Create(order2);
            unit.Save();

        }
        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new CantGetByIdError();
            }
            var order = unit.Resumes.GetAll().FirstOrDefault(i => i.Id == id);

            if (order == null) {
                throw new CantGetByIdError();
            }
            unit.Resumes.Delete(order.Id);
            unit.Save();
        }

        public List<Unem> GetListOfUn()
        {
            List<Unem> list = unit.Unems.GetAll().ToList();
            

            
            return list.ToList();
        }
        public List<Category> GetListOfCat()
        {
            List<Category> list = unit.Categorys.GetAll().ToList();



            return list.ToList();
        }

    }
}

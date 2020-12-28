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
    public class VacService
    {

        public UnitOfWork unit;
        public IMapper Ordermap = new MapperConfiguration(cfg => cfg.CreateMap<Vac, VacDto>()).CreateMapper();
        public VacService()
        {
            unit = new UnitOfWork();

        }

        public IEnumerable<VacDto> GetAll()
        {
            try
            {
                return Ordermap.Map<IEnumerable<Vac>, List<VacDto>>((IEnumerable<Vac>)unit.Vacs.GetAll());
            }
            catch
            {
                return null;
            }
        }

       
        public IEnumerable<VacDto> SortBySurname()
        {



            return Ordermap.Map<IEnumerable<Vac>, List<VacDto>>((IEnumerable<Vac>)unit.Vacs.GetAll().OrderBy(r => r.Vacname));


        }
        public IEnumerable<VacDto> SortByName()
        {



            return Ordermap.Map<IEnumerable<Vac>, List<VacDto>>((IEnumerable<Vac>)unit.Vacs.GetAll().OrderBy(r => r.Salary));


        }
        public IEnumerable<VacDto> SortBySurnameDec()
        {



            return Ordermap.Map<IEnumerable<Vac>, List<VacDto>>((IEnumerable<Vac>)unit.Vacs.GetAll().OrderByDescending(r => r.Vacname));

        }
        public IEnumerable<VacDto> SortByNameDec()
        {



            return Ordermap.Map<IEnumerable<Vac>, List<VacDto>>((IEnumerable<Vac>)unit.Vacs.GetAll().OrderByDescending(r => r.Salary));


        }
        public VacDto GetByID(int id)
        {
            if (id <= 0)
            {
                throw new IncorrectId();
            }
            var item = unit.Vacs.GetAll().Where(r => r.Id == id).FirstOrDefault();
            if (item == null)
            {
                throw new CantGetByIdError($"Cant find Vacation with  id = {id}");
            }
            else
            {
                VacDto orderDto = new VacDto
                {
                    Category_Id = item.Category_Id,
                    Cust_Id = item.Cust_Id,
                    Id = item.Id,
                    Vacname = item.Vacname,
                    Salary = item.Salary
                };
                return orderDto;
            }
        }
        public void Edit(VacDto item)
        {
            if (item == null)
            {
                throw new NullableItemError();
            }
            if (item.Salary < 150)
            {
                item.Salary = 150;
            }
            Vac order = unit.Vacs.GetTbyID(item.Id);
            order.Category_Id = item.Category_Id;
            order.Cust_Id = item.Cust_Id;
            order.Salary = item.Salary;
            order.Vacname = item.Vacname;
            unit.Vacs.Update(order);
            unit.Save();

        }

        public void Create(VacDto item, int k, int b)
        {
            if (item == null)
            {
                throw new NullableItemError();
            }
            if (item.Salary < 150)
            {
                item.Salary = 150;
            }
            
            Vac order2 = new Vac
            {
                Category_Id = item.Category_Id,
                Cust_Id = item.Cust_Id,
                Salary = item.Salary,
                Vacname = item.Vacname
            };

            unit.Vacs.Create(order2);
            unit.Save();

        }
        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new IncorrectId();
            }
            var order = unit.Vacs.GetAll().FirstOrDefault(i => i.Id == id);

            if (order == null)
            {
                throw new CantGetByIdError();
            }
            unit.Vacs.Delete(order.Id);
            unit.Save();
        }

        public List<Cust> GetListOfCust()
        {
            List<Cust> list = unit.Custs.GetAll().ToList();



            return list.ToList();
        }
        public List<Category> GetListOfCat()
        {
            List<Category> list = unit.Categorys.GetAll().ToList();



            return list.ToList();
        }

    }
}

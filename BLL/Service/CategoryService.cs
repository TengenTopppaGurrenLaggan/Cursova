using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.MyErrors;
using DAL;
using DAL.Repositories;

namespace BLL.Service
{
    public class CategoryService
    {

        public UnitOfWork uofs;
        public IMapper Goodmapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDto>()).CreateMapper();
        
        public CategoryService()
        {
            uofs = new UnitOfWork();
        }




        public IEnumerable<CategoryDto> GetAll()
        {


            try
            {
                return Goodmapper.Map<IEnumerable<Category>, List<CategoryDto>>((IEnumerable<Category>)uofs.Categorys.GetAll());
            }

            catch
            {
                return null;
            }
        }
        public List<CategoryDto> GetByItem(CategoryDto items)
        {
            int count;
            int start;
            int end;
            int k;
            List<CategoryDto> baka = new List<CategoryDto>();
            CategoryDto s=new CategoryDto();
            
            List<CategoryDto> c = Goodmapper.Map<IEnumerable<Category>, List<CategoryDto>>(uofs.Categorys.GetAll());
            foreach(CategoryDto item in c)
            {
                k = -1;
                start = 0;
                end = item.Catname.Length;
                k = 0;
                do
                {
                    count = end - start;
                    k = item.Catname.ToLower().IndexOf(items.Catname.ToLower(),start,count);
                    if (k != -1)
                    {
                        s=item;
                        baka.Add(s);
                        break;
                    }
                    start++;
                } while (start < end);
                
            }
           
            return baka;
        }

        public CategoryDto GetById(int id)
        {
            if (id <= 0)
            {
                throw new IncorrectId();
            }


            var item = uofs.Categorys.GetAll().Where(r => r.Id == id).FirstOrDefault();
            if (item == null)
            {
                throw new CantGetByIdError($"Cant find Category with Id {id}");
            }
            else
            {
                CategoryDto GoodDto = new CategoryDto
                {
                    Catname = item.Catname,
                    
                };
                return GoodDto;
            }


            return Goodmapper.Map<Category, CategoryDto>(item);
        }

        public int Create(CategoryDto item)
        {
            int k = 0;
            int b = 0;
            if (item == null)
            {
                throw new NullableItemError();
            }
            IEnumerable<Category> deta = uofs.Categorys.GetAll();
            foreach (Category item2 in deta)
            {
                k = item2.Catname.ToLower().CompareTo(item.Catname.ToLower());
                if (k == 0)
                {
                    b++;
                }
            }
            if (b > 0)
            {
                throw new CreationError();
            }
            Category good = new Category
            {
                Catname = item.Catname,
                
            };
            uofs.Categorys.Create(good);
            uofs.Save();
            return uofs.Categorys.GetAll().OrderByDescending(r => r.Id).FirstOrDefault().Id;

        }
        public int Delete(int id)
        {

            if (id <= 0)
            {
                throw new IncorrectId();
            }
            var ing = uofs.Categorys.GetTbyID(id);
            var T = uofs.Vacs.GetAll().Where(t=>t.Category_Id== id);
            var S = uofs.Resumes.GetAll().Where(t => t.Category_Id == id);
            foreach(Vac item in T)
            {
                uofs.Vacs.Delete(item.Id);
            }
            foreach (Resume item2 in S)
            {
                uofs.Resumes.Delete(item2.Id);
            }
             if (ing == null)
            {
                throw new CantGetByIdError($"Cant find Category with Id {id}");
            }




            uofs.Categorys.Delete(id);
            uofs.Save();
            return id;
        }

        public void Edit(CategoryDto item)
        {
            if (item == null)
            {
                throw new NullableItemError();
            }
            Category good = uofs.Categorys.GetTbyID(item.Id);
            
            good.Catname = item.Catname;

            

            uofs.Categorys.Update(good);
            uofs.Save();

        }

    }
}

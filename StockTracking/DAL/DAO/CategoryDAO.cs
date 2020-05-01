using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class CategoryDAO : StockContext, IDAO<Category, CategoryDetailDTO>
    {
        public List<CategoryDetailDTO> Select()
        {
            var categories = new List<CategoryDetailDTO>();
            var list = db.Categorys;

            foreach (var item in list)
            {
                var dto = new CategoryDetailDTO();
                dto.ID = item.ID;
                dto.CategoryName = item.CategoryName;

                categories.Add(dto);
            }

            return categories;
        }

        public bool Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Category entity)
        {
            try
            {
                db.Categorys.Add(entity);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Category entity)
        {
            try
            {
                var category = db.Categorys.First(x => x.ID == entity.ID);
                category.CategoryName = entity.CategoryName;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using StockTracking.DAL;
using StockTracking.DAL.DAO;
using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.BLL
{
    public class CategoryBLL : IBLL<CategoryDetailDTO, CategoryDTO>
    {
        private CategoryDAO dao = new CategoryDAO();

        public bool Delete(CategoryDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CategoryDetailDTO entity)
        {
            Category category = new Category();
            category.CategoryName = entity.CategoryName;

            return dao.Insert(category);
        }

        public CategoryDTO Select()
        {
            var dto = new CategoryDTO();
            dto.Categories = dao.Select();

            return dto;
        }

        public bool Update(CategoryDetailDTO entity)
        {
            var category = new Category();
            category.ID = entity.ID;
            category.CategoryName = entity.CategoryName;

            return dao.Update(category);
        }
    }
}

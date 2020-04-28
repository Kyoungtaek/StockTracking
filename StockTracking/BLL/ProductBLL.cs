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
    public class ProductBLL : IBLL<ProductDetailDTO, ProductDTO>
    {
        private CategoryDAO categoryDao = new CategoryDAO();
        private ProductDAO productDao = new ProductDAO();

        public bool Delete(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProductDetailDTO entity)
        {
            var product = new Product();
            product.ProductName = entity.ProductName;
            product.Price = entity.Price;
            product.CategoryID = entity.CategoryID;

            return productDao.Insert(product);
        }

        public ProductDTO Select()
        {
            var dto = new ProductDTO();
            dto.Categories = categoryDao.Select();
            dto.Products = productDao.Select();

            return dto;
        }

        public bool Update(ProductDetailDTO entity)
        {
            var product = new Product();
            product.ID = entity.ProductID;
            product.Price = entity.Price;
            product.ProductName = entity.ProductName;
            product.StockAmount = entity.StockAmount;
            product.CategoryID = entity.CategoryID;

            return productDao.Update(product);
        }
    }
}

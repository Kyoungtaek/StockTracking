using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class ProductDAO : StockContext, IDAO<Product, ProductDetailDTO>
    {
        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Product entity)
        {
            try
            {
                db.Products.Add(entity);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ProductDetailDTO> Select()
        {
            try
            {
                var products = new List<ProductDetailDTO>();
                var list = (from p in db.Products
                            join c in db.Categories on p.CategoryID equals c.ID
                            select new
                            {
                                ProductName = p.ProductName,
                                CategoryName = c.CategoryName,
                                StockAmount = p.StockAmount,
                                Price = p.Price,
                                ProductID = p.ID,
                                CategoryID = c.ID
                            }).OrderBy(x => x.ProductName).ToList();

                foreach (var item in list)
                {
                    var dto = new ProductDetailDTO();
                    dto.ProductName = item.ProductName;
                    dto.CategoryID = item.CategoryID;
                    dto.ProductID = item.ProductID;
                    dto.CategoryName = item.CategoryName;
                    dto.Price = item.Price;
                    dto.StockAmount = item.StockAmount;

                    products.Add(dto);
                }

                return products;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Product entity)
        {
            try
            {
                Product product = db.Products.First(x => x.ID == entity.ID);
                if (entity.CategoryID == 0)
                {
                    product.StockAmount = entity.StockAmount;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

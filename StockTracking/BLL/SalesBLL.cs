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
    public class SalesBLL : IBLL<SalesDetailDTO, SalesDTO>
    {
        private SalesDAO dao = new SalesDAO();
        private ProductDAO productDao = new ProductDAO();
        private CategoryDAO categoryDao = new CategoryDAO();
        private CustomerDAO customerDao = new CustomerDAO();

        public bool Delete(SalesDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SalesDetailDTO entity)
        {
            var sale = new Sale();
            sale.CategoryID = entity.CategoryID;
            sale.ProductID = entity.ProductID;
            sale.CustomerID = entity.CustomerID;
            sale.ProductSalesPrice = entity.Price;
            sale.ProductSalesAmount = entity.SalesAmount;
            sale.SalesDate = entity.SalesDate;

            if (dao.Insert(sale))
            {
                var product = new Product();
                product.ID = entity.ProductID;

                int temp = entity.StockAmount - entity.SalesAmount;
                product.StockAmount = temp;

                if (productDao.Update(product))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        public SalesDTO Select()
        {
            var dto = new SalesDTO();
            dto.Products = productDao.Select();
            dto.Customers = customerDao.Select();
            dto.Categories = categoryDao.Select();
            dto.Sales = dao.Select();

            return dto;
        }

        public bool Update(SalesDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

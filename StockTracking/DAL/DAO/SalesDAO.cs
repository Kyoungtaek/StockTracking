using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class SalesDAO : StockContext, IDAO<Sale, SalesDetailDTO>
    {
        public bool Delete(Sale entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Sale entity)
        {
            try
            {
                db.Sales.Add(entity);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SalesDetailDTO> Select()
        {
            try
            {
                var sales = new List<SalesDetailDTO>();
                var list = (from s in db.Sales
                            join p in db.Products on s.ProductID equals p.ID
                            join c in db.Customers on s.CustomerID equals c.ID
                            join ca in db.Categorys on s.CategoryID equals ca.ID
                            select new SalesDetailDTO
                            {
                                ProductName = p.ProductName,
                                CustomerName = c.CustomerName,
                                CategoryName = ca.CategoryName,
                                ProductID = s.ProductID,
                                CustomerID = s.CustomerID,
                                SalesID = s.ID,
                                CategoryID = s.CustomerID,
                                Price = s.ProductSalesPrice,
                                SalesAmount = s.ProductSalesAmount,
                                SalesDate = s.SalesDate
                            }).OrderByDescending(x => x.SalesDate).ToList();

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Sale entity)
        {
            throw new NotImplementedException();
        }
    }
}

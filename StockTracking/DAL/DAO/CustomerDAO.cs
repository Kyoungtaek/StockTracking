using StockTracking.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracking.DAL.DAO
{
    public class CustomerDAO : StockContext, IDAO<Customer, CustomerDetailDTO>
    {
        public bool Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Customer entity)
        {
            try
            {
                db.Customers.Add(entity);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CustomerDetailDTO> Select()
        {
            try
            {
                var customers = new List<CustomerDetailDTO>();
                var list = db.Customers;

                foreach (var item in list)
                {
                    var dto = new CustomerDetailDTO();
                    dto.ID = item.ID;
                    dto.CsutomerName = item.CustomerName;

                    customers.Add(dto);
                }

                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Customer entity)
        {
            try
            {
                Customer customer = db.Customers.First(x => x.ID == entity.ID);
                customer.CustomerName = entity.CustomerName;
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

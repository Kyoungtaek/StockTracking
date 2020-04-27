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
    public class CustomerBLL : IBLL<CustomerDetailDTO, CustomerDTO>
    {
        private CustomerDAO dao = new CustomerDAO();
        public bool Delete(CustomerDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CustomerDetailDTO entity)
        {
            var customer = new Customer();
            customer.CustomerName = entity.CsutomerName;

            return dao.Insert(customer);
        }

        public CustomerDTO Select()
        {
            var dto = new CustomerDTO();
            dto.Customers = dao.Select();

            return dto;
        }

        public bool Update(CustomerDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}

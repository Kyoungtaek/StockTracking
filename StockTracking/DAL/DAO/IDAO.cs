using System.Collections.Generic;

namespace StockTracking.DAL.DAO
{
    interface IDAO<T,K> where T:class where K:class
    {
        List<K> Select();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool GetBack(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MasterProjectDAL.Product
{
    public interface IProductRepository
    {
        Task<DataModel.Product> AddProduct(DataModel.Product product);
    }
}

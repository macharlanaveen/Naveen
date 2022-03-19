using MasterProjectCommonUtility.Logger;
using MasterProjectDAL.DataModel;
using MasterProjectDAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MasterProjectDAL.Product
{
    public class ProductRepository : IProductRepository
    {
        private InaveendbContext _masterProjectContext;
        private ILoggerManager _loggerManager;


        public ProductRepository(InaveendbContext masterProjectContext, ILoggerManager loggerManager) 
        {
            _masterProjectContext = masterProjectContext;

            _loggerManager= loggerManager;
        }
        //public async Task<DataModel.Product> AddProduct(DataModel.Product product)
        //{
        //    _loggerManager.LogInfo("Entry ProductRepository=> AddProduct");
        //    await _masterProjectContext.Product.AddAsync(product);
        //    await _masterProjectContext.SaveChangesAsync();
        //    _loggerManager.LogInfo("Exit ProductRepository=> AddProduct");
        //    return product;
        //}
    }
}

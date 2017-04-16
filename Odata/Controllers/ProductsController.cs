using System.Collections.Generic;
using System.Linq;
using System.Web.OData;
using Odata.Models;

namespace Odata.Controllers
{
    public class ProductsController : ODataController
    {
        [EnableQuery]
        public IQueryable<Product> Get()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Category = "A",
                    Id = 1,
                    Name = "Test1",
                    Price = 32.2m
                },
                new Product
                {
                    Category = "B",
                    Id = 2,
                    Name = "Test2",
                    Price = 124.1m
                }
            }.AsQueryable();
        }
    }
}
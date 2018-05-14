using System;
using System.Collections.Generic;
using System.Text;

namespace Itb.Shared
{
    public interface IProductRepository
    {
		IEnumerable<Product> GetProducts();
		Product GetProduct(int id);
		int DeleteProduct(int id);
		int UpdateProduct(Product prod);
		int AddProduct(Product prod);
    }
}

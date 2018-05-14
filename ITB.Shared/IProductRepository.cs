using System;
using System.Collections.Generic;

namespace ITB.Shared
{
	interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		Product GetProduct(int id);
		bool DeleteProduct(int id);
		bool UpdateProduct(Product prod);
		bool InsertProduct(Product prod);

	}
}

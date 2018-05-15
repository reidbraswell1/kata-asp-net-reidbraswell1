using System;
using System.Collections.Generic;
using Itb.Shared;

namespace Itb.Repositories
{
	public class ProductRepository : IProductRepository
	{
		int IProductRepository.CreateProduct(Product prod)
		{
			throw new NotImplementedException();
		}

		int IProductRepository.DeleteProduct(int id)
		{
			throw new NotImplementedException();
		}

		Product IProductRepository.GetProduct(int id)
		{
			throw new NotImplementedException();
		}

		IEnumerable<Product> IProductRepository.GetProducts()
		{
			throw new NotImplementedException();
		}

		int IProductRepository.UpdateProduct(Product prod)
		{
			throw new NotImplementedException();
		}
	}
}

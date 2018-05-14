using System;
using System.Collections.Generic;
using System.Data;
using Itb.Shared;
using Dapper;

namespace Itb.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly IDbConnection _conn;

		public ProductRepository(IDbConnection conn)
		{
			_conn = conn;
		}

		int IProductRepository.AddProduct(Product prod)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Execute("INSERT INTO product (Name) VALUES (@Name)", prod);
			}
		}

		int IProductRepository.DeleteProduct(int id)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Execute("DELETE FROM product WHERE ProductId = @Id", id);
			}
		}

		int IProductRepository.UpdateProduct(Product prod)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Execute("UPDATE product SET Name = @Name WHERE ProductId = @Id", id);
			}
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

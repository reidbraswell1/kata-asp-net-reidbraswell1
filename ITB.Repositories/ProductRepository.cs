using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
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
				return conn.Execute("DELETE FROM product WHERE ProductId = @Id", new { id });
			}
		}

		int IProductRepository.UpdateProduct(Product prod)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Execute("UPDATE product SET Name = @Name WHERE ProductId = @Id", prod);
			}
		}

		Product IProductRepository.GetProduct(int id)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Query<Product>("SELECT *, ProductId as Id WHERE ProductId = @Id", new { id }).FirstOrDefault();
			}
		}

		Task<IEnumerable<Product>> IProductRepository.GetProducts()
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.QueryAsync<Product>("SELECT *, ProductId as Id");
			}
		}
	}
}

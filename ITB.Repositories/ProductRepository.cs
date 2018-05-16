using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using ITB.Shared;
using Dapper;

namespace ITB.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly IDbConnection _conn;

		public ProductRepository(IDbConnection conn)
		{
			_conn = conn;
		}

		public int AddProduct(Product prod)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Execute("INSERT INTO product (Name) VALUES (@Name)", prod);
			}
		}

		public int DeleteProduct(int id)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Execute("DELETE FROM product WHERE ProductId = @Id", new { id });
			}
		}

		public int UpdateProduct(Product prod)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Execute("UPDATE product SET Name = @Name WHERE ProductId = @Id", prod);
			}
		}

		public Product GetProduct(int id)
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.Query<Product>("SELECT *, ProductId as Id FROM product WHERE ProductId = @Id", new { id }).FirstOrDefault();
			}
		}

		public Task<IEnumerable<Product>> GetProducts()
		{
			using (var conn = _conn)
			{
				conn.Open();
				return conn.QueryAsync<Product>("SELECT *, ProductId as Id FROM product ORDER BY Id DESC");
			}
		}
	}
}

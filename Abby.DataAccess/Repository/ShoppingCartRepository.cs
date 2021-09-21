using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db= db;
        }

		public int DecrementCount(ShoppingCart shoppingCart, int count)
		{
			shoppingCart.Count -= count;
			_db.SaveChanges();
			return shoppingCart.Count;
		}

		public int IncrementCount(ShoppingCart shoppingCart, int count)
		{
			shoppingCart.Count += count;
			_db.SaveChanges();
			return shoppingCart.Count;
		}
	}
}

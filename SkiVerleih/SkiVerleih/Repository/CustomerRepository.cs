using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SkiVerleih.Models;

namespace SkiVerleih.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(MyContext context) : base(context)
        {
        }
    }
}
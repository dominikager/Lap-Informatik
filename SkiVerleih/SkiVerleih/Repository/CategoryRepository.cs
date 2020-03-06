using SkiVerleih.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkiVerleih.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(MyContext context) : base(context)
        {
        }
    }
}
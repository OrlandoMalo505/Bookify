using Bookify.Domain.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Repositories;
internal sealed class ReviewRepository : Repository<Review>
{
    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
    }
}

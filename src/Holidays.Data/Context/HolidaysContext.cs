using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holidays.Data.Context
{
    public class HolidaysContext : DbContext
    {
        public HolidaysContext(DbContextOptions<HolidaysContext> options) : base(options) { }
    }
}

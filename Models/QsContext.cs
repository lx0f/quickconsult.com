using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuickConsult.Models;

public class QsContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public QsContext(DbContextOptions options) : base(options)
    {
    }
}
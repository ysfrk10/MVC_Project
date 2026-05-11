using System;
using System.Collections.Generic;
using System.Text;
using GymDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymDAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}

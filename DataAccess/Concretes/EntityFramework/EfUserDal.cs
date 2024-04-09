using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        public void Add(User user)
        {
            using (UserDbContext context = new UserDbContext())
            {
                var addedEntity = context.Entry(user);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(User user)
        {
            using (UserDbContext context = new UserDbContext())
            {
                var deletedEntity = context.Entry(user);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            using (UserDbContext context = new UserDbContext())
            {
                return context.Set<User>().ToList();
            }
        }

        public User GetById(int id)
        {
            using (UserDbContext context = new UserDbContext())
            {
                return context.Set<User>().SingleOrDefault(u => u.Id == id);
            }
        }

        public void Update(User user)
        {
            using (UserDbContext context = new UserDbContext())
            {
                var updatedEntity = context.Entry(user);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

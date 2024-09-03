using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }


        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
            )
        {
            //Se crea una conulta IQueryable a partir del DbSet del Contexto
            IQueryable<T> query = dbSet;

            //Se aplica el filtro si se proporciona
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Se incluyen propiedades de navegación si se proporcionan
            if (includeProperties != null)
            {
                //Se divide la cadena de propiedades por coma y se itera sobre ella
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            //Se aplica el ordenamiento si se proporciona
            if (orderBy != null)
            {
                //Se ejecuta la función de ordenamiento y se convierte la consulta en una lista
                return orderBy(query).ToList();
            }

            //Si no se proporciona un ordenamiento, simplemente se convierte la consulta en una lista
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            //Se crea una conulta IQueryable a partir del DbSet del Contexto
            IQueryable<T> query = dbSet;

            //Se aplica el filtro si se proporciona
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Se incluyen propiedades de navegación si se proporcionan
            if (includeProperties != null)
            {
                //Se divide la cadena de propiedades por coma y se itera sobre ella
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityRemove = dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TCA.Nucleo.Entidades.Base;

namespace TCA.DAL.EntityFramework.SQL.Repositorios.Base
{
    public abstract class RepositorioEF<TEntity> : Nucleo.DAL.Interfaces.Base.Repositorio<TEntity>
        where TEntity : Entidade
    {
        private DbContext contexto { get; set; }

        protected DbSet<TEntity> entidades { get; set; }

        protected RepositorioEF(DbContext contexto)
        {
            this.contexto = contexto;
            this.entidades = contexto.Set<TEntity>();
        }

        protected virtual IEnumerable<TEntity> Listar(
            Expression<Func<TEntity, bool>> expressaoWhere = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> expressaoOrderBy = null,
            string propriedadesParaIncluir = "")
        {
            IQueryable<TEntity> query = entidades;

            if (expressaoWhere != null)
                query = query.Where(expressaoWhere);

            var propriedades = propriedadesParaIncluir.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var propriedade in propriedades)
                query = query.Include(propriedade);

            if (expressaoOrderBy != null)
                return expressaoOrderBy(query).ToList();

            return query.ToList();
        }

        public TEntity Obter(long id)
        {
            return entidades.Find(id);
        }

        public IEnumerable<TEntity> Listar()
        {
            return entidades.ToList();
        }

        public void Inserir(TEntity entidade)
        {
            try
            {
                entidades.Add(entidade);
            }
            finally
            {
                contexto.SaveChanges();
            }
        }

        public void Atualizar(TEntity entidade)
        {
            try
            {
                entidades.Attach(entidade);
                contexto.Entry(entidade).State = EntityState.Modified;
            }
            finally
            {
                contexto.SaveChanges();
            }
        }

        public void Excluir(long id)
        {
            try
            {
                var entidade = Obter(id);
                Delete(entidade);
            }
            finally
            {
                contexto.SaveChanges();
            }
        }

        private void Delete(TEntity entidade)
        {
            if (contexto.Entry(entidade).State == EntityState.Detached)
                entidades.Attach(entidade);

            entidades.Remove(entidade);
        }
    }
}
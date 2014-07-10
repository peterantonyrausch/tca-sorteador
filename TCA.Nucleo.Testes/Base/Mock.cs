using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TCA.Nucleo.DAL.Interfaces.Base;
using TCA.Nucleo.Entidades.Base;

namespace TCA.Nucleo.Testes.Base
{
    public abstract class Mock<TEntidade> : Repositorio<TEntidade> where TEntidade : Entidade
    {
        protected readonly List<TEntidade> Entidades;

        protected Mock()
        {
            this.Entidades = new List<TEntidade>();
        }

        public TEntidade Obter(long id)
        {
            return Entidades.FirstOrDefault(entidade => entidade.Id == id);
        }

        public IEnumerable<TEntidade> Listar()
        {
            return Entidades;
        }

        public void Inserir(TEntidade entidade)
        {
            entidade.Id = (Entidades.Count == 0)
                ? 1
                : Entidades.Max(e => e.Id) + 1;

            Entidades.Add(entidade);
        }

        public void Atualizar(TEntidade entidade)
        {
            var entidadeAtualizar = Obter(entidade.Id);

            if (entidadeAtualizar == null)
                throw new Exception(string.Format("Você tentou atualizar a entidade {0} que não existe no repositório.", entidade.GetType().Name));

            entidadeAtualizar = Mapper.DynamicMap<TEntidade>(entidade);
        }

        public void Excluir(long id)
        {
            Entidades.RemoveAll(entidade => entidade.Id == id);
        }
    }
}
using System.Collections.Generic;
using TCA.Nucleo.Entidades.Base;

namespace TCA.Nucleo.DAL.Interfaces.Base
{
    public interface Repositorio<TEntidade> where TEntidade : Entidade
    {
        TEntidade Obter(long id);

        IEnumerable<TEntidade> Listar();

        void Inserir(TEntidade entidade);

        void Atualizar(TEntidade entidade);

        void Excluir(long id);
    }
}
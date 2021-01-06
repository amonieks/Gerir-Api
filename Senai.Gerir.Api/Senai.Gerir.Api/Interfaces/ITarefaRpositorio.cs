using Senai.Gerir.Api.Dominios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gerir.Api.Interfaces
{
    public interface ITarefaRepositorio
    {

        Tarefa Cadastrar(Tarefa tarefa);

        List<Tarefa> ListarTodos(Guid IdUsuario);

        Tarefa AlterarStatus(Guid IdTarefa);

        void Remover(Guid IdTarefa);

        Tarefa Editar(Tarefa tarefa);

        Tarefa BuscarPorId(Guid IdTarefa);

      
    }
}

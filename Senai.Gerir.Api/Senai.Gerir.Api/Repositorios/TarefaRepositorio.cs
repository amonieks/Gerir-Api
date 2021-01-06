using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using Senai.Gerir.Api.Contextos;


namespace Senai.Gerir.Api.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {

        // Criar representação do banco de Dados

        private readonly GerirContext _context;

        // Instancia o obejeto para acessar os métodos do banco de dados(contexto)
        public TarefaRepositorio()
        {
            _context = new GerirContext();
        }

        public Tarefa AlterarStatus(Guid IdTarefa)
        {
            try
            {
                //busca a tarefa utilizando o método BuscarporId
                var tarefa = BuscarPorId(IdTarefa);

                if (tarefa.Status == false)
                {
                    tarefa.Status = true;
                }else
                {
                    tarefa.Status = false;
                }

                return tarefa;
            }
            catch(Exception ex)
            {

                throw new(ex.Message);
            }
        }

       

        public Tarefa BuscarPorId(Guid IdTarefa)
        {
            try
            {
                var tarefa = _context.Tarefas.Find(IdTarefa);

                return tarefa;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

       
        public Tarefa Cadastrar(Tarefa tarefa)
        {
            try
            {
                _context.Tarefas.Add(tarefa);

                _context.SaveChanges();

                return tarefa;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Tarefa Editar(Tarefa tarefa)
        {
            try
            {
                //busca a tarefa por Id
                var tarefaexiste = BuscarPorId(tarefa.Id);

                //testar se existe a tarefa
                if(tarefaexiste==null)
                
                    throw new Exception("Tarefa não encontrada ");

                //Atualiza os dados (Titulo,descrição, categoria, Dataenrega,status,UsuarioID)
                tarefaexiste.Titulo = tarefa.Titulo;
                tarefaexiste.Descricao = tarefa.Descricao;
                tarefaexiste.Categoria = tarefa.Categoria;
                tarefaexiste.Dataentrega = tarefa.Dataentrega;
                tarefaexiste.Status = tarefa.Status;
                tarefaexiste.UsuarioId = tarefa.UsuarioId;

                //salva alterações

                _context.Tarefas.Update(tarefaexiste);
                _context.SaveChanges();


                               
                return tarefaexiste;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<Tarefa> ListarTodos(Guid IdUsuario)
        {
            try
            {

            List<Tarefa> tarefas = new List<Tarefa>();


                tarefas = (List<Tarefa>)_context.Tarefas.Where(e => e.UsuarioId == IdUsuario);

                return tarefas;

            }
            catch(Exception ex)
            {

            throw new NotImplementedException();
            }


        }

        public void Remover(Guid IdTarefa)
        {
            try
            {
                var tarefa = BuscarPorId(IdTarefa);

                _context.Tarefas.Remove(tarefa);
            }
            catch(Exception ex)
            {

                throw new(ex.Message);
            }
        }
    }
}

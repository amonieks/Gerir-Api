using Senai.Gerir.Api.Contextos;
using Senai.Gerir.Api.Dominios;
using Senai.Gerir.Api.Interfaces;
using System;
using System.Linq;

namespace Senai.Gerir.Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        //Declaro um objeto do tipo GerirContext que será
        //a representação do banco de dados
        private readonly GerirContext _context;

        public UsuarioRepositorio()
        {
            //Cria uma instância de GerirContext
            _context = new GerirContext();
        }

        public Usuario BuscarPorId(Guid idUsuario)
        {
            try
            {
                var usuario = _context.Usuarios.Find(idUsuario);

                return usuario;
            }
            catch(System.Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public Usuario Cadastrar(Usuario usuario)
        {
            try
            {
                //adiciona um usuario ao DbSet Usuarios do contexto
                _context.Usuarios.Add(usuario);
                //Salva as alterações do contexto
                _context.SaveChanges();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario Editar(Usuario usuario)
        {
            try
            {
                var usuarioexiste = BuscarPorId(usuario.Id);

                //verifica se o usuário existe
                if (usuarioexiste == null)
                
                    throw new Exception("usuario não encontrado");

                //Altera os valores do usuário
                usuarioexiste.Nome = usuario.Nome;
                usuarioexiste.Email = usuario.Email;

                if (!string.IsNullOrEmpty(usuario.Senha))
                    usuarioexiste.Senha = usuario.Senha;

                _context.Usuarios.Update(usuarioexiste);
                _context.SaveChanges();


                return usuarioexiste;
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Usuario Logar(string email, string senha)
        {
            try
            {
                var usuario = _context.Usuarios
                            .FirstOrDefault(c => c.Email == email && c.Senha == senha);

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

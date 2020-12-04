using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp2;
using Tp2.Models;

namespace PdD2.DAOs
{
    public class UsuariosDAO
    {
        public static UsuariosDAO instance = null;
        public List<Usuario> usuarios = new List<Usuario>();

        private UsuariosDAO() { }

        public static UsuariosDAO getInstancia()
        {

            if (instance == null)
            {
                instance = new UsuariosDAO();
            }

            return instance;

        }

        public UsuariosDAO Add(Usuario usuario)
        {
            usuarios.Add(usuario);
            return this;

        }

        public Usuario usuarioExistente(string username, string password)
        {
            return usuarios.Find(x => x.usuario == username && x.password == password);
        }
        public List<Usuario> verUsuarios()
        {
            //return personas;
            var queryBuilder = DBConnection.getInstance().getQueryBuilder();
            queryBuilder.setQuery("SELECT * FROM personas");

            var dataReader = DBConnection.getInstance().select(queryBuilder);
            var lista = new List<Usuario>();
            while (dataReader.Read())
            {
                var persona = new Usuario(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2));
                lista.Add(persona);
            }

            return lista;
        }

        public Usuario verUsuario(int id)
        {

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("SELECT * FROM personas WHERE id=@id");
            queryBuilder.addParam("@id", id);

            var dataReader = DBConnection.getInstance().select(queryBuilder);
            Usuario persona = null;
            while (dataReader.Read())
            {
                persona = new Usuario(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetString(2));
            }

            return persona;

        }
        public void agregarPersona(Usuario persona)
        {

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("INSERT INTO personas (usuario,password) VALUES (@usuario,@password)");
            queryBuilder.addParam("@usuario", persona.usuario);
            queryBuilder.addParam("@password", persona.password);

            //this.personas.Add(persona)
            DBConnection.getInstance().abm(queryBuilder);

        }

        public void eliminarPersona(Usuario persona)
        {
            //this.personas.Remove(persona)

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("DELETE FROM personas WHERE id=@id");
            queryBuilder.addParam("@id", persona.id);

            DBConnection.getInstance().abm(queryBuilder);

        }

        // SOBRECARGA
        public void eliminarPersona(int id)
        {
            //this.personas.Remove(persona)

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("DELETE FROM personas WHERE id=@id");
            queryBuilder.addParam("@id", id);

            DBConnection.getInstance().abm(queryBuilder);

        }

        public void actualizarPersona(Usuario persona)
        {

            /*this.eliminarPersona(id);
            this.agregarPersona(persona);*/

            var queryBuilder = DBConnection.getInstance().getQueryBuilder();

            queryBuilder.setQuery("UPDATE personas SET id=@id,usuario=@usuario, password=@password WHERE id=@id");
            queryBuilder.addParam("@id", persona.id);
            queryBuilder.addParam("@usuario", persona.usuario);
            queryBuilder.addParam("@password", persona.password);

            DBConnection.getInstance().abm(queryBuilder);


        }





    }
}

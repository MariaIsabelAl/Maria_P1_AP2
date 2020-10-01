using Microsoft.EntityFrameworkCore;
using Maria_P1_AP2.DAL;
using Maria_P1_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Maria_P1_AP2.BLL
{
    public class CategoriaBLL

    {
        public static bool Guardar(Categorias categorias)
        {
            if (!Existe(categorias.CategoriaId))

                return Insertar(categorias);
            else
                return Modificar(categorias);

        }
        private static bool Insertar(Categorias categorias)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Categorias.Add(categorias);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Categorias categorias)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(categorias).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var auxCategoria = contexto.Categorias.Find(id);
                if (auxCategoria != null)
                {
                    contexto.Categorias.Remove(auxCategoria);
                    paso = contexto.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Categorias Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Categorias categorias;

            try
            {
                categorias = contexto.Categorias.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return categorias;

        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Categorias.Any(p=>p.CategoriaId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> expression)
        {
            List<Categorias> lista = new List<Categorias>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Categorias.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}
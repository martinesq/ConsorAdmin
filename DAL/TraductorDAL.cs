using BE;
using INT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TraductorDAL
    {
        DAO mDAO;
        Idioma i2;
        public TraductorDAL()
        {
            mDAO = new DAO();
        }
        public IList<IIdioma> ObtenerIdiomas()
        {
            IList<IIdioma> _idiomas = new List<IIdioma>();
            DataSet d = mDAO.ObtenerDatos("SELECT * FROM Idioma");
            if (d.Tables.Count >= 0)
                if (d.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in d.Tables[0].Rows)
                    {
                        Idioma idi = new Idioma();
                        Completar(dr, idi);
                        _idiomas.Add(i2);
                    }
                }
            return _idiomas;
        }
        private void Completar(DataRow d, Idioma i)
        {
            i = new Idioma(Guid.Parse(d["Idioma_ID"].ToString()));
            i.Nombre = d["Idioma_Descripcion"].ToString();
            i.Default = bool.Parse(d["Idioma_Default"].ToString());
            i.DVH = Convert.ToInt32(d["DVH"]);
            i.Estado = TipoEstado.SinCambios;
            i2 = i;
        }
        public IIdioma ObtenerIdiomaDefault()
        {
            return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
        }
        public IDictionary<string, ITraduccion> ObtenerTraduccion(IIdioma _idioma = null)
        {
            if (_idioma == null)
            {
                _idioma = ObtenerIdiomaDefault();
            }
            IDictionary<string, ITraduccion> _traducciones = new Dictionary<string, ITraduccion>();
            DataSet d = mDAO.ObtenerDatos("SELECT * FROM Etiqueta E INNER JOIN Traduccion T ON E.Etiqueta_ID = T.Etiqueta_ID WHERE T.Idioma_ID='" + _idioma.Id + "'");
            if (d.Tables.Count >= 0)
                if (d.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in d.Tables[0].Rows)
                    {
                        var etiqueta = dr["Etiqueta_Descripcion"].ToString();
                        Etiqueta eti = new Etiqueta(Guid.Parse(dr["Etiqueta_ID"].ToString()));
                        eti.Nombre = etiqueta;
                        Traduccion tra = new Traduccion();
                        tra.Etiqueta = eti;
                        tra.Texto = dr["Traduccion_Traduccion"].ToString();
                        tra.IdiomaId = _idioma.Id;
                        _traducciones.Add(etiqueta, tra);
                    }
                }
            return _traducciones;
        }
        public void Crear(List<ITraduccion> diccionario, IIdioma nuevoIdioma)
        {
            try
            {
                mDAO.EjecutarQuery("INSERT INTO Idioma (Idioma_ID, Idioma_Descripcion, Idioma_Default, DVH) VALUES ('" + nuevoIdioma.Id + "','" + nuevoIdioma.Nombre + "',0," + ((IVerificable)nuevoIdioma).DVH + ")");
                foreach (ITraduccion dic in diccionario)
                {     
                    mDAO.EjecutarQuery("INSERT INTO Traduccion (Etiqueta_ID, Idioma_ID, Traduccion_Traduccion, DVH) VALUES ('" + dic.Etiqueta.Id + "','" + nuevoIdioma.Id + "','" + dic.Texto + "'," + ((IVerificable)dic).DVH + ")");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Etiqueta> ObtenerEtiquetas()
        {
            List<Etiqueta> lista = new List<Etiqueta>();
            DataSet d = mDAO.ObtenerDatos("SELECT * FROM Etiqueta");
            foreach (DataRow dr in d.Tables[0].Rows)
            {
                Etiqueta e = new Etiqueta(Guid.Parse(dr["Etiqueta_ID"].ToString()));
                e.Nombre = dr["Etiqueta_Descripcion"].ToString();
                e.DVH = Convert.ToInt32(dr["DVH"]);
                lista.Add(e);
            }
            return lista;
        }

        public List<Traduccion> ObtenerTodasLasTraducciones()
        {
            List<Traduccion> lista = new List<Traduccion>();
            DataSet d = mDAO.ObtenerDatos("SELECT * FROM Traduccion");
            foreach (DataRow dr in d.Tables[0].Rows)
            {
                Traduccion t = new Traduccion();
                t.Etiqueta = new Etiqueta(Guid.Parse(dr["Etiqueta_ID"].ToString()));
                t.IdiomaId = Guid.Parse(dr["Idioma_ID"].ToString());
                t.Texto = dr["Traduccion_Traduccion"].ToString();
                t.DVH = Convert.ToInt32(dr["DVH"]);
                lista.Add(t);
            }
            return lista;
        }

        public void ActualizarDvhIdioma(Guid id, int dvh)
        {
            mDAO.EjecutarQuery("UPDATE Idioma SET DVH=" + dvh + " WHERE Idioma_ID='" + id + "'");
        }

        public void ActualizarDvhEtiqueta(Guid id, int dvh)
        {
            mDAO.EjecutarQuery("UPDATE Etiqueta SET DVH=" + dvh + " WHERE Etiqueta_ID='" + id + "'");
        }

        public void ActualizarDvhTraduccion(Guid etiquetaId, Guid idiomaId, int dvh)
        {
            mDAO.EjecutarQuery("UPDATE Traduccion SET DVH=" + dvh + " WHERE Etiqueta_ID='" + etiquetaId + "' AND Idioma_ID='" + idiomaId + "'");
        }

    }
}

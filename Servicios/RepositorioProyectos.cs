using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        public List<Proyecto> GetProyectos();
    }

    public class RepositorioProyectos: IRepositorioProyectos
    {
        public List<Proyecto> GetProyectos()
        {
            return new List<Proyecto> {
            new Proyecto()
            {
                Titulo = "FRISA Forjados SA de SV",
                Descripcion = "Desarrollo del software Consulta OP Aero de clase confidencial para el sector de Aeronautica",
                Link = "https://www.frisa.com/es/welcome",
                ImagenUrl = "http://ecotonourbano.com/img/frisa/Frisa_02.jpg"
            },

             new Proyecto()
            {
                Titulo = "AMAZON",
                Descripcion = "Desarrollo de pagina web de administracion de vendedores.",
                Link = "https://amazon.com",
                ImagenUrl = "https://m.media-amazon.com/images/G/33/gc/designs/livepreview/amazon_dkblue_noto_email_v2016_mx-main._CB468300557_.png"
            },

            new Proyecto()
            {
                Titulo = "Samsung Electronics",
                Descripcion = "Desarrollo de software de solicitudes REST para coordinacion de plantas",
                Link = "https://www.samsung.com/mx/",
                ImagenUrl = "https://i0.wp.com/imgs.hipertextual.com/wp-content/uploads/2022/06/Samsung.jpg?fit=1846%2C1000&quality=55&strip=all&ssl=1"
            }
        };
        }
    }
}

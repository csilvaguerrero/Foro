//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Foro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comentarios
    {
        public short idComentario { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fechaPublicacion { get; set; }
        public Nullable<byte> idUsuario { get; set; }
        public Nullable<short> idPregunta { get; set; }
    
        public virtual Preguntas Preguntas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}

using FarhangbookAPI.Areas.AdminArea.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarhangbookAPI.Areas.AdminArea.Models.Base
{
    public interface IEntityObject
    {

    }
    public abstract class FieldPublicInherits : IEntityObject
    {
        public string UserID { get; set; }
        public DateTime CreateDateTime { get; set; }

        [ForeignKey("UserID")]
        public virtual ApplicationUsers Users { get; set; }
    }
}

using FarhangbookAPI.Areas.AdminArea.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace FarhangbookAPI.Areas.AdminArea.Models.Entities
{
    public class ApplicationUsers : IdentityUser<string>, IEntityObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string UserImage { get; set; }
        public string MelliCode { get; set; }
        public string PersonalCode { get; set; }
        public DateTime BirthdayDate { get; set; }
        public DateTime CreateDateTime { get; set; }

        //true == مرد
        //false == زن
        public bool GenderSex { get; set; }

        // UserType 1 : ADMIN
        // UserType 2 : USER
        public byte UserType { get; set; }
    }
}

using SQLite;

namespace Epr3.Models
{
    public class CatalogClientModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public long Uid { get; set; }
        public string RegisterPerson { get; set; } // CPF/CNPJ
        public string Email { get; set; }
        public string Address { get; set; }
        public string Observation { get; set; }
        public string ReferencePoint { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        public CatalogClientModel(long uid, string registerPerson, string email, string address
            , string observation, string referencePoint, string name, string telephone)
        {
            Uid = uid;
            RegisterPerson = registerPerson;
            Email = email;
            Address = address;
            Observation = observation;
            ReferencePoint = referencePoint;
            Name = name;
            Telephone = telephone;
        }
    }
}
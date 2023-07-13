namespace CleanArchMvc.Domain.Entities 
{
    public sealed class Category :EntityBase
    {
        
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(name);
        }
        public ICollection<Product> Products { get; private set; }
        public void update(string name)
        {
            ValidateDomain(name);
            Name = name;
        }
        public void ValidateDomain (string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
            "Invalid name.Name is required");
            DomainExceptionValidation.When(name.Length < 3, 
            "Invalid name, too short, minimum 3 characters is required");
            Name = name;   
        }
    }
}

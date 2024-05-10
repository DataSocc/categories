using MyApp.Domain.Validation;

namespace MyApp.Domain.Entity;
public class Genre
{

    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    private List<Guid> _categories = new List<Guid>();
    public IReadOnlyList<Guid> Categories => _categories.AsReadOnly();

    public Genre(string name, bool isActive = true)
    {
        Name = name;
        IsActive = isActive;
        CreatedAt = DateTime.Now;
        Validate();
    }

    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
    public void Update(string name) => Name = name;
    public void AddCategory(Guid categoryId) => _categories.Add(categoryId);
    public void RemoveCategory(Guid categoryId) => _categories.Remove(categoryId);
    public void RemoveAllCategories() => _categories.Clear();

    private void Validate() => DomainValidation.NotNullOrEmpty(Name, nameof(Name));
}

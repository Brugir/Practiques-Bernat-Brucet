public class Employee : User
{
    public string Category { get; set; }
    public decimal Salary { get; set; }

    public Employee(string name, string lastName, int age, string address, string phone, string category, decimal salary)
        : base(name, lastName, age, address, phone)
    {
        Category = category;
        Salary = salary;
    }

    public override string ToString()
    {
        return base.ToString() + $" - Categoría: {Category} - Salario: {Salary:C}";
    }
}

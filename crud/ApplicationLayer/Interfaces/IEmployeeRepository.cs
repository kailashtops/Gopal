using DomainLayer.Models;

namespace ApplicationLayer.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employes employee);
        IEnumerable<Employes> GetAllEmployees();
    }
}

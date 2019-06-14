using System.Threading.Tasks;

namespace scotus_scan.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}
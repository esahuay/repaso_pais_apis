using repaso_pais_api.Models;

namespace repaso_pais_api.Utils
{
    public interface ITablapaiService
    {
        Task<List<Tablapai>> GetTabs();
        Task<Tablapai> Tablapais(int id);
        Task<Tablapai> PostTablaPais(Tablapai tpais);
        Task<Tablapai> PutTablaPais(int idpais, Tablapai tablapai);
        Task<Tablapai> DeleteTablaPais(int id);
    }
}

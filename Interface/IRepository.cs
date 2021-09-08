using ClientTum.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientTum.Interface
{
    public interface IRepository
    {
        Task<bool> UpdateFolios(List<FolioViajeGeneral> list);
        Task<bool> UpdateConcesionario(List<ConcesionarioRutum> list);
        Task CleanFolios();
        Task CleanConcesionarios();
    }
}

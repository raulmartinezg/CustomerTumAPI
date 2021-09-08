using ClientTum.Data;
using ClientTum.Entities;
using ClientTum.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientTum.Repositories
{
    public class Repository : IRepository
    {
        private readonly SID_AutoCargaV3Context _context;

        public Repository(SID_AutoCargaV3Context context)
        {
            _context = context;
        }


        public async Task<bool> UpdateFolios(List<FolioViajeGeneral> list)
        {
            try
            {
                _context.FolioViajeGenerals.AddRange(list);
                var response = await _context.SaveChangesAsync();
                return response > 0;
            }
            catch (Exception)
            {

                throw new Exception("Error con el servidor Toluca") ;
            }
        }

        public async Task<bool> UpdateConcesionario(List<ConcesionarioRutum> list)
        {
            try
            {
                var table = new List<ConcesionarioRutum>();
                foreach (ConcesionarioRutum e in list)
                {
                    var data = _context.ConcesionarioRuta.FirstOrDefault(x => x.ClaveFolioViaje == e.ClaveFolioViaje && x.NumeroConcCte == e.NumeroConcCte);
                    if (data == null)
                    {
                        table.Add(e);   
                    }
                }
                 _context.ConcesionarioRuta.AddRange(table);
                var response = await _context.SaveChangesAsync();
                return response > 0;
            }
            catch (Exception e)
            {

                throw new Exception("Error con el servidor Toluca" + e);
            }
        }

        public async Task CleanFolios()
        {
            try
            {
                var items = _context.FolioViajeGenerals.AsEnumerable();
                 _context.FolioViajeGenerals.RemoveRange(items);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Error con el servidor Toluca");
            }
        }

        public async Task CleanConcesionarios()
        {
            try
            {
                var items = _context.ConcesionarioRuta.AsEnumerable();
                if(items != null)
                {
                    _context.ConcesionarioRuta.RemoveRange(items);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw new Exception("Error con el servidor Toluca");
            }
        }
    }
}

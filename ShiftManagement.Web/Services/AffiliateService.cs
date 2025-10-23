using ShiftManagement.Web.Data;
using ShiftManagement.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShiftManagement.Web.Services
{
    public class AffiliateService
    {
        private readonly AppDbContext _context;

        public AffiliateService(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los afiliados
        public List<Affiliate> GetAll()
        {
            return _context.Affiliates.ToList();
        }

        // Obtener un afiliado por ID
        public Affiliate GetById(int id)
        {
            return _context.Affiliates.Find(id);
        }

        // Crear un nuevo afiliado
        public void Add(Affiliate affiliate)
        {
            _context.Affiliates.Add(affiliate);
            _context.SaveChanges();
        }

        // Actualizar afiliado
        public void Update(Affiliate affiliate)
        {
            _context.Affiliates.Update(affiliate);
            _context.SaveChanges();
        }

        // Eliminar afiliado
        public void Delete(int id)
        {
            var affiliate = _context.Affiliates.Find(id);
            if (affiliate != null)
            {
                _context.Affiliates.Remove(affiliate);
                _context.SaveChanges();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shift_management.Data;
using shift_management.Models;


namespace shift_management.Services
{
    public class TurnService
    {
        private readonly AppDbContext _context;

        public TurnService(AppDbContext context)
        {
            _context = context;
        }

        // crear un nuevo turno 
        public void AddTurn(Turn turn)
        {
            _context.Turns.Add(turn);
            _context.SaveChanges();
        }

        //listar todos los turnos
        public List<Turn> GetAllTurns()
        {
            return _context.Turns.ToList();
        }


        // Buscar turno por ID
        public Turn? GetTurn(int id)
        {
            return _context.Turns.Find(id);
        }


        // Actualizar un turno 
        public void UpdateTurn(Turn turn)
        {
            _context.Turns.Remove(turn);
            _context.SaveChanges();
        }
        
        // Eliminar un turno 
        public void DeleteTurn(int id)
        {
            var turn = _context.Turns.Find(id);
            if (turn != null)
            {
                _context.Turns.Remove(turn);
                _context.SaveChanges();
            }
        }

    }
}

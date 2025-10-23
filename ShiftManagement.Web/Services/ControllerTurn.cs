using ShiftManagement.Web.Models;
using ShiftManagement.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShiftManagement.Web.Services
{
    public class TurnService
    {
        private readonly AppDbContext _context;

        public TurnService(AppDbContext context)
        {
            _context = context;
        }

        // Crear un nuevo turno 
        public void AddTurn(Turn turn)
        {
            _context.Turns.Add(turn);
            _context.SaveChanges();
        }

        // Listar todos los turnos
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
            _context.Turns.Update(turn);
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
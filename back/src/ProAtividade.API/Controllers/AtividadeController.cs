using Microsoft.AspNetCore.Mvc;
using Models;
using Data;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]

public class AtividadeController : ControllerBase 
{
    private readonly DataContext _context;
    public AtividadeController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Atividade> Get()
    {
        return _context.Atividades;
    }

    [HttpGet("{id}")]
    public Atividade Get(int id)
    {
        return _context.Atividades.FirstOrDefault(ati => ati.Id == id);
    }

    [HttpPut("{id}")]
    public Atividade Put(int id, Atividade atividade)
    {
        if(atividade.Id != id) 
            throw new Exception("Voce esta tentando atualizar uma atividade errada ");

        _context.Update(atividade);     
            
        if (_context.SaveChanges() > 0)
            return _context.Atividades.FirstOrDefault(ativ => ativ.Id == id);
        return new Atividade();
    }

    [HttpPost]
    public Atividade Post(Atividade atividade)
    {
        _context.Atividades.Add(atividade);
        if (_context.SaveChanges() > 0)
            return _context.Atividades.FirstOrDefault(ativ => ativ.Id == atividade.Id);
        else
            throw new Exception("Voce não conseguiu adicionar uma atividade");
    }
    
    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        var atividade = _context.Atividades.FirstOrDefault(ativ => ativ.Id == id);
        if(atividade == null) 
            throw new Exception("Voce esta tentando deletar uma atividade que não existe");
        else
            _context.Remove(atividade);

        return _context.SaveChanges() > 0;
    }
}
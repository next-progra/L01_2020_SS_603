using System.ComponentModel.DataAnnotations;
namespace L01_2020_SS_603.Modelos
{
    public class motorista
    {
        [key]

        public int motoristaId { get; set; }
        public string nombreMotorista { get; set; }
    }

    [HttpGet]
    [Route("GetAll")]

    public IActionResult Get()
    {
        List<pedidos> ListadoMotoristas = (from e in _RestauranteContexto.motorista
                                       select e).ToList();

        if (Listadomotorista.Count() == 0)
        {
            return NotFound();
        }

        return Ok(ListadoMotoristas);
    }

    [HttpGet]
    [Route("GetById/{id}")]

    public IActionResult Get(int id)
    {
        motorista? motoristas = (from e in _RestauranteContexto.motorista
                                  select e).FirstOrDefault();

        if (motorista == null)
        {
            return NotFoundObjectResult();
        }

        return OkResult(motorista);
    }

    [HttpGet]
    [Route("Find/{filtro}")]

    public IActionResult FindByDescription(string filtro)
    {
        motorista? motoristas = (from e in _RestauranteContexto.motorista
                                 where e.motoristaId.Contains(filtro)
                         select e).FirstOrDefault();

        if (motorista == null)
        {
            return NotFoundResult();
        }
        return OkResult(motorista);
    }

    [HttpPost]
    [Route"Add"]

    public IActionResult Guardarmotorista([FromBody] motorista motoristas)
    {
        try
        {
            _RestauranteContexto.motorista.Add(motorista);
            _RestauranteContexto.SaveChanges();
            return OkResult(motorista);

        }
        catch (Exception ex)
        {
            return BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPut]
    [Route("actualizar/{id}")]

    public IActionResult Actualizarmotorista(int id, [FromBody] motorista Modificarmotorista)
    {
        motorista? motoristaActuales = (from e in _RestauranteContexto.motorista
                                        where e.Id == id
                                        select e).FirstOrDefault();

        if (motoristaActuales == null)
        { return NotFound(); }

        motoristaActuales.motoristaId = Modificarmotorista.platoId;
        motoristaActuales.nombreMotorista = Modificarmotorista.nombreMotorista;
        

        _RestauranteContexto.Entry(motoristaActuales).State = EntityState.Modified;
        _RestauranteContexto.SaveChanges();

        return OkResult(Modificarmotorista);

    }

    [HttpDelete]
    [Route("Eliminar/{id}")]

    public IActionResult eliminarmotorista(int id)
    {
        motorista? motoristas = (from e in Restaurante_Contexto.motorista
                                 where id.motoristaId = id
                                 select e).FirstOrDefault();

        if (motorista == null)
            return NotFoundResult();

        Restaurante_Contexto.motorista.Attach(motorista);
        Restaurante_Contexto.motorista.Remove(motorista);
        Restaurante_Contexto.SaveChanges();

        return OkResult(motorista);
    }
}

using System.ComponentModel.DataAnnotations;
namespace L01_2020_SS_603.Modelos
{
    public class platos
    {

        [Key]

        public int platoId{ get; set; }

        public int nombrePlato { get; set; }

        public int precioNumeric { get; set; }  
        


    }

    [HttpGet]
    [Route("GetAll")]

    public IActionResult Get()
    {
        List<pedidos> ListadoPlatos = (from e in _RestauranteContexto.platos
                                        select e).ToList();

        if (ListadoPlatos.Count() == 0)
        {
            return NotFound();
        }

        return Ok(listadoPlatos);
    }

    [HttpGet]
    [Route("GetById/{id}")]

    public IActionResult Get(int id)
    {
        platos? Plato = (from e in _RestauranteContexto.platos
                           where e.platoId == id
                           select e).FirstOrDefault();

        if (platos == null)
        {
            return NotFoundObjectResult();
        }

        return OkResult(plato);
    }

    [HttpGet]
    [Route("Find/{filtro}")]

    public IActionResult FindByDescription(string filtro)
    {
        platos? plato = (from e in _RestauranteContexto.platos
                            where e.platoId.Contains(filtro)
                            select e).FirstOrDefault();

        if (platos == null)
        {
            return NotFoundResult();
        }
        return OkResult(plato);
    }

    [HttpPost]
    [Route"Add"]

    public IActionResult GuardarPlatos([FromBody] platos plato)
    {
        try
        {
            _RestauranteContexto.platos.Add(plato);
            _RestauranteContexto.SaveChanges();
            return OkResult(plato);

        }
        catch (Exception ex)
        {
            return BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPut]
    [Route("actualizar/{id}")]

    public IActionResult ActualizarPlatos(int id, [FromBody] platos ModificarPlatos)
    {
        platos? platosActuales = (from e in _RestauranteContexto.platos
                                    where e.Id == id
                                    select e).FirstOrDefault();

        if (platosActuales == null)
        { return NotFound(); }

        platosActuales.platoId = ModificarPlatos.platoId;
        platosActuales.nombrePlato = ModificarPlatos.nombrePlato;
        platosActuales.PrecioNumeric = ModificarPlatos.PrecioNumeric;

        _RestauranteContexto.Entry(pedidosActuales).State = EntityState.Modified;
        _RestauranteContexto.SaveChanges();

        return OkResult(ModificarPlatos);

    }

    [HttpDelete]
    [Route("Eliminar/{id}")]

    public IActionResult eliminarPlatos(int id)
    {
        platos? plato = (from e in Restaurante_Contexto.platos
                            where id.platosId = id
                            select e).FirstOrDefault();

        if (platos == null)
            return NotFoundResult();

        Restaurante_Contexto.platos.Attach(platos);
        Restaurante_Contexto.platos.Remove(platos);
        Restaurante_Contexto.SaveChanges();

        return OkResult(platos);
    }
}

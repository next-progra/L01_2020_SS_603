using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Server.IIS;

namespace L01_2020_SS_603.Modelos
{
    public class pedidos
    {
        [Key]
        public int pedidoId { get; set; }

        public int motoristaId { get; set; }

        public int clienteIde { get; set; }

        public int PlatoId { get; set; }

        public int Cantidad { get; set; }

        public string PrecioNumeric { get; set; }



    }

    [HttpGet]
    [Route("GetAll")]

    public IActionResult Get()
    {
        List<pedidos> ListadoPedidos = (from e in _RestauranteContexto.pedidos
                                        select e).ToList();

        if (ListadoPedidos.Count() == 0)
        {
            return NotFound();
        }

        return Ok(listadoPedidos);
    }

    [HttpGet]
    [Route("GetById/{id}")]

    public IActionResult Get(int id)
    {
        pedidos? pedido = (from e in _RestauranteContexto.pedidos
                           where e.pedidoId == id
                           select e).FirstOrDefault();

        if (pedido == null)
        {
            return NotFoundObjectResult();
        }

        return OkResult(pedido);
    }

    [HttpGet]
    [Route("Find/{filtro}")]

    public IActionResult FindByDescription(string filtro)
    {
        pedidos? pedidos = (from e in _RestauranteContexto.pedidos
                            where e.pedidoId.Contains(filtro)
                            select e).FirstOrDefault();

        if (pedidos == null)
        {
            return NotFoundResult();
        }
        return OkResult(pedido);
    }

    [HttpPost]
    [Route"Add"]

    public IActionResult GuardarPedidos([FromBody] pedidos pedido)
    {
        try
        {
            _RestauranteContexto.pedidos.Add(pedido);
            _RestauranteContexto.SaveChanges();
            return OkResult(pedido);

        }
        catch (Exception ex)
        {
            return BadRequestObjectResult(ex.Message);
        }
    }

    [HttpPut]
    [Route("actualizar/{id}")]

    public IActionResult ActualizarPedidos(int id, [FromBody] pedidos ModificarPedidos)
    {
        pedidos? pedidosActuales = (from e in _RestauranteContexto.pedidos
                                    where e.Id == id
                                    select e).FirstOrDefault();

        if (pedidoActual == null)
        { return NotFound(); }

        pedidosActuales.pedidoId = ModificarPedidos.pedidoId;
        pedidosActuales.motoristaId = ModificarPedidos.motoristaId;
        pedidosActuales.clienteIde = ModificarPedidos.clienteIde;
        pedidosActuales.PlatoId = ModificarPedidos.pedidoId;
        pedidosActuales.Cantidad = ModificarPedidos.Cantidad;
        pedidosActuales.PrecioNumeric = ModificarPedidos.PrecioNumeric;

        _RestauranteContexto.Entry(pedidosActuales).State = EntityState.Modified;
        _RestauranteContexto.SaveChanges();

        return OkResult(ModificarPedidos);

    }

    [HttpDelete]
    [Route("Eliminar/{id}")]

    public IActionResult eliminarPedidos (int id) 
    {
        pedidos? pedidos = (from e in Restaurante_Contexto.pedidos
                            where id.pedidosId = id
                            select e).FirstOrDefault();

        if (pedidos == null)
            return NotFoundResult();

        Restaurante_Contexto.pedidos.Attach(pedidos);
        Restaurante_Contexto.pedidos.Remove(pedidos);
        Restaurante_Contexto.SaveChanges();

        return OkResult(pedidos);
    }
    
    


}


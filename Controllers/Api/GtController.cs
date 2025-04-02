using Microsoft.AspNetCore.Components.forms;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gt")]
public class GtController : Controller {
    [HttpGet("casas-ventas-metros-terreno")]
    public IActionResult CasasEnVentaConMasDeXMetrosTerreno(){
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Obtener todas las casas en venta con mas de 500 metros de construccion
        var filtroCasas = Builders<Inmuebles>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroVenta = Builders<Inmuebles>.Filter.Eq(x => x.Operacion, "Venta");
        var filtroMetros = Builders<Inmuebles>.Filter.Eq(x => x.MetrosConstrccion, 500);

        var filtroCompuesto = Builders<Inmuebles>.Filter.And(filtroCasas, filtroVenta, filtroMetros);
        var list = collection.Find(filtroCompuesto).ToList();
        return Ok();
    }
}
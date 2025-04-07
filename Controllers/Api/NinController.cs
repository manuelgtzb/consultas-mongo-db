using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/nin")]
public class NinController : Controller {
    private readonly IMongoCollection<Inmueble> _collection;

    public NinController() {
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        _collection = db.GetCollection<Inmueble>("RentasVentas");
    }

    [HttpGet("no-false")]
    public IActionResult NoFalse() {
        var filtro = Builders<Inmueble>.Filter.Nin(x => x.TienePatio, new[] { false });
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("no-terreno")]
    public IActionResult NoTerreno() {
        var filtro = Builders<Inmueble>.Filter.Nin(x => x.Tipo, new[] { "terreno" });
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("no-venta")]
    public IActionResult NoVenta() {
        var filtro = Builders<Inmueble>.Filter.Nin(x => x.Operacion, new[] { "venta" });
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("casa-sin-banios")]
    public IActionResult CasaSinBanios() {
        var filtro = Builders<Inmueble>.Filter.And(
            Builders<Inmueble>.Filter.Eq(x => x.Tipo, "casa"),
            Builders<Inmueble>.Filter.Nin(x => x.Banios, new[] { 1, 2, 3, 4, 5 })
        );
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("terreno-no-mayor-600")]
    public IActionResult TerrenoNoMayor600() {
        var filtro = Builders<Inmueble>.Filter.Lte(x => x.MetrosTerreno, 600);
        return Ok(_collection.Find(filtro).ToList());
    }
}

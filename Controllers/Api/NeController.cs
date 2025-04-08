using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/ne")]
public class NeController : Controller {
    private readonly IMongoCollection<Inmueble> _collection;

    public NeController() {
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        _collection = db.GetCollection<Inmueble>("RentasVentas");
    }

    [HttpGet("no-es-true")]
    public IActionResult NoEsTrue() {
        var filtro = Builders<Inmueble>.Filter.Ne(x => x.TienePatio, true);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("no-es-casa")]
    public IActionResult NoEsCasa() {
        var filtro = Builders<Inmueble>.Filter.Ne(x => x.Tipo, "casa");
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("no-es-venta")]
    public IActionResult NoEsVenta() {
        var filtro = Builders<Inmueble>.Filter.Ne(x => x.Operacion, "venta");
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("casa-no-dos-banios")]
    public IActionResult CasaNoDosBanios() {
        var filtro = Builders<Inmueble>.Filter.And(
            Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa"),
            Builders<Inmueble>.Filter.Ne(x => x.Banios, 2)
        );
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("terreno-no-mayor-900")]
    public IActionResult TerrenoNoMayor900() {
        var filtro = Builders<Inmueble>.Filter.Lte(x => x.MetrosTerreno, 900);
        return Ok(_collection.Find(filtro).ToList());
    }
}

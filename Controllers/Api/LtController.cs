using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/lt")]
public class LtController : Controller {
    private readonly IMongoCollection<Inmueble> _collection;

    public LtController() {
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        _collection = db.GetCollection<Inmueble>("RentasVentas");
    }

    [HttpGet("banios-menos-dos")]
    public IActionResult BaniosMenosDos() {
        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Banios, 2);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("costo-menos-dos-millones")]
    public IActionResult CostoMenosDosMillones() {
        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Costo, 2000000);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("terreno-menos-900")]
    public IActionResult TerrenoMenos900() {
        var filtro = Builders<Inmueble>.Filter.Lt(x => x.MetrosTerreno, 900);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("construccion-menos-600")]
    public IActionResult ConstruccionMenos600() {
        var filtro = Builders<Inmueble>.Filter.Lt(x => x.MetrosConstruccion, 600);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("pisos-menos-3")]
    public IActionResult PisosMenos3() {
        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Pisos, 3);
        return Ok(_collection.Find(filtro).ToList());
    }
}

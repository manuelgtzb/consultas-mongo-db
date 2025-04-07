using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/lte")]
public class LteController : Controller {
    private readonly IMongoCollection<Inmueble> _collection;

    public LteController() {
        var client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        _collection = db.GetCollection<Inmueble>("RentasVentas");
    }

    [HttpGet("banios-tres-o-menos")]
    public IActionResult BaniosTresOMenos() {
        var filtro = Builders<Inmueble>.Filter.Lte(x => x.Banios, 3);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("costo-hasta-dos-millones")]
    public IActionResult CostoHastaDosMillones() {
        var filtro = Builders<Inmueble>.Filter.Lte(x => x.Costo, 2000000);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("terreno-hasta-900")]
    public IActionResult TerrenoHasta900() {
        var filtro = Builders<Inmueble>.Filter.Lte(x => x.MetrosTerreno, 900);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("construccion-hasta-600")]
    public IActionResult ConstruccionHasta600() {
        var filtro = Builders<Inmueble>.Filter.Lte(x => x.MetrosConstruccion, 600);
        return Ok(_collection.Find(filtro).ToList());
    }

    [HttpGet("pisos-tres-o-menos")]
    public IActionResult PisosTresOMenos() {
        var filtro = Builders<Inmueble>.Filter.Lte(x => x.Pisos, 3);
        return Ok(_collection.Find(filtro).ToList());
    }
}

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gte")]
public class GteController : Controller {
    [HttpGet("banios-mayores-o-iguales-a-dos")]
    public IActionResult BaniosGteDos() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Gte(x => x.Banios, 2);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("pisos-mayores-o-iguales-a-dos")]
    public IActionResult PisosGteDos() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Gte(x => x.Pisos, 2);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("precio-millon-o-mas")]
    public IActionResult PrecioMillonOMas() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Gte(x => x.Costo, 1000000);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("renta-mayor-o-igual-a-7000")]
    public IActionResult RentaMayorOIgual7000() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtroOperacion = Builders<Inmueble>.Filter.Eq(x => x.Operacion, "Renta");
        var filtroCosto = Builders<Inmueble>.Filter.Gte(x => x.Costo, 7000);
        var filtro = Builders<Inmueble>.Filter.And(filtroOperacion, filtroCosto);

        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("construccion-mayor-o-igual-150")]
    public IActionResult ConstruccionGte150() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Gte(x => x.MetrosConstruccion, 150);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }
}

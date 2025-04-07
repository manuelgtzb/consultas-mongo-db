using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gt")]
public class GtController : Controller {
    [HttpGet("construccion-mayor-500")]
    public IActionResult ConstruccionMayor500() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Gt(x => x.MetrosConstruccion, 500);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }
    
    [HttpGet("terreno-mayor-700")]
    public IActionResult TerrenoMayor700() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Gt(x => x.MetrosTerreno, 700);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }


    [HttpGet("mas-dos-pisos")]
    public IActionResult MasDeDosPisos() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Gt(x => x.Pisos, 2);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("rentas-mayores-6000")]
    public IActionResult RentasMayoresA6000() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtroOperacion = Builders<Inmueble>.Filter.Eq(x => x.Operacion, "Renta");
        var filtroRenta = Builders<Inmueble>.Filter.Gt(x => x.Costo, 6000);
        var filtro = Builders<Inmueble>.Filter.And(filtroOperacion, filtroRenta);

        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }

    [HttpGet("baños-mas-dos")]
    public IActionResult MasDeDosBanos() {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtro = Builders<Inmueble>.Filter.Gt(x => x.Banios, 2);
        var list = collection.Find(filtro).ToList();
        return Ok(list);
    }
}

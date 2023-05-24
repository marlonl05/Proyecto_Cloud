using LibreriaMB.UAPI;
using LibreriaMB.Modelos;


/*
var uapi = new Crud<Pais>();
var ec = uapi.Select_ById("https://localhost:7264/api/Paises", "1");
ec.Capital = "QUITO DM";
ec.Idioma = "ESPAÑOL";
ec.Moneda = "DOLAR USD";
//uapi.Update("https://localhost:7264/api/Paises", "1", ec);
var paises = uapi.Select("https://localhost:7264/api/Paises");
/*
var co = new Pais
{
    Nombre = "COLOMBIA",
    Capital = "BOGOTA",
    CodigoISO = "CO",
    Idioma = "ES",
    Moneda = "PCO",
    Poblacion = 30000000,
    CodigoPais = 0
};
var nuevoPais = uapi.Insert("https://localhost:7264/api/Paises", co);
uapi.Delete("https://localhost:7264/api/Paises", "2");
paises = uapi.Select("https://localhost:7264/api/Paises");
*/

var libro = new Crud<Libro>();

var nuevolibro = libro.Insert("https://localhost:7264/api/cantones", new Libro
{
    Titulo = "XYZ",
    Tipo ="Misterio" ,
    Autor = "ABC",
    NumeroPag=450,
    Id = 0
});


Console.WriteLine("Hello, World!");

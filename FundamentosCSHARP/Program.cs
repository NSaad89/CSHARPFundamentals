using FundamentosCSHARP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FundamentosCSHARP
{
    class Program
    {
        static async Task Main(string[] args)
        {

            //ELIMINAR UN ELEMENTO DE UN WEBSERVICE

            string url = "https://jsonplaceholder.typicode.com/posts/99";

            var client = new HttpClient();
            
            var httpResponse = await client.DeleteAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

            }

            /*
             * ACTUALIZAR UN ELEMENTO DE UN WEB SERVICE PASÁNDOLE UN OBJETO DEL TIPO POST SERIALIZADO COMO UN JSON
             * 
            string url = "https://jsonplaceholder.typicode.com/posts/99";

            var client = new HttpClient();

            Post post = new Post()
            {
                userId = 50,
                body = "Soy un body",
                title = "Soy un título"

            };

            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PutAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                var postResult = JsonSerializer.Deserialize<Post>(result);
                Console.WriteLine(postResult);

            }
            */
            /*
             * TOMAR UN OBJETO DEL TIPO POST Y POSTEARLO A UN WEB SERVICE SERIALIZADO COMO UN JSON
             * 
            string url = "https://jsonplaceholder.typicode.com/posts";
          
            var client = new HttpClient();

            Post post = new Post()
            {
                userId = 50,
                body = "Soy un body",
                title = "Soy un título"

            };

            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync(url,content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                var postResult = JsonSerializer.Deserialize<Post>(result);
                Console.WriteLine(postResult);


            }
            */
            /*
             * TOMAR UN JSON DESDE UN WEB SERVICE POR MÉTODO GET Y SERIALIZARLO A UNA LISTA DE OBJETOS DE TIPO POST
             * 
            string url = "https://jsonplaceholder.typicode.com/posts";

            HttpClient client = new HttpClient();

            var httpResponse = await client.GetAsync(url);

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();

                List<Post> posts = JsonSerializer.Deserialize<List<Post>>(content);
                Console.WriteLine(posts);

            }
            */

            /*
             *SERIALIZAR UNA INSTANCIA DE CERVEZA A UN JSON 
             *
            Cerveza cerveza = new Cerveza(10, "Cerveza");
            string miJson=JsonSerializer.Serialize(cerveza);
            File.WriteAllText("objeto.txt", miJson); //permite crear un archivo a partir de un Json
            */
            /*
             * DESERIALIZAR UN JSON A UN OBJETO DEL TIPO CERVEZA
             * 
            string miJson = File.ReadAllText("objeto.txt");
            Cerveza cerveza = JsonSerializer.Deserialize<Cerveza>(miJson);
            Console.WriteLine(cerveza.Nombre);
            Console.WriteLine(cerveza.Cantidad);
            */
            //CervezaBD cervezaBD = new CervezaBD();

            //INSERTAR UNA NUEVA CERVEZA EN LA DB
            /*
            {
                Cerveza cerveza = new Cerveza(15, "Pale Ale");
                cerveza.Marca = "Minerva";
                cerveza.Alcohol = 6;
                cervezaBD.Add(cerveza);
            }
            */

            /*
             * EDITAR UNA CERVEZA DE LA DB
            {
                Cerveza cerveza = new Cerveza(15, "Pale Ale");
                cerveza.Marca = "Minerva";
                cerveza.Alcohol = 5;
                cervezaBD.Edit(cerveza,4);
            }
            */
            //ELIMINAR UNA CERVEZA DE LA DB
            //
            //cervezaBD.Delete(4);

            //OBTENER TODAS LAS CERVEZAS DE LA DB
            /*
            var cervezas = cervezaBD.Get();

            foreach (var cerveza in cervezas)
            {
                Console.WriteLine(cerveza.Nombre);
            }
            */
            /*
             * IMPRIMIR RECOMENDACIÓN PARA UNA BEBIDA ALCOHÓLICA DEL TIPO CERVEZA
             * 
            var bebidaAlcoholica = new Cerveza(500);

            MostrarRecomendacion(bebidaAlcoholica);

            //AGREGAR UNA CERVEZA A UNA LISTA DE OBJETOS DEL TIPO CERVEZA

            List<Cerveza> cervezas = new List<Cerveza>() { new Cerveza(10, "Cerveza Premium") };

            Cerveza porter = new Cerveza(500, "Cerveza de Trigo");
            cervezas.Add(porter);

            foreach (var cerveza in cervezas)
            {
                Console.WriteLine("cerveza " + cerveza.Nombre);
            }
            */
        }
        /*
         * MÉTODO QUE TOMA UNA INTERFAZ DEL TIPO BEBIDA ALCOHÓLICA Y MUESTRA SU MAXIMO RECOMENDADO
         * 
        static void MostrarRecomendacion(IBebidaAlcoholica bebida)
        {
            bebida.MaxRecomendado();
        }
        */
    }
}

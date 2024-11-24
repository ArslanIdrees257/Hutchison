using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using DogsAndOriginAPI.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogsAndOriginAPI.Controllers
{
    [Route("api/[controller]")]
    public class DogsController : Controller
    {
        private readonly string _filePath;
        public DogsController(IWebHostEnvironment env)
        {
            _filePath = Path.Combine(env.ContentRootPath, "Model", "dogs.json");
        }
        // Load data from the JSON file
        private Dictionary<string, List<string>> LoadData()
        {
            if (!System.IO.File.Exists(_filePath))
            {
                // Create an empty file if it doesn't exist
                var emptyData = new Dictionary<string, List<string>>();
                SaveData(emptyData);
            }

            var json = System.IO.File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json)
                   ?? new Dictionary<string, List<string>>();
        }

        // Save data to the JSON file
        private void SaveData(Dictionary<string, List<string>> data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            System.IO.File.WriteAllText(_filePath, json);
        }

        [HttpGet]
        public IActionResult GetAllDogs()
        {
            var data = LoadData();
            return Ok(data);
        }


        [HttpPost]
        public IActionResult AddDog(string dog,[FromBody]List<string> origins)
        {
            var data = LoadData();
            if (data.ContainsKey(dog))
             {
                    // Add only unique origins to the existing breed
                    var existingOrigins = data[dog];
                    foreach (var origin in origins)
                    {
                        if (!existingOrigins.Contains(origin))
                        {
                            existingOrigins.Add(origin);
                        }
                    }
                }
                else
                {
                    data.Add(dog, origins);
                }

            SaveData(data);
            return Ok(data);
        }

        [HttpPut("{origin}")]
        public IActionResult UpdateDog(string dog, [FromBody] List<string> origin)
        {
            var data = LoadData();

            if (!data.ContainsKey(dog))
            {
                return NotFound($"'{dog}' not found.");
            }

            data[dog] = origin; // Replace the origin list
            SaveData(data);
            return Ok(data);
        }

        [HttpDelete("{dog}")]
        public IActionResult DeleteDog(string dog)
        {
            var data = LoadData();

            if (!data.ContainsKey(dog))
            {
                return NotFound($"'{dog}' not found.");
            }

            data.Remove(dog);
            SaveData(data);
            return Ok(data);
            
        }

    }
}


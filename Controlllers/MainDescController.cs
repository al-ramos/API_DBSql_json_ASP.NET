using Microsoft.AspNetCore.Mvc;
using GrowEasy.Models;
using GrowEasy.Repository.Interfaces;
using System.Collections;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Collections.Generic;


namespace GrowEasy.Controlllers
{

    [Route("/api/[controller]")]
    public class MainDescController : ControllerBase
    {
        private readonly IMainDesc _mainDesc;        
        private readonly IVivencia _vivencia;
        private readonly IActivitie _action;

        public MainDescController  (IMainDesc mainDesc, IVivencia vivencia, IActivitie activitie) {
            _mainDesc = mainDesc;
            _vivencia = vivencia;            
            _action = activitie;
		}

		[HttpGet]
		public IActionResult GetData()
			{

			IEnumerable<MainDesc> MainList =  _mainDesc.GetData( includeProperties: "Vivencias,Vivencias.Activities");			
			return Ok(MainList);

			}

        [HttpGet("{id}")]
        public IActionResult GetData(int id)
            {

                var desc = _mainDesc.GetData(id);

                if (desc == null) return NotFound();

                return Ok(desc);

            }

		[HttpPost]
		public IActionResult NewData([FromBody] MainDesc mainDesc)
			{

			_mainDesc.NewData(mainDesc);

			return Ok();

			}

		[HttpPut]
        public IActionResult PutData([FromBody] MainDesc mainDesc)
            {

            var desc = _mainDesc.GetData(mainDesc.Id);

            if (desc == null) return NotFound();

            _mainDesc.PutData(mainDesc);
            return Ok();

        
         }

		[HttpDelete("{id}")]
		public IActionResult DelData (int id)  {

             var desc = _mainDesc.GetData(id); 

             if (desc == null) return NotFound();
                
             _mainDesc.DelData(desc);
             return Ok();
             

            }            
    }}
   

       
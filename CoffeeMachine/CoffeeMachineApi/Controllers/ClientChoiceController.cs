using CoffeeApiMachine.DTO;
using CoffeeApiMachine.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApiMachine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientChoiceController : ControllerBase
    {
        private readonly IClientChoiceService clientSelectionService;

        public ClientChoiceController(IClientChoiceService clientSelectionService)
        {
            this.clientSelectionService = clientSelectionService;
        }

        
        [HttpGet("GetClientChoice/{badgeNumber}")]
        public IActionResult GetClientChoice(string badgeNumber)
        {
            var clientSelection = clientSelectionService.GetClientChoice(badgeNumber);

            if (clientSelection == null)
            {
                return NotFound();
            }

            return Ok(clientSelection);
        }

        [HttpPost]
        public IActionResult AddSelection(ClientChoiceDTO clientSelectionDTO)
        {
            clientSelectionService.AddClientChoice(clientSelectionDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateSelection(ClientChoiceDTO clientSelectionDTO)
        {
            clientSelectionService.UpdateClientChoice(clientSelectionDTO);
            return Ok();
        }
    }
}

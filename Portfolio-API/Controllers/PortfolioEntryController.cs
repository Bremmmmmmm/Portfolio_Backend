using Interface.Interfaces.Logic;
using Interface.RequestBodies;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio_API.Controllers;

[ApiController]
public class PortfolioEntryController : Controller
{
    private readonly ILogicFactoryBuilder _logicFactoryBuilder;
    
    public PortfolioEntryController(ILogicFactoryBuilder logicFactoryBuilder)
    {
        _logicFactoryBuilder = logicFactoryBuilder;
    }
    
    [HttpPost]
    [Route("CreatePortfolioEntry")]
    public async Task<IActionResult> CreatePortfolioEntry([FromBody] PortfolioEntryBody body)
    {
        if(!CreatePortfolioEntryRequestIsValid(body).Item1)
        {
            return BadRequest(CreatePortfolioEntryRequestIsValid(body).Item2);
        }

        try
        {
            await _logicFactoryBuilder.BuildHandlerFactory().BuildPortfolioEntryHandler().CreatePortfolioEntry(body);
            return Ok();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return StatusCode(500, $"Could not create portfolio entry:\r\n{e.Message}");
        }
    }
    
    [HttpGet]
    [Route("GetPortfolioEntryById")]
    public async Task<IActionResult> GetPortfolioEntryById(int id)
    {
        try
        {
            var portfolioEntry = await _logicFactoryBuilder.BuildHandlerFactory().BuildPortfolioEntryHandler().GetPortfolioEntryById(id);
            return Ok(portfolioEntry);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return StatusCode(500, $"Could not get portfolio entry:\r\n{e.Message}");
        }
    }
    
    [HttpGet]
    [Route("GetAllPortfolioEntries")]
    public async Task<IActionResult> GetAllPortfolioEntries()
    {
        try
        {
            var portfolioEntries = await _logicFactoryBuilder.BuildHandlerFactory().BuildPortfolioEntryHandler().GetAllPortfolioEntries();
            return Ok(portfolioEntries);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return StatusCode(500, $"Could not get portfolio entries:\r\n{e.Message}");
        }
    }
    
    [HttpPut]
    [Route("UpdatePortfolioEntry")]
    public async Task<IActionResult> UpdatePortfolioEntry([FromBody] PortfolioEntryBody body)
    {
        if(!CreatePortfolioEntryRequestIsValid(body).Item1)
        {
            return BadRequest(CreatePortfolioEntryRequestIsValid(body).Item2);
        }

        try
        {
            await _logicFactoryBuilder.BuildHandlerFactory().BuildPortfolioEntryHandler().UpdatePortfolioEntry(body);
            return Ok();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return StatusCode(500, $"Could not update portfolio entry:\r\n{e.Message}");
        }
    }
    
    [HttpDelete]
    [Route("DeletePortfolioEntry")]
    public async Task<IActionResult> DeletePortfolioEntry(int id)
    {
        try
        {
            await _logicFactoryBuilder.BuildHandlerFactory().BuildPortfolioEntryHandler().DeletePortfolioEntry(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return StatusCode(500, $"Could not delete portfolio entry:\r\n{e.Message}");
        }
    }
    
    private (bool, string) CreatePortfolioEntryRequestIsValid(PortfolioEntryBody body)
    {
        if (body.Id <= 0)
        {
            return (false, "Invalid Id");
        }
        if (string.IsNullOrWhiteSpace(body.Title))
        {
            return (false, "Title is required");
        }
        if (string.IsNullOrWhiteSpace(body.Description))
        {
            return (false, "Description is required");
        }
        if (string.IsNullOrWhiteSpace(body.MediaUrl))
        {
            return (false, "MediaUrl is required");
        }
        return (true, string.Empty);
    }
}
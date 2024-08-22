using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using microtech_task_final.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//any class that i want to convert to API is defined with [ApiController]
[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AccountsController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet("top level accounts")]
    public async Task<IActionResult> GetTopLevelBalances()
    {
        var topLevelAccounts = await _context.Accounts
            .Where(a => a.AccParent == null)
            .Select(a => new
            {
                a.AccNumber
            })
            .ToListAsync();

        var result = new List<object>();

        foreach (var account in topLevelAccounts)
        {
            var totalBalance = await GetBalance(account.AccNumber, null);
            result.Add(new
            {
                TopLevelAccount = account.AccNumber,
                TotalBalance = totalBalance
            });
        }

        return Ok(result);
    }

    private async Task<decimal> GetBalance(string parentID, decimal? balance)
    {
        // Check if the balance is provided and non-zero
        if (balance != null && balance != 0)
            return balance.Value;

        // Get children accounts
        var children = await _context.Accounts
            .Where(a => a.AccParent == parentID)
            .Select(a => new
            {
                a.AccNumber,
                a.Balance
            })
            .ToListAsync();

        // Sum the balances of the children
        decimal sum = 0;
        foreach (var child in children)
        {
            sum += await GetBalance(child.AccNumber, child.Balance);
        }
        return sum;
    }

    /********************************************************************************/

    //APi(Action)"HttpGet:get data from db"
    [HttpGet("get total balance for specific account")]
    public async Task<IActionResult> GetAccountDetails(string accountID)
    {
        var accountDetails = await GetDetailedBalances(accountID);

        return Ok(accountDetails);
    }


    private async Task<List<object>> GetDetailedBalances(string parentID)
    {
        var children = await _context.Accounts
            .Where(a => a.AccParent == parentID)
            .Select(a => new
            {
                a.AccNumber,
                a.Balance
            })
            .ToListAsync();

        var result = new List<object>();

        foreach (var child in children)
        {
            if (child.Balance != null && child.Balance != 0)
            {
                result.Add(new
                {
                    AccountPath = parentID + "-" + child.AccNumber,
                    Balance = child.Balance.Value
                });
            }
            else
            {
                var childDetails = await GetDetailedBalances(child.AccNumber);
                foreach (var detail in childDetails)
                {
                    result.Add(new
                    {
                        AccountPath = parentID + "-" + ((dynamic)detail).AccountPath,
                        Balance = ((dynamic)detail).Balance
                    });
                }
            }
        }

        return result;
    }


}

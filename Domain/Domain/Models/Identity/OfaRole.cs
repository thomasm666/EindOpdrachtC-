using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Identity framework
/// </summary>
namespace OrderFoodApp.Domain.Models.Identity
{
    public class OfaRole : IdentityRole<int, UserRole>
    {
    }
}

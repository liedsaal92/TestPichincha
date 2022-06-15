using Microsoft.AspNetCore.Mvc;
using PichinchaTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PichinchaTest.Business
{
    public class ClientesBs
    {
        
        internal static Task<ActionResult<IEnumerable<cliente>>> ConsultarClientes(Task<List<cliente>> task)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Model;

namespace MVC_App.Controllers
{
    public class MarksController : BaseController<MarksController,MarksModel>
    {
        public MarksController(IBaseRepo<MarksModel> repo) : base(repo)
        {
            
        }
    }
}

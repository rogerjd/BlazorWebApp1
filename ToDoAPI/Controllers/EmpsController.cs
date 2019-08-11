using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ToDoAPI.DB;
using ToDoAPI.Models;
using ToDoAPI.Models.Emp;


//https://stackoverflow.com/questions/38865498/how-to-convert-datatable-to-generic-list-in-c-sharp

//https://itnext.io/adding-features-to-a-simple-blazor-mvvm-client-with-composition-f31bfb01e20a

//https://visualstudiomagazine.com/blogs/tool-tracker/2018/05/converting-datatables-to-json.aspx

//Web API handles serialization for you, so you do not need to call JsonConvert.SerializeObject.That is why you are getting an escaped string as your output value.Just pass the datatable directly to CreateResponse.Web API will turn it into JSON or XML for you depending on what was sent in the Accept header of the request. (It uses Json.Net under the covers.)
//return Request.CreateResponse(HttpStatusCode.OK, dt);

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpsController : ControllerBase
    {
        //private readonly TodoContext _context;
        private DataTable tbl;
        private AppSettings appSettings { get; set; }

        public EmpsController(IOptions<AppSettings> settings)
        {
            appSettings = settings.Value;

            tbl = new DataTable();
            tbl.Columns.Add("num");
            tbl.Columns.Add("name");

            tbl.Rows.Add(1, "abc");
            tbl.Rows.Add(2, "def");
            tbl.Rows.Add(3, "ghi");
        }

        //[EnableCors]
        [HttpGet]
        public ActionResult<string> GetEmp()
        {
//            return "test abc";

            DataTable dt = new PR_Mgr().GetEmp();
            string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return json;
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetEmpById(int id)
        {
            PR_Mgr pm = new PR_Mgr();
            DataTable dt = pm.GetEmpByID(id);
            string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return json;
        }


        //public ActionResult<IEnumerable<Emp>> GetEmp()
        //{
        //    DataTable dt = new PR_Mgr().GetEmp();  
        //    List<Emp> l = DBUtil.BindList<Emp>(dt);
        //    return l;
        //    //ok w/string: return "emp wip";
        //}


        //[HttpGet]
        //public async DataTable GetTodoItems()
        //{
        //    return tbl;
        //}

        // PUT api/emps/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            PR_Mgr mgr = new PR_Mgr();
            Emp emp = JsonConvert.DeserializeObject<Emp>(value);
            mgr.EmpUpdate(emp);
        }
    }
}

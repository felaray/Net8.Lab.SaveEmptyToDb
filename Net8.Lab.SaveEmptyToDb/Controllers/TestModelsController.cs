using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net8.Lab.SaveEmptyToDb;
using Net8.Lab.SaveEmptyToDb.Data;

namespace Net8.Lab.SaveEmptyToDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestModelsController : ControllerBase
    {
        private readonly Net8LabSaveEmptyToDbContext _context;

        public TestModelsController(Net8LabSaveEmptyToDbContext context)
        {
            _context = context;
        }

        // GET: api/TestModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestModel>>> GetTestModel()
        {
            return await _context.TestModel.ToListAsync();
        }

        // GET: api/TestModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestModel>> GetTestModel(int id)
        {
            var testModel = await _context.TestModel.FindAsync(id);

            if (testModel == null)
            {
                return NotFound();
            }

            return testModel;
        }

        // POST: api/TestModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestModel>> PostTestModel(TestModel testModel)
        {
            if(testModel.MyName2 == null)
            {
                testModel.MyName2 = "";
            }
            _context.TestModel.Add(testModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestModel", new { id = testModel.Id }, testModel);
        }


    }
}

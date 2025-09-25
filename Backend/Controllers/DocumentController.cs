using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController:ControllerBase
    {
        private readonly IDocuments documents;
        public DocumentController(IDocuments documents)
        {
            this.documents = documents;
        }

        [HttpGet]
        [Route("Get-All-Docs")]
        public IActionResult GetAllDocs()
        {
            if ((documents.GetAllDocuments()) == null)
            {
                return NotFound();
            }
            return Ok(documents.GetAllDocuments());
        }

        [HttpPost]
        [Route("Add-Docs")]
        public IActionResult AddDoc(Documents docRecord)
        {
            if (docRecord == null)
            {
                return BadRequest("The doc record your provided is NULL");
            }
            else
            {
                documents.AddDocumentRecord(docRecord);
                return Ok("Successfully Doc record");
            }
        }

        [HttpPut]
        [Route("Editing-Docs")]
        public IActionResult UpdateDoc(int Id, Documents docRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (docRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                documents.UpdateDocumentRecord(Id, docRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-A-Doc-Record")]
        public IActionResult DeleteDoc(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                documents.DeleteDocumentRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}

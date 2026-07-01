using Backend.DatabasContext;
using Backend.DTOs;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController:ControllerBase
    {
        private readonly IDriver driver;
        private readonly IVehicle vehicle;
        private readonly ApplicationDatabaseContext _context;
        private readonly ILogger<Vehicle> _logger;
        public DriverController(
            IDriver driver,
            IVehicle vehicle, 
            ApplicationDatabaseContext db,
            ILogger<Vehicle> _logger)
        {
            this.driver = driver;
            this.vehicle = vehicle;
            this._context = db;
            this._logger = _logger;
        }

        [HttpGet]
        [Route("Get-All-Drivers")]
        public IActionResult GetAllVehicles()
        {
            if ((driver.GetAllDrivers() == null))
            {
                return NotFound();
            }
            return Ok(driver.GetAllDrivers());
        }

        [HttpGet]
        [Route("Get-All-Orders-Claimed-By-Driver-ID")]
        public IActionResult AllOrdersPlacedByDriverID(int id)
        {
            var result = driver.GetAllOrdersClaimedByDriverID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("get-driver-byUserId")]
        public IActionResult GetDriverRecordByUserId(int UserId)
        {
            var result = driver.GetDriverByUserId(UserId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Driver")]
        public IActionResult AddDriver(Driver driverRecord)
        {
            if (driverRecord == null)
            {
                return BadRequest("The driver record your provided is NULL");
            }
            else
            {
                driver.CreateDriverRecord(driverRecord);
                return Ok("Successfully Driver record");
            }
        }

        [HttpPut]
        [Route("Editing-Driver")]
        public IActionResult UpdateDriver(int Id, Driver driverRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (driverRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                driver.UpdateDriverRecord(Id, driverRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpGet]
        [Route("Get-Single-Driver-Details")]
        public IActionResult GetSingleDriverDetails(int Id)
        {
            var driverRecord = driver.GetDriverDetails(Id);
            if(driverRecord == null)
            {
                return BadRequest("The Id you provided gives the output of a null value");
            }
            else
            {
                return Ok(driverRecord);
            }
        }
        [HttpDelete]
        [Route("Delete-A-Driver-Record")]
        public IActionResult DeleteDriver(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                driver.DeleteDriverRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
        [HttpPost]
        [Route("Collection-Post")]
        public IActionResult PostCollectionOrders(IEnumerable<OrderPlacement> orders, int DriverId)
        {
            if(orders == null || DriverId<0)
            {
                return BadRequest("Collection is null");
            }
            else
            {
                driver.AddCollectionOfOrdersPlaced(orders, DriverId);
                return Ok("Successfully added");
            }
        }
    

        [HttpGet]
        [Route("Get-All-Vehcile")]
        public IActionResult GetAll()
        {
            if ((vehicle.GetAllVehicles()) == null)
            {
                 return NotFound();
            }
            return Ok(vehicle.GetAllVehicles());
        }

        [HttpGet]
        [Route("Get-Vehcile-By-Id")]
        public IActionResult GetById(int id)
        {
           var result = vehicle.GetSingleRecord(id);
           if (result == null)
           {
               return NotFound();
           }
           return Ok(result);
        }

        [HttpGet]
        [Route("Get-Vehicle-By-DriverId")]
        public IActionResult GetByDriverId(int DriverId)
        {
            var result = vehicle.GetVehicleByDriverId(DriverId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
         }

         [HttpPost]
         [Route("Add-Vehcile")]
         public IActionResult AddVehicle(Vehicle vehicleRecord)
         {
            if (vehicleRecord == null)
            {
                return BadRequest("The Vehcile record your provided is NULL");
            }
            else
            {
                 vehicle.AddVehicleRecord(vehicleRecord);
                 return Ok("Successfully add Vehicle record");
            }
          }

         [HttpPut]
         [Route("Edit-Vehcile")]
         public IActionResult UpdateVehicle(int Id, Vehicle vehicleRecord)
         {
             if (Id <= 0)
             {
                 return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
             }
             else if (vehicleRecord == null)
             {
                 return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
             }
             else
             {
                vehicle.UpdateVehicleRecord(Id, vehicleRecord);
                return Ok("Successfully Updated the record");
             }
         }

         [HttpDelete]
         [Route("Delete-A-Vehcile-Record")]
         public IActionResult DeleteVehicle(int Id)
          {
             if (Id <= 0)
             {
                 return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
             }
             else
             {
                   vehicle.DeleteVehicleRecord(Id);
                    return Ok($"Record with ID = {Id} has been successfully deleted");
              }
          }


        [HttpPut]
        [Route("Upload")]
        public IActionResult UploadImage([FromForm] ImageUploadDto uploadDto, int VehicleId)
        {
            try
            {
                // 1. Validate the file
                if(uploadDto.Image == null || uploadDto.Image.Length == 0)
                {
                    return BadRequest(new { error = "No file uploaded." });
                }

                // 2. Validate file type
                var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/webp" };
                if (!allowedContentTypes.Contains(uploadDto.Image.ContentType))
                {
                    return BadRequest(new { error = "Invalid file type. Please upload JPEG, PNG, GIF, or WebP images." });
                }

                // 3. Validate file size (e.g., max 5MB)
                if (uploadDto.Image.Length > 5 * 1024 * 1024)
                {
                    return BadRequest(new { error = "File size exceeds 5MB limit." });
                }

                var response = vehicle.UploadImageInfo(uploadDto, VehicleId);
                
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }



        [HttpPut]
        [Route("deleteImage")]
        public IActionResult ClearImageInfo(int vehicleId)
        {
            try
            {
                var vehicleRecord = vehicle.ClearImageData(vehicleId);
                if (vehicleRecord == null)
                    return NotFound(new { message = "Image not found" });

                // Delete old image if exists
                else if (!string.IsNullOrEmpty(vehicleRecord))
                {
                    return Ok(vehicleRecord);
                }
                else
                {
                    return Ok(vehicleRecord);
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        
        [HttpGet]
        [Route("info")]
        public  IActionResult GetImageInfo(int Id)
        {
            try
            {
                var vehicleRecord = vehicle.GetImageData(Id);

                if (vehicleRecord == null)
                {
                    return NotFound(new { error = "Vehicle not found." });
                }
                else
                {
                    return Ok(vehicleRecord);
                }                   
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving image info {Id}", Id);
                return StatusCode(500, new { error = "Internal server error while retrieving image info." });
            }
        }


        // GET: api/databaseimage/details/{id}
        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<ImageResponseDto>> GetImageDetails(int id)
        {
            try
            {
                var vehicleImage = vehicle.GetImageDetail(id);

                if (vehicleImage == null)
                {
                    return NotFound(new { error = "Vehicle Image details not found." });
                }

                return Ok(vehicleImage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving image details {Id}", id);
                return StatusCode(500, new { error = "Internal server error" });
            }
        }


        // GET: api/databaseimage/list
        [HttpGet("images-list")]
        public  IActionResult GetAllImages()
        {
            try
            {
                var images = vehicle.GetAllImageData(); 
                return Ok(images);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all images");
                return StatusCode(500, new { error = "Internal server error while retrieving images." });
            }
        }
    }
}

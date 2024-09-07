using EcommerceAPR.model;
using EcommerceRPA.DataConnection;
using EcommerceRPA.DTO;
using EcommerceRPA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EcommerceRPA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet("Color")]
        public async Task<ActionResult<IEnumerable<Color>>> GetColors()
        {
            try
            {
                var colors = await _context.Colors
                    .Select(c => new Color
                    {
                        ColorId = c.ColorId,
                        ColorName = c.ColorName
                    })
                    .ToListAsync();


                return Ok(colors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpGet("Ram")]
        public async Task<ActionResult<IEnumerable<RAM>>> GetRam()
        {
            try
            {
                var rAMs = await _context.RAMs
                    .Select(c => new RAM
                    {
                        RamId = c.RamId,
                        RamValue = c.RamValue
                    })
                    .ToListAsync();


                return Ok(rAMs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("Rom")]
        public async Task<ActionResult<IEnumerable<ROM>>> GetRom()
        {
            try
            {
                var rOMs = await _context.ROMs
                    .Select(c => new ROM
                    {
                        RomId = c.RomId,
                        RomValue = c.RomValue
                    })
                    .ToListAsync();


                return Ok(rOMs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("Processor")]
        public async Task<ActionResult<IEnumerable<Processor>>> GetProcessor()
        {
            try
            {
                var processors = await _context.Processors
                    .Select(c => new Processor
                    {
                        ProcessorId = c.ProcessorId,
                        ProcessorValue = c.ProcessorValue
                    })
                    .ToListAsync();


                return Ok(processors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetProducts()
        {
            try
            {
                var products = await _context.Products
                                             .Include(v => v.Category)
                                             .Include(v => v.Feature.Rom).
                                             Include(v => v.Feature.Ram).
                                             Include(v => v.Feature.processor)
                                             .Include(v => v.Feature.Color)
                                             .ToListAsync();
                var productDtos = products.Select(p => new ProductResponseDTO
                {
                    ProductName = p.ProductName,
                    ProductDescription = p.ProductDescription,
                    ImageUrl = p.ImageUrl,
                    CategoryName = p.Category.CategoryName,
                    ColorName = p.Feature.Color.ColorName,
                    RamValue = p.Feature.Ram.RamValue,
                    RomValue = p.Feature.Rom.RomValue,
                    ProcessorValue = p.Feature.processor.ProcessorValue,
                    UnitPrice = p.UnitPrice,

                }).ToList();

                return Ok(productDtos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }


        
        [HttpPost]
        public async Task<ActionResult<CreateProductDTO>> PostProduct(CreateProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sellingPrice = productDto.UnitPrice+ (productDto.UnitPrice * 15) / 100;
            try
            {
                // Check if the feature exists
                var feature = await _context.Features
                    .Where(f => f.ColorId == productDto.ColorId &&
                                f.ProcessorId == productDto.ProcessorId &&
                                f.RomId == productDto.RomId &&
                                f.RamId == productDto.RamId)
                    .FirstOrDefaultAsync();

                // If the feature doesn't exist, create a new one
                if (feature == null)
                {
                    feature = new Feature
                    {
                        RamId = productDto.RamId,
                        RomId = productDto.RomId,
                        ProcessorId = productDto.ProcessorId,
                        ColorId = productDto.ColorId
                    };
                    _context.Features.Add(feature);
                    await _context.SaveChangesAsync();
                }

                // Create the new product
                var product = new Product
                {
                    ProductName = productDto.ProductName,
                    ProductDescription = productDto.ProductDescription,
                    CategoryId = productDto.CategoryId,
                    FeatureId = feature.FeatureId,
                    UnitPrice = productDto.UnitPrice,
                    SellingPrice = sellingPrice,
                    ImageUrl = productDto.ImageUrl,
                    CreatedAt = DateTime.Now
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return StatusCode(200, "Success");
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Unable to save changes to the database.");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

    //    [HttpPut("{productId}")]
    //    public async Task<CommonResponse<string>> UpdateProducts(int productId, CreateProductDTO request)
    //    {
            
    //        var product = await _context.Products.FindAsync(productId);
    //        if (product == null)
    //        {
    //            return NotFound($"Vendor with ID {productId} not found.");
    //        }
        
    //        else
    //        {
    //            product.ProductName = request.ProductName;
    //            product.ProductDescription = request.ProductDescription;
    //            product.CategoryId = request.CategoryId;
    //            product.Feature.RamId = request.RamId;
    //            product.Feature.RomId = request.RomId;
    //            product.Feature.ProcessorId = request.ProcessorId;
    //            product.Feature.ColorId = request.ColorId;
    //            product.ImageUrl = request.ImageUrl;
    //            product.UnitPrice = request.UnitPrice;
    //            product.SellingPrice = request.SellingPrice;

    //            _context.Entry(product).State = EntityState.Modified;
    //            await _context.SaveChangesAsync();
    //            commonResponse.Status = true;
    //            commonResponse.Message = "Data Updated Successfully";

             

    //}
    //        return commonResponse;
    //    }


        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, UpdateProductDTO request)
        {
            if (productId != request.ProductId)
            {
                return BadRequest("Product ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var feature = await _context.Features
                    .Where(f => 
                                
                                f.ColorId == request.ColorId &&
                                f.ProcessorId == request.ProcessorId &&
                                f.RomId == request.RomId &&
                                f.RamId == request.RamId)
                    .FirstOrDefaultAsync();
            if (feature == null) {
                feature = new Feature
                {
                    RamId = request.RamId,
                    RomId = request.RomId,
                    ProcessorId = request.ProcessorId,
                    ColorId = request.ColorId
                };
                _context.Features.Add(feature);
                await _context.SaveChangesAsync();

            }
            var product = await _context.Products.FirstOrDefaultAsync( f => f.ProductId == productId);
            
            if (product == null)
            {
                return NotFound($"Product with ID {productId} not found.");
            }

                          product.ProductName = request.ProductName;
                          product.ProductDescription = request.ProductDescription;
                          product.CategoryId = request.CategoryId;
                          //product.Feature.RamId = feature.RamId;
                          //product.Feature.RomId = feature.RomId;
                          //product.Feature.ProcessorId = feature.ProcessorId;
                          //product.Feature.ColorId = feature.ColorId;
                         product.FeatureId = feature.FeatureId;
                          product.ImageUrl = request.ImageUrl;
                          product.UnitPrice = request.UnitPrice;
                          product.SellingPrice = request.SellingPrice;


            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
         
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }

            return StatusCode(200, "Success");
        }

[HttpDelete("{productId}")]
public async Task<IActionResult> DeleteProducts(int productId)
{


    if (productId == null)
    {
        return StatusCode(404, "no data  found.");
    }
    else
    {
        var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
        _context.Products.Remove(product);
        _context.SaveChanges();
        return StatusCode(200, "success");

    }
  
   
}



        //[HttpGet]
        //public async Task<CommonResponse<List<ProductDTO>>> GetProducts()
        //{

        //    CommonResponse<List<ProductDTO>> commonResponse = new CommonResponse<List<ProductDTO>>();
        //    try
        //    {
        //        commonResponse.Response = _context.Products.Select(x => new ProductDTO
        //        {
        //            ProductId = x.ProductId,
        //            ProductName = x.ProductName,
        //            ProductDescription = x.ProductDescription,
        //            CategoryId = x.CategoryId,
        //            AttributeId = x.AttributeId,
        //            ImageUrl = x.ImageUrl,
        //            UnitPrice = x.UnitPrice,
        //            SellingPrice = x.SellingPrice,
        //            CreatedAt = x.CreatedAt
        //        }).ToList();
        //        commonResponse.Status = true;
        //        commonResponse.Message = "Get Data Successfully!!";
        //        return commonResponse;


        //    }
        //    catch (Exception ex)
        //    {
        //        commonResponse.Status = false;
        //        commonResponse.Message = "Internal Server error";

        //        return commonResponse;

        //    }




        //[HttpDelete("{productId}")]
        //public async Task<CommonResponse<string>> DeleteProducts(int productId)
        //{

        //    CommonResponse<string> commonResponse = new CommonResponse<string>();
        //    if (productId == null)
        //    {
        //        commonResponse.Status = false;
        //        commonResponse.Message = "Data not found";
        //    }
        //    else
        //    {
        //        var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
        //        _context.Products.Remove(product);
        //        _context.SaveChanges();
        //        commonResponse.Status = true;
        //        commonResponse.Message = "Data deleted successfully";
        //    }
        //    return commonResponse;
        //}
        //[HttpPut("{productId}")]
        //public async Task<CommonResponse<string>> UpdateProducts(int productId,UpdatePoductDTO request)
        //{
        //    CommonResponse<string> commonResponse = new CommonResponse<string>();
        //    var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);
        //    if (product == null)
        //    {
        //        commonResponse.Status = false;
        //        commonResponse.Message = "Data Not Found";
        //    }
        //    else
        //    {
        //        product.ProductName = request.ProductName;
        //        product.ProductDescription = request.ProductDescription;
        //        product.CategoryId = request.CategoryId;
        //        product.AttributeId = request.AttributeId;
        //        product.ImageUrl = request.ImageUrl;
        //        product.UnitPrice = request.UnitPrice;
        //        product.SellingPrice = request.SellingPrice;

        //        _context.Entry(product).State = EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        commonResponse.Status = true;
        //        commonResponse.Message = "Data Updated Successfully";
        //    }
        //    return commonResponse;
        //}
    }
}

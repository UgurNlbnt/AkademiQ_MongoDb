using AkademiQMongoDb.Dtos.ProductDto;
using AkademiQMongoDb.Dtos.TestimonialDto;
using AkademiQMongoDb.Services.ProductServices;
using AkademiQMongoDb.Services.TestimonialServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialServices;

        public TestimonialController(ITestimonialService testimonialServices)
        {
            _testimonialServices = testimonialServices;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _testimonialServices.GetAllTestimonialAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialServices.CreateTestimonialAsync(createTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(string id)
        {
            var value = await _testimonialServices.GetTestimonialByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialServices.UpdateTestimonialAsync(updateTestimonialDto);
            return RedirectToAction("TestimonialList");
        }

        public async Task<IActionResult> DeleteTestimonial(string id)
        {
            await _testimonialServices.DeleteTestimonialAsync(id);
            return RedirectToAction("TestimonialList");
        }
    }
}
